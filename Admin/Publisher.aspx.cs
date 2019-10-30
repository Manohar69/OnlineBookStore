using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class Admin_Publisher : System.Web.UI.Page
{
    string scn = ConfigurationSettings.AppSettings["connection"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        
        SqlDataAdapter da = new SqlDataAdapter("SELECT * from publishertable", scn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvPublishers.DataSource = dt;
        gvPublishers.DataBind();
    }




    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd1 = new SqlCommand("uspGetPublisherCount", con);
        int cnt = (int)cmd1.ExecuteScalar();
        cnt++;
        String puid = "pb" + cnt.ToString().PadLeft(3, '0');
        msg.InnerHtml = "";
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("Publisher", con);
        cmd.Parameters.Add(new SqlParameter("@pub_id", SqlDbType.Char, 5));
        cmd.Parameters["@pub_id"].Value = puid;
        cmd.Parameters.Add(new SqlParameter("@pub_name", SqlDbType.VarChar, 30));
        cmd.Parameters["@pub_name"].Value = txtPubname.Text;
        cmd.Parameters.Add(new SqlParameter("@pub_email_id", SqlDbType.VarChar, 25));
        cmd.Parameters["@pub_email_id"].Value = txtMailId.Text;
        cmd.Parameters.Add(new SqlParameter("@pub_phoneno", SqlDbType.VarChar, 25));
        cmd.Parameters["@pub_phoneno"].Value = txtPhno.Text;
        cmd.Parameters.Add(new SqlParameter("@pub_address", SqlDbType.VarChar, 100));
        cmd.Parameters["@pub_address"].Value = txtPubAddress.Text;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        con.Close();
        cmd1.Dispose();
        cmd.Dispose();
    }

    protected void gvPublishers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPublishers.EditIndex = -1;
        BindData();
    }
    protected void gvPublishers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE FROM publishertable WHERE pub_id=@pub_id";
        cmd.Parameters.Add("@pub_id", SqlDbType.Int).Value = Convert.ToInt32(gvPublishers.Rows[e.RowIndex].Cells[1].Text);

        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        BindData();

    }
    protected void gvPublishers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPublishers.EditIndex = e.NewEditIndex;
        BindData();

    }
    protected void gvPublishers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        if (((LinkButton)gvPublishers.Rows[0].Cells[0].Controls[0]).Text == "Insert")
        {
            SqlConnection con = new SqlConnection(scn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO publishertable(pub_id,pub_name,pub_emailid,pub_phoneno,pub_address) VALUES(@pub_id,@pub_name,@pub_emailid,@pub_phoneno,@pub_address)";
            cmd.Parameters.Add("@pub_id", SqlDbType.VarChar).Value = ((TextBox)gvPublishers.Rows[0].Cells[2].Controls[0]).Text;

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            SqlConnection con = new SqlConnection(scn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE publishertable SET pub_name=@pub_name WHERE pub_id=@pub_id";
            cmd.Parameters.Add("@pub_name", SqlDbType.VarChar).Value = ((TextBox)gvPublishers.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@pub_id", SqlDbType.Int).Value = Convert.ToInt32(gvPublishers.Rows[e.RowIndex].Cells[1].Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
    protected void pubBtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        SqlDataAdapter da = new SqlDataAdapter("SELECT pub_id, pub_name FROM publishertable", con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        // Here we'll add a blank row to the returned DataTable
        DataRow dr = dt.NewRow();
        dt.Rows.InsertAt(dr, 0);
        //Creating the first row of GridView to be Editable
        gvPublishers.EditIndex = 0;
        gvPublishers.DataSource = dt;
        gvPublishers.DataBind();
        //Changing the Text for Inserting a New Record
        ((LinkButton)gvPublishers.Rows[0].Cells[0].Controls[0]).Text = "Insert";

    }
    protected void cleardetails_Click(object sender, EventArgs e)
    {
        txtPubname.Text = "";
        txtMailId.Text = "";
        txtPhno.Text = "";
        txtPubAddress.Text = "";
    }
}