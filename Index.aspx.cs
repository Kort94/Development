using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web.Security;

namespace Monyetla5Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["EMAIL_ADDRESS"] = null;
            Session["Level"] = null;
            Session["Password"] = null;
            Session["userID"] = null;
            Session["Consortium_ID"] = null;
        }

        SqlCommand command;
        SqlConnection connection;
        SqlDataReader reader;
        bool state;
        int auth = 0;
        int Cons_ID = 0;
        string User_ID = null;

        public string Login(string email, string pass)
        {
            
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            string commandString = "SELECT * FROM SYSTEM_USERS WHERE EMAIL_ADDRESS = @Email AND PASSWORD = @Password";
            
            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", pass);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    if (email == reader["EMAIL_ADDRESS"].ToString() && pass == reader["PASSWORD"].ToString())
                    {
                        state = true;
                        User_ID = reader["USER_ID"].ToString();

                    }

                }

            }
            connection.Close();
            connection.Dispose();
            command.Connection.Close();
            command.Connection.Dispose();

            return User_ID;
        }

        public int Authentication(string email, string pass)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            string commandString = "SELECT * FROM SYSTEM_USERS WHERE EMAIL_ADDRESS = @Email AND PASSWORD = @Password";
            
            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", pass);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    if (email == reader["EMAIL_ADDRESS"].ToString() && pass == reader["PASSWORD"].ToString())
                    {
                        state = true;
                        auth = Convert.ToInt16(reader["USER_STAT"].ToString());
                    }
                    else if (email != reader["EMAIL_ADDRESS"].ToString() && pass != reader["PASSWORD"].ToString())
                    {
                        state = false;
                    }
                }
                
            }
            connection.Close();
            connection.Dispose();
            command.Connection.Close();
            command.Connection.Dispose();

            return auth;
        }

        public int GetConsortiumID(string email, string pass)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            string commandString = "SELECT * FROM SYSTEM_USERS WHERE EMAIL_ADDRESS = @Email AND PASSWORD = @Password";

            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", pass);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    if (email == reader["EMAIL_ADDRESS"].ToString() && pass == reader["PASSWORD"].ToString())
                    {
                        state = true;
                        Cons_ID = Convert.ToInt16(reader["CONSORTIUM_ID"].ToString());
                    }
                    else if (email != reader["EMAIL_ADDRESS"].ToString() && pass != reader["PASSWORD"].ToString())
                    {
                        state = false;
                    }
                }

            }
            connection.Close();
            connection.Dispose();
            command.Connection.Close();
            command.Connection.Dispose();

            return Cons_ID;
        }

        public string GeConsName(int ConsID)
        {
            string ConsN = "";
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            string commandString = "SELECT CONSORTIUM_NAME FROM CONSORTIUM WHERE CONSORTIUM_ID = @CONS_ID";

            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@CONS_ID", ConsID);
            
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ConsN = reader["CONSORTIUM_NAME"].ToString();
                }

            }
            connection.Close();
            connection.Dispose();
            command.Connection.Close();
            command.Connection.Dispose();

            return ConsN;
        }

        public string GetConsReg(int ConsID)
        {
            string RegNo = "";
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            string commandString = "SELECT REGISTRATION_NO FROM CONSORTIUM WHERE CONSORTIUM_ID = @CONS_ID";

            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@CONS_ID", ConsID);

            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    RegNo = reader["REGISTRATION_NO"].ToString();
                }

            }
            connection.Close();
            connection.Dispose();
            command.Connection.Close();
            command.Connection.Dispose();

            return RegNo;
        }

        protected void BtnLogOn_Click1(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                lblemail.Visible = true;
            }
            else if (txtPassword.Text == "")
            {
                lblpass.Visible = true;
            }
            else
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                
                string userID = Login(email, password);
 
                if (User_ID != null)
                {
                    int _Authen = Authentication(email, password);
                    int _ConsID = GetConsortiumID(email, password);
                    string _ConsN = GeConsName(_ConsID);
                    string _RegNo = GetConsReg(_ConsID);

                    //Declaring sessions...
                    Session["EMAIL_ADDRESS"] = email;
                    Session["Level"] = _Authen;
                    Session["Password"] = password;
                    Session["userID"] = userID;
                    Session["Consortium_ID"] = _ConsID;
                    Session["Consortium_Name"] = _ConsN;
                    Session["Consortium_Reg"] = _RegNo;

                    if (_ConsID.Equals(0))
                    {
                        Response.Redirect("Pages/Admin.aspx");

                    }
                    else
                    {
                        Response.Redirect("Pages/Consortium.aspx");

                    }

                }
                else
                {
                    lblwrong.Visible = true;
                }
            }
        }

    }
}