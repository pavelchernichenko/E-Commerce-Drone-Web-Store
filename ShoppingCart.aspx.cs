using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.Page
{
    public double TotalOrderPrice { get; set; }
    public double TotalOrderWeight { get; set; }
    public double TotalOrderQuantity { get; set; }
    public double TotalOrderItems { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var cartItems = (List<InventoryItem>)Session["InventoryItems"];
        if (cartItems != null)
        {
            var table = FillShoppingCart(cartItems);
            shoppingCart.Controls.Add(table);
           
        }
    }

    private Table FillShoppingCart(List<InventoryItem> cartItems)
    {
        TotalOrderPrice = 0;
        TotalOrderWeight = 0;
        TotalOrderQuantity = 0;
        TotalOrderItems = 0;
        var table = new Table();
       
        table.Attributes["class"] = "table table-bordered";
        var row = new TableHeaderRow();
        row.TableSection = TableRowSection.TableHeader;
        row.Attributes["class"] = ".thead-dark";
        //row.Attributes["class"] = ".thead-light";
        row.Cells.Add(AddHeaderCell("<div style='color:#4169e1;'>Item</div>"));
        row.Cells.Add(AddHeaderCell("<div style='color:#4169e1;'>Price</div>"));
        row.Cells.Add(AddHeaderCell("<div style='color:#4169e1;'>Quantity</div>"));
        row.Cells.Add(AddHeaderCell("<div style='color:#4169e1;'>Weight (oz)</div>"));
        //row.Cells.Add(AddHeaderCell("<div style='color:#4169e1;'>Change</div>"));
       // row.Cells.Add(AddHeaderCell("<div style='color:#4169e1;'>Remove</div>"));
        table.Rows.Add(row);

        foreach (InventoryItem item in cartItems)
        {
            if (item.InShoppingCart)
            {
                var tblrow = new TableRow();
                tblrow.Cells.Add(AddCell("<div style='color:#ffffff;'>" + item.ItemName + "</div>"));
                tblrow.Cells.Add(AddCell("<div style='color:#ffffff;'>" + item.Price + " </div>"));
                tblrow.Cells.Add(AddCell("<div style='color:#ffffff;'>" + item.ShoppingCartQuantity + " </div>"));
                tblrow.Cells.Add(AddCell("<div style='color:#ffffff;'>" + item.Weight + " </div>"));

                // change from cart button
                var btnCell = new TableCell();
                var btn = new Button();
                btn.Attributes["class"] = "btn btn-outline-primary";
                btn.Text = "Change";
                btn.Click += (theSender, evt) =>
                {
                    Server.Transfer("ItemDetailPage.aspx?Item=" + HttpContext.Current.Server.UrlEncode(item.ItemId + ""));
                };
                btnCell.Controls.Add(btn);
                tblrow.Cells.Add(btnCell);

                // remove from cart button
                btnCell = new TableCell();
                btn = new Button();
                btn.Attributes["class"] = "btn btn-outline-danger";
                btn.Text = "Delete";
                btn.Click += (theSender, evt) => RemoveFromCart_Click(theSender, evt, item.ItemId);
                btnCell.Controls.Add(btn);
                tblrow.Cells.Add(btnCell);
                table.Rows.Add(tblrow);

                TotalOrderPrice += item.Price * item.ShoppingCartQuantity;
                TotalOrderQuantity += item.ShoppingCartQuantity;
                TotalOrderWeight += item.Weight * item.ShoppingCartQuantity;
                TotalOrderItems++;
            }
        }
        var footer = new TableFooterRow();
        footer.Cells.Add(AddCell("<strong><span style='color:#4169e1;'>Total Order Price: </span></strong><span style='color: #ffffff'>" + TotalOrderPrice.ToString("C", CultureInfo.CurrentCulture) + "</span>"));
        footer.Cells.Add(AddCell("<strong><span style='color:#4169e1;'>Total Order Quantity: </span></strong><span style='color: #ffffff'>" + TotalOrderQuantity + "</span>"));
        footer.Cells.Add(AddCell("<strong><span style='color:#4169e1;'>Total Order Weight: </span></strong><span style='color: #ffffff'>" + TotalOrderWeight + " oz</span>"));
        table.Rows.Add(footer);
        return table;
    }

    protected void RemoveFromCart_Click(object sender, EventArgs e, int itemId)
    {
        var inventoryItems = (List<InventoryItem>)Session["InventoryItems"];
        foreach (var item in inventoryItems)
        {
            if (item.ItemId == itemId)
            {
                item.InShoppingCart = false;
            }
        }
        Response.Redirect(Request.RawUrl);
    }

    protected void Checkout_Click(object sender, EventArgs e)
    {
        string redirect = "Checkout.aspx?Price=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderPrice + "")
            + "&Weight=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderWeight + "")
            + "&Quantity=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderQuantity + "")
            + "&Item=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderItems + "");
        Response.Redirect(redirect);
    }

    private TableHeaderCell AddHeaderCell(string text)
    {
        var cell = new TableHeaderCell();
        cell.Text = text;
        return cell;
    }

    private TableCell AddCell(string text)
    {
        var cell = new TableCell();
        cell.Text = text;
        return cell;
    }
}