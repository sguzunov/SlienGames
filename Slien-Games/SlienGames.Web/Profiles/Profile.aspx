<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="SlienGames.Web.Profiles.Profile" %>

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
                </div>
                <br />
                <div class="block">
                    <div class="block-bot">
                        <div class="head">
                            <div class="head-cnt">
                                <a href="#" class="view-all">See all</a>
                                <h3>FavoriteGames</h3>
                                <div class="cl">&nbsp;</div>
                            </div>
                        </div>
                        <div class="col-articles articles flexed">                                                 
                            
                            <asp:ListView ID="ListViewFavorites" runat="server"
                                ItemType="SlienGames.Data.Models. ">
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

