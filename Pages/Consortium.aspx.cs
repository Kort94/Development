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
    public partial class Consortium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ViewTable = ViewScheduledCourse();
            ViewScheduledCourseData.InnerHtml = ViewTable;
        }
        string ViewScheduledCourse()
        {
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;
            int Cons_ID = Convert.ToInt32(Session["Consortium_ID"]);

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT * FROM CONSORTIUM_COURSE_SCHEDULE, SCHEDULE_STATUS WHERE CONSORTIUM_ID = @Cons_id AND CONSORTIUM_COURSE_SCHEDULE.SCHED_STAT_ID = SCHEDULE_STATUS.SCHED_STAT_ID;";


            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@Cons_id", Cons_ID);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            string HTMLString = "<table width='100%'  class='table table-striped table - bordered table - hover' id='dataTables - example'>";
            HTMLString += "<thead><tr><th> Name</th><th> Start Date</th><th> End Date</th><th> Instructor</th><th> Course Status</th></tr></thead><tbody>";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HTMLString += "<tr class='odd gradeX'><td>" + reader["COURSE_NAME"] + "</td><td>" + Convert.ToDateTime(reader["START_DATE"]).ToString("yyyy/MM/dd") + "</td>";
                    HTMLString += "<td>" + Convert.ToDateTime(reader["END_DATE"]).ToString("yyyy/MM/dd") + "</td><td>" + reader["INSTRUCTER_SURNAME"] + " " + reader["INSTRUCTER_FIRSTNAME"] + "</td>";
                    HTMLString += "<td>" + reader["SCHED_DESC"] + "</td></tr>";
                }
            }

            HTMLString += "</tbody></table>";

            command.Connection.Close();
            command.Connection.Dispose();

            return HTMLString;
        }
    }
}