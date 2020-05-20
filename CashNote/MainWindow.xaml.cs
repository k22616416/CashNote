using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace CashNote
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        String connetStr = "server=60.249.179.122;user=klionfr2_cashnote;password=kk013579@gmail.com; database=klionfr2_cashnote;";
        MySqlConnectionStringBuilder sqlInfo = new MySqlConnectionStringBuilder();
        MySqlConnection sqlClient = new MySqlConnection();

        const String CustomItemName = "CustomItem";

        public MainWindow()
        {
            InitializeComponent();
            Button[] btn = new Button[] { ItemBtn1, ItemBtn2, ItemBtn3, ItemBtn4 };
            sqlInfo.Server = "127.0.0.1";
            sqlInfo.UserID = "root";
            //sqlInfo.Password = "2vCICyfiqsmrPFg8";
            sqlInfo.Database = "cashnote";
            //sqlInfo.Port = 3306;
            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.ItemBtn_Click));

            this.DataGrid1.ItemsSource = GetDataTable().DefaultView;
            List<int> list1 = new List<int>() { 1, 2, 3, 4 };

            
            
        }

        public DataTable GetDataTable()
        {
            //MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            
            

            MySqlConnection con = new MySqlConnection(sqlInfo.ToString());
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter ada = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                ada.SelectCommand = cmd;

                string cmdtxt = @"select IID,DATE_FORMAT(date,'%Y/%m/%d') as date,item,cash,remark from test";

                cmd.CommandText = cmdtxt;
                ada.Fill(dt);
            }
            catch(MySqlException ex)
            {
                ErrorLabel.Visibility = Visibility.Visible;
                ErrorLabel.Content = ex.Message;
            }
            finally
            {
                con.Close();
            }
            

            return dt;
        }

        private void ItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Name == CustomItemName)
            {
                /*
                TestLabel.Content = System.DateTime.Now + " " + InputCash.Text + " " + InputItem.Text;
                InputCash.Text = "";
                */
            }
            else
            {
                /*
                TestLabel.Content = System.DateTime.Now + " " + InputCash.Text + " " + btn.Content;
                InputCash.Text = "";
                */
            }
            
            /*
            FrameworkElement feSource = e.Source as FrameworkElement;
            TestLabel.Content = feSource.ContextMenu;
            */



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new MySqlConnection(sqlInfo.ToString()))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM test", conn);
                    MySqlDataReader data = cmd.ExecuteReader();
                    //列出查詢到的資料
                    while (data.Read())
                    {
                        //Console.WriteLine("id={0} , name={1}", data["id"], data["name"]);
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", data[0], data[1], data[2], data[3], data[4]);

                    }
                    /*
                    int index = cmd.ExecuteNonQuery();
                    if (index > 0)
                    {
                        SQLLabel.Content = "Status:Cannot connect to server.";
                    }
                    else
                    {
                        SQLLabel.Content = "Status:Error.";
                    }*/
                    conn.Close();
                }
                catch(MySqlException ex)
                {
                    SQLLabel.Content = "Status:" + ex.Message;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                
                
            }

            /*
                try
                {
                    sqlClient.Open();
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            SQLLabel.Content = "Status:Cannot connect to server.";
                            break;

                        case 1045:
                            SQLLabel.Content = "Status:Invalid user name and/or password.";
                            break;

                        default:
                            SQLLabel.Content = "Status:Error.";
                            break;
                    }
                }
                finally
                {
                    sqlClient.Close();
                }
                */
        }

        
    }
}
