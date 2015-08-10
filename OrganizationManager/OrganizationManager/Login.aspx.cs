using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.Security;

namespace OrganizationManager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string loginName = loginname.Text;
            string password = pass.Text;


            string enc1 = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            //        Response.Write(loginName);
            //      Response.Write(enc1);
            string check = "select * from employee where EmployeeId = '" + loginName + "' and Password = '" + enc1 + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                oReader.Read();
                string col1 = oReader["EmployeeId"].ToString();
                string col2 = oReader["Password"].ToString();
                string col3 = oReader["Location"].ToString();

                string sub = col3.Substring(0, 1);
                if (sub.Equals("r"))
                {
                    string sub2 = col3.Substring(0, 2);
                    if (sub2.Equals("rs"))
                    {
                        Session["value"] = col1;
                        FormsAuthentication.SetAuthCookie(col1, false);
                        Response.Redirect("~/store/storePage.aspx");
                    }
                    else
                    {
                        Session["value"] = col1;
                        FormsAuthentication.SetAuthCookie(col1, false);
                        Response.Redirect("~/region/regionPage.aspx");
                    }
                }
                if(sub.Equals("z"))
                {
                    Session["value"] = col1;
                    FormsAuthentication.SetAuthCookie(col1, false);
                    Response.Redirect("~/zone/zonePage.aspx");
                }
                if (sub.Equals("n"))
                {
                    Session["value"] = col1;
                    FormsAuthentication.SetAuthCookie(col1, false);
                    Response.Redirect("~/national/nationalPage.aspx");
                }


            }
            else
            {
                loginname.Text = "";
                pass.Text = "";
                Label1.Visible = true;

            }


        }
    }
}