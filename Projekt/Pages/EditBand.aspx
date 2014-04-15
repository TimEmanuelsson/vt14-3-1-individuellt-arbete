<%@ Page Title="Redigera band" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditBand.aspx.cs" Inherits="Projekt.Pages.EditBand" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Redigera Band</h1>
    <asp:FormView ID="EditBandFormView" runat="server"
        ItemType="Projekt.Model.Band"
        DataKeyNames="Bandid"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="EditBandFormView_GetItem"
        UpdateMethod="EditBandFormView_UpdateItem">
        <EditItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <asp:TextBox ID="Band" runat="server" Text='<%# BindItem.Namn %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet få inte vara tomt!" ControlToValidate="Band" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fältet få endast innehålla bokstäver!" ControlToValidate="Band" Display="Dynamic" ValidationExpression="[a-zA-Z]{1,30}"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("BandDetails", new { id = Item.Bandid }) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>

