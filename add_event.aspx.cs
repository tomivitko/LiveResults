using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class add_event : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["loggedin"] != "ok")
            Response.Redirect("index.aspx");
    }

    protected void DropDownListSport_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selIndex = this.DropDownListSport.SelectedIndex.ToString();
        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        using (MySqlConnection cn = new MySqlConnection(connectionString))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT id_team, team_name FROM live_results_db.team where id_sport = "+selIndex))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                DropDownListHome.DataSource = cmd.ExecuteReader();
                DropDownListHome.DataTextField = "team_name";
                DropDownListHome.DataValueField = "id_team";
                DropDownListHome.DataBind();
                cn.Close();

                cn.Open();
                DropDownListAway.DataSource = cmd.ExecuteReader();
                DropDownListAway.DataTextField = "team_name";
                DropDownListAway.DataValueField = "id_team";
                DropDownListAway.DataBind();
                cn.Close();


            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT id_competition, competition_name FROM live_results_db.competition where id_sport = " + selIndex))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                DropDownListCompetition.DataSource = cmd.ExecuteReader();
                DropDownListCompetition.DataTextField = "competition_name";
                DropDownListCompetition.DataValueField = "id_competition";
                DropDownListCompetition.DataBind();
                cn.Close();
                
            }
            
        }
        DropDownListHome.Items.Insert(0, new ListItem("Odaberi domaćina", "0"));
        DropDownListAway.Items.Insert(0, new ListItem("Odaberi gosta", "0"));
        DropDownListCompetition.Items.Insert(0, new ListItem("Odaberi natjecanje", "0"));
    }

    protected void ButtonDodajDogadaj_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(this.DropDownListSport.SelectedValue) == 0 || Convert.ToInt32(this.DropDownListHome.SelectedValue) == 0 
            || Convert.ToInt32(this.DropDownListAway.SelectedValue) == 0 || this.TextBoxDate.Text == "")
        {
            this.errorLabel.Text = "Nisu ispunjena sva polja!";
        }
        else if (DropDownListHome.SelectedValue == DropDownListAway.SelectedValue)
            this.errorLabel.Text = "Krivo odabrane ekipe!";
        else
        {

            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    MySqlCommand command = new MySqlCommand(null, cn);
                    command.CommandText = @"insert into live_results_db.match values(@pk, @hometeam, @awayteam, @start, @id_competition, @result, @status);";
                    command.Parameters.AddWithValue("@pk", null);
                    command.Parameters.AddWithValue("@hometeam", Convert.ToInt32(this.DropDownListHome.SelectedValue));
                    command.Parameters.AddWithValue("@awayteam", Convert.ToInt32(this.DropDownListAway.SelectedValue));
                    command.Parameters.AddWithValue("@start", this.TextBoxDate.Text);
                    command.Parameters.AddWithValue("@id_competition", Convert.ToInt32(this.DropDownListCompetition.SelectedValue));
                    command.Parameters.AddWithValue("@result", "0:0");
                    command.Parameters.AddWithValue("@status", 1);
                    command.ExecuteNonQuery();
                    this.errorLabel.Text = "Utakmica uspješno dodana!";

                    this.DropDownListSport.SelectedIndex = 0;
                    this.DropDownListHome.SelectedIndex = 0;
                    this.DropDownListAway.SelectedIndex = 0;
                    this.DropDownListCompetition.SelectedIndex = 0;
                    this.TextBoxDate.Text = "";

                }
                catch (Exception ex) { Response.Write(ex.Message); }
                finally { cn.Close(); }
            }
        }
    }
}