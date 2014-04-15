<%@ Page Title="Medlems info" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="MedlemDetails.aspx.cs" Inherits="Projekt.Pages.MedlemDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Detaljerad info</h1>
    <asp:Label ID="Status" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Button ID="Remover" runat="server" Text="X" Visible="false" CausesValidation="false" OnClick="Remover_Click" />

        <asp:FormView ID="MedlemDetailsFormView" runat="server"
        ItemType="Projekt.Model.Medlem"
        SelectMethod="MedlemDetailsFormView_GetItem"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <label for="FName">Förnamn</label>
            </div>
            <div>
                <%#: Item.FNamn %>
            </div>
            <div>
                <label for="EName">Efternamn</label>
            </div>
            <div>
                <%#: Item.ENamn %>
            </div>
            <div>
                <label for="Alder">Ålder</label>
            </div>
            <div>
                <%#: Item.Alder %>
            </div>
            <div>
                <label for="BandName">Band Namn</label>
            </div>
            <div>
                <%#: Item.BandNamn %>
            </div>
            <div>
                <label for="Rolltyp">Rolltyp</label>
            </div>
            <div>
                <%#: Item.Rolltyp %>
            </div>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera(UR FUNKTION)" NavigateUrl='<%# GetRouteUrl("EditMedlem", new { id = Item.Medid }) %>' />
                <asp:HyperLink ID="HyperLink2" runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("DeleteMedlem", new { id = Item.Medid }) %>'></asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Medlemmar", null)%>' />
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
