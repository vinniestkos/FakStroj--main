using EFSQLite.Data;
using EFSQLite.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace EFSQLite.Records;

public partial class InvoiceRecords3 : ContentPage
{
    MyContext3 FakturyContext;
    public InvoiceRecords3()
    {
        InitializeComponent();
        FakturyContext = new();
        lst3.ItemsSource = FakturyContext.Invoices.ToList();
    }
    private async void Detail(object sender, EventArgs e)
    {
        int id = (lst3.SelectedItem as Invoice).Id;
        InvoiceRecord dp = new(id, FakturyContext);
        await Navigation.PushAsync(dp);
    }

    private void Delete(object sender, EventArgs e)
    {
        Invoice keSmazani = lst3.SelectedItem as Invoice;
        if (keSmazani != null)
        {
            FakturyContext.Invoices.Remove(keSmazani); // odebrání Customera z data setu
            FakturyContext.SaveChanges(); // uloží zmìny do databáze
            refresh();
        }
    }

   
private void Button_Clicked(object sender, EventArgs e)
    {
        {
            Invoice keSmazani = lst3.SelectedItem as Invoice;

            //string accountNumber = keSmazani.AccountNumber;
            //int celkcena = Int32.Parse(keSmazani.Price) * Int32.Parse(keSmazani.PocetKusu);

            //string paymentString = $"SPD*1.0*ACC:{accountNumber}";

            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(paymentString, QRCodeGenerator.ECCLevel.L);

            //PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            //byte[] qrCodeBytes = qrCode.GetGraphic(20);

            //string imageFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "qrcode.png");
            //File.WriteAllBytes(imageFilePath, qrCodeBytes);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Odeslane.pdf");
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(QuestPDF.Helpers.Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    // Záhlaví faktury
                    page.Header()
                        .AlignCenter()
                        .Text("Faktura-Daòový doklad")
                        .SemiBold().FontSize(24).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);


                    // Informace o zákazníkovi
                    page.Content()
                                    .Background(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                    .Padding(12)

                                    .Text(text =>
                                    {
                                        text.Span("Dodavatel: ").Bold();
                                        text.Span($"{keSmazani.SupplierName}\n");

                                        text.Span("Adresa: ").Bold();
                                        text.Span($"{keSmazani.SupplierAddress}\n");

                                        text.Span("Mìsto: ").Bold();
                                        text.Span($"{keSmazani.SupplierCity}\n");

                                        text.Span("PSÈ: ").Bold();
                                        text.Span($"{keSmazani.SupplierPSC}\n");

                                        text.Span("ICO: ").Bold();
                                        text.Span($"{keSmazani.SupplierICO}\n");

                                        text.Span("DIC: ").Bold();
                                        text.Span($"{keSmazani.SupplierDIC}\n");

                                        text.Span("Produkt").Bold();
                                        text.Span($"{keSmazani.Product}\n");

                                        text.Span("Cena: ").Bold();
                                        text.Span($"{keSmazani.Quantity}\n");

                                        text.Span("Zpùsob platby: ").Bold();
                                        text.Span($"{keSmazani.Price}\n");

                                        text.Span("Odbìratel: ").Bold();
                                        text.Span($"{keSmazani.CustomerName}\n");

                                        text.Span("Adresa: ").Bold();
                                        text.Span($"{keSmazani.CustomerAddress}\n");

                                        text.Span("Mìsto: ").Bold();
                                        text.Span($"{keSmazani.CustomerCity}\n");

                                        text.Span("PSÈ: ").Bold();
                                        text.Span($"{keSmazani.CustomerPSC}\n");

                                        text.Span("IÈO: ").Bold();
                                        text.Span($"{keSmazani.CustomerICO}\n");

                                        text.Span("DIÈ").Bold();
                                        text.Span($"{keSmazani.CustomerDIC}\n");






                                        // Celková cena
                                        //double cena;
                                        //if (double.TryParse(keSmazani.Price, out double parsedPrice) && double.TryParse(keSmazani.PocetKusu, out double parsedQuantity))
                                        //{
                                        //    cena = parsedPrice * parsedQuantity;
                                        //    text.Span($"Celková cena: ").Bold().FontColor(QuestPDF.Helpers.Colors.Red.Darken1);
                                        //    text.Span($"{cena}\n");
                                        //}
                                        //else
                                        //{
                                        //    text.Span("Neplatné údaje pro výpoèet celkové ceny.");
                                        //}



                                    });




                    page.Footer()
                        .AlignCenter()
                        .Column(Column =>
                        {
                            Column
                        .Item()
                        .Width(200)
                        .Height(200);
                            //.Image(imageFilePath);
                        });
                });
            })
        .GeneratePdf(path);
        }

}

    void refresh()
    {

        lst3.ItemsSource = null;
        lst3.ItemsSource = FakturyContext.Invoices.ToList();
    }
}