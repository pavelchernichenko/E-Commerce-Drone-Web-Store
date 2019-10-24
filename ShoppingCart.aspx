<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="jumbotron" style="padding-top:15px; padding-bottom:15px; background-color:black; color:royalblue; border-color:royalblue; border-style:solid; border-width:2px;">
            <h1>Shopping Cart</h1>
        </div>
    </div>
    <form runat="server" id="form">
        <div class="container" runat="server" id="cartParent">
            <div class="table-responsive" runat="server" id="shoppingCart"></div>
        </div>
      
        <div class="container" runat="server" id="cartButtons">
            <asp:Button class="btn btn-outline-primary" id='AddToCart' runat='server' Text='Checkout' OnClick='Checkout_Click' />
        </div>
    </form>
</asp:Content>