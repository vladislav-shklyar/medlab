using medlab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.CodeDom;
namespace medlab
{
    public partial class Documents : System.Web.UI.Page
    {
        string reqid;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\medlabdb.mdf;Initial Catalog = medlabdb; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            reqid = Session["Value"].ToString();
            SqlCommand cmd = new SqlCommand(@"SELECT req_id, dept_name
                                            FROM RequestItem JOIN Item ON RequestItem.item_id = Item.item_id WHERE req_id = " + reqid,con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            tbl.AcceptChanges();
            GridView1.DataSource = tbl;
            GridView1.DataBind();
            con.Close();
        }
        public void SaveFile(Guid id)
        {
            clinicdbEntities2 db = new clinicdbEntities2();
            var doc = db.Set<document>().ToList().Select(c => c).Where(c => c.doc_id == id).FirstOrDefault();
            byte[] buffer = (byte[])doc.doc_file;
            Response.Clear();
            Response.ContentType = doc.format;
            Response.AddHeader("Content-Disposition", "attachement;filename=" + doc.name);
            Response.BinaryWrite(buffer);
            Response.Flush();
            Response.Close();
        }
        public void RequestListView_OnItemCommand(Guid id)
        {
            
        }

    }
}