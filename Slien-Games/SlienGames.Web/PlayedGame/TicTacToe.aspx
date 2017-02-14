<%@ Page Title="" Language="C#" MasterPageFile="~/PlayedGame/PlayedGame.master" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="SlienGames.Web.PlayedGame.TicTacToe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="GamePlaceholder" runat="server">
    <script src="../Scripts/jquery.signalR-2.2.1.js"></script>
    <script src="<%= ResolveUrl("~/signalr/hubs") %>" type="text/javascript"></script>

    <script>
        $(function () {
            var gameProxy = $.connection.ticTacToeHub;

            // Start the connection with the server.
            $.connection.hub.start().done(function () {
                gameProxy.server.findOpponent("Pesho");
            });
        }());
    </script>
</asp:Content>
