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

public partial class add_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["loggedin"] != "ok")
            Response.Redirect("index.aspx");
    }

    protected void ButtonAddAdmin_Click(object sender, EventArgs e) {

        if (this.TextBoxFirstname.Text != "" && this.TextBoxLastname.Text != "" && this.TextBoxEmail.Text != ""
            && this.TextBoxUsername.Text != "" && this.TextBoxPassword.Text != "" && this.TextBoxPasswordAgain.Text != "")
        {
            if (this.TextBoxPassword.Text == this.TextBoxPasswordAgain.Text)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        MySqlCommand command = new MySqlCommand(null, cn);
                        command.CommandText = @"select * from live_results_db.admins where username=@uname; ";
                        command.Parameters.AddWithValue("@uname", this.TextBoxUsername.Text);
                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            
                            this.errorLabel.Text = "korisničko ime već postoji";
                        }

                        else
                        {
                            cn.Close();
                            cn.Open();
                            MySqlCommand command2 = new MySqlCommand(null, cn);
                            command2.CommandText = @"insert into live_results_db.admins values(@pk, @fname, @lname, @user, @pass, @email);";
                            command2.Parameters.AddWithValue("@pk", null);
                            command2.Parameters.AddWithValue("@fname", this.TextBoxFirstname.Text);
                            command2.Parameters.AddWithValue("@lname", this.TextBoxLastname.Text);
                            command2.Parameters.AddWithValue("@user", this.TextBoxUsername.Text);
                            command2.Parameters.AddWithValue("@pass", ConvertStringtoMD5(this.TextBoxPassword.Text));
                            command2.Parameters.AddWithValue("@email", this.TextBoxEmail.Text);
                            command2.ExecuteNonQuery();
                            this.errorLabel.Text = "admin uspješno dodan";
                            ClearTextboxes();
                        }


                    }
                    catch (Exception ex) { Response.Write(ex.Message); }
                    finally { cn.Close(); }
                }
             }else this.errorLabel.Text = "lozika i ponovljena lozinka nisu iste";
        }else this.errorLabel.Text = "nisu ispunjena sva polja";
    }

    protected void ButtonReset_Click(object sender, EventArgs e) {

        ClearTextboxes();
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

    public void ClearTextboxes() {
        this.TextBoxFirstname.Text = string.Empty;
        this.TextBoxLastname.Text = string.Empty;
        this.TextBoxEmail.Text = string.Empty;
        this.TextBoxUsername.Text = string.Empty;
        this.TextBoxPassword.Text = string.Empty;
        this.TextBoxPasswordAgain.Text = string.Empty;
    }
}