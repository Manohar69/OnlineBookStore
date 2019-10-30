using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Books : System.Web.UI.Page
{

    string scn = ConfigurationManager.AppSettings["connection"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void details_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("Books", con);
        cmd.Parameters.Add(new SqlParameter("@bk_id", SqlDbType.Char, 8));
        cmd.Parameters["@bk_id"].Value = txtBkid.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_name", SqlDbType.VarChar, 50));
        cmd.Parameters["@bk_name"].Value = txtBkname.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_au_id", SqlDbType.Char, 15));
        cmd.Parameters["@bk_au_id"].Value = txtBkaudId.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_pub_id ", SqlDbType.Char, 15));
        cmd.Parameters["@bk_pub_id "].Value = txtbkpubid.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_edition", SqlDbType.Int));
        cmd.Parameters["@bk_edition"].Value = txtbkedit.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_price", SqlDbType.Decimal));
        cmd.Parameters["@bk_price"].Value = txtbkprice.Text;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        con.Close();
    }
}