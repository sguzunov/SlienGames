<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PlayedGame/PlayedGame.master" CodeBehind="EmbeddedGame.aspx.cs" Inherits="SlienGames.Web.PlayedGame.EmbeddedGame" %>

<%@ Register Src="~/CustomControlls/Chat/ChatController.ascx" TagPrefix="uc1" TagName="ChatController" %>


<asp:Content ContentPlaceHolderID="GameScriptsPlaceholder" runat="server">
    <script src="../Scripts/jquery.signalR-2.2.1.js"></script>
    <script src="<%= ResolveUrl("~/signalr/hubs") %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="GamePlaceholder" runat="server">
    <div id="game-container">

    </div>
    <input type="hidden" id="username" value="" />
    <input type="hidden" id="userPictureUrl" value="" />
    <input type="hidden" id="groupName" value="" />
    <uc1:ChatController runat="server" ID="ChatController" />
</asp:Content>
