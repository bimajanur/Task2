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
            Label1.Text = "";

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
            Label1.Text = "Saved Successfully";
        }
    }
}