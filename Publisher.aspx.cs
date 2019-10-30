using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class Publisher : System.Web.UI.Page
{
    string scn = ConfigurationSettings.AppSettings["connection"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("Publisher", con);
        cmd.Parameters.Add(new SqlParameter("@pub_id", SqlDbType.Char, 5));
        cmd.Parameters["@pub_id"].Value = txtPubid.Text;
        cmd.Parameters.Add(new SqlParameter("@pub_name", SqlDbType.VarChar, 30));
        cmd.Parameters["@pub_name"].Value = txtPubname.Text;
        cmd.Parameters.Add(new SqlParameter("@pub_email_id", SqlDbType.VarChar, 25));
        cmd.Parameters["@pub_email_id"].Value = txtMailId.Text;
        cmd.Parameters.Add(new SqlParameter("@pub_phoneno", SqlDbType.VarChar, 25));
        cmd.Parameters["@pub_phoneno"].Value = txtPhno.Text;
        cmd.Parameters.Add(new SqlParameter("@pub_address", SqlDbType.VarChar, 100));
        cmd.Parameters["@pub_address"].Value = txtPubAddress.Text;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        con.Close();
    }
}