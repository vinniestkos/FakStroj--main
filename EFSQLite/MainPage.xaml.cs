using EFSQLite.Data;
using EFSQLite.Models;
using EFSQLite.Records;
using Microsoft.EntityFrameworkCore.Internal;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;

namespace EFSQLite;


public partial class MainPage : ContentPage
{
    
	MyContext _context;
    MyContext2 context_;
    MyContext3 FakturyContext;


    public MainPage()
	{
        QuestPDF.Settings.License = LicenseType.Community;

        //Document.Create(container =>
        //{

        //})
        //    .ShowInPreviewer();

        //Document.Create(document =>
        //{
        //    document.Page(page =>
        //    {

        //        page.Size(PageSizes.A4);

        //        page.Header()
        //        .Text(forCustomerName);


        //    });
        //});

        _context = new();
        context_ = new();
        FakturyContext = new();
        QuestPDF.Settings.License = LicenseType.Community;
        InitializeComponent();
        lst.ItemsSource = _context.Customers.ToList();
        lst2.ItemsSource = context_.Suppliers.ToList(); // připojení zdroje dat k ListView
        lst3.ItemsSource = FakturyContext.Invoices.ToList();

    }

    private async void SupplierButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InvoiceRecords2());
        //await Navigation.PushAsync(new SupplierRecords());
        //int id = (lst2.SelectedItem as Supplier).Id;
        //SupplierRecords dp = new(id, context_);
        //await Navigation.PushAsync(dp);

    }

    private async void CustomerButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InvoiceRecords());
        ////await Navigation.PushAsync(new CustomerRecords());
        //int id = (lst.SelectedItem as Customer).Id;
        //CustomerRecords dp = new(id, _context);
        //await Navigation.PushAsync(dp);
    }
    //void refresh()
    //{
    //    lst.ItemsSource = null;
    //    lst.ItemsSource = _context.Customers.ToList();
    //    lst2.ItemsSource = null;
    //    lst2.ItemsSource = context_.Suppliers.ToList();
    //}
    public void UlozObjednavku(object sender, EventArgs e)
    {
      

        Customer newCustomer = new Customer

        {
            Name = forCustomerName.Text,
            Address = forCustomerAddress.Text,
            City = forCustomerCity.Text,
            PSC = forCustomerPSC.Text,
            ICO= forCustomerICO.Text,
            DIC= forCustomerDIC.Text,
            Product = forProdukt.Text,
            Quantity = forQuantity.Text,
            Price = forPrice.Text
        };

        _context.Add(newCustomer); // přidá záznam do Data Setu
        _context.SaveChanges(); // uloží změny do databáze !


        Supplier newSupplier = new Supplier
        {
            Name = forSupplierName.Text,
            Address = forSupplierAddress.Text,
            City = forSupplierCity.Text,
            PSC = forSupplierPSC.Text,
            ICO = forSupplierICO.Text,
            DIC = forSupplierDIC.Text,
            Product = forProdukt.Text,
            Quantity = forQuantity.Text,
            Price = forPrice.Text
        };
        context_.Add(newSupplier); 
        context_.SaveChanges();

        Invoice newInvoice = new Invoice
        {
            CustomerName = forCustomerName.Text,
            CustomerAddress = forSupplierAddress.Text,
            CustomerCity = forSupplierCity.Text,
            CustomerPSC = forSupplierPSC.Text,
            CustomerICO = forSupplierICO.Text,
            CustomerDIC = forSupplierDIC.Text,
            SupplierName = forSupplierName.Text,
            SupplierAddress = forSupplierAddress.Text,
            SupplierCity = forSupplierCity.Text,
            SupplierPSC = forSupplierPSC.Text,
            SupplierICO = forSupplierICO.Text,
            SupplierDIC = forSupplierDIC.Text,
            Product = forProdukt.Text,
            Quantity = forQuantity.Text,
            Price = forProdukt.Text
        };
        FakturyContext.Add(newInvoice);
        FakturyContext.SaveChanges();

        refresh();

        

    }
    void refresh()
    {
        lst.ItemsSource = null;
        lst.ItemsSource = _context.Customers.ToList();
        lst2.ItemsSource = null;
        lst2.ItemsSource = context_.Suppliers.ToList();
        lst3.ItemsSource = null;
        lst3.ItemsSource = FakturyContext.Invoices.ToList();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InvoiceRecords());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InvoiceRecords3());
    }



    //private void Smazat(object sender, EventArgs e)
    //{
    //    Customer keSmazani = lst.SelectedItem as Customer;
    //    if (keSmazani != null)
    //    {
    //        _context.Customers.Remove(keSmazani); // odebrání Customera z data setu
    //        _context.SaveChanges(); // uloží změny do databáze
    //        refresh();
    //    }
    //}










}

