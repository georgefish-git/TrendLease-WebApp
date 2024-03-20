using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrendLease_WebApp.App.Users;

namespace TrendLease_WebApp
{
    public partial class Sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var userRepo = new UserRepository();

            // getting user in database       
            var currUser = userRepo.LogInUser(username.Text);

            // validation of existing user
            if (currUser != null && currUser.Any())
            {
                foreach (var user in currUser)
                {
                    if (user.Username != null)
                    {
                        // validation of password
                        if (user.UserPass == password.Text)
                        {
                            currentUser onlineUser = new currentUser
                            {
                                Username = user.Username,
                                Password = user.UserPass
                            };

                            // redirect page
                            Response.Redirect("MainContent.aspx?username=" + onlineUser.Username);
                        }

                        else
                        {
                            Response.Write($"<script>alert('Incorrect Password.');</script>");
                        }
                    }

                    else
                    {
                        Response.Write($"<script>alert('User is not Registered.');</script>");
                    }

                }
                
            }

            else
            {
                Response.Write($"<script>alert('User is not Registered.');</script>");
            }
            
        }

    }
}