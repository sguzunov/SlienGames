<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.Master" CodeBehind="PageNotFound.aspx.cs" Inherits="SlienGames.Web.Errors.PageNotFound" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <div class="page-not-found-container">
                <img class="img-responsive" src="/Content/System/NotFound.jpg" />
                <div class="righ-not-found">
                <h1 ><span class="glyphicon glyphicon-ban-circle" aria-hidden="true"></span>404 page not found</h1>
                <h3>You may try:</h3>
                    <ul>
                        <li> Go to<a href="/"> Home</a>.</li>
                        <li> Use the navigation.</li>
                        <li> Do whatever you want.</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
