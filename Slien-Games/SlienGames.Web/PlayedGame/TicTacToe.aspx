<%@ Page Title="" Language="C#" MasterPageFile="~/PlayedGame/PlayedGame.master" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="SlienGames.Web.PlayedGame.TicTacToe" %>

<asp:Content ContentPlaceHolderID="GameScriptsPlaceholder" runat="server">
    <script src="../Scripts/jquery.signalR-2.2.1.js"></script>
    <script src="<%= ResolveUrl("~/signalr/hubs") %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="GamePlaceholder" runat="server">
    <asp:HiddenField ID="InputUsername" runat="server" />

    <img id="game-cover" class="cover-image" src="<%= ResolveUrl("~/Uploaded_Images/Covers/tic-tac-toe.png") %>" />
    <input id="find-opponent" type="button" value="Find Opponent" class="btn btn-default" />
    <p id="messages"></p>

    <%-- TicTacToe game client logic --%>
    <script>
        $(function () {
            function initGameFiled(playerName, opponentName) {
                var $gameField = $('<div />').attr('id', 'game-field').addClass('clearfix').addClass('game-field');
                for (var i = 0; i < 9; i++) {
                    var $markerBox = $('<div />').attr('id', i).addClass('marker-box').attr('data-value', i);
                    $gameField.append($markerBox);
                }

                $('#game-panel')
                    .append($('<p />')
                    .text(playerName + ' VS ' + opponentName))
                    .append($gameField);

                $('.marker-box').click(function () {
                    var position = $(this).attr('data-value');
                    gameProxy.server.playTurn(position);
                });
            }

            function finishGame(message) {
                $('#game-field').remove();
                var $finalScr = $('<div />').addClass('clearfix').addClass('game-final-scr');
                $finalScr.append($('<h4 />').text(message).addClass('state'));
                $finalScr.append($('<button />').text('Play Again').addClass('btn btn-default').click(() => { window.location.reload() }));
                $('#game-panel').append($finalScr);

            }

            var gameProxy = $.connection.ticTacToeHub;
            var playerName = $('#MainContent_GamePlaceholder_InputUsername').val();

            $('#find-opponent').click(function () {
                $("#messages").hide();
                gameProxy.server.findOpponent();
            });

            // Register client functions.
            gameProxy.client.endGame = function (message) {
                finishGame(message);
            };

            gameProxy.client.noOpponentFound = function () {
                $("#messages")
                    .text("No opponent found. Please try again.")
                    .show();
            };

            gameProxy.client.playGame = function (opponentName) {
                $("#game-cover").hide();
                $("#find-opponent").hide();
                initGameFiled(playerName, opponentName);
            };

            gameProxy.client.waitTurn = function () {
                $('#messages').text("Wait your turn! Your opponent is thinking.");
            };

            gameProxy.client.addMarker = function (position, whoPlayed) {
                if (whoPlayed == playerName) {
                    $('#' + position).addClass('mark-x');
                } else {
                    $('#' + position).addClass('mark-o');
                }
            };

            // Start the connection with the server.
            $.connection.hub.start().done(function () {
                gameProxy.server.registerPlayer(playerName);
            });
        }());
    </script>
</asp:Content>
