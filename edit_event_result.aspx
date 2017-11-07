<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="edit_event_result.aspx.cs" Inherits="edit_event_result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        td {width: 20%;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:placeholder id="PlaceHolder1" runat="server" />
    <br>
    <div id="comments">
        <div class="block clear">
            <label for="comment">Rezultat:</label>
            <asp:textbox id="TextBoxRezultat" runat="server"></asp:textbox>
            <br>
            <asp:button id="ButtonUpisiRezultat" runat="server" text="Promijeni rezultat" onclick="ButtonUpisiRezultat_Click" />
        </div>
        <br>
        <asp:button id="ButtonUTijeku" runat="server" text="U tijeku" onclick="ButtonUTijeku_Click" />
        &nbsp;
        <asp:button id="ButtonKraj" runat="server" text="Kraj utakmice" onclick="ButtonKraj_Click" />
        &nbsp;        
    </div>


</asp:Content>

