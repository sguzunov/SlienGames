<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PlayedGame/PlayedGame.master" CodeBehind="CurrentGame.aspx.cs" Inherits="SlienGames.Web.PlayedGame.CurrentGame" %>

<%@ Register Src="~/CustomControlls/Chat/ChatController.ascx" TagPrefix="uc1" TagName="ChatController" %>


<asp:Content ContentPlaceHolderID="GameScriptsPlaceholder" runat="server">
    <script src="../Scripts/jquery.signalR-2.2.1.js"></script>
    <script src="<%= ResolveUrl("~/signalr/hubs") %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="GamePlaceholder" runat="server">
        <div class="current-game-content" style="display:flex; width:800px; margin:auto;">
            <div id="game-container"  style="display:flex; justify-content:flex-start" >
                <%# this.Game.GameContent %>

            </div>
            <div class="chat-container" style="padding-left:160px;">
                <uc1:ChatController runat="server" ID="ChatController" />
            </div>
            <input type="hidden" id="username" value="<%#: this.CurrentUser.UserName %>" />
            <input type="hidden" id="userPictureUrl" value="<%#: this.CurrentUser.ProfileImage!= null?
                          this.CurrentUser.ProfileImage.FileSystemUrlPath 
                              + this.CurrentUser.ProfileImage.FileName : "/Content/Avatars/default.png" %>" />
            <input type="hidden" id="groupName" value="<%#: this.Request.QueryString["id"] %>" />
        </div>
    <script src="//static.miniclipcdn.com/js/game-embed.js"></script>
</asp:Content>
