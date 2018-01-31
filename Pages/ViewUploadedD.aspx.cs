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
    public partial class ViewUploadedD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ViewTable = ViewDocumentF();
            ViewDocData.InnerHtml = ViewTable;
        }

        string ViewDocumentF()
        {
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;
            int ConsID = Convert.ToInt32(Session["Consortium_ID"].ToString());

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT * FROM LEARNER_PORTFOLIO_DOCS, LEARNER WHERE LEARNER.CONSORTIUM_ID = @ConsID " +
                "AND LEARNER_PORTFOLIO_DOCS.LEARNER_ID = LEARNER.LEARNER_ID;";

            command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@ConsID", ConsID);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            string HTMLString = "<table width='100%'  class='table table-striped table - bordered table - hover' id='dataTables - example'>";
            HTMLString += "<thead><tr><th> Document Name</th><th> Learner name</th><th> SA ID Number</th><th> Date Uploaded</th></tr></thead><tbody>";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HTMLString += "<tr class='odd gradeX'><td>" + reader["DOC_FILE_NAME"] + "</td><td>" + reader["FIRST_NAME"] + " " + reader["SURNAME"] + "</td>";
                    HTMLString += "<td>" + reader["SA_ID_NO"] + "</td><td>" + reader["DATE_UPLOADED"] + "</td></tr>";
                }
            }

            HTMLString += "</tbody></table>";

            command.Connection.Close();
            command.Connection.Dispose();

            return HTMLString;
        }
    }
}