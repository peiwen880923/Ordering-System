using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Configuration;

namespace WebApplication2
{
    public partial class About : Page
    {
        
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {


            /* using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
             {
                 OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 ORDER BY 訂單編號 Asc", connection);
                 connection.Open();
                 DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                 OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                 adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                 adapter.Fill(table); //存在table裡面



                 GridView1.DataSource = table;
                 GridView1.DataBind();
             }*/
            string dbHost = "資料庫位址";
            string dbUser = "資料庫使用者名稱";
            string dbPass = "資料庫使用者密碼";
            string dbName = "資料庫名稱";

            // 如果有特殊的編碼在database後面請加上;CharSet=編碼, utf8請使用utf8_general_ci
            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            MySqlConnection conn = new MySqlConnection(connStr);

            // 連線到資料庫
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("無法連線到資料庫.");
                        break;
                    case 1045:
                        Console.WriteLine("使用者帳號或密碼錯誤,請再試一次.");
                        break;
                }
            }

            // 進行select
            string SQL = "select plain from yammer order by id desc limit 0,10 ";
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataReader myData = cmd.ExecuteReader();

                if (!myData.HasRows)
                {
                    // 如果沒有資料,顯示沒有資料的訊息
                    Console.WriteLine("No data.");
                }
                else
                {
                    // 讀取資料並且顯示出來
                    while (myData.Read())
                    {
                        Console.WriteLine("Text={0}", myData.GetString(0));
                    }
                    myData.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " : " + ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 ORDER BY 訂單編號 Asc", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");

            try
            {
                conn.Open();

                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand("SELECT SUM(金額) FROM 訂單紀錄表", conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Label1.Text = reader[0].ToString();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 WHERE 點餐機台=1 ORDER BY 訂單編號 Asc", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面

                GridView1.DataSource = table;
                GridView1.DataBind();
            }

            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");
            try
            {
                conn.Open();

                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐機台=1 ", conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Label1.Text = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 WHERE 點餐機台=2 ORDER BY 訂單編號 Asc", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面

                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");

            try
            {
                conn.Open();

                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐機台=2 ", conn);

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    Label1.Text = reader[0].ToString();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 WHERE 點餐機台=3 ORDER BY 訂單編號 Asc", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");

            try
            {
                conn.Open();

                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐機台=3 ", conn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Label1.Text = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 WHERE 點餐機台=4 ORDER BY 訂單編號 Asc", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");

            try
            {
                conn.Open();

                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand("SELECT SUM(金額) FROM 訂單紀錄 WHERE 點餐機台=4 ", conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   Label1.Text = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 WHERE 點餐機台=5 ORDER BY 訂單編號 Asc", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");

            try
            {
                conn.Open();

                OleDbDataReader reader = null;  // This is OleDb Reader
                OleDbCommand cmd = new OleDbCommand("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐機台=5 ", conn);

                reader = cmd.ExecuteReader();
                // sum = int.Parse(reader.ToString());


                while (reader.Read())
                {

                    Label1.Text = reader[0].ToString();
                }

                // Label1.Text = reader.ToString();


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 ORDER BY 點餐機台 Asc", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT *  FROM  訂單紀錄表 ORDER BY 金額 DESC", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                String cmmd = string.Format("SELECT * FROM 訂單紀錄表 WHERE 點餐時間 IN('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", DateTime.Now.AddDays(Convert.ToDouble((1 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((2 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((3 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((4 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((5 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((6 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((7 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString());
                OleDbCommand cmd1 = new OleDbCommand(cmmd, connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = cmd1; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");
            conn.Open();

            OleDbDataReader reader = null;  // This is OleDb Reader
            String cmdd = string.Format("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐時間 IN('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", DateTime.Now.AddDays(Convert.ToDouble((1 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((2 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((3 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((4 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((5 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((6 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString(), DateTime.Now.AddDays(Convert.ToDouble((7 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString());
            OleDbCommand cmd = new OleDbCommand(cmdd, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label1.Text = reader[0].ToString();
            }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                String cmmd = string.Format("SELECT * FROM 訂單紀錄表 WHERE 點餐時間 LIKE '{0}%'  ORDER BY 訂單編號 Asc ", DateTime.Now.ToString("yyyy-MM"));
                OleDbCommand cmd1 = new OleDbCommand(cmmd, connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = cmd1; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");
            conn.Open();

            OleDbDataReader reader = null;  // This is OleDb Reader
            String cmdd = string.Format("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐時間 LIKE '{0}%' ", DateTime.Now.ToString("yyyy-MM"));
            OleDbCommand cmd = new OleDbCommand(cmdd, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Label1.Text = reader[0].ToString();
            }
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                String cmmd = string.Format("SELECT * FROM 訂單紀錄表 WHERE 點餐時間 LIKE '{0}'", DateTime.Now.ToShortDateString());
                OleDbCommand cmd1 = new OleDbCommand(cmmd, connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = cmd1; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");
            conn.Open();

            OleDbDataReader reader = null;  // This is OleDb Reader
            String cmdd = string.Format("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐時間 LIKE '{0}'", DateTime.Now.ToShortDateString());
            OleDbCommand cmd = new OleDbCommand( cmdd, conn);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Label1.Text = reader[0].ToString();
            }
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            string month = DropDownList1.SelectedValue;
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                String cmmd = string.Format("SELECT * FROM 訂單紀錄表 WHERE 點餐時間 LIKE '{0}%'", month);
                OleDbCommand cmd1 = new OleDbCommand(cmmd, connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = cmd1; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }     
            OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb");
            conn.Open();

            OleDbDataReader reader = null;  // This is OleDb Reader
            String cmdd = string.Format("SELECT SUM(金額) FROM 訂單紀錄表 WHERE 點餐時間 LIKE '{0}%'",month);
            OleDbCommand cmd = new OleDbCommand(cmdd, conn);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Label1.Text = reader[0].ToString();
            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT 點餐機台 AS 機台 ,sum(金額) AS 總金額 FROM  訂單紀錄表 GROUP BY 點餐機台", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT 點餐月份 AS 月份 ,sum(金額) AS 總金額 FROM  訂單紀錄表  GROUP BY 點餐月份 ORDER BY 點餐月份", connection);
                connection.Open();
                DataTable table = new DataTable(); //建資料表 資料存近來比較整齊
                OleDbDataAdapter adapter = new OleDbDataAdapter(); //選取一個物件 和datatable一起使用 會比較整齊
                adapter.SelectCommand = selectCommand; //選取要指令的命令 第25行的指令
                adapter.Fill(table); //存在table裡面



                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }
    }
}