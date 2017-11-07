<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="comments">
        
        <h2>Prijava</h2>
    <div class="block clear">
        <label for="comment">Username</label>
        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
    </div>
    <div class="block clear">
        <label for="comment">Password</label>
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="ButtonPrijava" runat="server" Text="Prijavi me" OnClick="ButtonPrijava_Click" />
        &nbsp;
        <asp:Button ID="ButtonReset" runat="server" Text="Reset" OnClick="ButtonReset_Click" />
        
    </div>
    </div>
    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
</asp:Content>

