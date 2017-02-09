<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAvatar.aspx.cs" Inherits="SlienGames.Web.Account.ManageAvatar" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="row ">
        <div class="col-md-5 col-md-offset-4">
            <h2>Change avatar</h2>
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <div class="form-background">
                <div class="form-horizontal">
                    
                    <img src="<%#: this.CurrentUser.ProfileImage!= null?
                          this.CurrentUser.ProfileImage.FileSystemUrlPath 
                              + this.CurrentUser.ProfileImage.FileName : "/Content/Avatars/default.png" %>"
                        class="img-responsive img-thumbnail .p-3" width="100px"/>
                    <br />
                    <br />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FileUpload" CssClass="col-md-2 control-label">Select avatar</asp:Label>
                        <div class="col-md-10">
                            <asp:FileUpload runat="server" ID="FileUpload" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FileUpload"
                                CssClass="text-danger" ErrorMessage="Choose avatar!" />
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="Unnamed_Click" Text="Submit" CssClass="btn btn-info mx-auto" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
