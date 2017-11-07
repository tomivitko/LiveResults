<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="add_event.aspx.cs" Inherits="add_event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="comments">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="block clear">
                    <label for="comment">Sport:</label><br />
                    <asp:DropDownList ID="DropDownListSport" runat="server" Width="100%" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownListSport_SelectedIndexChanged">
                        <asp:ListItem Text="Odaberi sport" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Nogomet" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Košarka" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Rukomet" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Tenis" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="block clear">
                    <label for="comment">Domaćin:</label><br />
                    <asp:DropDownList ID="DropDownListHome" runat="server" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="block clear">
                    <label for="comment">Gost:</label><br />
                    <asp:DropDownList ID="DropDownListAway" runat="server" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="block clear">
                    <label for="comment">Natjecanje:</label><br />
                    <asp:DropDownList ID="DropDownListCompetition" runat="server" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="block clear">
                    <label for="comment">Početak:</label>
                    <asp:TextBox ID="TextBoxDate" runat="server" placeholder="2017-01-01 15:00:00"></asp:TextBox>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownListSport" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        
       
        <div>
            <asp:button id="ButtonDodajDogadaj" runat="server" text="Dodaj" onClick="ButtonDodajDogadaj_Click" />
        </div>
        <asp:label id="errorLabel" runat="server" text=""></asp:label>


    </div>
</asp:Content>

