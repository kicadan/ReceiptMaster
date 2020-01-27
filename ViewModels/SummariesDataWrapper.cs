using ReceiptMaster.Models;
using System.Collections.Generic;

namespace ReceiptMaster.ViewModels
{
    public class SummariesDataWrapper
    {
        public ICollection<SummariesData> SummariesDatas { get; set; }
        public string Column { get; set; }
    }
}
