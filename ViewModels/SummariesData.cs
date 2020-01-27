using ReceiptMaster.Models;
using System.Collections.Generic;

namespace ReceiptMaster.ViewModels
{
    public class SummariesData
    {
        public Item Item { get; set; }
        public decimal Rate { get; set; }
        public Receipt Receipt { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public SummariesData(Item item, decimal rate)
        {
            this.Item = item;
            this.Rate = rate;
        }
        public SummariesData(Receipt receipt, decimal rate)
        {
            this.Receipt = receipt;
            this.Rate = rate;
        }
        public SummariesData(string name, decimal rate)
        {
            this.Name = name;
            this.Rate = rate;
        }
        public SummariesData(string name, decimal rate, string secondName)
        {
            this.Name = name;
            this.Rate = rate;
            this.SecondName = secondName;
        }
        public SummariesData(string name, decimal rate, string secondName, string thirdName)
        {
            this.Name = name;
            this.Rate = rate;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
        }
    }
}
