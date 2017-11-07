<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="add_admin.aspx.cs" Inherits="add_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <div id="comments">
        <div class="block clear">
            <asp:Label ID="errorLabel" runat="server" Text=" "></asp:Label>
        </div>
        <div class="block clear">
            <label for="comment">Ime</label>
            <asp:TextBox ID="TextBoxFirstname" runat="server"></asp:TextBox>
        </div>
        <div class="block clear">
            <label for="comment">Prezime</label>
            <asp:TextBox ID="TextBoxLastname" runat="server"></asp:TextBox>
        </div>
        <div class="block clear">
            <label for="comment">E-mail</label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        </div>

        <div class="block clear">
            <label for="comment">Korisničko ime</label>
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
        </div>
        <div class="block clear">
            <label for="comment">Lozinka</label>
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="block clear">
            <label for="comment">Ponovi lozinku</label>
            <asp:TextBox ID="TextBoxPasswordAgain" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonPrijava" runat="server" Text="Prijavi me" OnClick="ButtonAddAdmin_Click" />
            &nbsp;
        <asp:Button ID="ButtonReset" runat="server" Text="Reset" OnClick="ButtonReset_Click" />

        </div>
    </div>
</asp:Content>

