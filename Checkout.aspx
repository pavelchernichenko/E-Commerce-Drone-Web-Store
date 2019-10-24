<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" runat="server">
        <div class="jumbotron" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;" runat="server">
            
            <h1 class="display-4">Order Summary</h1>
            <br />
            <h2 style="border: solid; border-color:royalblue; border-width:2px; border-top:none; border-right:none; border-left:none;" runat="server"> </h2>
            <br />
            <h6 id="PriceDisplay" runat="server"></h6>
            <h6 id="TaxDisplay" runat="server"><</h6>
            <h6 id="ShippingDisplay" runat="server"></h6>
            <h6 id="TotalDisplay" runat="server"></h6>
            <h6 id="QuantityDisplay" runat="server"></h6>
            <h6 id="WeightDisplay" runat="server"></h6>
            <!--<h6 id="ItemsDisplay" runat="server"></h6>-->
            <br />
        </div>
        <div class="alert alert-warning alert-dismissible fade show" role="alert"></div>
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="Name" style="color:royalblue;">Name</label>
                <input class="form-control" type="text" id="NameInput" runat="server" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;" required="required"/>
            </div>
            <div class="form-group">
                <label for="Street" style="color:royalblue;">Shipping Address</label>
                <input class="form-control" ID="StreetInput" runat="server" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;" required="required"/>
            </div>
            <div class="form-group">
                <label for="City" style="color:royalblue;">City</label>
                <input class="form-control" ID="CityInput" runat="server" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;" required="required"/>
            </div>
            <div class="form-group">
                <label for="State" style="color:royalblue;">State</label>
                <input class="form-control" ID="StateInput" runat="server" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;" required="required"/>
            </div>
            <div class="form-group">
                <label for="Zip" style="color:royalblue;">Zip Code</label>
                <input class="form-control" ID="ZipInput" runat="server" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;" required="required"/>
            </div>
           
            <div class="form-group">
                <label for="Email" style="color:royalblue;">Email Address</label>
                <input class="form-control" ID="EmailInput" runat="server" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;" required="required"/>
                <small id="emailHelp" class="form-text text-muted">Email is secure.</small>
            </div>
            <asp:Button class="btn btn-outline-primary" runat="server"  OnClick="SubmitOrder_Click" OnClientClick="return validateForm();" Text="Confirm Purchase"/>
        </form>
    </div>
</asp:Content>
