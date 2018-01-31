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
    public partial class EnrollLearner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand command;
                SqlConnection connection;
                int Cons_ID = Convert.ToInt32(Session["Consortium_ID"].ToString());
                //int Cos_ID = Convert.ToInt32(drpName.SelectedItem.Value);

                string constr = ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString;
                using (connection = new SqlConnection(constr))
                {
                    using (command = new SqlCommand("SELECT START_DATE, COURSE_ID FROM CONSORTIUM_COURSE_SCHEDULE WHERE CONSORTIUM_ID = @Cons_ID;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@Cons_ID", Cons_ID);
                        command.Connection = connection;
                        connection.Open();
                        drpStartD.DataSource = command.ExecuteReader();
                        drpStartD.DataTextField = "START_DATE";
                        drpStartD.DataValueField = "COURSE_ID";
                        drpStartD.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT COURSE_ID, COURSE_NAME FROM CONSORTIUM_COURSE_SCHEDULE WHERE CONSORTIUM_ID = @Cons_ID;"))
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
                    using (command = new SqlCommand("SELECT COMP_STAT_ID, COMP_STAT_DESC FROM COMPLETION_STATUS;"))
                    {
                        command.CommandType = CommandType.Text;
                        
                        command.Connection = connection;
                        connection.Open();
                        drpCourseStat.DataSource = command.ExecuteReader();
                        drpCourseStat.DataTextField = "COMP_STAT_DESC";
                        drpCourseStat.DataValueField = "COMP_STAT_ID";
                        drpCourseStat.DataBind();
                        connection.Close();
                    }
                    using (command = new SqlCommand("SELECT LEARNER_ID, SA_ID_NO FROM LEARNER WHERE CONSORTIUM_ID = @Cons_ID;"))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@Cons_ID", Cons_ID);
                        command.Connection = connection;
                        connection.Open();
                        drpSAID.DataSource = command.ExecuteReader();
                        drpSAID.DataTextField = "SA_ID_NO";
                        drpSAID.DataValueField = "LEARNER_ID";
                        drpSAID.DataBind();
                        connection.Close();
                    }
                }
                drpCourseStat.Items.Insert(0, new ListItem("--Select Status--", "0"));
                drpName.Items.Insert(0, new ListItem("--Select Course Name--", "0"));
                drpStartD.Items.Insert(0, new ListItem("--Select Start Date--", "0"));
                drpSAID.Items.Insert(0, new ListItem("--Select ID Number--", "0"));
            }
        }

        protected void BtnEnroll_Click(object sender, EventArgs e)
        {
            if (drpName.SelectedItem.Value == "0")
            {
                lblField.Visible = true;
            }
            else if (drpStartD.SelectedItem.Value == "0")
            {
                lblField.Visible = true;
            }
            else if (drpCourseStat.SelectedItem.Value == "0")
            {
                lblField.Visible = true;
            }
            else if (drpSAID.SelectedItem.Value == "0")
            {
                lblField.Visible = true;
            }
            
            else
            {
                int courseShedID = Convert.ToInt32(drpStartD.SelectedItem.Value);
                int learnerID = Convert.ToInt32(drpSAID.SelectedItem.Value);
                int compStaID = Convert.ToInt32(drpCourseStat.SelectedItem.Value);
                string StatReason = Request.Form["txtReason"];
                int courseID = Convert.ToInt32(drpName.SelectedItem.Value);
                int conID = Convert.ToInt32(Session["Consortium_ID"]);
                

                string EnrollStat = EnrollF(courseShedID, courseID, learnerID, conID, compStaID, StatReason);

                if (EnrollStat.Equals("Enrolled"))
                {
                    lblAdState.Visible = true;
                }
            }
        }

        string EnrollF(int courseSchedId, int course_id, int learnerid, int consID, int compStat, string statReason)
        {
            string addState = "Enrolled";
            SqlCommand command;
            SqlConnection connection;

            string commandString;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            commandString = "INSERT INTO LEARNER_TRAIN_COURSES (COURSE_SCHED_ID, COURSE_ID, LEARNER_ID, CONSORTIUM_ID, COMP_STAT_ID, STATUS_REASON) " +
                "VALUES (@courseSchedId, @courseid, @learnerid, @consID, @compStat, @statReason)";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@courseSchedId", courseSchedId);
            command.Parameters.AddWithValue("@courseid", course_id);
            command.Parameters.AddWithValue("@learnerid", learnerid);
            command.Parameters.AddWithValue("@consID", consID);
            command.Parameters.AddWithValue("@compStat", compStat);
            command.Parameters.AddWithValue("@statReason", statReason);


            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();

            return addState;
        }
    }
}