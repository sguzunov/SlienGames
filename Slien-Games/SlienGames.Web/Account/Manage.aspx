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
                        <img src="<%#: 
                          this.CurrentUser.ProfileImage.FileSystemUrlPath 
                              + this.CurrentUser.ProfileImage.FileName + "." + 
                              this.CurrentUser.ProfileImage.FileExtension %>"
                            class="img-responsive" width="304" height="236" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
