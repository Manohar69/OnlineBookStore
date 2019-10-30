using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Admin_Author : System.Web.UI.Page
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

        SqlDataAdapter da = new SqlDataAdapter("SELECT * from authortable", scn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvAuthors.DataSource = dt;
        gvAuthors.DataBind();
    }

    protected void Audetails_Click(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd1 = new SqlCommand("uspGetAuthorCount", con);
        int cnt =(int) cmd1.ExecuteScalar();       
        cnt++;
        String auid = "au"+cnt.ToString().PadLeft(3, '0');
        msg.InnerHtml = "";
        SqlCommand cmd = new SqlCommand(scn, con);
        cmd = new SqlCommand("Author", con);
        cmd.Parameters.Add(new SqlParameter("@au_id", SqlDbType.Char, 5));
        cmd.Parameters["@au_id"].Value = auid;
        cmd.Parameters.Add(new SqlParameter("@au_name", SqlDbType.VarChar, 30));
        cmd.Parameters["@au_name"].Value = txtAuname.Text;
        cmd.Parameters.Add(new SqlParameter("@au_email", SqlDbType.VarChar, 25));
        cmd.Parameters["@au_email"].Value = txtAuemail.Text;
        cmd.Parameters.Add(new SqlParameter("@au_address", SqlDbType.VarChar, 100));
        cmd.Parameters["@au_address"].Value = txtAuaddress.Text;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        con.Close();
        cmd1.Dispose();
        cmd.Dispose();
    }

    protected void gvAuthors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAuthors.EditIndex = -1;
        BindData();
    }
    protected void gvAuthors_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE FROM authortable WHERE au_id=@au_id";
        cmd.Parameters.Add("@au_id", SqlDbType.Int).Value = Convert.ToInt32(gvAuthors.Rows[e.RowIndex].Cells[1].Text);

        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        BindData();
    }
    protected void gvAuthors_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAuthors.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void gvAuthors_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (((LinkButton)gvAuthors.Rows[0].Cells[0].Controls[0]).Text == "Insert")
        {
            SqlConnection con = new SqlConnection(scn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO authortable(au_id,au_name,au_emailid,au_address) VALUES(@au_id,@au_name,@au_emailid,@au_address)";
            cmd.Parameters.Add("@au_id", SqlDbType.VarChar).Value = ((TextBox)gvAuthors.Rows[0].Cells[2].Controls[0]).Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            SqlConnection con = new SqlConnection(scn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE authortable SET au_name=@au_name WHERE au_id=@au_id";
            cmd.Parameters.Add("@au_name", SqlDbType.VarChar).Value = ((TextBox)gvAuthors.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@au_id", SqlDbType.Int).Value = Convert.ToInt32(gvAuthors.Rows[e.RowIndex].Cells[1].Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
    protected void aubtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(scn);
        SqlDataAdapter da = new SqlDataAdapter("SELECT au_id, au_name FROM authortable", con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        // Here we'll add a blank row to the returned DataTable
        DataRow dr = dt.NewRow();
        dt.Rows.InsertAt(dr, 0);
        //Creating the first row of GridView to be Editable
        gvAuthors.EditIndex = 0;
        gvAuthors.DataSource = dt;
        gvAuthors.DataBind();
        //Changing the Text for Inserting a New Record
        ((LinkButton)gvAuthors.Rows[0].Cells[0].Controls[0]).Text = "Insert";

    }
    protected void Cleardetails_Click(object sender, EventArgs e)
    {
        txtAuname.Text = "";
        txtAuemail.Text = "";
        txtAuaddress.Text = "";
    }
}