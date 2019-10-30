using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_Books : System.Web.UI.Page
{
    string scn = ConfigurationManager.AppSettings["connection"];
    String year;
    private void myBindAuthors()
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();


        SqlDataAdapter sda = new SqlDataAdapter("uspGetAuthorInfo", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "author");
        ddlAuthor.DataSource = ds.Tables["author"];
        ddlAuthor.DataValueField = "au_id";
        ddlAuthor.DataTextField = "au_name";
        ddlAuthor.DataBind();
    }
    private void myBindPublishers()
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("uspGetPublisherInfo", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "publisher");
        ddlPublisher.DataSource = ds.Tables["publisher"];
        ddlPublisher.DataValueField = "pub_id";
        ddlPublisher.DataTextField = "pub_name";
        ddlPublisher.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      imgUplaod.Attributes.Add("onchange","return checkFileExtension(this)");
      if (!Page.IsPostBack)
      {
          myBindAuthors();
          myBindPublishers();
          
      }
    }
    protected void details_Click(object sender, EventArgs e)
    {
        DateTime _dt = DateTime.Now;
        String _year = _dt.Year.ToString();
        _year = _year.Substring(2);
        String pat = "bk" + _year;

        SqlConnection con = new SqlConnection(scn);
        con.Open();
        String stmt = "select count(*) from bookstable where bk_id like '" + pat + "%'";
        SqlCommand cmd1 = new SqlCommand(stmt, con);        
        int cnt = (int)cmd1.ExecuteScalar();
        cnt++;
        
        String bkid = pat + cnt.ToString().PadLeft(4, '0');
        msg.InnerHtml = "";
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("Books", con);
        cmd.Parameters.Add(new SqlParameter("@bk_id", SqlDbType.Char, 8));
        cmd.Parameters["@bk_id"].Value = bkid;
        cmd.Parameters.Add(new SqlParameter("@bk_name", SqlDbType.VarChar, 50));
        cmd.Parameters["@bk_name"].Value = txtBkname.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_au_id", SqlDbType.Char, 15));
        cmd.Parameters["@bk_au_id"].Value = ddlAuthor.SelectedItem.Value;
        cmd.Parameters.Add(new SqlParameter("@bk_pub_id ", SqlDbType.Char, 15));
        cmd.Parameters["@bk_pub_id "].Value = ddlPublisher.SelectedItem.Value;
        cmd.Parameters.Add(new SqlParameter("@bk_edition", SqlDbType.Int));
        cmd.Parameters["@bk_edition"].Value = txtbkedit.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_price", SqlDbType.Decimal));
        cmd.Parameters["@bk_price"].Value = txtbkprice.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_isbnno", SqlDbType.Char,15));
        cmd.Parameters["@bk_isbnno"].Value = txtisbnno.Text;
        cmd.Parameters.Add(new SqlParameter("@bk_year", SqlDbType.VarChar,5));
        cmd.Parameters["@bk_year"].Value = txtyearpub.Text;

        int filelen = imgUplaod.FileName.ToString().Trim().Length;
        String extension = imgUplaod.FileName.Substring(filelen -4);
        String mypath=null;
        if (imgUplaod.HasFile)
        {
            mypath = "~/Admin/bookImages/" + bkid + extension;
            imgUplaod.SaveAs(Server.MapPath(mypath));
        }
        cmd.Parameters.Add(new SqlParameter("@img_url", SqlDbType.VarChar,35));
        cmd.Parameters["@img_url"].Value = mypath;


        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        con.Close();
        cmd1.Dispose();
        cmd.Dispose();

    }
    protected void bksclea_Click(object sender, EventArgs e)
    {
        txtBkname.Text = "";
        txtbkedit.Text = "";
        txtbkprice.Text = "";
        txtisbnno.Text = "";
        txtyearpub.Text = "";
    }
}