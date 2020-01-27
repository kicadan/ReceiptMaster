using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReceiptMaster.Data;
using ReceiptMaster.Models;
using ReceiptMaster.ViewModels;

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
        public IActionResult Summary(string summary, string column)
        {
            SummariesDataWrapper summariesDataWrapper = new SummariesDataWrapper();
            if (summary.Contains("Average"))
            {
                switch (column)
                {
                    case "Name":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .GroupBy(i => new { i.Name })
                            .Select(x => new SummariesData(x.Key.Name, x.Average(y => y.Price), column)).ToList();
                        break;
                    case "Category":
                        summariesDataWrapper.SummariesDatas = _context.Items
                           .GroupBy(i => new { i.Category })
                           .Select(x => new SummariesData(x.Key.Category, x.Average(y => y.Price), column)).ToList();
                        break;
                    case "Receipt":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Average(y => y.Price), column)).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Shop, i.Name})
                            .Select(x => new SummariesData(x.Key.Name, x.Average(y => y.Price), x.Key.Shop)).ToList();
                        break;
                    case "Date":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.PurchaseDate.Month, i.Receipt.PurchaseDate.Year, i.Name, i.Receipt.Shop})
                            .Select(x => new SummariesData(x.Key.Name, x.Average(y => y.Price), x.Key.Shop, new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"))).ToList();
                        break;
                }
            } else if (summary.Contains("Sum"))
            {
                switch (column)
                {
                    case "Name":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .GroupBy(i => new { i.Name })
                            .Select(x => new SummariesData(x.Key.Name, x.Sum(y => y.Price))).ToList();
                        break;
                    case "Category":
                        summariesDataWrapper.SummariesDatas = _context.Items
                           .GroupBy(i => new { i.Category })
                           .Select(x => new SummariesData(x.Key.Category, x.Sum(y => y.Price))).ToList();
                        break;
                    case "Receipt":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Sum(y => y.Price))).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Shop, i.Name })
                            .Select(x => new SummariesData(x.Key.Name, x.Sum(y => y.Price), x.Key.Shop)).ToList();
                        break;
                    case "Date":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.PurchaseDate.Month, i.Receipt.PurchaseDate.Year, i.Name, i.Receipt.Shop })
                            .Select(x => new SummariesData(x.Key.Name, x.Sum(y => y.Price), x.Key.Shop, new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"))).ToList();
                        break;
                }
            } else if (summary.Contains("Minimum"))
            {
                switch (column)
                {
                    case "Name":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .GroupBy(i => new { i.Name })
                            .Select(x => new SummariesData(x.Key.Name, x.Min(y => y.Price))).ToList();
                        break;
                    case "Category":
                        summariesDataWrapper.SummariesDatas = _context.Items
                           .GroupBy(i => new { i.Category })
                           .Select(x => new SummariesData(x.Key.Category, x.Min(y => y.Price))).ToList();
                        break;
                    case "Receipt":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Min(y => y.Price))).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Shop, i.Name })
                            .Select(x => new SummariesData(x.Key.Name, x.Min(y => y.Price), x.Key.Shop)).ToList();
                        break;
                    case "Date":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.PurchaseDate.Month, i.Receipt.PurchaseDate.Year, i.Name, i.Receipt.Shop })
                            .Select(x => new SummariesData(x.Key.Name, x.Min(y => y.Price), x.Key.Shop, new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"))).ToList();
                        break;
                }
            } else if (summary.Contains("Maximum"))
            {
                switch (column)
                {
                    case "Name":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .GroupBy(i => new { i.Name })
                            .Select(x => new SummariesData(x.Key.Name, x.Max(y => y.Price))).ToList();
                        break;
                    case "Category":
                        summariesDataWrapper.SummariesDatas = _context.Items
                           .GroupBy(i => new { i.Category })
                           .Select(x => new SummariesData(x.Key.Category, x.Max(y => y.Price))).ToList();
                        break;
                    case "Receipt":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Max(y => y.Price))).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.Shop, i.Name })
                            .Select(x => new SummariesData(x.Key.Name, x.Max(y => y.Price), x.Key.Shop)).ToList();
                        break;
                    case "Date":
                        summariesDataWrapper.SummariesDatas = _context.Items
                            .Include(item => item.Receipt)
                            .GroupBy(i => new { i.Receipt.PurchaseDate.Month, i.Receipt.PurchaseDate.Year, i.Name, i.Receipt.Shop })
                            .Select(x => new SummariesData(x.Key.Name, x.Max(y => y.Price), x.Key.Shop, new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"))).ToList();
                        break;
                }
            }
            ViewBag.Summary = summary;
            ViewBag.ItemType = "Items";
            summariesDataWrapper.Column = column;
            return View(summariesDataWrapper);
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
        public IActionResult Create(int? receiptID, bool? plusButtonPressed)
        {
            ViewData["Categories"] = new SelectList(_context.Items.Select(i => i.Category).Distinct());
            if (plusButtonPressed == null)
                ViewData["NewCategory"] = false;
            else
                ViewData["NewCategory"] = plusButtonPressed;
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
        public async Task<IActionResult> Edit(int? id, bool? plusButtonPressed)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["Categories"] = new SelectList(_context.Items.Select(i => i.Category).Distinct());
            if (plusButtonPressed == null)
                ViewData["NewCategory"] = false;
            else
                ViewData["NewCategory"] = plusButtonPressed;

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
            return RedirectToAction("Index", "Receipts", new { id = item.ReceiptID });
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
