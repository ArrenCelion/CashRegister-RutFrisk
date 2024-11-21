using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public enum PriceTypes
    {
        kilo,
        styck

    }

    internal class Product
    {
        public string ProductName { get; set; }
        public short ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public PriceTypes PriceType { get; set; }
    }
}
