using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        public static int sum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            System.DateTime currentTime = new System.DateTime();
            string time = DateTime.Now.ToShortDateString();
            string month= currentTime.Month.ToString();
            int staff;
            staff = int.Parse(DropDownList1.SelectedValue);
            int[] quantity = new int[100]; ;
            string[] name = new string[100];
            int total = 0;
            int[] price = { 0, 44, 44, 72, 62, 110, 35, 25, 55, 55, 25, 20, 20, 25, 30, 35, 40, 35 };
            quantity[0] = 0;
            if (RadioButton1.Checked)
            {
                total += price[1];
                quantity[1] = 1;
                quantity[2] = 0;
                quantity[3] = 0;
                quantity[4] = 0;
                quantity[5] = 0;

            }
            if (RadioButton2.Checked)
            {
                total += price[2];
                quantity[2] = 1;
                quantity[1] = 0;
                quantity[3] = 0;
                quantity[4] = 0;
                quantity[5] = 0;
            }
            if (RadioButton3.Checked)
            {
                total += price[3];
                quantity[3] = 1;
                quantity[2] = 0;
                quantity[1] = 0;
                quantity[4] = 0;
                quantity[5] = 0;
            }
            if (RadioButton4.Checked)
            {
                total += price[4];
                quantity[4] = 1;
                quantity[2] = 0;
                quantity[3] = 0;
                quantity[1] = 0;
                quantity[5] = 0;
            }
            if (RadioButton5.Checked)
            {
                total += price[5];
                quantity[5] = 1;
                quantity[2] = 0;
                quantity[3] = 0;
                quantity[4] = 0;
                quantity[1] = 0;
            }
            if (RadioButton6.Checked)
            {
                total += price[6];
                quantity[6] = 1;
                quantity[7] = 0;
                quantity[8] = 0;
                quantity[9] = 0;
            }
            if (RadioButton7.Checked)
            {
                total += price[7];
                quantity[7] = 1;
                quantity[6] = 0;
                quantity[8] = 0;
                quantity[9] = 0;
            }
            if (RadioButton8.Checked)
            {
                total += price[8];
                quantity[8] = 1;
                quantity[7] = 0;
                quantity[6] = 0;
                quantity[9] = 0;
            }
            if (RadioButton9.Checked)
            {
                total += price[9];
                quantity[9] = 1;
                quantity[7] = 0;
                quantity[8] = 0;
                quantity[6] = 0;
            }
            if (RadioButton10.Checked)
            {
                total += price[10];
                quantity[10] = 1;
                quantity[11] = 0;
                quantity[12] = 0;
                quantity[13] = 0;
                quantity[14] = 0;
                
            }
            if (RadioButton11.Checked)
            {
                total += price[11];
                quantity[11] = 1;
                quantity[10] = 0;
                quantity[12] = 0;
                quantity[13] = 0;
                quantity[14] = 0;
            }
            if (RadioButton12.Checked)
            {
                total += price[12];
                quantity[12] = 1;
                quantity[11] = 0;
                quantity[10] = 0;
                quantity[13] = 0;
                quantity[14] = 0;
            }
            if (RadioButton13.Checked)
            {
                total += price[13];
                quantity[13] = 1;
                quantity[11] = 0;
                quantity[12] = 0;
                quantity[10] = 0;
                quantity[14] = 0;
            }
            if (RadioButton14.Checked)
            {
                total += price[14];
                quantity[14] = 1;
                quantity[11] = 0;
                quantity[12] = 0;
                quantity[13] = 0;
                quantity[10] = 0;
            }
            if (RadioButton15.Checked)
            {
                total += price[15];
                quantity[15] = 1;
                quantity[16] = 0;
                quantity[17] = 0;
            }
            if (RadioButton16.Checked)
            {
                total += price[16];
                quantity[16] = 1;
                quantity[15] = 0;
                quantity[17] = 0;
            }
            if (RadioButton17.Checked)
            {
                total += price[17];
                quantity[17] = 1;
                quantity[16] = 0;
                quantity[15] = 0;
            }
            total -= 30;
            if(RadioButton15.Checked || RadioButton16.Checked || RadioButton17.Checked)
            {
                total -= 10;
            }
            Label100.Text = "共 " + Convert.ToString(total) + " 元";
            //Session["sum"] = total.ToString();

            name[0] = "";
            name[1] = Label1.Text;
            name[2] = Label2.Text;
            name[3] = Label3.Text;
            name[4] = Label4.Text;
            name[5] = Label5.Text;
            name[6] = Label6.Text;
            name[7] = Label7.Text;
            name[8] = Label8.Text;
            name[9] = Label9.Text;
            name[10] = Label10.Text;
            name[11] = Label11.Text;
            name[12] = Label12.Text;
            name[13] = Label13.Text;
            name[14] = Label14.Text;
            name[15] = Label15.Text;
            name[16] = Label16.Text;
            name[17] = Label17.Text;

            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\611630020\Desktop\麥當勞資料表.accdb"))
            {
                OleDbCommand insertCommand = new OleDbCommand("SELECT * FROM  訂單紀錄表", connection);
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = insertCommand;
                adapter.Fill(table);

                string cmd = "Insert into 訂單紀錄表(訂單編號,點餐機台,點餐時間,點餐月份,主餐, 主餐數量,副餐,副餐數量,飲料,飲料數量,加購,加購數量,金額)values(?,?,?,?,?,?,?,?,?,?,?,?,?)"; //問號會去覆蓋之前的內容
                OleDbCommand addCommand = new OleDbCommand(cmd, connection);

                string main_name ; 
                int main_count;
                string set_name ;
                int set_count ;
                string drink_name;
                int drink_count ;
                string add_name ;
                int add_count ;

                addCommand.Parameters.AddWithValue("@訂單編號", table.Rows.Count + 1);
                addCommand.Parameters.AddWithValue("@點餐機台", staff);
                addCommand.Parameters.AddWithValue("@點餐時間", time);
                addCommand.Parameters.AddWithValue("@點餐月份", month);
                for (int i = 1; i <= 5; i++)
                {
                    if (quantity[i] != 0)
                    {
                        main_name = name[i];
                        addCommand.Parameters.AddWithValue("@主餐", main_name);
                        addCommand.Parameters.AddWithValue("@主餐數量",1);
                    } 
                }
                if(quantity[1]==0 && quantity[2]==0 && quantity[3]==0 && quantity[4]==0 && quantity[5]==0){
                    addCommand.Parameters.AddWithValue("@主餐", "無");
                    addCommand.Parameters.AddWithValue("@主餐數量", 0);
                }

                for (int i = 6; i <= 9; i++)
                {
                    if (quantity[i] != 0)
                    {
                        set_name = name[i];
                        addCommand.Parameters.AddWithValue("@副餐", set_name);
                        addCommand.Parameters.AddWithValue("@副餐數量", 1);
                    }
                }
                if (quantity[6] == 0 && quantity[7] == 0 && quantity[8] == 0 && quantity[9] == 0){
                    addCommand.Parameters.AddWithValue("@副餐", "無");
                    addCommand.Parameters.AddWithValue("@副餐數量", 0);
                }

                for (int i = 10; i <= 14; i++)
                {
                    if (quantity[i] != 0)
                    {
                        drink_name = name[i];
                        addCommand.Parameters.AddWithValue("@飲料", drink_name);
                        addCommand.Parameters.AddWithValue("@飲料數量", 1);
                    }                   
                }
                if (quantity[10] == 0 && quantity[11] == 0 && quantity[12] == 0 && quantity[13] == 0 && quantity[14] == 0)
                {
                    addCommand.Parameters.AddWithValue("@飲料","無");
                    addCommand.Parameters.AddWithValue("@飲料數量", 0);
                }

                for (int i = 15; i <= 17; i++)
                {
                    if (quantity[i] != 0)
                    {
                        add_name = name[i];
                        addCommand.Parameters.AddWithValue("@加購", add_name);
                        addCommand.Parameters.AddWithValue("@加購數量", 1);
                    }                   
                }
                if (quantity[15] == 0 && quantity[16] == 0 && quantity[17] == 0){
                        addCommand.Parameters.AddWithValue("@加購", "無");
                        addCommand.Parameters.AddWithValue("@加購數量", 0);
                }
                //addCommand.Parameters.AddWithValue("@套餐數量", count_drink);
                addCommand.Parameters.AddWithValue("@金額", total);

                try
                {
                    connection.Open(); //試有沒有連線成功
                    if (addCommand.ExecuteNonQuery() > 0) // >0 成功輸入
                    {

                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                }     
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
           
            Server.Transfer("About.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("Contact.aspx");
        }
    }
}

