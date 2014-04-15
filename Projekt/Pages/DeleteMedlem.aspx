<%@ Page Title="Ta bort medlem" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeleteMedlem.aspx.cs" Inherits="Projekt.Pages.DeleteMedlem" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Är du säker du vill ta bort medlemmen?</h1>
    <div>
        <asp:LinkButton ID="Tabort" runat="server" Text="Ja" OnCommand="Tabortkund_Command" CommandArgument='<%$ RouteValue:id %>'></asp:LinkButton>
        <asp:HyperLink ID="Avbryt" runat="server" Text="Nej" />
    </div>
</asp:Content>

