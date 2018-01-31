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

namespace Monyetla5Web.Pages.Sub_Pages
{
    public partial class NewConsortium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ViewTable = ViewNewConsortium();
            ViewNewConsortiumData.InnerHtml = ViewTable;
        }
        string ViewNewConsortium()
        {
            SqlCommand command;
            SqlConnection connection;
            SqlDataReader reader;

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);

            string commandString = "SELECT CONSORTIUM_NAME, REG_NUMBER, DATE_CREATED, FINAL_CONFIRM_DATE, CASE CONSORTIUM_REGISTRATION.APPROVAL_STAT WHEN 1 THEN 'Approved' WHEN 2 THEN 'Declined' ELSE '' END AS STATUS FROM CONSORTIUM_REGISTRATION WHERE APPROVAL_STAT != 1;";
               ;

            command = new SqlCommand(commandString);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;

            reader = command.ExecuteReader();

            string HTMLString = "<table width='100%'  class='table table-striped table - bordered table - hover' id='dataTables - example'>";
            HTMLString += "<thead><tr><th> Consortium Name </th><th> Registration Number</th><th> Date Registered</th><th> Date Finalised</th><th> Approval Status</th></tr></thead><tbody>";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HTMLString += "<tr class='odd gradeX'><td>" + reader["CONSORTIUM_NAME"] + "</td><td>" + reader["REG_NUMBER"] + "</td>";
                    HTMLString += "<td>" + reader["DATE_CREATED"] + "</td><td>" + reader["FINAL_CONFIRM_DATE"] + "</th><td>" + reader["STATUS"] + "</td></tr>";
                }
            }

            HTMLString += "</tbody></table>";

            command.Connection.Close();
            command.Connection.Dispose();

            return HTMLString;
        }

    }
}