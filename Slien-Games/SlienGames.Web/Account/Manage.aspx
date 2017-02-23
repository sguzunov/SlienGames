<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SlienGames.Web.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <h2><%# this.CurrentUser.UserName %></h2>
            <hr />
            <div class="container">
                <div class="row">
                    <div class="col-md-2 col-md-offset-5">
                        <img src="<%#: this.CurrentUser.ProfileImage!= null?
                          this.CurrentUser.ProfileImage.FileSystemUrlPath 
                              + this.CurrentUser.ProfileImage.FileName : "/Content/Avatars/default.png" %>"
                            class="img-responsive img-thumbnail" width="304" height="236" />
                    </div>
                    <div class="col-md-11">
                        <div class="dropdown pull-right">
                            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                                <span class="glyphicon glyphicon-cog"></span>Edit profile
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu">
                                <li><a href="/Account/ManageAvatar">Change avatar</a></li>
                                <li><a href="/Account/ManagePassword">Change password</a></li>
                                <li><a href="/Account/AddReview">Add new review</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <br />
                <div class="block">
                    <div class="block-bot">
                        <div class="head">
                            <div class="head-cnt">
                                <a href="/Account/AllFavorites" class="view-all">See all</a>
                                <h3>FavoriteGames</h3>
                                <div class="cl">&nbsp;</div>
                            </div>
                        </div>
                        <div class="col-articles articles flexed">

                            <asp:ListView ID="ListViewFavorites" runat="server"
                                ItemType="SlienGames.Data.Models.GameDetails">
                                <ItemTemplate>
                                    <div class="article">
                                        <div class="image">
                                            <a href="#">
                                                <img src="<%#: Item.CoverImage!= null ? Item.CoverImage.FileSystemUrlPath : "/Content/Avatars/default.png" %>"
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
