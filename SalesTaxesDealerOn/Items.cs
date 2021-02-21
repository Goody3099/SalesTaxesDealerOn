using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxesDealerOn
{
    class Items
    {
        public Items(string name, decimal price, bool taxable, decimal salesTax, bool imported, decimal importTax)
        {
            this.name = name;
            this.price = price;
            this.taxable = taxable;
            this.salesTax = salesTax;
            this.imported = imported;
            this.importTax = importTax;
        }

        public string name { get; set; }
        public decimal price { get; set; }
        public bool taxable { get; set; }
        public decimal salesTax { get; set; }
        public bool imported { get; set; }
        public decimal importTax { get; set; }
    }
}
