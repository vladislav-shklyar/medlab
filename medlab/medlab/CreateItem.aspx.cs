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
    public partial class CreateItem : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\medlabdb.mdf;Initial Catalog = medlabdb; Integrated Security = True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = new SqlCommand(@"SELECT cat_id, cat_name
                                            FROM Category", con);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                Category.DataSource = ds;
                Category.DataTextField = "cat_name";
                Category.DataValueField = "cat_id";
                Category.DataBind();
                con.Close();

                cmd.CommandText = String.Format("SELECT item_id, item_name FROM Item WHERE cat_id='{0}'", Guid.Parse(Category.SelectedValue));
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);
                tbl.AcceptChanges();
                GridView1.DataSource = tbl;
                GridView1.DataBind();
                con.Close();
            }
        }

        protected void NewItemCreate_Click(object sender, EventArgs e)
        { 
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = String.Format("INSERT INTO Item(item_id,item_name,cat_id) VALUES(NEWID(),'{0}','{1}')", NewItemName.Text, Guid.Parse(Category.SelectedValue));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Updategridview();
        }

       public void Updategridview()
        {
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = String.Format("SELECT item_id, item_name FROM Item WHERE cat_id='{0}'", Guid.Parse(Category.SelectedValue.ToString()));
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            tbl.AcceptChanges();
            GridView1.DataSource = tbl;
            GridView1.DataBind();
            con.Close();
        }


        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Updategridview();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid deleteid = Guid.Parse(GridView1.DataKeys[e.RowIndex]["item_id"].ToString());
            SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM Item WHERE item_id='{0}'", deleteid), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Updategridview();
            OuterUpdatePanel.Update();
        }
    }
}