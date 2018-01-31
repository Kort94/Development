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
    public partial class AddLearner : System.Web.UI.Page
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
                    using (command = new SqlCommand("SELECT LANG_ID, LANG_DESC FROM LANGUAGE;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpHmeLang.DataSource = command.ExecuteReader();
                        drpHmeLang.DataTextField = "LANG_DESC";
                        drpHmeLang.DataValueField = "LANG_ID";
                        drpHmeLang.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT DISABILITY_STAT_ID, DISABILITY_DESC FROM DISABILITY_STATUS;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpDisSt.DataSource = command.ExecuteReader();
                        drpDisSt.DataTextField = "DISABILITY_DESC";
                        drpDisSt.DataValueField = "DISABILITY_STAT_ID";
                        drpDisSt.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT PROVINCE_CODE, PROVINCE_NAME FROM PROVINCE;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpProv.DataSource = command.ExecuteReader();
                        drpProv.DataTextField = "PROVINCE_NAME";
                        drpProv.DataValueField = "PROVINCE_CODE";
                        drpProv.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT MAG_DISTRICT_NO, MAG_DISTRICT_NAME FROM MAGISTERIAL_DISTRICT;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpMagDist.DataSource = command.ExecuteReader();
                        drpMagDist.DataTextField = "MAG_DISTRICT_NAME";
                        drpMagDist.DataValueField = "MAG_DISTRICT_NO";
                        drpMagDist.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT SITE_CLASS_ID, SITE_CLASS_DESC FROM SITE_CLASS;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpAdClass.DataSource = command.ExecuteReader();
                        drpAdClass.DataTextField = "SITE_CLASS_DESC";
                        drpAdClass.DataValueField = "SITE_CLASS_ID";
                        drpAdClass.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT QUAL_ID, QUAL_NAME FROM QUALIFICATION;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpHighQual.DataSource = command.ExecuteReader();
                        drpHighQual.DataTextField = "QUAL_NAME";
                        drpHighQual.DataValueField = "QUAL_ID";
                        drpHighQual.DataBind();
                        connection.Close();
                    }
                }
                drpHmeLang.Items.Insert(0, new ListItem("--Select Language--", "0"));
                drpDisSt.Items.Insert(0, new ListItem("--Select Status--", "0"));
                drpProv.Items.Insert(0, new ListItem("--Select Province--", "0"));
                drpMagDist.Items.Insert(0, new ListItem("--Select Magisterial District--", "0"));
                drpAdClass.Items.Insert(0, new ListItem("--Select Site Classification--", "0"));
                drpHighQual.Items.Insert(0, new ListItem("--Select Highest Obtained Qualification--", "0"));
            }
        }

        string AddLearnerF(string surname, string firstname, string id_no, DateTime dateOfBirth, string gender, string popgroup, int disability_id, int lang_id,
            string PhoneN, string Email, int address_id, int qual_id, int qual_year, int consort_id, string activeIND)
        {
            string addState = "Added";
            SqlCommand command;
            SqlConnection connection;

            string commandString;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            commandString = "INSERT INTO LEARNER (SURNAME, FIRST_NAME, SA_ID_NO, DATE_OF_BRITH, GENDER, POP_GROUP, DISABILITY_STAT_ID, LANG_ID," +
            " PHONE_NO, EMAIL_ADDRESS, ADDRESS_ID, QUAL_ID, QUAL_YEAR, CONSORTIUM_ID, ACTIVE_IND) VALUES(@surname, @firstname, @ID_no, @DateOfBirth, @gender, @popGroup, @disabilityID," +
            " @lang_id, @PHONEno, @Email, @address_id, @qual_id, @qual_year, @consort_id, @activeIND)";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.AddWithValue("@ID_no", id_no);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@popGroup", popgroup);
            command.Parameters.AddWithValue("@disabilityID", disability_id);
            command.Parameters.AddWithValue("@lang_id", lang_id);
            command.Parameters.AddWithValue("@address_id", address_id);
            command.Parameters.AddWithValue("@qual_id", qual_id);
            command.Parameters.AddWithValue("@qual_year", qual_year);
            command.Parameters.AddWithValue("@consort_id", consort_id);
            command.Parameters.AddWithValue("@activeIND", activeIND);
            command.Parameters.AddWithValue("@PHONEno", PhoneN);
            command.Parameters.AddWithValue("@Email", Email);


            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();

            return addState;
        }

        int AddAddress(string ad1, string ad2, string ad3, string postalCode, int provinceCode, int magNo)
        {
            int ad_id = 0;
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            string commandString;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            commandString = "INSERT INTO ADDRESS (ADDRESS_LINE_1, ADDRESS_LINE_2, ADDRESS_LINE_3, POSTAL_CODE, PROVINCE_CODE," +
                " MAG_DISTRICT_NO) VALUES (@AD1, @AD2, @AD3, @PostalC, @ProvinceC, @MagDNo);" +
                " SELECT ADDRESS_ID from ADDRESS WHERE ADDRESS_LINE_1 = @AD1 AND ADDRESS_LINE_2 = @AD2 AND ADDRESS_LINE_3 = @AD3" +
                " AND POSTAL_CODE = @PostalC AND PROVINCE_CODE = @ProvinceC AND MAG_DISTRICT_NO = @MagDNo;";


            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@AD1", ad1);
            command.Parameters.AddWithValue("@AD2", ad2);
            command.Parameters.AddWithValue("@AD3", ad3);
            command.Parameters.AddWithValue("@PostalC", postalCode);
            command.Parameters.AddWithValue("@ProvinceC", provinceCode);
            command.Parameters.AddWithValue("@MagDNo", magNo);

            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   ad_id = Convert.ToInt32(reader["ADDRESS_ID"].ToString());
                }
            }

            command.Connection.Close();
            command.Connection.Dispose();

            return ad_id;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string _ID = txtIDnum.Text;
            string _DOB = Convert.ToDateTime(txtDOB.Text).ToString("yyMMdd");

            if (txtIDnum.Text == "")
            {
                lblField.Visible = true;
            }
            else if (txtIDnum.Text.Length > 13)
            {
                lblID.Visible = true;
            }
            else if (txtIDnum.Text.Length < 13)
            {
                lblID.Visible = true;
            }
            //Validating ID number against Date of birth
            //else if (_DOB = DateTime.ParseExact(_ID.Substring(0, 6), "yyMMdd");
            //{

            //}
            else if (txtFN.Text == "")
            {
                lblField.Visible = true;
            }
            else if (txtSN.Text == "")
            {
                lblField.Visible = true;
            }
            else if (txtDOB.Text == "")
            {
                lblField.Visible = true;
            }
            else if (drpMagDist.Text == "0")
            {
                lblField.Visible = true;
            }
            else if (drpGender.Text == "0")
            {
                lblField.Visible = true;
            }
            else if (drpPopG.Text == "0")
            {
                lblField.Visible = true;
            }
            else if (drpDisSt.Text == "0")
            {
                lblField.Visible = true;
            }
            else if (drpHmeLang.Text == "0")
            {
                lblField.Visible = true;
            }
            else if (txtPhysAd1.Text == "")
            {
                lblField.Visible = true;
            }
            else if (txtPostalC.Text == "")
            {
                lblField.Visible = true;
            }
            else if (drpProv.Text == "0")
            {
                lblField.Visible = true;
            }  
            else if (drpAdClass.Text == "0")
            {
                lblField.Visible = true;
            }
            else if (txtYearObt.Text == "")
            {
                lblField.Visible = true;
            }
            else
            {
                string ID = txtIDnum.Text;
                string FN = txtFN.Text;
                string SN = txtSN.Text;
                DateTime DOB = Convert.ToDateTime(txtDOB.Text);
                string Gender = drpGender.SelectedItem.Value;
                string PopG = drpPopG.SelectedItem.Value;
                int DisStat = Convert.ToInt32(drpDisSt.SelectedItem.Value);
                int HomeLang = Convert.ToInt32(drpHmeLang.SelectedItem.Value);
                string AD1 = txtPhysAd1.Text;
                string AD2 = txtPhysAd2.Text;
                string AD3 = txtPhysAd3.Text;
                string PostalC = txtPostalC.Text;
                int Province = Convert.ToInt32(drpProv.SelectedItem.Value);
                int Mag_Dist = Convert.ToInt32(drpMagDist.SelectedItem.Value);
                //int AddressClass = Convert.ToInt32(drpAdClass.SelectedItem.Value);
                int HighQual = Convert.ToInt32(drpHighQual.SelectedItem.Value);
                int YearObt = Convert.ToInt32(txtYearObt.Text);
                int ConsortiumID = Convert.ToInt32(Session["Consortium_ID"]);
                string ActiveIND = "Y";
                string Phone = txtPhone.Text;
                string Email = txtEmail.Text;

               
                //Inserting the Address and Getting the Address ID from the Function
                int AddressID = AddAddress(AD1, AD2, AD3, PostalC, Province, Mag_Dist);

                //Inserting the learner details and returning the add status
                string AddStatus = AddLearnerF(SN, FN, ID, DOB, Gender, PopG, DisStat, HomeLang, Phone, Email, AddressID, HighQual, YearObt, ConsortiumID, ActiveIND);

                if (AddStatus.Equals("Added"))
                {
                    lblAdState.Visible = true;
                }
            }
        }
    }
}