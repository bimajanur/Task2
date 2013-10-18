using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WGSTask2_Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ContactService.ContactServiceClient proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                proxy = new ContactService.ContactServiceClient();
                GridView1.DataSource = proxy.GetAllContact();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            proxy = new ContactService.ContactServiceClient();
            ContactService.Contact objcust = new ContactService.Contact()
            {
                cID = proxy.GetAllContact().Count()+1,
                cName = TextBox1.Text,
                cNoHP = TextBox2.Text
            };

            proxy.InsertContact(objcust);

            GridView1.DataSource = proxy.GetAllContact();
            GridView1.DataBind();
            Label1.Text = "Record Saved Successfully";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["cID"].ToString());
            proxy = new ContactService.ContactServiceClient();

            bool check = proxy.DeleteContact(userid);
            Label1.Text = "Record Deleted Successfully";
            GridView1.DataSource = proxy.GetAllContact();
            GridView1.DataBind();
        }
    }
}