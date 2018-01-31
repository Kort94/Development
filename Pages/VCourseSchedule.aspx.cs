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
    public partial class VCourseSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ViewTable = ViewCScheduleF();
            ViewData.InnerHtml = ViewTable;
        }
        string ViewCScheduleF()
        {
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT * FROM CONSORTIUM_COURSE, CONSORTIUM_COURSE_SCHEDULE, CONSORTIUM, SCHEDULE_STATUS WHERE " +
                "CONSORTIUM_COURSE.COURSE_ID = CONSORTIUM_COURSE_SCHEDULE.COURSE_ID AND CONSORTIUM_COURSE_SCHEDULE.COURSE_ID IS NULL AND " +
                "CONSORTIUM.CONSORTIUM_ID = CONSORTIUM_COURSE.CONSORTIUM_ID AND CONSORTIUM_COURSE_SCHEDULE.SCHED_STAT_ID = SCHEDULE_STATUS.SCHED_STAT_ID;";


            command = new SqlCommand(commandString);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            string HTMLString = "<table width='100%'  class='table table-striped table - bordered table - hover' id='dataTables - example'>";
            HTMLString += "<thead><tr><th> Course name</th><th> Consortium name</th><th> Start date</th><th> End date</th><th> Schedule Status</th></tr></thead><tbody>";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HTMLString += "<tr class='odd gradeX'><td>" + reader["CONSORTIUM_COURSE.COURSE_NAME"] + "</td><td>" + reader["CONSORTIUM_NAME"] + "</td>";
                    HTMLString += "<td>" + Convert.ToDateTime(reader["START_DATE"]).ToString("yyyy/MM/dd") + "</td><td>" + Convert.ToDateTime(reader["END_DATE"]).ToString("yyyy/MM/dd") + "</td><td>" + reader["SCHED_DESC"] + "</td></tr>";
                }
            }

            HTMLString += "</tbody></table>";

            command.Connection.Close();
            command.Connection.Dispose();

            return HTMLString;
        }
    }
}