<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="add_team.aspx.cs" Inherits="add_team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="comments">
        <div class="block clear">
    <label for="comment">Sport:</label><br />
            <asp:DropDownList ID="DropDownListSport" runat="server" Width="100%">
                <asp:ListItem Text="Odaberi sport" Value="0"></asp:ListItem>
                <asp:ListItem Text="Nogomet" Value="1"></asp:ListItem>
                <asp:ListItem Text="Košarka" Value="2"></asp:ListItem>
                <asp:ListItem Text="Rukomet" Value="3"></asp:ListItem>
                <asp:ListItem Text="Tenis" Value="3"></asp:ListItem>
            </asp:DropDownList>
            </div>
        <div class="block clear">
        <label for="comment">Naziv ekipe:</label>
        <asp:TextBox ID="TextBoxTeamName" runat="server"></asp:TextBox>
    </div>
        <div>
        <asp:Button ID="ButtonDodajEkipu" runat="server" Text="Dodaj" OnClick="ButtonDodajEkipu_Click" />
                
    </div>
        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>

