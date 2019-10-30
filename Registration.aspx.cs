using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Registration : System.Web.UI.Page
{
    string scn = ConfigurationSettings.AppSettings["connection"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        int gen;
        if (radmale.Checked == true)
            gen = 1;
        else
            gen = 0;


        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("registration", con);
        cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 20));
        cmd.Parameters["@name"].Value = txtRegusername.Text;
        cmd.Parameters.Add(new SqlParameter("@emailid", SqlDbType.VarChar, 30));
        cmd.Parameters["@emailid"].Value = txtregemail.Text;
        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 15));
        cmd.Parameters["@password"].Value = txtregpassword.Text;
        cmd.Parameters.Add(new SqlParameter("@mobilenumber", SqlDbType.Char, 10));
        cmd.Parameters["@mobilenumber"].Value = txtregmobileno.Text;
        cmd.Parameters.Add(new SqlParameter("@gender", SqlDbType.Bit));
        cmd.Parameters["@gender"].Value = gen;
        cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 100));
        cmd.Parameters["@address"].Value = txtRegAddress.Text;


        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtRegusername.Text = "";
        txtregemail.Text = "";
        txtregpassword.Text = "";
        txtregmobileno.Text = "";
        radmale.Checked = false;
        radfemale.Checked = false;
        txtRegAddress.Text = "";
    }
}