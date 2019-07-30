using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PitchMetrics.Models;

namespace PitchMetrics.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                string handedness = handDDL.SelectedItem.Text;
                SendToDB(firstNametxt.Text, lastNametxt.Text, Email.Text, handedness);
                Response.Redirect("Login");
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
        protected void SendToDB(string fname, string lname, string em, string hand)
        {
            if (IsValid)
            {
                Session["FirstName"] = fname;
                Session["LastName"] = lname;
                Session["ThrowingHand"] = hand;
                var parameters = SqlDataSource1.InsertParameters;
                parameters["FirstName"].DefaultValue = fname;
                parameters["LastName"].DefaultValue = lname;
                parameters["Email"].DefaultValue = em;
                parameters["ThrowingHand"].DefaultValue = hand;
                try
                {
                    SqlDataSource1.Insert();
                    firstNametxt.Text = "";
                    lastNametxt.Text = "";
                    Email.Text = "";
                    Password.Text = "";
                }
                catch (Exception ex)
                {
                    Session["Exception"] = ex;
                    Response.Redirect("ErrorMessage");
                }
            }
        }
    }
}