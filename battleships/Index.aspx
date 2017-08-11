<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="battleships.Index" %>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h3>ENTER YOUR NAME, PRIVATE</h3>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="NO NAME, NO GAME!" ControlToValidate="nameInput" EnableClientScript="False"></asp:RequiredFieldValidator>
    <input id="nameInput" type="text" runat="server" />

    <asp:RadioButtonList ID="difficultyList" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem selected="True" Value="1">EASY</asp:ListItem>
        <asp:ListItem Value="2">MEDIUM</asp:ListItem>
        <asp:ListItem  Value="3">HARD</asp:ListItem>    
    </asp:RadioButtonList>

    <asp:Button ID="NewGameBtn" runat="server" Text="NEW GAME" OnClick="NewGameBtn_OnClick" />
    <asp:Button ID="ShowHighScores" runat="server" Text="SEE HIGHSCORES" OnClick="ShowHighScores_Click" />
</asp:Content>


<asp:Content ContentPlaceHolderID="bottomScripts" ID="scripts" runat="server">
    <asp:Literal ID="scriptLiteral" runat="server"></asp:Literal>
    <asp:Literal ID="audioLiteral" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ContentPlaceHolderID="modal" ID="modalBox" runat="server">
    <div id="myModal" class="modal">
        <!-- Modal content -->
        <div class="modal-content">
            <span class="close">&times;</span>
            <p id="scoreText"></p>
            <asp:Literal ID="ScoreList" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
