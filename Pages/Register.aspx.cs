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
    public partial class Register : System.Web.UI.Page
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
                    using (command = new SqlCommand("SELECT PROVINCE_CODE, PROVINCE_NAME FROM PROVINCE;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        drpProvCode.DataSource = command.ExecuteReader();
                        drpProvCode.DataTextField = "PROVINCE_NAME";
                        drpProvCode.DataValueField = "PROVINCE_CODE";
                        drpProvCode.DataBind();
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
                        drpSiteClass.DataSource = command.ExecuteReader();
                        drpSiteClass.DataTextField = "SITE_CLASS_DESC";
                        drpSiteClass.DataValueField = "SITE_CLASS_ID";
                        drpSiteClass.DataBind();
                        connection.Close();
                    }
                }
                
                drpProvCode.Items.Insert(0, new ListItem("--Select Province--", "0"));
                drpMagDist.Items.Insert(0, new ListItem("--Select Magisterial District--", "0"));
                drpSiteClass.Items.Insert(0, new ListItem("--Select Site Classification--", "0"));
            }

        }

        string Registration(string ConName, string RegNo, string PAddress1, string PAddress2, string PAddress3, int PostalCode,
               string SiteName, string SiteClass, int MDistrict, int ProvinceCode, string PMFirstName, string PMSurName, string PMphone, string PMcell,
               string PMemail, string As1FName, string As1SName, string As1phone, string As1cell, string As1email, string As2FName, string As2SName,
               string As2phone, string As2cell, string As2email, int ApprovalStat)
        {
            string regState = "Registered";
            SqlCommand command;
            SqlConnection connection;

            string commandString;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            commandString = "INSERT into CONSORTIUM_REGISTRATION  (CONSORTIUM_NAME, REG_NUMBER, ADDRESS_LINE_1, ADDRESS_LINE_2, ADDRESS_LINE_3, POSTAL_CODE, SITE_NAME, SITE_CLASS_ID, MAG_DISTRICT_NO, PROVINCE_CODE, PM_FIRSTNAME, PM_SURNAME, PM_PHONE_NO, PM_CELL_NO, PM_EMAIL, PM_ASSIST1_FIRSTNAME, PM_ASSIST1_SURNAME, PM_ASSIST1_PHONE_NO, PM_ASSIST1_CELL_NO, PM_ASSIST1_EMAIL, PM_ASSIST2_FIRSTNAME, PM_ASSIST2_SURNAME, PM_ASSIST2_PHONE_NO, PM_ASSIST2_CELL_NO, PM_ASSIST2_EMAIL, APPROVAL_STAT, DATE_CREATED)" +
            " values(@ConName, @RegNo, @PAddress1, @PAddress2, @PAddress3, @PostalCode, @SiteName, @SiteClass, @MDistrict, @ProvinceCode, @PMFirstName, @PMSurName, @PMphone, @PMCell, @PMemail, @As1FName, @As1SurName, @As1phone, @As1cell, @As1email, @As2FName, @As2SurName, @As2phone, @As2cell, @As2email, @ApprStat, GETDATE()); ";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@ConName", ConName);
            command.Parameters.AddWithValue("@RegNo", RegNo);
            command.Parameters.AddWithValue("@PAddress1", PAddress1);
            command.Parameters.AddWithValue("@PAddress2", PAddress2);
            command.Parameters.AddWithValue("@PAddress3", PAddress3);
            command.Parameters.AddWithValue("@PostalCode", PostalCode);
            command.Parameters.AddWithValue("@SiteName", SiteName);
            command.Parameters.AddWithValue("@SiteClass", SiteClass);
            command.Parameters.AddWithValue("@MDistrict", MDistrict);
            command.Parameters.AddWithValue("@ProvinceCode", ProvinceCode);
            command.Parameters.AddWithValue("@PMFirstName", PMFirstName);
            command.Parameters.AddWithValue("@PMSurName", PMSurName);
            command.Parameters.AddWithValue("@PMphone", PMphone);
            command.Parameters.AddWithValue("@PMCell", PMcell);
            command.Parameters.AddWithValue("@PMemail", PMemail);
            command.Parameters.AddWithValue("@As1FName", As1FName);
            command.Parameters.AddWithValue("@As1SurName", As1SName);
            command.Parameters.AddWithValue("@As1phone", As1phone);
            command.Parameters.AddWithValue("@As1cell", As1cell);
            command.Parameters.AddWithValue("@As1email", As1email);
            command.Parameters.AddWithValue("@As2FName", As2FName);
            command.Parameters.AddWithValue("@As2SurName", As2SName);
            command.Parameters.AddWithValue("@As2phone", As2phone);
            command.Parameters.AddWithValue("@As2cell", As2cell);
            command.Parameters.AddWithValue("@As2email", As2email);
            command.Parameters.AddWithValue("@ApprStat", ApprovalStat);
            
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Connection.Open();
            command.ExecuteNonQuery();

            command.Connection.Close();
            command.Connection.Dispose();

            return regState;
        }


        protected void BtnRegister_Click1(object sender, EventArgs e)
        {
            //Intitialising labels...
                lblConsN.Visible = false;
                lblAddress.Visible = false;
                lblPostalC.Visible = false;
                lblSiteC.Visible = false;
                lblMagNum.Visible = false;
                lblProvinceC.Visible = false;
                lblPMFirstN.Visible = false;
                lblPMSurname.Visible = false;
                lblPMPhoneNum.Visible = false;
                lblPMCellNum.Visible = false;  
                lblPMemail.Visible = false;
                
            if (txtconsName.Text == "")
            {
                lblConsN.Visible = true;
            }
            else if (txtphysicalAd1.Text == "")
            {
                lblAddress.Visible = true;
            }
            else if (txtpostalCode.Text == "")
            {
                lblPostalC.Visible = true;
            }
            else if (drpSiteClass.Text == "0")
            {
                lblSiteC.Visible = true;
            }
            else if (drpMagDist.Text == "0")
            {
                lblMagNum.Visible = true;
            }
            else if (drpProvCode.Text == "0")
            {
                lblProvinceC.Visible = true;
            }
            else if (txtprojectManFirst.Text == "")
            {
                lblPMFirstN.Visible = true;
            }
            else if (txtprojectManSurn.Text == "")
            {
                lblPMSurname.Visible = true;
            }
            else if (txtprojectManPhone.Text == "")
            {
                lblPMPhoneNum.Visible = true;
            }
            else if (txtprojectManCell.Text == "")
            {
                lblPMCellNum.Visible = true;
            }
            else if (txtprojectManEmail.Text == "")
            {
                lblPMemail.Visible = true;
            }
            else
            {
                string ConsName = txtconsName.Text;
                string RegNo = txtregNo.Text;
                string Adr1 = txtphysicalAd1.Text;
                string Adr2 = txtphysicalAd2.Text;
                string Adr3 = txtphysicalAd3.Text;
                int PostalCode = Convert.ToInt32(txtpostalCode.Text);
                string SiteName = txtsiteName.Text;
                string SiteClass = drpSiteClass.SelectedItem.Value;
                int MagisDistr = Convert.ToInt32(drpMagDist.SelectedItem.Value);
                int ProvinceCode = Convert.ToInt32(drpProvCode.SelectedItem.Value);
                string Assis1FirstN = txtassist1FirstN.Text;
                string Assis1Surn = txtassist1Surn.Text;
                string Assis1Phone = txtassist1PhoneN.Text;
                string Assis1Cell = txtassist1CellN.Text;
                string Assis1Email = txtassist1Email.Text;
                string Assis2FirstN = txtassist2FirstN.Text;
                string Assis2Surn = txtassist2Surn.Text;
                string Assis2Phone = txtassist2PhoneN.Text;
                string Assis2Cell = txtassist2CellN.Text;
                string Assis2Email = txtassist2Email.Text;
                string PMFirstN = txtprojectManFirst.Text;
                string PMSurname = txtprojectManSurn.Text;
                string PMphone = txtprojectManPhone.Text;
                string PMcell = txtprojectManCell.Text;
                string PMEmail = txtprojectManEmail.Text;
                int ApprovalStat = 0;
                
                
                

                string register = Registration(ConsName, RegNo, Adr1, Adr2, Adr3, PostalCode, SiteName, SiteClass, MagisDistr, ProvinceCode, PMFirstN, PMSurname, PMphone, PMcell,
                     PMEmail, Assis1FirstN, Assis1Surn, Assis1Phone, Assis1Cell, Assis1Email, Assis2FirstN, Assis2Surn, Assis2Phone, Assis2Cell, Assis2Email, ApprovalStat);

                if (register.Equals("Registered"))
                {

                    lblRegAppr.Visible = true;

                }
            }
        }
    }
}