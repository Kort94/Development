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
    public partial class adViewLearner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ViewTable = ViewadLearnerF();
            ViewData.InnerHtml = ViewTable;
        }
        string ViewadLearnerF()
        {
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT SURNAME, FIRST_NAME, SA_ID_NO, CONSORTIUM_NAME FROM LEARNER, CONSORTIUM WHERE LEARNER.CONSORTIUM_ID = CONSORTIUM.CONSORTIUM_ID;";


            command = new SqlCommand(commandString);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            string HTMLString = "<table width='100%'  class='table table-striped table - bordered table - hover' id='dataTables - example'>";
            HTMLString += "<thead><tr><th> Surname</th><th> First name</th><th> SA ID Number</th><th> Consortium name</th></tr></thead><tbody>";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HTMLString += "<tr class='odd gradeX'><td>" + reader["SURNAME"] + "</td><td>" + reader["FIRST_NAME"] + "</td>";
                    HTMLString += "<td>" + reader["SA_ID_NO"] + "</td><td>" + reader["CONSORTIUM_NAME"] + "</td></tr>";
                }
            }

            HTMLString += "</tbody></table>";

            command.Connection.Close();
            command.Connection.Dispose();

            return HTMLString;
        }
    }
}