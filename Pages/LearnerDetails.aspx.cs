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
    public partial class LearnerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand command;
                SqlConnection connection;
                int ConsID = Convert.ToInt32(Session["Consortium_ID"].ToString());

                string constr = ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString;
                using (connection = new SqlConnection(constr))
                {
                    using (command = new SqlCommand("SELECT LEARNER_ID, SA_ID_NO FROM LEARNER WHERE CONSORTIUM_ID = " + ConsID + ";"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpIDnum.DataSource = command.ExecuteReader();
                        drpIDnum.DataTextField = "SA_ID_NO";
                        drpIDnum.DataValueField = "LEARNER_ID";
                        drpIDnum.DataBind();
                        connection.Close();
                    }

                }

                drpIDnum.Items.Insert(0, new ListItem("--Choose Learner's ID--", "0"));

            }
        }

        protected void BtnView_Click1(object sender, EventArgs e)
        {
            int LearnerID = Convert.ToInt32(drpIDnum.SelectedItem.Value);
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT * FROM LEARNER, LANGUAGE, DISABILITY_STATUS, QUALIFICATION, ADDRESS, PROVINCE, MAGISTERIAL_DISTRICT WHERE LEARNER_ID = @LearnerID" +
                " AND LEARNER.DISABILITY_STAT_ID = DISABILITY_STATUS.DISABILITY_STAT_ID AND LEARNER.LANG_ID = LANGUAGE.LANG_ID" +
                " AND LEARNER.QUAL_ID = QUALIFICATION.QUAL_ID AND LEARNER.ADDRESS_ID = ADDRESS.ADDRESS_ID" +
                " AND ADDRESS.PROVINCE_CODE = PROVINCE.PROVINCE_CODE AND ADDRESS.MAG_DISTRICT_NO = MAGISTERIAL_DISTRICT.MAG_DISTRICT_NO;";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@LearnerID", LearnerID);

            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtFN.Text = reader["FIRST_NAME"].ToString();
                    txtSN.Text = reader["SURNAME"].ToString();
                    txtDOB.Text = Convert.ToDateTime(reader["DATE_OF_BRITH"]).ToString("yyyy/MM/dd");
                    txtGender.Text = reader["GENDER"].ToString();
                    txtPopG.Text = reader["POP_GROUP"].ToString();
                    txtDisStat.Text = reader["DISABILITY_DESC"].ToString();
                    txtHmeLang.Text = reader["LANG_DESC"].ToString();
                    txtPhone.Text = reader["PHONE_NO"].ToString();
                    txtEmail.Text = reader["EMAIL_ADDRESS"].ToString();
                    txtPhysAd1.Text = reader["ADDRESS_LINE_1"].ToString();
                    txtPhysAd2.Text = reader["ADDRESS_LINE_2"].ToString();
                    txtPhysAd3.Text = reader["ADDRESS_LINE_3"].ToString();
                    txtPostalC.Text = reader["POSTAL_CODE"].ToString();
                    txtProv.Text = reader["PROVINCE_NAME"].ToString();
                    txtMagDist.Text = reader["MAG_DISTRICT_NAME"].ToString();
                    //txtAddClass.Text = reader[""].ToString();
                    txtHQual.Text = reader["QUAL_NAME"].ToString();
                    txtYearObt.Text = reader["QUAL_YEAR"].ToString();
                }
            }

            command.Connection.Close();
            command.Connection.Dispose();
        }

        protected void BtnUploadDoc_Click(object sender, EventArgs e)
        {
            Session["ID_No"] = drpIDnum.SelectedItem.Text;
            Session["LnrID"] = drpIDnum.SelectedItem.Value;
            Session["LName"] = txtFN.Text;
            Session["Surname"] = txtSN.Text;
            Response.Redirect("UploadLDoc.aspx");
        }
    }
}