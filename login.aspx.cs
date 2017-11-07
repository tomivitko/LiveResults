using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.Data.OleDb;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonPrijava_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        using (MySqlConnection cn = new MySqlConnection(connectionString))
        {
            try
            {
                cn.Open();
                MySqlCommand command = new MySqlCommand(null, cn);

                command.CommandText = @"select first_name from live_results_db.admins where username=@uname and password=@pass; ";
                command.Parameters.AddWithValue("@uname", this.TextBoxUsername.Text);
                command.Parameters.AddWithValue("@pass", ConvertStringtoMD5(this.TextBoxPassword.Text));
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Session["loggedin"] = "ok";
                    Response.Redirect("~/edit_event.aspx");
                }
                else
                {
                    this.TextBoxUsername.Text = string.Empty;
                    this.TextBoxPassword.Text = string.Empty;
                    this.Label1.Text = "NEISPRAVNI PODATCI";
                }

                
            }
            catch(Exception ex) { Response.Write(ex.Message); }
            finally{ cn.Close(); }
        }
    }

    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        //string username = this.TextBoxUsername.Text;
        //string password = this.TextBoxPassword.Text;
        //this.Label1.Text = username;

        this.TextBoxUsername.Text = string.Empty;
        this.TextBoxPassword.Text = string.Empty;
    }

    public static string ConvertStringtoMD5(string strword)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("x2"));
        }
        return sb.ToString();
    }
}