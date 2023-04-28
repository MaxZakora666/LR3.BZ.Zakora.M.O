using ConsoleApp1;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using System.Data.Common;

using System.Windows.Forms;


namespace WindowsFormsApp1
{
    //select * from flights
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_update_Click(object sender, System.EventArgs e)
        {
            TableData.Rows.Clear();
            MySqlConnection conn = DBUtils.GetMySqlConnection();
            conn.Open();
            string sql = "select * from flights,sales where flights.f_fly_num = sales.flights_f_fly_num;";
            
            MySqlCommand cmd = new MySqlCommand(sql);

            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                List<string[]> data = new List<string[]>();
                if (reader.HasRows && reader.Read())
                {
                    while (reader.Read())
                    {
                        data.Add(new string[12]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                        data[data.Count - 1][4] = reader[4].ToString();

                        data[data.Count - 1][5] = reader[5].ToString();
                        data[data.Count - 1][6] = reader[6].ToString();
                        data[data.Count - 1][7] = reader[7].ToString();
                        data[data.Count - 1][8] = reader[8].ToString();
                        data[data.Count - 1][9] = reader[9].ToString();
                        data[data.Count - 1][10] = reader[10].ToString();
                        data[data.Count - 1][11] = reader[11].ToString();

                    }
                }
                reader.Close();
                conn.Close();

                foreach (string[] s in data)
                {
                    TableData.Rows.Add(s);
                }
            }
        }
    }
}
