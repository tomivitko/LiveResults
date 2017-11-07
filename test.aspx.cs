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

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tablica();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        this.PlaceHolder1.Controls.Clear();
        Tablica();
    }



    private void Tablica()
    {

        //Populating a DataTable from database.
        DataTable dt = this.GetData();

        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        int i = dt.Rows.Count;
        //Table start.
        html.Append("<table border = '1' width='100%'>");
        int competition_id = Convert.ToInt32(dt.Rows[0][6]);
        html.Append("<tr><th colspan='6'>" + dt.Rows[0][7] + "</th></tr>");
        for (i = 0; i < dt.Rows.Count; i++)
        {
            if (competition_id != Convert.ToInt32(dt.Rows[i][6]))
            {
                competition_id = Convert.ToInt32(dt.Rows[i][6]);
                html.Append("<tr><th colspan='6'>" + dt.Rows[i][7] + "</th></tr>");
            }
            html.Append("<tr>");
            for (int j = 0; j < 6; j++)
            {
                if (j < 5)
                {
                    html.Append("<td>");
                    html.Append(dt.Rows[i][j].ToString());
                    html.Append("</td>");
                }
                //else html.Append("<td><a href='details.aspx?match_id={" + dt.Rows[i][j].ToString() + "}'>Detalji</a></td>");
            }

            html.Append("</tr>");

        }
        //Table end.
        html.Append("</table>");

        //Append the HTML string to Placeholder.
        this.PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        //CheckMyConnection();
    }


    private void CheckMyConnection()
    {
        string connectionString = @"Data Source=localhost; Database=live_results_db; User ID=root; Password='root'; Port=3307";
        using (MySqlConnection cn = new MySqlConnection(connectionString))
        {
            cn.Open();
            Response.Write("radi");
            cn.Close();
        }
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
                                id_match,
                                c.id_competition,
                                c.competition_name
                                from
                                live_results_db.match left join live_results_db.team t1 on(match.id_home_team = t1.id_team)
                                left join live_results_db.team t2 on(match.id_away_team = t2.id_team)
                                left join live_results_db.competition c on(match.id_competition = c.id_competition)
                                left join live_results_db.match_status ms on (match.id_match_status = ms.id_match_status)
                                where DATE(match.match_start) = CURDATE() and c.id_sport = 1
                                order by c.id_competition; ";

            MySqlDataAdapter adp = new MySqlDataAdapter(sqlString, cn);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            return dt;
            cn.Close();
        }
    }

}