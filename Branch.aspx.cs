using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class Branch : System.Web.UI.Page
{
    string scn = ConfigurationSettings.AppSettings["connection"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("Branch", con);
        cmd.Parameters.Add(new SqlParameter("@br_id", SqlDbType.Char, 15));
        cmd.Parameters["@br_id"].Value = txtBrid.Text;
        cmd.Parameters.Add(new SqlParameter("@br_name", SqlDbType.VarChar, 25));
        cmd.Parameters["@br_name"].Value = txtBrname.Text;

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        con.Close();

    }
}