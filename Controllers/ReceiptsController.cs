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
    public class ReceiptsController : Controller
    {
        private readonly MvcReceiptContext _context;

        public ReceiptsController(MvcReceiptContext context)
        {
            _context = context;
        }

        // GET: Receipts
        public async Task<IActionResult> Index(int? id, int? itemID)
        {
            var viewModel = new ReceiptIndexData();

            viewModel.Receipts = _context.Receipt
                .Include(r => r.Items)
                .OrderBy(r => r.PurchaseDate);

            if(id != null)
            {
                ViewBag.ReceiptID = id.Value;
                ViewBag.ReceiptTitle = viewModel.Receipts.Where(x => x.ReceiptID == id).Select(x => x.Title).First();
                viewModel.Items = viewModel.Receipts.Where(
                    r => r.ReceiptID == id.Value).Single().Items;
            }

            if(itemID != null)
            {
                ViewBag.ItemID = itemID.Value;
                var selectedItem = viewModel.Items.Where(
                    x => x.ItemID == itemID).Single();
            }
            return View(viewModel);
            //return View(await _context.Receipt.ToListAsync());
        }

        public IActionResult Summary(string summary, string column)
        {
            SummariesDataWrapper summariesDataWrapper = new SummariesDataWrapper();
            if (summary.Contains("Average"))
            {
                switch (column)
                {
                    case "Title":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Average(y => y.Sum))).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                           .GroupBy(i => new { i.Shop })
                           .Select(x => new SummariesData(x.Key.Shop, x.Average(y => y.Sum))).ToList();
                        break;
                    case "PurchaseMonth":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Average(y => y.Sum), column)).ToList();
                        break;
                    case "MonthInShop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year, i.Shop })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Average(y => y.Sum), x.Key.Shop)).ToList();
                        break;
                }
            } else if (summary.Contains("Sum"))
            {
                switch (column)
                {
                    case "Title":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Sum(y => y.Sum))).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                           .GroupBy(i => new { i.Shop })
                           .Select(x => new SummariesData(x.Key.Shop, x.Sum(y => y.Sum))).ToList();
                        break;
                    case "PurchaseMonth":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Sum(y => y.Sum), column)).ToList();
                        break;
                    case "MonthInShop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year, i.Shop })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Sum(y => y.Sum), x.Key.Shop)).ToList();
                        break;
                }
            } else if (summary.Contains("Minimum"))
            {
                switch (column)
                {
                    case "Title":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Min(y => y.Sum))).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                           .GroupBy(i => new { i.Shop })
                           .Select(x => new SummariesData(x.Key.Shop, x.Min(y => y.Sum))).ToList();
                        break;
                    case "PurchaseMonth":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Min(y => y.Sum))).ToList();
                        break;
                    case "MonthInShop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year, i.Shop })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Min(y => y.Sum), x.Key.Shop)).ToList();
                        break;
                }
            } else if (summary.Contains("Maximum"))
            {
                switch (column)
                {
                    case "Title":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.Title })
                            .Select(x => new SummariesData(x.Key.Title, x.Max(y => y.Sum))).ToList();
                        break;
                    case "Shop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                           .GroupBy(i => new { i.Shop })
                           .Select(x => new SummariesData(x.Key.Shop, x.Max(y => y.Sum))).ToList();
                        break;
                    case "PurchaseMonth":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Max(y => y.Sum))).ToList();
                        break;
                    case "MonthInShop":
                        summariesDataWrapper.SummariesDatas = _context.Receipt
                            .GroupBy(i => new { i.PurchaseDate.Month, i.PurchaseDate.Year, i.Shop })
                            .Select(x => new SummariesData(new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM yyyy"), x.Max(y => y.Sum), x.Key.Shop)).ToList();
                        break;
                }
            }
            ViewBag.Summary = summary;
            ViewBag.ItemType = "Receipts";
            summariesDataWrapper.Column = column;
            return View(summariesDataWrapper);
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .FirstOrDefaultAsync(m => m.ReceiptID == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Receipts/Create
        public IActionResult Create(bool? plusButtonPressed)
        {
            ViewData["Shops"] = new SelectList(_context.Receipt.Select(i => i.Shop).Distinct());
            if (plusButtonPressed == null)
                ViewData["NewShop"] = false;
            else
                ViewData["NewShop"] = plusButtonPressed;
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceiptID,Title,Shop,PurchaseDate,Sum")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(int? id, bool? plusButtonPressed)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["Shops"] = new SelectList(_context.Receipt.Select(i => i.Shop).Distinct());
            if (plusButtonPressed == null)
                ViewData["NewShop"] = false;
            else
                ViewData["NewShop"] = plusButtonPressed;

            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceiptID,Title,Shop,PurchaseDate,Sum")] Receipt receipt)
        {
            if (id != receipt.ReceiptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.ReceiptID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .FirstOrDefaultAsync(m => m.ReceiptID == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipt.Any(e => e.ReceiptID == id);
        }
    }
}
