<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AllGames.aspx.cs" Inherits="SlienGames.Web.Games.AllGames" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <h2>Games</h2>
            <hr />

            <div class="container">
                <div class="block">
                    <div class="block-bot">
                        <div class="head">
                            <div class="head-cnt">

                                <div class="cl">&nbsp;</div>
                            </div>
                        </div>
                        <div class="col-articles articles flexed">

                            <asp:ListView ID="ListGames" runat="server"
                                ItemType="SlienGames.Data.Models.EmbeddedGame">
                                <ItemTemplate>
                                    <div class="listing-games-template">

                                        <div class="article">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="<%# Item.ImagePath %>" alt="" /></a>
                                            </div>
                                            <h4><a href="#"><%#: Item.Name %></a></h4>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                            <div class="">

                                <asp:DataPager ID="DataPagerCustomers" runat="server"
                                    PagedControlID="ListGames" PageSize="9"
                                    QueryStringField="page">
                                    <Fields>
                                        <asp:NextPreviousPagerField ShowFirstPageButton="true"
                                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ShowLastPageButton="true"
                                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
