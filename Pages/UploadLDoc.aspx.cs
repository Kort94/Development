using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web.Security;
using System.IO;
using System.Diagnostics;

namespace Monyetla5Web.Pages
{
    public partial class UploadLDoc : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Assigning sessions to variables...
            txtIDnum.Text = Session["ID_No"].ToString();
            txtFN.Text = Session["LName"].ToString();
            txtSN.Text = Session["Surname"].ToString();

            
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            //Initialising labels
            lblNFile.Visible = false;
            lblUpState.Visible = false;

            //Uploading file to the server
            if (FileUploadControl.HasFile)
            {
                string filname = Path.GetFileName(FileUploadControl.FileName);
                string SaveLocation = Path.Combine(@"C:\Users\kzs0305\Documents\Katleho\Projects\New Exciting Project\Monyetla\Files", filname);

                try
                {       
                    FileUploadControl.SaveAs(SaveLocation);
                    lblUpState.Visible = true;
                }
                catch (Exception ex)
                {
                    lblEx.Text = "File could not be uploaded. The following error occured: " + ex.Message;
                }

                //FileInfo fileToDownload = new FileInfo(filname);

                //if (fileToDownload.Exists)
                //{
                //    Process.Start(fileToDownload.FullName);
                //}
                //else
                //{
                //    lblNFile.Visible = true;
                //}

            }
            else
            {
                lblNFile.Visible = true;
            }

            //Initialising variables
            DateTime UploadD = DateTime.Now;
            int UploadStat = 1;
            int Con_ID = Convert.ToInt32(Session["Consortium_ID"]);
            string Location = @"C:\Users\kzs0305\Documents\Katleho\Projects\New Exciting Project\Monyetla\Files";
            string fileName = "";
            int L_ID = Convert.ToInt32(Session["LnrID"]);

            //Calling the upload function
            string UpSatus = UploadF(Con_ID, L_ID, UploadD, UploadStat, Location, fileName);



        }
        //Upload function
        string UploadF(int ConsID, int LearnerID, DateTime DateUpload, int UpStat, string DocFileP, string DocFileN)
        {
            string addState = "Uploaded";
            SqlCommand command;
            SqlConnection connection;

            string commandString;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonyetlaCon"].ConnectionString);
            commandString = "INSERT INTO LEARNER_PORTFOLIO_DOCS (PORTFOLIO_ID, PORTFOLIO_DOC_ID, CONSORTIUM_ID, LEARNER_ID, DATE_UPLOADED," +
                " UPLOAD_STATUS, DOC_FILE_PATH, DOC_FILE_NAME) VALUES (0, 0, @Consid, @learnerid, @dateup, @upstatus, @docfilep, @docfilen);";

            command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@Consid", ConsID);
            command.Parameters.AddWithValue("@learnerid", LearnerID);
            command.Parameters.AddWithValue("@dateup", DateUpload);
            command.Parameters.AddWithValue("@upstatus", UpStat);
            command.Parameters.AddWithValue("@docfilep", DocFileP);
            command.Parameters.AddWithValue("@docfilen", DocFileN);
         
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();

            return addState;
        }
    }
}