<%@ Page Title="Redigera Huvudroll" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditHuvudroll.aspx.cs" Inherits="Projekt.Pages.EditHuvudroll" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>Redigera Huvudroll</h1>
    <asp:FormView ID="EditHuvudrollFormView" runat="server"
        ItemType="Projekt.Model.Huvudroll"
        DataKeyNames="Rollid"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="EditHuvudrollFormView_GetItem"
        UpdateMethod="EditHuvudrollFormView_UpdateItem">
        <EditItemTemplate>
            <div>
                <label for="Name">Huvudroll</label>
            </div>
            <div>
                <asp:TextBox ID="Band" runat="server" Text='<%# BindItem.Rolltyp %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet få inte vara tomt!" ControlToValidate="Band" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fältet få endast innehålla bokstäver!" ControlToValidate="Band" Display="Dynamic" ValidationExpression="[a-zA-Z]{1,30}"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Huvudroll", null) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>

