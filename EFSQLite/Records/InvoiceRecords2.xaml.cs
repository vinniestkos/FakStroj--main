using EFSQLite.Data;
using EFSQLite.Models;
using EFSQLite.Records;

namespace EFSQLite;

public partial class InvoiceRecords2 : ContentPage
{
    MyContext2 context_;
    public InvoiceRecords2()
	{
		InitializeComponent();
        context_ = new();
        lst2.ItemsSource = context_.Suppliers.ToList();
    }

    private async void Detail(object sender, EventArgs e)
    {
        int id = (lst2.SelectedItem as Supplier).Id;
        SupplierRecords dp = new(id, context_);
        await Navigation.PushAsync(dp);
    }

    private void Delete(object sender, EventArgs e)
    {
        Supplier keSmazani = lst2.SelectedItem as Supplier;
        if (keSmazani != null)
        {
            context_.Suppliers.Remove(keSmazani); // odebrání Customera z data setu
            context_.SaveChanges(); // uloží zmìny do databáze
            refresh();
        }
    }

    void refresh()
    {
        
        lst2.ItemsSource = null;
        lst2.ItemsSource = context_.Suppliers.ToList();
    }
}