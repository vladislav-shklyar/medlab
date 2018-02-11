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
    public partial class CreateItemCategory : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\medlabdb.mdf;Initial Catalog = medlabdb; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT cat_id, cat_name
                                            FROM Category", con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            tbl.AcceptChanges();
            GridView1.DataSource = tbl;
            GridView1.DataBind();
            con.Close();
        }

        protected void NewCategoryCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = String.Format("INSERT INTO Category(cat_id,cat_name) VALUES(NEWID(),'{0}')", NewCategoryName.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid deleteid = Guid.Parse(GridView1.DataKeys[e.RowIndex]["cat_id"].ToString());
            SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM Category WHERE cat_id='{0}'", deleteid), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}