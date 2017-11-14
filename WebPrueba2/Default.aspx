<%@ Page Title="FatBank" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPrueba2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>WebServicePrueba</h1>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:GridView ID="GridUsuarios" runat="server">
            </asp:GridView>
        </p>
    </div>

    <div class="row">
        
        <div class="col-md-12">
           

            <br />
            <br />
            <br />
            
          <br />
            <br />
        </div>
    </div>

</asp:Content>
