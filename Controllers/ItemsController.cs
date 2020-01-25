using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReceiptMaster.Data;
using ReceiptMaster.Models;

namespace ReceiptMaster.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MvcReceiptContext _context;

        public ItemsController(MvcReceiptContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var mvcReceiptContext = _context.Items.Include(i => i.Receipt);
            return View(await mvcReceiptContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Receipt)
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create(int? receiptID)
        {
            if (receiptID == null)
            {
                ViewData["ReceiptID"] = new SelectList(_context.Receipt, "ReceiptID", "Title");
            }
            else
            {
                ViewData["ReceiptID"] = new SelectList(_context.Receipt.Where(x => x.ReceiptID == receiptID), "ReceiptID", "Title");
            }
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,Name,Category,Quantity,Price,ReceiptID")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                var receipt = _context.Receipt.Find(item.ReceiptID);
                receipt.Sum += item.Price;
                _context.Update(receipt);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Receipts", new { id = item.ReceiptID });
            }
            ViewData["ReceiptID"] = new SelectList(_context.Receipt, "ReceiptID", "ReceiptID", item.ReceiptID);
            return RedirectToAction("Index", "Receipts", new { id = item.ReceiptID });
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ReceiptID"] = new SelectList(_context.Receipt.Where(x => x.ReceiptID == item.ReceiptID), "ReceiptID", "Title", item.ReceiptID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,Name,Category,Quantity,Price,ReceiptID")] Item item)
        {
            if (id != item.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var previousPrice = _context.Items.Where(x => x.ItemID == id).Select(x => x.Price).First();
                    var receipt = _context.Receipt.Find(item.ReceiptID);
                    receipt.Sum += item.Price - previousPrice;
                    _context.Update(item);
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Receipts", new { id = item.ReceiptID });
            }
            ViewData["ReceiptID"] = new SelectList(_context.Receipt, "ReceiptID", "ReceiptID", item.ReceiptID);
            return RedirectToAction("Index", "Receipts", new { id = item.ReceiptID });
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Receipt)
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            var receipt = _context.Receipt.Find(item.ReceiptID);
            receipt.Sum -= item.Price;
            _context.Items.Remove(item);
            _context.Update(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
