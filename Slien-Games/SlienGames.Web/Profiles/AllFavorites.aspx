<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AllFavorites.aspx.cs" Inherits="SlienGames.Web.Account.AllFavorites" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <h2><%# this.CurrentUser.UserName %>'s all favorites</h2>
            <hr />
            <div class="container">
                <div class="block">
                    <div class="block-bot">
                        <div class="head">
                            <div class="head-cnt">
                                <h3>FavoriteGames</h3>
                                <div class="cl">&nbsp;</div>
                            </div>
                        </div>
                        <div class="col-articles articles flexed">

                            <asp:ListView ID="ListViewFavorites" runat="server"
                                ItemType="SlienGames.Data.Models.GameProfile">
                                <ItemTemplate>
                                    <div class="article">
                                        <div class="image">
                                            <a href="#">
                                                <img src="<%#: Item.CoverImage!= null?
                          Item.CoverImage.FileSystemUrlPath 
                              + Item.CoverImage.FileName : "/Content/Avatars/default.png" %>"
                                                    alt="" /></a>
                                        </div>
                                        <h4><a href="#"><%#: Item.Name %></a></h4>
                                        <p class="console"><strong><%#: Item.Rating %></strong></p>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
