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

namespace Monyetla5Web.Pages
{
    public partial class ConfirmConsortium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand command;
                SqlConnection connection;

                string constr = ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString;
                using (connection = new SqlConnection(constr))
                {
                    using (command = new SqlCommand("SELECT CONSORTIUM_ID, CONSORTIUM_NAME FROM CONSORTIUM_REGISTRATION WHERE APPROVAL_STAT != 1;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpChooseCon.DataSource = command.ExecuteReader();
                        drpChooseCon.DataTextField = "CONSORTIUM_NAME";
                        drpChooseCon.DataValueField = "CONSORTIUM_ID";
                        drpChooseCon.DataBind();
                        connection.Close();
                    }
                   
                }

                drpChooseCon.Items.Insert(0, new ListItem("--Choose Consortium--", "0"));
               
            }
        }

        

        protected void BtnView_Click1(object sender, EventArgs e)
        {
            int Cons_ID = Convert.ToInt32(drpChooseCon.SelectedItem.Value);
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT * FROM CONSORTIUM_REGISTRATION, SITE_CLASS, MAGISTERIAL_DISTRICT, PROVINCE WHERE CONSORTIUM_ID = @Cons_ID" +
                " AND CONSORTIUM_REGISTRATION.SITE_CLASS_ID = SITE_CLASS.SITE_CLASS_ID AND" +
                " CONSORTIUM_REGISTRATION.MAG_DISTRICT_NO = MAGISTERIAL_DISTRICT.MAG_DISTRICT_NO AND" +
                " CONSORTIUM_REGISTRATION.PROVINCE_CODE = PROVINCE.PROVINCE_CODE;";
            
            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@Cons_ID", Cons_ID);

            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtconsName.Text = reader["CONSORTIUM_NAME"].ToString();
                    txtregNo.Text = reader["REG_NUMBER"].ToString();
                    txtphysicalAd1.Text = reader["ADDRESS_LINE_1"].ToString();
                    txtphysicalAd2.Text = reader["ADDRESS_LINE_2"].ToString();
                    txtphysicalAd3.Text = reader["ADDRESS_LINE_3"].ToString();
                    txtpostalCode.Text = reader["POSTAL_CODE"].ToString();
                    txtsiteName.Text = reader["SITE_NAME"].ToString();
                    txtSiteClass.Text = reader["SITE_CLASS_DESC"].ToString();
                    txtProvince.Text = reader["PROVINCE_NAME"].ToString();
                    txtMagDistr.Text = reader["MAG_DISTRICT_NAME"].ToString();
                    txtprojectManFirst.Text = reader["PM_FIRSTNAME"].ToString();
                    txtassist1FirstN.Text = reader["PM_ASSIST1_FIRSTNAME"].ToString();
                    txtassist2FirstN.Text = reader["PM_ASSIST2_FIRSTNAME"].ToString();
                    txtprojectManSurn.Text = reader["PM_SURNAME"].ToString();
                    txtassist1Surn.Text = reader["PM_ASSIST1_SURNAME"].ToString();
                    txtassist2Surn.Text = reader["PM_ASSIST2_SURNAME"].ToString();
                    txtprojectManPhone.Text = reader["PM_PHONE_NO"].ToString();
                    txtassist1PhoneN.Text = reader["PM_ASSIST1_PHONE_NO"].ToString();
                    txtassist2PhoneN.Text = reader["PM_ASSIST2_PHONE_NO"].ToString();
                    txtprojectManCell.Text = reader["PM_CELL_NO"].ToString();
                    txtassist1CellN.Text = reader["PM_ASSIST1_CELL_NO"].ToString();
                    txtassist2CellN.Text = reader["PM_ASSIST2_CELL_NO"].ToString();
                    txtprojectManEmail.Text = reader["PM_EMAIL"].ToString();
                    txtassist1Email.Text = reader["PM_ASSIST1_EMAIL"].ToString();
                    txtassist2Email.Text = reader["PM_ASSIST2_EMAIL"].ToString();
                }
            }
            

            command.Connection.Close();
            command.Connection.Dispose();
        }

        protected void BtnApprove_Click1(object sender, EventArgs e)
        {
            int ConsO_ID = Convert.ToInt32(drpChooseCon.SelectedItem.Value);
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "EXEC spCreateConsortium @Cons_ID;";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@Cons_ID", ConsO_ID);

            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();
            command.Connection.Close();
            command.Connection.Dispose();

            lblApproved.Visible = true;
        }

        protected void BtnReject_Click1(object sender, EventArgs e)
        {
            int ConsO_ID = Convert.ToInt32(drpChooseCon.SelectedItem.Value);
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "EXEC spRejectConsortium @Cons_ID;";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@Cons_ID", ConsO_ID);

            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();
            command.Connection.Close();
            command.Connection.Dispose();

            lblRejected.Visible = true;
        }
    }
}