<%@ Page Title="Band" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Band.aspx.cs" Inherits="Projekt.Pages.Band" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Band</h1>

    <asp:Label ID="Status" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Button ID="Remover" runat="server" Text="X" Visible="false" CausesValidation="false" OnClick="Remover_Click" />
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=NewBand %>' Text="Lägg till nytt band" />
        </div>
    <div>
        <asp:ListView ID="ListViewBand" runat="server"
                ItemType="Projekt.Model.Band"
                SelectMethod="ListViewBand_GetData"
                DateKeyNames="Bandid">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Namn
                            </th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("BandDetails", new { id = Item.Bandid })  %>' Text='<%# Item.Namn %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Inga band kunde visas!
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>

        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%$ RouteUrl:routename=Medlemmar %>' Text="Medlemmar" />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%$ RouteUrl:routename=Huvudroll %>' Text="Huvudroll" />
    </div>
</asp:Content>
