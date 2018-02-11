using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using medlab.Models;
using System.Data.SqlClient;
using System.Data;

namespace medlab.Account
{
    public partial class Register : Page
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\medlabdb.mdf;Initial Catalog = medlabdb; Integrated Security = True");
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Дополнительные сведения о включении подтверждения учетной записи и сброса пароля см. на странице https://go.microsoft.com/fwlink/?LinkID=320771.
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Подтверждение учетной записи", "Подтвердите вашу учетную запись, щелкнув <a href=\"" + callbackUrl + "\">здесь</a>.");
                
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = String.Format(@"INSERT INTO AspNetUsers(Id,Email,PhoneNumber,UserName,FirstName,SecondName,ThirdName,Department)   
VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", user.Id,user.Email,PhoneNumber.Text, user.UserName, FirstName.Text, SecondName.Text, ThirdName.Text, Guid.Parse(Department.SelectedValue));
                con.Open();
                cmd.ExecuteNonQuery();
                if (Role.SelectedValue == "Worker")
                    cmd.CommandText = String.Format("INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('{0}','{1}')", user.Id, 2);
                else
                    cmd.CommandText = String.Format("INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('{0}','{1}')", user.Id, 1);
                cmd.ExecuteNonQuery();
                con.Close();
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void Department_Load(object sender, EventArgs e)
        {
            
        }

        protected void Department_Init(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT dept_id, dept_name
                                            FROM Department", con);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            Department.DataSource = ds;
            Department.DataTextField = "dept_name";
            Department.DataValueField = "dept_id";
            Department.DataBind();
            con.Close();
        }
    }
    }
