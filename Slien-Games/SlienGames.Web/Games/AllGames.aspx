<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AllGames.aspx.cs" Inherits="SlienGames.Web.Games.AllGames" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <h2>Games</h2>
            <hr />
            <div class="container">
                <div class="row">
                    <asp:ListView runat="server" ID="ListGames" ItemType="SlienGames.Data.Models.EmbeddedGame">
                        <ItemTemplate>
                             <div class="article">
                                <div class="image">
                                    <a href="#">
                                        <img src="<%#: Item.ImagePath %>" alt="" /></a>
                                </div>
                                <h4><a href="#"><%#: Item.Name %></a></h4>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>