<%@ Page Title="Ta bort band" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeleteBand.aspx.cs" Inherits="Projekt.Pages.DeleteBand" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Är du säker du vill ta bort bandet?</h1>
    <div>
        <asp:LinkButton ID="Tabort" runat="server" Text="Ja" OnCommand="Tabortband_Command" CommandArgument='<%$ RouteValue:id %>'></asp:LinkButton>
        <asp:HyperLink ID="Avbryt" runat="server" Text="Nej" />
    </div>
</asp:Content>
