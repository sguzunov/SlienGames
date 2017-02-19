<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Review.aspx.cs" Inherits="SlienGames.Web.Review" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <h2><%# this.CurrentReview.Title %></h2>
            <span>by<a href="/Profiles/Profile?id=<%#:this.CurrentReview.Author.Id %>"> <%#: this.CurrentReview.Author.UserName %></a></span>
            <hr />
            <div class="container">
                <div class="row">
                    <div class="col-md-2 col-md-offset-2">
                        <iframe width="640" height="360" src="<%# "https://www.youtube.com/embed/" + this.CurrentReview.VideoUrl %>"></iframe>
                    </div>
                </div>
                <br />
                <div class="jumbotron" style="background-color:#303030">
                    <h1><%# this.CurrentReview.Title %></h1>
                    <p><%# this.CurrentReview.Description %></p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
