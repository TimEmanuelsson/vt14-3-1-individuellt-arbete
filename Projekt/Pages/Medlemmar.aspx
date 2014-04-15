<%@ Page Title="Medlemmar" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Medlemmar.aspx.cs" Inherits="Projekt.Pages.Medlemmar" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Medlemmar</h1>

    <asp:Label ID="Status" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Button ID="Remover" runat="server" Text="X" Visible="false" CausesValidation="false" OnClick="Remover_Click" />
    <div>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%$ RouteUrl:routename=NewMedlem %>' Text="Lägg till ny kund" />
        </div>
    <div>
        <asp:ListView ID="ListViewKund" runat="server"
                ItemType="Projekt.Model.Medlem"
                SelectMethod="ListViewKund_GetData"
                DateKeyNames="Medid">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Förnamn
                            </th>
                            <th>
                                Efternamn
                            </th>
                            <th>
                                Ålder
                            </th>
                            <th>
                                Band Namn
                            </th>
                            <th>
                                Rolltyp
                            </th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("MedlemDetails", new { id = Item.Medid })  %>' Text='<%# Item.FNamn %>' />
                        </td>
                        <td>
                            <%#: Item.ENamn %>
                        </td>
                        <td>
                            <%#: Item.Alder %>
                        </td>
                        <td>
                            <%#: Item.BandNamn %>
                        </td>
                        <td>
                            <%#: Item.Rolltyp %>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Kunduppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>

        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='<%$ RouteUrl:routename=Band %>' Text="Band" />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%$ RouteUrl:routename=Huvudroll %>' Text="Huvudroll" />
    </div>
</asp:Content>
