using EFSQLite.Data;
using EFSQLite.Models;
using System.Net;
using System.Xml.Linq;

namespace EFSQLite.Records;

public partial class InvoiceRecord : ContentPage
{
    new public string Id { get; set; }
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

    MyContext3 FakturyContext;
    public InvoiceRecord(int id, MyContext3 context)
	{
        FakturyContext = context;

        

        Invoice i = (from Invoice in context.Invoices
                     where Invoice.Id == id
                     select Invoice).FirstOrDefault();

        if (i != null)
        {
            Id = $"faktura èíslo:{i.Id}";
            CustomerName = $"jméno odbìratele: {i.CustomerName}";
            CustomerAddress = $"adresa odbìratele: {i.CustomerAddress}, {i.CustomerPSC} {i.CustomerCity}";
            CustomerICO = $"IÈO odbìratele s: {i.CustomerICO}";
            CustomerDIC = $"DIÈ odbìratele s: {i.CustomerDIC}";
            SupplierName = $"jméno dodavatele:{i.SupplierName}";
            SupplierAddress = $"adresa dodavatele: {i.SupplierAddress},{i.SupplierPSC} {i.SupplierCity} ";
            SupplierPSC = $"PSÈ dodavatele: {i.SupplierPSC}";
            SupplierICO = $"IÈO dodavatele s: {i.SupplierICO}";
            SupplierDIC = $"DIÈ dodavatele s: {i.SupplierDIC}";
            Product = $"odbìratel{i.CustomerName} koupil: {i.Quantity} ks {i.Product}, cena za kus: {i.Price}";

        }
        InitializeComponent();
        BindingContext = this;
    }
}