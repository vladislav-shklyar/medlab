using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;


namespace medlab
{
    public partial class CreateRequest : System.Web.UI.Page
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
                Updatedatagridview();
            }
        }

        public void Updatedatagridview()
        {
            SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = String.Format("SELECT item_id, item_name FROM Item WHERE cat_id='{0}'", Guid.Parse(Category.SelectedValue));
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
            Updatedatagridview();
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("", con);
            Guid NewOne = Guid.NewGuid();
            cmd.CommandText = String.Format("INSERT INTO Request(req_id,req_date,status,user_id) VALUES('{0}','{1}','{2}','{3}')", NewOne, DateTime.Now, "Ожидает одобрения главы", User.Identity.GetUserId());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            for (int i = 0; i <= GridView1.Rows.Count-1; i++)
            {             
                cmd.CommandText = String.Format("INSERT INTO RequestItem(reqitem_id,request_id,item_id,amount) VALUES(NewID(),'{0}','{1}','{2}')", NewOne, Guid.Parse(GridView1.DataKeys[i]["item_id"].ToString()),Int32.Parse(((TextBox)GridView1.Rows[i].Cells[0].Controls[1]).Text));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}