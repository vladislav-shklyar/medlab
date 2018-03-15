using medlab.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medlab
{
    public partial class Requests : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\medlabdb.mdf;Initial Catalog = medlabdb; Integrated Security = True");
        ApplicationUserManager manager;
        ApplicationSignInManager signinManager;
        ApplicationUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                user = signinManager.UserManager.FindByNameAsync(User.Identity.Name).Result;
                SqlCommand cmd = new SqlCommand(@"SELECT Request.req_id, Request.req_date
                                            FROM Request WHERE Request.req_id = Reqdept.req_id AND Reqdept.dept_id = Department.dept_id AND Department.dept_id = AspNetUsers.Department AND AspNetUsers.Id = " + user.Id.ToString(), con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);
                tbl.AcceptChanges();
                GridView1.DataSource = tbl;
                GridView1.DataBind();
                con.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Session["Value"] = row.Cells[0];
            Response.Redirect("~/Documents.aspx");
        }
    }
}