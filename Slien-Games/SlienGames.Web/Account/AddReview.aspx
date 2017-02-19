<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddReview.aspx.cs" Inherits="SlienGames.Web.Account.AddReview" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <div id="main-bot">
            <h2>New Review</h2>
            <hr />

            <div class="container">
                <fieldset>
                    <div class="form-group">
                        <label for="inputTitle" class="col-lg-2 control-label">Title</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" id="inputTitle" placeholder="Title">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputVideoUrl" class="col-lg-2 control-label">Video Url</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" id="inputVideoUrl" placeholder="Video URL">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="description" class="col-lg-2 control-label">Description</label>
                        <div class="col-lg-10">
                            <textarea class="form-control" rows="5" id="description"></textarea>
                        </div>
                    </div>
                    <div  class="form-group"></div>
                    <div class="form-group">

                            <label class="col-lg-2 control-label">Cover Picture</label>
                            <div class="col-lg-10 ">
                                <asp:FileUpload runat="server" ID="PictureUpload" />
                            </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-5">
                            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </fieldset>

            </div>
        </div>
    </div>
</asp:Content>
