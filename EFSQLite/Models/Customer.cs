namespace EFSQLite.Models
{
    public class Customer
    {
        public int Id { get; set; } // PK pro databázovou tabulku

        public string Name { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string PSC { get; set; }

        public string ICO { get; set; }

        public string DIC { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return $"odběratel {Name} s id: {Id}";   
        }
    }
}
