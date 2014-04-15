<%@ Page Title="Huvudroller" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Huvudroll.aspx.cs" Inherits="Projekt.Pages.Huvudroll" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Huvudroller</h1>

    <asp:Label ID="Status" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Button ID="Remover" runat="server" Text="X" Visible="false" CausesValidation="false" OnClick="Remover_Click" />

        <asp:ListView ID="ListViewHuvudroll" runat="server"
                ItemType="Projekt.Model.Huvudroll"
                SelectMethod="ListViewHuvudroll_GetData">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Huvudroller
                            </th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.Rolltyp %>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("EditHuvudroll", new { id = Item.Rollid })  %>' Text="Redigera" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Inga huvudroller kunde visas!
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>

        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%$ RouteUrl:routename=Medlemmar %>' Text="Medlemmar" />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%$ RouteUrl:routename=Band %>' Text="Band" />
</asp:Content>
