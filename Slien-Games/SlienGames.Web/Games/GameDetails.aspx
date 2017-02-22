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
                        <asp:LoginView ID="LoginViewLike" runat="server" ViewStateMode="Disabled">
                            <LoggedInTemplate>
                                <asp:UpdatePanel runat="server" ID="RatingUpdater" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:ImageButton runat="server" ID="ButtonLikeUnlike" OnClick="ButtonLikeUnlike_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </LoggedInTemplate>
                        </asp:LoginView>
                    </div>
                    <asp:LoginView runat="server" ID="LoginViewAddComment">
                        <LoggedInTemplate>
                            <div class="comments-section block">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Label runat="server" ID="CommentContentErrorMessage" />
                                        <textarea id="CommentContent" runat="server" class="form-control" maxlength="200" />
                                        <button runat="server" id="ButtonAddComment" class="btn btn-default right" onserverclick="ButtonAddComment_ServerClick">
                                            <i class="glyphicon glyphicon-pencil"></i>Add Comment
                                        </button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </LoggedInTemplate>
                    </asp:LoginView>
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
                </section>
            </div>
        </div>
    </div>
</asp:Content>
