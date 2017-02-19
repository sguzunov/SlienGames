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
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="form-control" placeholder="Title"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="TextBoxTitle" runat="server" ErrorMessage="Title is required!"></asp:RequiredFieldValidator>
                            <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ForeColor="Red" ControlToValidate="TextBoxTitle" MinimumValue="2" MaximumValue="50" ErrorMessage="Title must be between 2 and 50 characters!"></asp:RangeValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputVideoUrl" class="col-lg-2 control-label">Video Url</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="TextBoxVideoUrl" CssClass="form-control" placeholder="Video url" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="TextBoxVideoUrl" runat="server" ErrorMessage="Video URL is required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="description" class="col-lg-2 control-label">Description</label>
                        <div class="col-lg-10">
                            <textarea class="form-control" runat="server" rows="5" id="description"></textarea>
                        </div>
                    </div>
                    <div class="form-group"></div>
                    <div class="form-group">

                        <label class="col-lg-2 control-label">Cover Picture</label>
                        <div class="col-lg-10 ">
                            <asp:FileUpload runat="server" ID="PictureUpload" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="PictureUpload" ErrorMessage="Cover picture is required!"></asp:RequiredFieldValidator>
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
