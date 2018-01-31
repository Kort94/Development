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
    public partial class AddCourse : System.Web.UI.Page
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
                    using (command = new SqlCommand("SELECT COURSE_STATUS_DESC, COURSE_STATUS_ID FROM COURSE_STATUS;"))
                    {
                        command.CommandType = CommandType.Text;

                        command.Connection = connection;
                        connection.Open();
                        drpCourseStat.DataSource = command.ExecuteReader();
                        drpCourseStat.DataTextField = "COURSE_STATUS_DESC";
                        drpCourseStat.DataValueField = "COURSE_STATUS_ID";
                        drpCourseStat.DataBind();
                        connection.Close();
                    }
                }
            }
        }
            string AddCourseF(int ConsID, string CourseName, string Classification, string TrainProgName, int TrainCStat)
            {
                string addState = "Added";
                SqlCommand command;
                SqlConnection connection;

                string commandString;
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
                commandString = "INSERT INTO CONSORTIUM_COURSE (CONSORTIUM_ID, COURSE_NAME, CLASSIFICATION, TRAIN_PROG_NAME, COURSE_STATUS_ID)" +
                    " VALUES (@ConsID, @CourseN, @Class, @TrainPN, @TrainCS);";

                command = new SqlCommand(commandString);

                command.Parameters.AddWithValue("@ConsID", ConsID);
                command.Parameters.AddWithValue("@CourseN", CourseName);
                command.Parameters.AddWithValue("@Class", Classification);
                command.Parameters.AddWithValue("@TrainPN", TrainProgName);
                command.Parameters.AddWithValue("@TrainCS", TrainCStat);


                command.Connection = connection;
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                return addState;
            }
        
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtCN.Text == "") 
            {
                lblField.Visible = true;
            }
            else
            {
                int ConsID = Convert.ToInt32(Session["Consortium_ID"].ToString());
                string CourseN = txtCN.Text;
                string Class = txtClass.Text;
                string TrainPN = txtTP.Text;
                int TrainCS = Convert.ToInt32(drpCourseStat.SelectedItem.Value);

                string State = AddCourseF(ConsID, CourseN, Class, TrainPN, TrainCS);

                if (State.Equals("Added"))
                {
                    lblAdState.Visible = true;
                }
            }
        }
    }
}