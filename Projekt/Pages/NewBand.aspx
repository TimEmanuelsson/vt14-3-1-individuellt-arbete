<%@ Page Title="Nytt band" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewBand.aspx.cs" Inherits="Projekt.Pages.NewBand" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Nytt band</h1>
        <asp:FormView ID="NewBandFormView" runat="server"
        ItemType="Projekt.Model.Band"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="NewBandFormView_InsertItem">
        <InsertItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <asp:TextBox ID="Band" runat="server" Text='<%# BindItem.Namn %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet få inte vara tomt!" ControlToValidate="Band" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fältet få endast innehålla bokstäver!" ControlToValidate="Band" Display="Dynamic" ValidationExpression="[a-zA-Z]{1,30}"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Insert" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Band", null) %>' />
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
