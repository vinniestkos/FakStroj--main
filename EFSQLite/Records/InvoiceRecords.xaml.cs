using EFSQLite.Data;
using EFSQLite.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EFSQLite.Records;

public partial class InvoiceRecords : ContentPage
{

    MyContext _context;
    public InvoiceRecords()
	{
		InitializeComponent();
		_context = new();

        lst.ItemsSource = _context.Customers.ToList();
    }
    private async void PDF(object sender, EventArgs e)
    {

    }

    private async void Detail(object sender, EventArgs e)
    {
        int id = (lst.SelectedItem as Customer).Id;
        CustomerRecords dp = new(id, _context);
        await Navigation.PushAsync(dp);
       
    }

    private void Delete(object sender, EventArgs e)
    {
        Customer keSmazani = lst.SelectedItem as Customer;
        if (keSmazani != null)
        {
            _context.Customers.Remove(keSmazani); // odebrání Customera z data setu
            _context.SaveChanges(); // uloží zmìny do databáze
            refresh();
        }
    }

    void refresh()
    {
        lst.ItemsSource = null;
        lst.ItemsSource = _context.Customers.ToList();
    }
}