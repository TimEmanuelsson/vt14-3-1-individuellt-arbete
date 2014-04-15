<%@ Page Title="Band info" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="BandDetails.aspx.cs" Inherits="Projekt.Pages.BandDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Detaljerad info</h1>
    <asp:Label ID="Status" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Button ID="Remover" runat="server" Text="X" Visible="false" CausesValidation="false" OnClick="Remover_Click" />
    <div>
    <asp:FormView ID="BandDetailsFormView" runat="server"
        ItemType="Projekt.Model.Band"
        SelectMethod="BandDetailsFormView_GetItem"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <%#: Item.Namn %>
            </div>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("EditBand", new { id = Item.Bandid }) %>' />
                <asp:HyperLink ID="HyperLink2" runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("DeleteBand", new { id = Item.Bandid }) %>'></asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Band", null)%>' />
            </div>
        </ItemTemplate>
    </asp:FormView>
    </div>
</asp:Content>
