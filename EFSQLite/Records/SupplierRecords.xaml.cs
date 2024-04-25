using EFSQLite.Data;
using EFSQLite.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace EFSQLite.Records;

public partial class SupplierRecords : ContentPage
{
    new public string Id { get; set; }
    public string Name { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string PSC { get; set; }

    public string ICO { get; set; }

    public string DIC { get; set; }

    public string Product { get; set; }

    public string Quantity { get; set; }

    public string Price { get; set; }

    MyContext2 context_;


    public SupplierRecords(int id, MyContext2 context)
    {

        context_ = context;

        Supplier s = (from supplier in context.Suppliers
                      where supplier.Id == id
                      select supplier).FirstOrDefault();



        if (s != null)
        {
            Id = $"dodavatel s id:{s.Id}";
            Name = $"jméno dodavatele:{s.Name}";
            Address = $"adresa dodavatele: {s.Address},{s.PSC} {s.City} ";
            PSC = $"PSÈ dodavatele: {s.PSC}";
            ICO = $"IÈO dodavatele s: {s.ICO}";
            DIC = $"DIÈ dodavatele s: {s.DIC}";
            Product = $"dodavatel prodal: {s.Quantity} ks {s.Product}, cena za kus: {s.Price}";
        }

        InitializeComponent();
        BindingContext = this;

    }
}

