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
    public partial class storePage : System.Web.UI.Page
    {
        public static string loginId = "";
        public static string fname = ""; 
        public static string lname = "";
        public static string location = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        
            loginId = Session["value"].ToString();
            //loginId = "101";
            loginNameDisplay.Text = loginId;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            string check = "select * from Employee where EmployeeId = '" + loginId +"'";
            SqlCommand com = new SqlCommand(check, conn);
                
            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                oReader.Read();
                fname = oReader["FirstName"].ToString();
                lname = oReader["LastName"].ToString();
                location = oReader["Location"].ToString();

                loginNameDisplay.Text = fname + " " + lname;
                personLocation.Text = location;
            }
        }

        protected void addProductPop_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
        }

        protected void addProductButon_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            DateTime DateCurrent= DateTime.UtcNow.Date;
            
            string checkPhysician = "insert into Product (ProductId,ProductName,StoreId,Price,priceDate,counts) values (@id,@name, @storeid, @price, @date,@counts) ";
            SqlCommand com1 = new SqlCommand(checkPhysician, conn);
            com1.Parameters.AddWithValue("@id", pId.Text);
            com1.Parameters.AddWithValue("@name", pName.Text);
            com1.Parameters.AddWithValue("@storeid", location);
            com1.Parameters.AddWithValue("@price", price.Text);
            com1.Parameters.AddWithValue("@date", DateCurrent.ToString());
            com1.Parameters.AddWithValue("@counts", 0);

            com1.ExecuteNonQuery();
            conn.Close();
            Panel1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            Table displayProducts = new Table();
            displayProducts.HorizontalAlign = HorizontalAlign.Center;
            TableCell c1 = new TableCell();
            c1.Text = "Product ID";
            c1.Font.Bold = true;
            TableCell c2 = new TableCell();
            c2.Text = "Product Name";
            c2.Font.Bold = true;
            TableCell c3 = new TableCell();
            c3.Text = "Price";
            c3.Font.Bold = true;
            TableCell c4 = new TableCell();
            c4.Text = "Effective Date";
            c4.Font.Bold = true;


            TableRow r1 = new TableRow();
            r1.Controls.Add(c1);
            r1.Controls.Add(c2);
            r1.Controls.Add(c3);
            r1.Controls.Add(c4);

            displayProducts.Controls.Add(r1);
            
            string check = "select * from Product where StoreId = '" + location + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["ProductName"].ToString();
                    string col3 = oReader["StoreId"].ToString();
                    string col4 = oReader["Price"].ToString();
                    string col5 = oReader["priceDate"].ToString();

                    //row2
                    TableCell c6 = new TableCell();
                    c6.Text = col1;
                    TableCell c8 = new TableCell();
                    c8.Text = col2;
                    TableCell c5 = new TableCell();
                    c5.Text = col4;
                    TableCell c7 = new TableCell();
                    c7.Text = col5;
                    TableRow r2 = new TableRow();
                    r2.Controls.Add(c6);
                    r2.Controls.Add(c8);
                    r2.Controls.Add(c5);
                    r2.Controls.Add(c7);

                    displayProducts.Controls.Add(r2);
                }
            }
            else
            {
                Label l1 = new Label();
                l1.Text = "No Products in the Store";
                l1.ForeColor = System.Drawing.Color.Red ;
                Panel2.Controls.Add(l1);
            }
            Panel2.Controls.Add(displayProducts);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;

            DropDownList1.Items.Clear();
            

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            string check = "select * from Product where StoreId = '" + location + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["ProductName"].ToString();
                    string col3 = oReader["StoreId"].ToString();
                    string col4 = oReader["Price"].ToString();

                    DropDownList1.Items.Add(col2);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string selectedProd = DropDownList1.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            string check = "delete from Product where ProductName = '"+selectedProd+"' and StoreId = '" + location + "'";
            SqlCommand com = new SqlCommand(check, conn);

            com.ExecuteNonQuery();
            conn.Close();
        }

        protected void addEmployeeButton_Click(object sender, EventArgs e)
        {
            //Guid newguid = new Guid();
            
            DateTime DateCurrent= DateTime.UtcNow.Date;
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            //string check = "insert into Employee (Location,Ssn,FirstName,LastName,Gender,JobTitle,Password,BeginDate,Salary) values (@location, @ssn, @fname, @lname, @gender, @jotitle, @pass, @beginDate, @salary) ";
            string check = "insert into Employee (EmployeeId,Location,Ssn,FirstName,LastName,Gender,JobTitle,Password,BeginDate,Salary) values (@id,@location, @ssn, @fname, @lname, @gender, @jotitle, @pass, @beginDate, @salary) ";
            SqlCommand com1 = new SqlCommand(check, conn);

            com1.Parameters.AddWithValue("@id", System.Guid.NewGuid().ToString());
            com1.Parameters.AddWithValue("@location", location);
            com1.Parameters.AddWithValue("@ssn", essn.Text);
            com1.Parameters.AddWithValue("@fname", efname.Text);
            com1.Parameters.AddWithValue("@lname", elname.Text);
            com1.Parameters.AddWithValue("@gender", egender.Text);
            com1.Parameters.AddWithValue("@jotitle", etitle.Text);
            com1.Parameters.AddWithValue("@pass", epass.Text);
            com1.Parameters.AddWithValue("@beginDate", DateCurrent.ToString());
            com1.Parameters.AddWithValue("@salary", esalary.Text);

            com1.ExecuteNonQuery();
            conn.Close();
            Panel1.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            
            DropDownList2.Items.Clear();
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            string check = "select * from Employee where Location = '" + location + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["FirstName"].ToString();
                    string col2 = oReader["LastName"].ToString();
                    string col3 = oReader["EmployeeId"].ToString();

                    if(!col3.Equals(loginId))
                    {
                        string fullName = col1 + " " + col2;
                        DropDownList2.Items.Add(fullName);
                    }
                }
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string selectedName = DropDownList2.Text;

            var splitName = selectedName.Split(' ');
            string fname = splitName[0];
            string lname = splitName[1];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            string check = "delete from Employee where FirstName = '" + fname + "' and LastName = '" + lname + "'";
            SqlCommand com = new SqlCommand(check, conn);

            com.ExecuteNonQuery();
            conn.Close();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = true;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            Table displayProducts = new Table();
            displayProducts.HorizontalAlign = HorizontalAlign.Center;
            TableCell c1 = new TableCell();
            c1.Text = "Product ID";
            c1.Font.Bold = true;
            TableCell c2 = new TableCell();
            c2.Text = "Product Name";
            c2.Font.Bold = true;
            TableCell c3 = new TableCell();
            c3.Text = "Price";
            c3.Font.Bold = true;
            TableCell c4 = new TableCell();
            c4.Text = "Effective Date";
            c4.Font.Bold = true;
            TableRow r1 = new TableRow();
            r1.Controls.Add(c1);
            r1.Controls.Add(c2);
            r1.Controls.Add(c3);
            r1.Controls.Add(c4);
            displayProducts.Controls.Add(r1);

            string check = "select * from Product where ProductName like '" + prodSearchBox.Text +"%' and StoreId = '"+ location+"'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["ProductName"].ToString();
                    string col3 = oReader["StoreId"].ToString();
                    string col4 = oReader["Price"].ToString();
                    string col5 = oReader["priceDate"].ToString();
                    int col6 = (int)oReader["counts"];
                    //row2
                    if(col6 > 0)
                    {
                        TableCell c6 = new TableCell();
                        c6.Text = col1;
                        TableCell c8 = new TableCell();
                        c8.Text = col2;
                        TableCell c5 = new TableCell();
                        c5.Text = col4;
                        TableCell c7 = new TableCell();
                        c7.Text = col5;
                        TableRow r2 = new TableRow();
                        r2.Controls.Add(c6);
                        r2.Controls.Add(c8);
                        r2.Controls.Add(c5);
                        r2.Controls.Add(c7);
                        displayProducts.Controls.Add(r2);
                    }
                    
                }
            }
            Panel6.Controls.Add(displayProducts);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            Table displayProducts = new Table();
            displayProducts.HorizontalAlign = HorizontalAlign.Center;
            TableCell c1 = new TableCell();
            c1.Text = "Employee ID";
            c1.Font.Bold = true;
            TableCell c2 = new TableCell();
            c2.Text = "Location";
            c2.Font.Bold = true;
            TableCell c3 = new TableCell();
            c3.Text = "SSN";
            c3.Font.Bold = true;
            
            TableCell c4 = new TableCell();
            c4.Text = "First Name";
            c4.Font.Bold = true;
            TableCell c5 = new TableCell();
            c5.Text = "Last Name";
            c5.Font.Bold = true;
            TableCell c6 = new TableCell();
            c6.Text = "Gender";
            c6.Font.Bold = true;

            TableCell c7 = new TableCell();
            c7.Text = "Title";
            c7.Font.Bold = true;
            TableCell c8 = new TableCell();
            c8.Text = "Begin Date";
            c8.Font.Bold = true;
            TableCell c9 = new TableCell();
            c9.Text = "Salary";
            c9.Font.Bold = true;
            TableRow r1 = new TableRow();
            r1.Controls.Add(c1);
            r1.Controls.Add(c2);
            r1.Controls.Add(c3);
            r1.Controls.Add(c4);
            r1.Controls.Add(c5);
            r1.Controls.Add(c6);
            r1.Controls.Add(c7);
            r1.Controls.Add(c8);
            r1.Controls.Add(c9);
            displayProducts.Controls.Add(r1);

            string check = "select * from Employee where FirstName like '" + nameSearchBox.Text + "%' and Location = '" + location + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["EmployeeId"].ToString();
                    string col2 = oReader["Location"].ToString();
                    string col3 = oReader["Ssn"].ToString();
                    string col4 = oReader["FirstName"].ToString();
                    string col5 = oReader["LastName"].ToString();
                    string col6 = oReader["Gender"].ToString();
                    string col7 = oReader["JobTitle"].ToString();
                    string col8 = oReader["beginDate"].ToString();
                    string col9 = oReader["salary"].ToString();

                    //row2
                    TableCell c10 = new TableCell();
                    c10.Text = col1;
                    TableCell c11 = new TableCell();
                    c11.Text = col2;
                    TableCell c12 = new TableCell();
                    c12.Text = col3;
                    
                    TableCell c13 = new TableCell();
                    c13.Text = col4;
                    TableCell c14 = new TableCell();
                    c14.Text = col5;
                    TableCell c15 = new TableCell();
                    c15.Text = col6;
                    
                    TableCell c16 = new TableCell();
                    c16.Text = col7;
                    TableCell c17 = new TableCell();
                    c17.Text = col8;
                    TableCell c18 = new TableCell();
                    c18.Text = col9;
                    TableRow r2 = new TableRow();
                    r2.Controls.Add(c10);
                    r2.Controls.Add(c11);
                    r2.Controls.Add(c12);
                    r2.Controls.Add(c13);
                    r2.Controls.Add(c14);
                    r2.Controls.Add(c15);
                    r2.Controls.Add(c16);
                    r2.Controls.Add(c17);
                    r2.Controls.Add(c18);
                    displayProducts.Controls.Add(r2);
                }
            }
            Panel7.Controls.Add(displayProducts);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = true;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = true;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;

            priceListToUpdate.Items.Clear();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            string check = "select * from Product where StoreId = '" + location + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["ProductName"].ToString();
                    string col3 = oReader["StoreId"].ToString();
                    string col4 = oReader["Price"].ToString();

                    priceListToUpdate.Items.Add(col2);
                }
            }
        }

        protected void updatePrice_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn1.Open();
            DateTime DateCurrent = DateTime.UtcNow.Date;
            string checkPhysician = "update Product set Price = " + newPrice.Text + ", priceDate = '"+ DateCurrent.ToString()+"' where ProductName = '" + priceListToUpdate.Text + "' and StoreId = '" + location + "'";
            SqlCommand com1 = new SqlCommand(checkPhysician, conn1);
            com1.ExecuteNonQuery();

            newPrice.Text = "";
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = true;
            Panel10.Visible = false;
            Panel11.Visible = false;
        }
        //for day
        protected void Button14_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            DateTime CurrentDate = new DateTime();
            

            Table sales = new Table();
            sales.HorizontalAlign = HorizontalAlign.Center;
            TableCell c1 = new TableCell();
            c1.Text = "Product Name";
            c1.HorizontalAlign = HorizontalAlign.Center;
            c1.Font.Bold = true;
            TableCell c2 = new TableCell();
            c2.Text = "Store";
            c2.HorizontalAlign = HorizontalAlign.Center;
            c2.Font.Bold = true;
            TableCell c3 = new TableCell();
            c3.Text = "Counts";
            c3.HorizontalAlign = HorizontalAlign.Center;
            c3.Font.Bold = true;
            TableCell c4 = new TableCell();
            c4.Text = "Amount";
            c4.HorizontalAlign = HorizontalAlign.Center;
            c4.Font.Bold = true;
            TableCell c5 = new TableCell();
            c5.Text = "date";
            c5.HorizontalAlign = HorizontalAlign.Center;
            c5.Font.Bold = true;
            TableRow r1 = new TableRow();
            r1.Controls.Add(c1);
            r1.Controls.Add(c2);
            r1.Controls.Add(c3);
            r1.Controls.Add(c4);
            r1.Controls.Add(c5);
            sales.Controls.Add(r1);
            string check = "select * from accounts where StoreId = '" + location + "' and date = '" + CurrentDate + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();

            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["StoreId"].ToString();
                    string col3 = oReader["counts"].ToString();
                    string col4 = oReader["amount"].ToString();
                    string col5 = oReader["date"].ToString();


                    TableCell c6 = new TableCell();
                    c6.Text = col1;
                    c6.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c7 = new TableCell();
                    c7.Text = col2;
                    c7.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c8 = new TableCell();
                    c8.Text = col3;
                    c8.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c9 = new TableCell();
                    c9.Text = col4;
                    c9.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c10 = new TableCell();
                    c10.Text = col5;
                    c10.HorizontalAlign = HorizontalAlign.Center;
                    TableRow r2 = new TableRow();
                    r2.Controls.Add(c6);
                    r2.Controls.Add(c7);
                    r2.Controls.Add(c8);
                    r2.Controls.Add(c9);
                    r2.Controls.Add(c10);
                    sales.Controls.Add(r2);

                }
                Panel9.Controls.Add(sales);
            }
            else
            {
                Label l1 = new Label();
                l1.Text = "No sales for today..";
                l1.ForeColor = System.Drawing.Color.Red;
                Panel9.Controls.Add(l1);
            }
        }
        //for week
        protected void Button15_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            //DateTime CurrentDate = new DateTime();
            DayOfWeek weekStart = DayOfWeek.Monday;
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            DateTime previousWeekStart = startingDate.AddDays(-7);
            DateTime previousWeekEnd = startingDate.AddDays(-1);

            Table sales = new Table();
            sales.HorizontalAlign = HorizontalAlign.Center;
            TableCell c1 = new TableCell();
            c1.Text = "Product Name";
            c1.HorizontalAlign = HorizontalAlign.Center;
            c1.Font.Bold = true;
            TableCell c2 = new TableCell();
            c2.Text = "Store";
            c2.HorizontalAlign = HorizontalAlign.Center;
            c2.Font.Bold = true;
            TableCell c3 = new TableCell();
            c3.Text = "Counts";
            c3.HorizontalAlign = HorizontalAlign.Center;
            c3.Font.Bold = true;
            TableCell c4 = new TableCell();
            c4.Text = "Amount";
            c4.HorizontalAlign = HorizontalAlign.Center;
            c4.Font.Bold = true;
            TableCell c5 = new TableCell();
            c5.Text = "date";
            c5.HorizontalAlign = HorizontalAlign.Center;
            c5.Font.Bold = true;
            TableRow r1 = new TableRow();
            r1.Controls.Add(c1);
            r1.Controls.Add(c2);
            r1.Controls.Add(c3);
            r1.Controls.Add(c4);
            r1.Controls.Add(c5);
            sales.Controls.Add(r1);
            string check = "select * from accounts where StoreId = '" + location + "' and date between '" + previousWeekStart + "' and '" + previousWeekEnd + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();

            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["StoreId"].ToString();
                    string col3 = oReader["counts"].ToString();
                    string col4 = oReader["amount"].ToString();
                    string col5 = oReader["date"].ToString();


                    TableCell c6 = new TableCell();
                    c6.Text = col1;
                    c6.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c7 = new TableCell();
                    c7.Text = col2;
                    c7.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c8 = new TableCell();
                    c8.Text = col3;
                    c8.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c9 = new TableCell();
                    c9.Text = col4;
                    c9.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c10 = new TableCell();
                    c10.Text = col5;
                    c10.HorizontalAlign = HorizontalAlign.Center;
                    TableRow r2 = new TableRow();
                    r2.Controls.Add(c6);
                    r2.Controls.Add(c7);
                    r2.Controls.Add(c8);
                    r2.Controls.Add(c9);
                    r2.Controls.Add(c10);
                    sales.Controls.Add(r2);

                }
                Panel9.Controls.Add(sales);
            }
            else
            {
                Label l1 = new Label();
                l1.Text = "No sales for Last Week..";
                l1.ForeColor = System.Drawing.Color.Red;
                Panel9.Controls.Add(l1);
            }
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            //DateTime CurrentDate = new DateTime();

            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            DateTime first = month.AddMonths(-1);
            DateTime last = month.AddDays(-1);
            Response.Write(first);
            Response.Write(last);

            Table sales = new Table();
            sales.HorizontalAlign = HorizontalAlign.Center;
            TableCell c1 = new TableCell();
            c1.Text = "Product Name";
            c1.HorizontalAlign = HorizontalAlign.Center;
            c1.Font.Bold = true;
            TableCell c2 = new TableCell();
            c2.Text = "Store";
            c2.HorizontalAlign = HorizontalAlign.Center;
            c2.Font.Bold = true;
            TableCell c3 = new TableCell();
            c3.Text = "Counts";
            c3.HorizontalAlign = HorizontalAlign.Center;
            c3.Font.Bold = true;
            TableCell c4 = new TableCell();
            c4.Text = "Amount";
            c4.HorizontalAlign = HorizontalAlign.Center;
            c4.Font.Bold = true;
            TableCell c5 = new TableCell();
            c5.Text = "date";
            c5.HorizontalAlign = HorizontalAlign.Center;
            c5.Font.Bold = true;
            TableRow r1 = new TableRow();
            r1.Controls.Add(c1);
            r1.Controls.Add(c2);
            r1.Controls.Add(c3);
            r1.Controls.Add(c4);
            r1.Controls.Add(c5);
            sales.Controls.Add(r1);
            string check = "select * from accounts where StoreId = '" + location + "' and date between '" + first + "' and '" + last + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();

            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["StoreId"].ToString();
                    string col3 = oReader["counts"].ToString();
                    string col4 = oReader["amount"].ToString();
                    string col5 = oReader["date"].ToString();

                    TableCell c6 = new TableCell();
                    c6.Text = col1;
                    c6.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c7 = new TableCell();
                    c7.Text = col2;
                    c7.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c8 = new TableCell();
                    c8.Text = col3;
                    c8.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c9 = new TableCell();
                    c9.Text = col4;
                    c9.HorizontalAlign = HorizontalAlign.Center;
                    TableCell c10 = new TableCell();
                    c10.Text = col5;
                    c10.HorizontalAlign = HorizontalAlign.Center;
                    TableRow r2 = new TableRow();
                    r2.Controls.Add(c6);
                    r2.Controls.Add(c7);
                    r2.Controls.Add(c8);
                    r2.Controls.Add(c9);
                    r2.Controls.Add(c10);
                    sales.Controls.Add(r2);
                }
                Panel9.Controls.Add(sales);
            }
            else
            {
                Label l1 = new Label();
                l1.Text = "No sales for Last Month..";
                l1.ForeColor = System.Drawing.Color.Red;
                Panel9.Controls.Add(l1);
            }
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = true;
            Panel11.Visible = false;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();

            Table displayProducts = new Table();
            displayProducts.HorizontalAlign = HorizontalAlign.Center;
            TableCell c1 = new TableCell();
            c1.Text = "Employee ID";
            c1.Font.Bold = true;
            TableCell c9 = new TableCell();
            c9.Text = "Salary";
            c9.Font.Bold = true;
            TableRow r1 = new TableRow();
            r1.Controls.Add(c1);
            r1.Controls.Add(c9);
            displayProducts.Controls.Add(r1);

            string check = "select * from Employee where Location = '" + location +"'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            int totalSalary = 0;
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["EmployeeId"].ToString();
                    int col9 = (int)oReader["salary"];
                    //row2
                    TableCell c10 = new TableCell();
                    c10.Text = col1;
                    TableCell c18 = new TableCell();
                    c18.Text = col9.ToString();
                    totalSalary = totalSalary + col9;
                    TableRow r2 = new TableRow();
                    r2.Controls.Add(c10);
                    r2.Controls.Add(c18);
                    
                    displayProducts.Controls.Add(r2);
                }
            }
            
            Label1.Text = "Total Payeroll = $" + totalSalary;
            Label1.Visible = true;
            Panel10.Controls.Add(displayProducts);
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = true;

            productList.Items.Clear();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn.Open();
            string check = "select * from Product where StoreId = '" + location + "'";
            SqlCommand com = new SqlCommand(check, conn);

            SqlDataReader oReader = com.ExecuteReader();
            if (oReader.HasRows)
            {
                while (oReader.Read())
                {
                    string col1 = oReader["ProductId"].ToString();
                    string col2 = oReader["ProductName"].ToString();
                    string col3 = oReader["StoreId"].ToString();
                    string col4 = oReader["Price"].ToString();

                    productList.Items.Add(col2);
                }
            }

        }

        protected void addInventory_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString);
            conn1.Open();
            DateTime DateCurrent = DateTime.UtcNow.Date;
            string checkPhysician = "update Product set counts = " + int.Parse(prodCount.Text) +" where ProductName = '" + productList.Text + "' and StoreId = '" + location + "'";
            SqlCommand com1 = new SqlCommand(checkPhysician, conn1);
            com1.ExecuteNonQuery();

        }
    }
}