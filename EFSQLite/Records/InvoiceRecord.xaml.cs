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
            Id = $"faktura ��slo:{i.Id}";
            CustomerName = $"jm�no odb�ratele: {i.CustomerName}";
            CustomerAddress = $"adresa odb�ratele: {i.CustomerAddress}, {i.CustomerPSC} {i.CustomerCity}";
            CustomerICO = $"I�O odb�ratele s: {i.CustomerICO}";
            CustomerDIC = $"DI� odb�ratele s: {i.CustomerDIC}";
            SupplierName = $"jm�no dodavatele:{i.SupplierName}";
            SupplierAddress = $"adresa dodavatele: {i.SupplierAddress},{i.SupplierPSC} {i.SupplierCity} ";
            SupplierPSC = $"PS� dodavatele: {i.SupplierPSC}";
            SupplierICO = $"I�O dodavatele s: {i.SupplierICO}";
            SupplierDIC = $"DI� dodavatele s: {i.SupplierDIC}";
            Product = $"odb�ratel{i.CustomerName} koupil: {i.Quantity} ks {i.Product}, cena za kus: {i.Price}";

        }
        InitializeComponent();
        BindingContext = this;
    }
}