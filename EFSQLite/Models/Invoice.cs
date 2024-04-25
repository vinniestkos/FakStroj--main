using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EFSQLite.Models
{
    public class Invoice
    {

        public int Id { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public string CustomerCity { get; set; }
        public string CustomerPSC { get; set; }

        public string CustomerICO { get; set; }

        public string CustomerDIC { get; set; }

        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }

        public string SupplierCity { get; set; }
        public string SupplierPSC { get; set; }

        public string SupplierICO { get; set; }

        public string SupplierDIC { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }


        public override string ToString()
        {
            return $"faktura číslo:{Id}";
        }
    }
}
