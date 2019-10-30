using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class GridView : System.Web.UI.Page
{

    string scn = ConfigurationManager.AppSettings["connection"];

    DataSet ds;
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        String command = "select * from reg";
        da = new SqlDataAdapter(command, scn);
        ds = new System.Data.DataSet();
        da.Fill(ds, "registereddetails");
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
        con.Close();
    }
}