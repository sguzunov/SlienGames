<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="SlienGames.Web.Games.GameDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <div id="main">
            <div id="main-bot">
                <section>
                    <section class="game-info-section clearfix">
                        <h1 class="game-name"><%# this.Model.GameName %></h1>
                        <asp:Image runat="server" ID="ImageCover" ImageUrl="<%# this.Model.CoverImageFileSystemPath %>" CssClass="cover-image" />
                        <p class="game-description"><%#: this.Model.GameDescription %></p>
                    </section>
                    <div class="play-btn-panel">
                        <a href="/PlayedGame/CurrentGame?id= <%#: this.Model.GameId %>" class="btn btn-default play-btn">Play</a>
                    </div>
                    <div>
                        <asp:UpdatePanel runat="server" ID="RatingUpdater">
                            <ContentTemplate>
                                <ajaxToolkit:Rating
                                    ID="Rating"
                                    runat="server"
                                    CurrentRating="3"
                                    MaxRating="5"
                                    StarCssClass="ratingStar"
                                    WaitingStarCssClass="savedRatingStar"
                                    FilledStarCssClass="filledRatingStar"
                                    EmptyStarCssClass="emptyRatingStar"
                                    OnChanged="Rating_Changed" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:ImageButton runat="server" ID="ButtonLikeUnlike" ImageUrl="/Content/Images/liked-game.png" />
                    </div>
                    <div class="comments-section block">
                        <div class="new-comment-section">
                            <a id="new-comment-btn">Add Comment</a>
                            <div id="comment-content" class="form-group comment-content hidden">
                                <label for="comment">Comment:</label>
                                <textarea class="form-control" rows="5" id="comment"></textarea>
                            </div>
                        </div>
                        <div class="block-bot">
                            <div class="head">
                                <div class="head-cnt">
                                    <h3>Comments</h3>
                                </div>
                            </div>
                            <div class="text-articles articles">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelComments" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Repeater runat="server" ID="RepeaterComments" ItemType="SlienGames.Data.Models.Comment" DataSource="<%# this.Model.Comments %>">
                                            <ItemTemplate>
                                                <article class="game-comment-box article">
                                                    <p><%#: Item.Content %></p>
                                                    <hr />
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
