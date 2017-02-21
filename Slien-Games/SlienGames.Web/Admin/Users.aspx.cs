using SlienGames.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlienGames.Web.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        public string Query
        {
            get
            {
                return @"SELECT u.Id,u.Email,u.UserName,u.IsBlocked, r.Name, ur.RoleId 
                         FROM AspNetUsers u
                         JOIN AspNetUserRoles ur ON u.Id= ur.UserId
                         JOIN AspNetRoles r ON r.Id = ur.RoleId";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}