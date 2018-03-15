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
    public partial class RedirectRequest : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\medlabdb.mdf;Initial Catalog = medlabdb; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = new SqlCommand(@"SELECT req_id, dept_name
                                            FROM reqdept", con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);
                tbl.AcceptChanges();
                GridView1.DataSource = tbl;
                GridView1.DataBind();
                con.Close();

                cmd = new SqlCommand(@"SELECT dept_id, dept_name
                                            FROM Department", con);
                DataSet ds = new DataSet();
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                Department.DataSource = ds;
                Department.DataTextField = "dept_name";
                Department.DataValueField = "dept_id";
                Department.DataBind();
                con.Close();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid deleteid = Guid.Parse(GridView1.DataKeys[e.RowIndex]["req_id"].ToString());
            SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM reqdept WHERE req_id='{0}'", deleteid), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd = new SqlCommand(String.Format("DELETE FROM Requests WHERE req_id='{0}'", deleteid), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd = new SqlCommand(String.Format("DELETE FROM Document WHERE req_id='{0}'", deleteid), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("", con);
            GridViewRow row = GridView1.SelectedRow;
            cmd.CommandText = String.Format("UPDATE reqdept SET dept_id = '{0}' WHERE req_id = '{1}'", Guid.Parse(Department.SelectedValue), row.Cells[0]);
        }
    }
}