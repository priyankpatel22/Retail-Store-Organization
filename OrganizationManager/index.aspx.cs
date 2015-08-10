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
    public partial class index : System.Web.UI.Page
    {
        string storeId = "";
        Table cart = new Table();
        int totalprice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            string check = "select * from OrganizationInfo";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();

            HashSet<string> set = new HashSet<string>();
            while(oReader.Read())
            {
                set.Add(oReader["NationalOfficeId"].ToString());
            }

            foreach(var item in set)
            {
                DropDownList1.Items.Add(item.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            Label2.Visible = true;
            DropDownList2.Visible = true;
            Button2.Visible = true;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            string check = "select * from OrganizationInfo where NationalOfficeId = '"+DropDownList1.Text+"'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();

            HashSet<string> set = new HashSet<string>();
            while (oReader.Read())
            {
                set.Add(oReader["RegionOfficeId"].ToString());
            }

            foreach (var item in set)
            {
                DropDownList2.Items.Add(item.ToString());
            }
        }

      

        protected void Button2_Click(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            Label3.Visible = true;
            DropDownList3.Visible = true;
            Button3.Visible = true;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            Response.Write(DropDownList2.Text);
            string check = "select * from OrganizationInfo where RegionOfficeId = '" + DropDownList2.Text + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();

            HashSet<string> set = new HashSet<string>();
            while (oReader.Read())
            {
                set.Add(oReader["ZoneOfficeId"].ToString());
            }

            foreach (var item in set)
            {
                DropDownList3.Items.Add(item.ToString());
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DropDownList4.Items.Clear();
            Label4.Visible = true;
            DropDownList4.Visible = true;
            Button5.Visible = true;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            Response.Write(DropDownList2.Text);
            string check = "select * from OrganizationInfo where ZoneOfficeId = '" + DropDownList3.Text + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();

            HashSet<string> set = new HashSet<string>();
            while (oReader.Read())
            {
                set.Add(oReader["StoreId"].ToString());
            }

            foreach (var item in set)
            {
                DropDownList4.Items.Add(item.ToString());
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Panel4.Visible = true;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            storeId = DropDownList4.Text;
            string check = "select * from Product where StoreId = '" + DropDownList4.Text + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col2 = oReader["ProductName"].ToString();
                    string col4 = oReader["Price"].ToString();
                    string col5 = oReader["counts"].ToString();
                    productList.Items.Add(col2);
                }
            }
            else
            {
                Label5.Visible = true;
            }
            Panel3.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Label6.Visible = false;
            Label7.Visible = true;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            string check = "select * from Product where ProductName = '" + productList.Text + "' and StoreId = '" + DropDownList4.Text + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            oReader.Read();

            string prodId = oReader["ProductId"].ToString();
            string col4 = oReader["Price"].ToString();
            int p = int.Parse(col4);
            int col5 = (int)oReader["counts"];

            if(int.Parse(TextBox1.Text) > col5)
            {
                Label6.Visible = true;
                Label6.Text = "Only " + col5 + " counts of this product available..";
            }
            else 
            {
                cart.HorizontalAlign = HorizontalAlign.Center;
                TableCell c1 = new TableCell();
                c1.Text = productList.Text;
                TableCell c2 = new TableCell();
                c2.Text = " x   "+ TextBox1.Text;
                TableCell c3 = new TableCell();
                c3.Text = "= $ "+(int.Parse(TextBox1.Text) * p).ToString();
                totalprice = int.Parse(TextBox1.Text)+ totalprice;
                TableRow r1 = new TableRow();
                r1.Controls.Add(c1);
                r1.Controls.Add(c2);
                r1.Controls.Add(c3);
                cart.Controls.Add(r1);
                Panel5.Controls.Add(cart);

                //Update Product Table
                SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
                conn1.Open();
                int countChange = col5 - int.Parse(TextBox1.Text);
                string checkPhysician = "update Product set counts = " + countChange + " where ProductName = '" + productList.Text + "' and StoreId = '" + DropDownList4.Text + "'";
                SqlCommand com1 = new SqlCommand(checkPhysician, conn1);
                com1.ExecuteNonQuery();

                //Add to Accounts table
                SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
                conn3.Open();

                DateTime DateCurrent = DateTime.UtcNow.Date;

                string checkPhysician2 = "insert into accounts (ProductId,StoreId,counts,amount,date) values (@id,@storeid, @counts, @amount, @date) ";
                SqlCommand com2 = new SqlCommand(checkPhysician2, conn3);
                com2.Parameters.AddWithValue("@id", prodId);
                com2.Parameters.AddWithValue("@storeid", DropDownList4.Text);
                com2.Parameters.AddWithValue("@counts", int.Parse(TextBox1.Text).ToString());
                com2.Parameters.AddWithValue("@amount", (int.Parse(TextBox1.Text) * p).ToString());
                com2.Parameters.AddWithValue("@date", DateCurrent.ToString());

                com2.ExecuteNonQuery();
            }
            Button7.Visible = true;
        }
        

        protected void Button7_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/customerLogout.aspx");
        }
    }
}