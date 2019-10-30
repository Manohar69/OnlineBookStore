using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    string scn = ConfigurationSettings.AppSettings["connection"];
    SqlDataReader myReader;
    int check;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("uspCheckUser", con);
        cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 25));
        cmd.Parameters["@username"].Value = txtUserName.Text;
        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 30));
        cmd.Parameters["@password"].Value = txtPassword.Text;

        cmd.CommandType = CommandType.StoredProcedure;

        int cnt = (int)cmd.ExecuteScalar();
        con.Close();
        if (cnt == 1)
            Response.Redirect("");
        else
            msg.InnerHtml = "Invalid Username or password";
        
    }
}