<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.Master" CodeBehind="ErrorPage.aspx.cs" Inherits="SlienGames.Web.Errors.ErrorPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <div class="page-not-found-container">
                <img class="img-responsive" src="/Content/System/error.jpg" />
                <div class="righ-not-found">
                    <h1>Oh, no!</h1>
                    <h3>Something's not right,<br/>but we're sorting it out. </h3>
                    <p>The server encountered an error <br/>
                        when processing the last request. <br/>
                      Most often this is due to a problem <br/>
                        in the server's software.</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
