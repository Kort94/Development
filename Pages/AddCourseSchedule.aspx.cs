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
    public partial class AddCourseSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand command;
                SqlConnection connection;
                int Cons_ID = Convert.ToInt32(Session["Consortium_ID"].ToString());

                string constr = ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString;
                using (connection = new SqlConnection(constr))
                {
                    using (command = new SqlCommand("SELECT CONSORTIUM_SITE_ID, SITE_NAME FROM CONSORTIUM_SITES WHERE CONSORTIUM_ID = @Cons_ID;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@Cons_ID", Cons_ID);
                        command.Connection = connection;
                        connection.Open();
                        drpConsSite.DataSource = command.ExecuteReader();
                        drpConsSite.DataTextField = "SITE_NAME";
                        drpConsSite.DataValueField = "CONSORTIUM_SITE_ID";
                        drpConsSite.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT COURSE_ID, COURSE_NAME FROM CONSORTIUM_COURSE WHERE CONSORTIUM_ID = @Cons_ID;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@Cons_ID", Cons_ID);
                        command.Connection = connection;
                        connection.Open();
                        drpName.DataSource = command.ExecuteReader();
                        drpName.DataTextField = "COURSE_NAME";
                        drpName.DataValueField = "COURSE_ID";
                        drpName.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT SCHED_STAT_ID, SCHED_DESC FROM SCHEDULE_STATUS;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@Cons_ID", Cons_ID);
                        command.Connection = connection;
                        connection.Open();
                        drpShedStat.DataSource = command.ExecuteReader();
                        drpShedStat.DataTextField = "SCHED_DESC";
                        drpShedStat.DataValueField = "SCHED_STAT_ID";
                        drpShedStat.DataBind();
                        connection.Close();
                    }
                }
                
                drpName.Items.Insert(0, new ListItem("--Select Course Name--", "0"));
                drpConsSite.Items.Insert(0, new ListItem("--Select Site--", "0"));
            }
        }
        protected void BtnSchedule_Click(object sender, EventArgs e)
        {
            if (drpName.SelectedItem.Value == "0")
            {
                lblField.Visible = true;
            }
            else if (txtSTD.Text == "")
            {
                lblField.Visible = true;
            }
            else if (drpShedStat.SelectedItem.Value == "0")
            {
                lblField.Visible = true;
            }
            else if (drpConsSite.SelectedItem.Value == "0")
            {
                lblField.Visible = true;
            }
            else if (txtIFN.Text == "")
            {
                lblField.Visible = true;
            }
            else if (txtISN.Text == "")
            {
                lblField.Visible = true;
            }
            else
            {
                int courseID = Convert.ToInt32(drpName.SelectedItem.Value);
                int consID = Convert.ToInt32(Session["Consortium_ID"]);
                string CName = drpName.SelectedItem.Text;
                DateTime StartD = Convert.ToDateTime(txtSTD.Text);
                DateTime EndD = Convert.ToDateTime(txtED.Text);
                int SchedStat = Convert.ToInt32(drpShedStat.SelectedItem.Value);
                int ConSite = Convert.ToInt32(drpConsSite.SelectedItem.Value);
                string InstructFN = txtIFN.Text;
                string InstructSN = txtISN.Text;
                int CourseStat = 0;

                string Sched = Schedule(courseID, consID, CName, CourseStat, StartD, EndD, InstructFN, InstructSN, SchedStat, ConSite);

                if (Sched.Equals("Scheduled"))
                {
                    lblAdState.Visible = true;
                }
            }
        }

        string Schedule(int courseid, int consid, string courseN, int tcourseStat, DateTime startdate, DateTime enddate, string instrFN, string instrSN,
            int schedStatId, int consSiteID)
        {
            string addState = "Scheduled";
            SqlCommand command;
            SqlConnection connection;

            string commandString;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            commandString = "INSERT INTO CONSORTIUM_COURSE_SCHEDULE (COURSE_ID, CONSORTIUM_ID, COURSE_NAME, TRAIN_COURSE_STAT, START_DATE, END_DATE, INSTRUCTER_FIRSTNAME, INSTRUCTER_SURNAME, SCHED_STAT_ID, CONSORTIUM_SITE_ID) " +
                "VALUES (@courseid, @consid, @courseN, @tcourseStat, @startdate, @endDate, @instrFN, @instrSN, @schedStatID, @consSiteID);";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@courseid", courseid);
            command.Parameters.AddWithValue("@consid", consid);
            command.Parameters.AddWithValue("@courseN", courseN);
            command.Parameters.AddWithValue("@tcourseStat", tcourseStat);
            command.Parameters.AddWithValue("@startdate", startdate);
            command.Parameters.AddWithValue("@endDate", enddate);
            command.Parameters.AddWithValue("@instrFN", instrFN);
            command.Parameters.AddWithValue("@instrSN", instrSN);
            command.Parameters.AddWithValue("@schedStatID", schedStatId);
            command.Parameters.AddWithValue("@consSiteID", consSiteID);
            
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();

            return addState;
        }
    }
}