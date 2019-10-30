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

public partial class BooksPage : System.Web.UI.Page
{
    string scn = ConfigurationManager.AppSettings["connection"];
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        String sql = "Select b.bk_id, b.bk_name, a.au_name,p.pub_name,b.edition,b.price,b.bk_img,b.isbnno,b.[year of publishing]from bookstable b, authortable a, publishertable p where b.au_id = a.au_id and b.pub_id = p.pub_id and bk_name like '" + txtSearch.Text + "%'";
        SqlDataSource2.SelectCommand = sql;
        SqlDataSource2.DataBind();
        dlBooks.DataBind();

    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        String sql = "Select b.bk_id, b.bk_name, a.au_name,p.pub_name,b.edition,b.price,b.bk_img,b.isbnno,b.[year of publishing]from bookstable b, authortable a, publishertable p where b.au_id = a.au_id and b.pub_id = p.pub_id";
        SqlDataSource2.SelectCommand = sql;
        SqlDataSource2.DataBind();
        dlBooks.DataBind();
    }
    DataTable bookstable;
    DataView CartView;
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    SqlConnection con = new SqlConnection(scn);
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand(scn, con);
    //    con.Open();
    //    String sql = "select count(*) from bookstable";
    //    SqlCommand cmd1 = new SqlCommand(sql, con);
    //    SqlDataSource2.SelectCommand = sql;
    //    SqlDataSource2.DataBind();
    //    dlBooks.DataBind();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.ExecuteNonQuery();
    //    con.Close();

    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Loginpage.aspx");
    }
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        string[] arr = e.ToString().Split('|');

       DataRow dr = bookstable.NewRow();
        //CartView = new DataView(Cart);

        dr[0] = arr[0];
        dr[1] = arr[1];
        //dr[2] = (float)Convert.ToDouble(arr[2].ToString().Replace("$", ""));
        dr[2] = Convert.ToDouble(arr[2].ToString());

        bookstable.Rows.Add(dr);
        CartView = new DataView(bookstable);
        //ShoppingCart.DataSource = CartView;
        //ShoppingCart.DataBind();
        Session["BuybookCart"] = bookstable;
        AddToCartDB(dr);
        
    }
    private void AddToCartDB(DataRow dr)
    {



        SqlConnection con = new SqlConnection(scn);
        con.Open();
        SqlCommand cmd = new SqlCommand(scn, con);
        string sql = "insert into bookstable(au_name,pub_name,) values (" + Session["UserID"] + "," + dr[0] + ",'" + dr[1] + "'," + dr[2] + ")";
        SqlCommand cmd1 = new SqlCommand(sql, con);
        SqlDataReader dreader = cmd.ExecuteReader();
        dreader.Close();
        cmd.Dispose();
        con.Close();
    }
}