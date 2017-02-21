<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.Master" CodeBehind="Users.aspx.cs" Inherits="SlienGames.Web.Admin.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin: auto">

        <asp:SqlDataSource ID="SqlDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:SlienGamesConnection %>"
            SelectCommand="SELECT u.Id,u.Email,u.UserName,u.IsBlocked, r.Name as Role, ur.RoleId FROM AspNetUsers u JOIN AspNetUserRoles ur ON u.Id= ur.UserId JOIN AspNetRoles r ON r.Id = ur.RoleId"
            UpdateCommand="UPDATE [AspNetUsers] SET [Email] = @Email, [UserName] = @UserName, [IsBlocked] = @IsBlocked WHERE [Id] = @Id UPDATE [AspNetUserRoles] SET [RoleId] = @RoleId WHERE [UserId] = @Id">

            <UpdateParameters>
                <asp:Parameter Name="Id" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="IsBlocked" Type="Boolean" />
                <asp:Parameter Name="Role" Type="String" />
                <asp:Parameter Name="RoleId" Type="String" />

            </UpdateParameters>
        </asp:SqlDataSource>


        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource" AutoGenerateColumns="false" DataKeyNames="Id">
            <Columns>
                <asp:CommandField ShowEditButton="True" />

                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" >
                     <HeaderStyle Width="160px" />
                </asp:BoundField >
                <asp:CheckBoxField DataField="IsBlocked" HeaderText="IsBlocked" SortExpression="IsBlocked" >
                    <HeaderStyle Width="160px" />
                </asp:CheckBoxField >
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" >
                     <HeaderStyle Width="160px" />
                </asp:BoundField >
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" >
                   <HeaderStyle Width="160px" />
                </asp:BoundField >
                <asp:BoundField DataField="RoleId" HeaderText="RoleId (set 1 for admin 2 for mortal)" SortExpression="RoleId" >
                    <HeaderStyle Width="160px" />
                </asp:BoundField >
                <asp:BoundField DataField="Role" ReadOnly="true" HeaderText="Role" SortExpression="Role" >
                     <HeaderStyle Width="160px" />
                </asp:BoundField >

            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
