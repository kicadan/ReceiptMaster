using System.Collections.Generic;
using ReceiptMaster.Models;

namespace ReceiptMaster.ViewModels
{
    public class ReceiptIndexData
    {
        public IEnumerable<Receipt> Receipts { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
