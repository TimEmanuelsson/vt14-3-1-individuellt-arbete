<%@ Page Title="Redigera medlem" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditMedlem.aspx.cs" Inherits="Projekt.Pages.EditMedlem" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Redigera medlem</h1>
        <asp:FormView ID="EditMedlemFormView" runat="server"
        ItemType="Projekt.Model.Medlem"
        DataKeyNames="Medid"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="EditMedlemFormView_GetItem"
        UpdateMethod="EditMedlemFormView_UpdateItem">
        <EditItemTemplate>
            <div>
                <label for="FName">Förnamn</label>
            </div>
            <div>
                <asp:TextBox ID="FNamn" runat="server" Text='<%# BindItem.FNamn %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet få inte vara tomt!" ControlToValidate="FNamn" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fältet få endast innehålla bokstäver och minst 2st!" ControlToValidate="FNamn" Display="Dynamic" ValidationExpression="[a-zA-Z]{2,30}"></asp:RegularExpressionValidator>
            </div>
            <div>
                <label for="EName">Efternamn</label>
            </div>
            <div>
                <asp:TextBox ID="ENamn" runat="server" Text='<%# BindItem.ENamn %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fältet få inte vara tomt!" ControlToValidate="ENamn" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Fältet få endast innehålla bokstäver och minst 2st!" ControlToValidate="FNamn" Display="Dynamic" ValidationExpression="[a-zA-Z]{2,30}"></asp:RegularExpressionValidator>
            </div>
            <div>
                <label for="Alder">Ålder</label>
            </div>
            <div>
                <asp:TextBox ID="Alder" runat="server" Text='<%# BindItem.Alder %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fältet få inte vara tomt!" ControlToValidate="Alder" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Fåltet få endast innehålla heltal!" ControlToValidate="Alder" Display="Dynamic" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fätet måste vara mellan 1-150!" ControlToValidate="Alder" MaximumValue="150" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            </div>
            <div>
                <label for="Bandid">Bandid</label>
            </div>
            <div>
                <asp:DropDownList 
                    id="Dropdownlistband"
                    runat="server" 
                    ItemType="Projekt.Model.Band"
                    DataTextField="Namn"
                    DataValueField="Bandid"
                    SelectMethod="Dropdownlistband_GetData">
                </asp:DropDownList>
            </div>
            <div>
                <label for="Rollid">Rollid</label>
            </div>
            <div>
                <asp:DropDownList 
                    id="Dropdownlistroll"
                    runat="server" 
                    ItemType="Projekt.Model.Huvudroll"
                    DataTextField="Rolltyp"
                    DataValueField="Rollid"
                    SelectMethod="Dropdownlistroll_GetData">
                </asp:DropDownList>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("MedlemDetails", new { id = Item.Medid }) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
