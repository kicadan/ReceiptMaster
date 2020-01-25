using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceiptMaster.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        [Range(1, 9999)]
        public int Quantity { get; set; }
        [Range(0.01, 9999.99)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int ReceiptID { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
