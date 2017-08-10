<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="battleships.Game" %>

<asp:Content ID="gameBoard" ContentPlaceHolderID="main" runat="server">
    <table>
        <asp:Literal ID="gameLiteral" runat="server"></asp:Literal>
    </table>
</asp:Content>

<%--<asp:Content ID="countHolder" ContentPlaceHolderID="main" runat="server">
    
</asp:Content>--%>
