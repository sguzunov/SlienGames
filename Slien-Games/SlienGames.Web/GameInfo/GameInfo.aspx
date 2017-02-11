<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameInfo.aspx.cs" Inherits="SlienGames.Web.GameInfo.GameInfo" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <div id="main">
            <div id="main-bot">
                <section class="clearfix">
                    <section class="game-info-section">
                        <h1 class="game-name"><%# this.Model.GameName %></h1>
                        <asp:Image runat="server" ID="ImageCover" ImageUrl="<%# this.Model.CoverImageFileSystemPath %>" CssClass="cover-image" />
                        <p class="game-description"><%#: this.Model.GameDescription %></p>
                    </section>
                    <div class="comments-section block">
                        <div class="block-bot">
                            <div class="head">
                                <div class="head-cnt">
                                    <h3>Comments</h3>
                                </div>
                            </div>
                            <div class="text-articles articles">
                                <asp:Repeater runat="server" ID="RepeaterComments" ItemType="SlienGames.Data.Models.Comment" DataSource="<%# this.Model.Comments %>">
                                    <ItemTemplate>
                                        <article class="game-comment-box article">
                                            <p><%#: Item.Content %></p>
                                            <footer class="comment-footer">
                                                <i>Posted on: </i><span class="date"><%#: Item.PostedOn.ToString("dd.MM.yyyy") %></span>
                                                <i>by </i>
                                                <a href="../Profiles/Profile.aspx?id=<%# Item.AuthorId %>">
                                                    <%#: Item.Author.UserName %>
                                                </a>
                                            </footer>
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
