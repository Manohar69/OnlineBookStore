using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Author : System.Web.UI.Page
{
    string scn = ConfigurationSettings.AppSettings["connection"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Audetails_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("Author", con);
        cmd.Parameters.Add(new SqlParameter("@au_id", SqlDbType.Char, 5));
        cmd.Parameters["@au_id"].Value = txtAuid.Text;
        cmd.Parameters.Add(new SqlParameter("@au_name", SqlDbType.VarChar, 30));
        cmd.Parameters["@au_name"].Value = txtAuname.Text;
        cmd.Parameters.Add(new SqlParameter("@au_email", SqlDbType.VarChar, 25));
        cmd.Parameters["@au_email"].Value = txtAuemail.Text;
        cmd.Parameters.Add(new SqlParameter("@au_address", SqlDbType.VarChar, 100));
        cmd.Parameters["@au_address"].Value = txtAuaddress.Text;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        con.Close();

    }
}