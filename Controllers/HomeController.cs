using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReceiptMaster.Models;
using ReceiptMaster.ViewModels;

namespace ReceiptMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Summaries(SummariesDataWrapper? summariesDataWrapper, string? summary, string? itemType)
        {
            if (summariesDataWrapper != null)
            {
                ViewBag.ItemType = itemType;
                ViewBag.Summary = summary;
                return View(summariesDataWrapper);
            }
            else
                return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
