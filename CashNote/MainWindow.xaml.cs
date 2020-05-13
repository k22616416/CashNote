using System;
using System.Collections.Generic;
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
            sqlInfo.Server = "60.249.179.122";
            sqlInfo.UserID = "klionfr2_cashnote";
            sqlInfo.Password = "kk013579@gmail.com";
            sqlInfo.Database = "klionfr2_cashnote";
            sqlInfo.Port = 3306;
            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.ItemBtn_Click));

        }

        private void ItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Name == CustomItemName)
            {
                TestLabel.Content = System.DateTime.Now + " " + InputCash.Text + " " + InputItem.Text;
                InputCash.Text = "";
            }
            else
            {
                TestLabel.Content = System.DateTime.Now + " " + InputCash.Text + " " + btn.Content;
                InputCash.Text = "";
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
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM 'noteTest'", conn);
                    int index = cmd.ExecuteNonQuery();
                    if (index > 0)
                    {
                        SQLLabel.Content = "Status:Cannot connect to server.";
                    }
                    else
                    {
                        SQLLabel.Content = "Status:Error.";
                    }
                    conn.Close();
                }
                catch(MySqlException ex)
                {
                    SQLLabel.Content = "Status:Error code " + ex.Number;
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
