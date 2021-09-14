using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blog
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Response.Write("No File Seleceted"); return;
            }
            else
            {
                string filename = FileUpload1.PostedFile.FileName;

                //convert the image into the byte
                byte[] imageByte = System.IO.File.ReadAllBytes(filename);

                using (SqlConnection connection = new SqlConnection())
                {

                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["blogDbEntities"].ToString();

                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;

                    string commandText = "Insert into Images values (@Rollno,@image,getdate())";
                    cmd.CommandText = commandText;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@image", SqlDbType.VarBinary);
                    cmd.Parameters["@image"].Value = imageByte;
                    cmd.Parameters.Add("@Rollno", SqlDbType.VarChar);
                    cmd.Parameters["@Rollno"].Value = txtrollno.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    Response.Write("Data has been Added");


                }
            }
        }
    }
}