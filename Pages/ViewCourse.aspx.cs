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
    public partial class ViewCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ViewTable = ViewCourseF();
            ViewCourseData.InnerHtml = ViewTable;
        }
        string ViewCourseF()
        {
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;
            int ConsID = Convert.ToInt32(Session["Consortium_ID"].ToString());

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT COURSE_NAME, CLASSIFICATION FROM CONSORTIUM_COURSE WHERE CONSORTIUM_ID = @ConsID;";
                
            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@ConsID", ConsID);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            string HTMLString = "<table width='100%'  class='table table-striped table - bordered table - hover' id='dataTables - example'>";
            HTMLString += "<thead><tr><th> Name</th><th> Classification</th><th></th></tr></thead><tbody>";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HTMLString += "<tr class='odd gradeX'><td>" + reader["COURSE_NAME"] + "</td><td>" + reader["CLASSIFICATION"] + "</td></tr>";
                    
                }
            }

            HTMLString += "</tbody></table>";

            command.Connection.Close();
            command.Connection.Dispose();

            return HTMLString;
        }
    }
}