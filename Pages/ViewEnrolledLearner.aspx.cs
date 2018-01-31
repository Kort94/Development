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
    public partial class ViewEnrolledLearner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ViewTable = ViewELearnerF();
            ViewLearnerData.InnerHtml = ViewTable;
        }

        string ViewELearnerF()
        {
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;
            int ConsID = Convert.ToInt32(Session["Consortium_ID"].ToString());

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT * FROM LEARNER, LEARNER_TRAIN_COURSES, CONSORTIUM_COURSE_SCHEDULE WHERE LEARNER_TRAIN_COURSES.CONSORTIUM_ID = @ConsID" +
                " AND LEARNER.LEARNER_ID = LEARNER_TRAIN_COURSES.LEARNER_ID AND LEARNER_TRAIN_COURSES.COURSE_SCHED_ID = CONSORTIUM_COURSE_SCHEDULE.COURSE_SCHED_ID;";

            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@ConsID", ConsID);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            string HTMLString = "<table width='100%'  class='table table-striped table - bordered table - hover' id='dataTables - example'>";
            HTMLString += "<thead><tr><th> Surname</th><th> First name</th><th> SA ID Number</th><th> Course name</th></tr></thead><tbody>";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HTMLString += "<tr class='odd gradeX'><td>" + reader["SURNAME"] + "</td><td>" + reader["FIRST_NAME"] + "</td>";
                    HTMLString += "<td>" + reader["SA_ID_NO"] + "</td><td>" + reader["COURSE_NAME"] + "</td></tr>";
                }
            }

            HTMLString += "</tbody></table>";

            command.Connection.Close();
            command.Connection.Dispose();

            return HTMLString;
        }
    }
}