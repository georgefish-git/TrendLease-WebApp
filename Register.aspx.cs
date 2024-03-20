using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TrendLease_WebApp.App.Users;

namespace TrendLease_WebApp
{
    public partial class Register_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            if (registrationValidation())
            {
                string newUser = usernameTxtBox.Text;


                if (!DoesUserExists(newUser))
                {
                    Response.Write($"<script>alert('Successful Registration');</script>");

                    // user creation
                    var userRepo = new UserRepository();

                    userRepo.CreateUser(new User()
                    {
                        FirstName = fNameTxtBox.Text,
                        LastName = lNameTxtBox.Text,
                        Address = addressTxtBox.Text,
                        Email = emailTxtBox.Text,
                        PhoneNumber = phoneNoTxtBox.Text,
                        Username = usernameTxtBox.Text,
                        UserPass = pass1TxtBox.Text,

                    });


                    // clear values
                    ClearTxtboxValues();

                    Response.Write("<script>window.setTimeout(function(){ window.location.href = 'Login.aspx'; }, 1000);</script>");
                    // Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write($"<script>alert('User {newUser} already exists');</script>");

                    // clear values
                    ClearTxtboxValues();
                }
            }
            else
            {
                // invalid creation
                Response.Write($"<script>alert('Unsuccessful Registration. Please check your inputted values.');</script>");
            }
        }


        protected void ClearTxtboxValues()
        {
            // clear input fields
            fNameTxtBox.Text = "";
            lNameTxtBox.Text = "";
            addressTxtBox.Text = "";
            emailTxtBox.Text = "";
            phoneNoTxtBox.Text = "";
            usernameTxtBox.Text = "";
            pass1TxtBox.Text = "";
            pass2TxtBox.Text = "";
        }




        protected bool registrationValidation()
        {
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        protected bool DoesUserExists(string newUser)
        {
            UserRepository repository = new UserRepository();
            IEnumerable<User> userMembers = repository.GetAllUser();

            return userMembers.Any(user => user.Username == newUser);
        }
    }
}