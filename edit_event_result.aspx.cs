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

public partial class edit_event_result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["loggedin"] != "ok")
            Response.Redirect("index.aspx");
        Tablica();
    }


    private void Tablica() {
        //Populating a DataTable from database.
        DataTable dt = this.GetData();

        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        int i = dt.Rows.Count;
        //Table start.
        html.Append("<table border = '1' width='100%'>");
        //int competition_id = Convert.ToInt32(dt.Rows[0][5]);
        //html.Append("<tr><th colspan='5'>" + dt.Rows[0][6] + "</th></tr>");
        for (i = 0; i < dt.Rows.Count; i++)
        {
            //if (competition_id != Convert.ToInt32(dt.Rows[i][5]))
            // {
            //   competition_id = Convert.ToInt32(dt.Rows[i][5]);
            //    html.Append("<tr><th colspan='5'>" + dt.Rows[i][6] + "</th></tr>");
            //}
            html.Append("<tr>");
            for (int j = 0; j < 5; j++)
            {

                html.Append("<td>");
                html.Append(dt.Rows[i][j].ToString());
                html.Append("</td>");
            }

            html.Append("</tr>");

        }
        //Table end.
        html.Append("</table>");

        //Append the HTML string to Placeholder.
        this.PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    private DataTable GetData()
    {
        //string connectionString = @"Data Source=localhost; Database=contacts_db; User ID=root; Password='root'; Port=3307";
        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        using (MySqlConnection cn = new MySqlConnection(connectionString))
        {
            cn.Open();
            String sqlString = @"select 
                                date_format(match_start, '%H:%i'),
                                t1.team_name as home_team,
                                result,
                                t2.team_name as away_team,
                                ms.description,
                                
                                id_match
                                
                                from
                                live_results_db.match left join live_results_db.team t1 on(match.id_home_team = t1.id_team)
                                left join live_results_db.team t2 on(match.id_away_team = t2.id_team)
                                
                                left join live_results_db.match_status ms on (match.id_match_status = ms.id_match_status)
                                where id_match =" + Request.QueryString["match_id"];

            MySqlDataAdapter adp = new MySqlDataAdapter(sqlString, cn);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            return dt;
            cn.Close();
        }
    }

    protected void ButtonUTijeku_Click(object sender, EventArgs e)
    {

        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        using (MySqlConnection cn = new MySqlConnection(connectionString))
        {
            try
            {
                cn.Open();
                MySqlCommand command = new MySqlCommand(null, cn);
                command.CommandText = @"update live_results_db.match set match.id_match_status = 2 where match.id_match =" + Request.QueryString["match_id"];
                MySqlDataReader reader = command.ExecuteReader();
                
            }
            catch (Exception ex) { Response.Write(ex.Message); }
            finally { cn.Close();
                
            }
        }
        Response.Redirect("~/edit_event.aspx");
    }

    protected void ButtonKraj_Click(object sender, EventArgs e) {

        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        using (MySqlConnection cn = new MySqlConnection(connectionString))
        {
            try
            {
                cn.Open();
                MySqlCommand command = new MySqlCommand(null, cn);
                command.CommandText = @"update live_results_db.match set match.id_match_status = 3 where match.id_match =" + Request.QueryString["match_id"];
                MySqlDataReader reader = command.ExecuteReader();
                
            }
            catch (Exception ex) { Response.Write(ex.Message); }
            finally { cn.Close(); }
        }
        Response.Redirect("~/edit_event.aspx");
    }

    protected void ButtonUpisiRezultat_Click(object sender, EventArgs e) {

        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        using (MySqlConnection cn = new MySqlConnection(connectionString))
        {
            try
            {
                cn.Open();
                MySqlCommand command = new MySqlCommand(null, cn);
                command.CommandText = @"update live_results_db.match set match.result =@result where match.id_match =" + Request.QueryString["match_id"];
                command.Parameters.AddWithValue("@result", this.TextBoxRezultat.Text);
                MySqlDataReader reader = command.ExecuteReader();
                
            }
            catch (Exception ex) { Response.Write(ex.Message); }
            finally { cn.Close(); }
        }
        Response.Redirect("~/edit_event.aspx");
    }

    
}