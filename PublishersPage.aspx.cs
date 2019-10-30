using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PublishersPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        String sql = "Select b.bk_id, b.bk_name, a.au_name,p.pub_name,b.edition,b.price,b.bk_img,b.isbnno,b.[year of publishing]from bookstable b, authortable a, publishertable p where b.au_id = a.au_id and b.pub_id = p.pub_id and bk_name like '" + txtbox.Text + "%'";
        SqlDataSource2.SelectCommand = sql;
        SqlDataSource2.DataBind();
        dlBooks.DataBind();
    }
    protected void btnshowall_Click(object sender, EventArgs e)
    {
        String sql = "Select b.bk_id, b.bk_name, a.au_name,p.pub_name,b.edition,b.price,b.bk_img,b.isbnno,b.[year of publishing]from bookstable b, authortable a, publishertable p where b.au_id = a.au_id and b.pub_id = p.pub_id";
        SqlDataSource2.SelectCommand = sql;
        SqlDataSource2.DataBind();
        dlBooks.DataBind();
    }
}