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

public partial class add_team : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["loggedin"] != "ok")
            Response.Redirect("index.aspx");
    }

    protected void ButtonDodajEkipu_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(DropDownListSport.SelectedValue) == 0)
        {
            this.errorLabel.Text = "Molim odabrati sport!";
        }
        else if (this.TextBoxTeamName.Text == "")
            this.errorLabel.Text = "Molim upisati naziv!";
        else
        {

            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    MySqlCommand command = new MySqlCommand(null, cn);
                    command.CommandText = @"insert into live_results_db.team values(@pk, @teamname, @sportid);";
                    command.Parameters.AddWithValue("@pk", null);
                    command.Parameters.AddWithValue("@teamname", this.TextBoxTeamName.Text);
                    command.Parameters.AddWithValue("@sportid", Convert.ToInt32(DropDownListSport.SelectedValue));
                    command.ExecuteNonQuery();
                    this.errorLabel.Text = "ekipa uspješno dodana";
                    ClearTextboxes();

                }
                catch (Exception ex) { Response.Write(ex.Message); }
                finally { cn.Close(); }
            }
        }
    }

    public void ClearTextboxes()
    {
        this.TextBoxTeamName.Text = string.Empty;
        this.DropDownListSport.SelectedIndex = 0;
    }

}