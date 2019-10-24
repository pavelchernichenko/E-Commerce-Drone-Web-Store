using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    private double Price { get; set; }
    private double Shipping { get; set; }
    private double Weight { get; set; }
    private int Quantity { get; set; }
    private int Items { get; set; }
    private double TaxRate = 0.088;
    private double Tax;

    protected void Page_Load(object sender, EventArgs e)
    {
        Price = 0;
        Shipping = 0;
        Weight = 0;
        Items = 0;
        Quantity = 0;
        if (Request.QueryString["Price"] != null)
        {
            Price = double.Parse(Request.QueryString["Price"]);
        }
        if (Request.QueryString["Weight"] != null)
        {
            Weight = double.Parse(Request.QueryString["Weight"]);
        }
        if (Request.QueryString["Quantity"] != null)
        {
            Quantity = int.Parse(Request.QueryString["Quantity"]);
        }
        if (Request.QueryString["Item"] != null)
        {
            Items = int.Parse(Request.QueryString["Item"]);
        }
        Shipping = Weight * 0.800;
        Tax = Price * TaxRate;
        PriceDisplay.InnerText = "Order Cost: " + Price.ToString("C", CultureInfo.CurrentCulture);
        TaxDisplay.InnerText = "Tax: " + Tax.ToString("C", CultureInfo.CurrentCulture);
        ShippingDisplay.InnerText = "Shipping Cost: " + Shipping.ToString("C", CultureInfo.CurrentCulture);
        TotalDisplay.InnerText = "Total Cost: " + (Price + Shipping + Tax).ToString("C", CultureInfo.CurrentCulture);
        WeightDisplay.InnerText = "Weight: " + Weight + " oz";
        QuantityDisplay.InnerText = "Item(s): " + Quantity;
        ItemsDisplay.InnerText = "Unique Items: " + Items;
    }

    protected void SubmitOrder_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(EmailInput.Value);
            mailMessage.From = new MailAddress("postmaster@pavelchernichenko.com");
            mailMessage.Subject = "Drone Order Confirmation";
            mailMessage.Body = "Thank you for shopping at Drone-Mart!\nYour order has been confirmed.\n\n";
            mailMessage.Body += "ORDER INFORMATION:\n\nOrder Cost: $" + Price + "\nTax: $" + Tax + "\nShipping Cost: $" + Shipping + "\nTotal Cost: $" + (Price + Shipping + Tax) + "\nWeight: " + Weight + " oz" + "\nQuantity: " + Quantity + "\nUnique Items: " + Items;
            SmtpClient smtpClient = new SmtpClient("mail.pavelchernichenko.com");
            NetworkCredential Credentials = new NetworkCredential("postmaster@pavelchernichenko.com", "Envent11");
            smtpClient.Credentials = Credentials;
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Response.Write("<div style='color:red'>ERROR: Could not send the E-Mail - " + ex.Message + "</div>");
        }
        Server.Transfer("OrderSuccess.aspx");
    }

    protected void BackToCart_Click(object sender, EventArgs e)
    {
        Server.Transfer("ShoppingCart.aspx");
    }
}