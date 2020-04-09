using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace loginpage
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select * from [user] where UserName ='" + TextBox1.Text + "' and Password =='" + TextBox2.Text + "'";

            SqlCommand com = new SqlCommand(query , con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if(temp ==1)
            {
                con.Open();
                string checkpassword = "select Password from [user] where Password =='" + TextBox2.Text + "'";
                SqlCommand Passcom = new SqlCommand(checkpassword, con);
                string password = Passcom.ExecuteScalar().ToString().Replace(" ", "");

                if(password == TextBox2.Text)
                {
                    Session["New"] = TextBox1.Text;
                    Response.Write("Password is correct");

                }
                else
                {
                    Response.Write("Password is not correct");
                }
            }
            else
            {
                Response.Write("UserName is not correct");
            }

        }
    }
}