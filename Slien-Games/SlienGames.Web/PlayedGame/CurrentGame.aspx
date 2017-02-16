<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PlayedGame/PlayedGame.master" CodeBehind="CurrentGame.aspx.cs" Inherits="SlienGames.Web.PlayedGame.CurrentGame" %>

<%@ Register Src="~/CustomControlls/Chat/ChatController.ascx" TagPrefix="uc1" TagName="ChatController" %>


<asp:Content ContentPlaceHolderID="GameScriptsPlaceholder" runat="server">
    <script src="../Scripts/jquery.signalR-2.2.1.js"></script>
    <script src="<%= ResolveUrl("~/signalr/hubs") %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="GamePlaceholder" runat="server">
    <div id="game-container">
        <%# this.Game.GameContent %>
    </div>
    <input type="hidden" id="username" value="" />
    <input type="hidden" id="userPictureUrl" value="" />
    <input type="hidden" id="groupName" value="" />
    <uc1:ChatController runat="server" ID="ChatController" />
    <script src="//static.miniclipcdn.com/js/game-embed.js"></script>
</asp:Content>
