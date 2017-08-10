<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="battleships.Index" %>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:Button ID="Button1" runat="server" Text="New Game" OnClick="Button1_Click" />

    <asp:RadioButtonList ID="difficultyList" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Easy</asp:ListItem>
        <asp:ListItem Value="2">Medium</asp:ListItem>
        <asp:ListItem Value="3">Hard</asp:ListItem>
    </asp:RadioButtonList>
<%--    <form action="">
       <input type="radio" id="btn-easy" value="1"> Easy<br>
       <input type="radio" id="btn-medium" value="2"> Medium<br>
       <input type="radio" id="btn-hard" value="3"> Hard
    </form>--%>
</asp:Content>

