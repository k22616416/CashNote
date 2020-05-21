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
using Org.BouncyCastle.Asn1.Cms;

namespace CashNote
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        String connetStr = "server=60.249.179.122;user=	klionfr2_app;password=123; database=klionfr2_cashnote;";
        MySqlConnectionStringBuilder sqlInfo = new MySqlConnectionStringBuilder();
        MySqlConnection sqlClient;

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
            

            
            
        }

        public DataTable GetDataTable()
        {
            //MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();



            sqlClient = new MySqlConnection(sqlInfo.ToString());
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter ada = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sqlClient.Open();
                cmd.Connection = sqlClient;
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
                sqlClient.Close();
            }
            

            return dt;
        }

        private void ItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string item,remark = InputRemark.Text != String.Empty ? InputRemark.Text : String.Empty;
            if (btn.Name == CustomItemName)
            {
                item = InputItem.Text;
                /*
                TestLabel.Content = System.DateTime.Now + " " + InputCash.Text + " " + InputItem.Text;
                InputCash.Text = "";
                */
            }
            else
            {
                item = btn.Content.ToString();
                
                /*
                TestLabel.Content = System.DateTime.Now + " " + InputCash.Text + " " + btn.Content;
                InputCash.Text = "";
                */
                
            try
                {
                    sqlClient.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    string cmdtxt = ($"INSERT INTO `cashnote`(`時間`, `項目`, `金額`, `備註`) VALUES ({DateTime.Today},{item},{int.Parse(InputCash.Text)},{remark})");
                    cmd.CommandText = cmdtxt;
                    InputCash.Text = InputRemark.Text = String.Empty;
                }
                catch (MySqlException ex)
                {
                    ErrorLabel.Visibility = Visibility.Visible;
                    ErrorLabel.Content = ex.Message;
                }
                finally
                {
                    sqlClient.Close();
                }
            }
            
            /*
            FrameworkElement feSource = e.Source as FrameworkElement;
            TestLabel.Content = feSource.ContextMenu;
            */



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                sqlClient.Open();
                MySqlCommand cmd = new MySqlCommand();
                string cmdtxt = $"INSERT INTO `cashnote`(`時間`, `項目`, `金額`, `備註`) VALUES ({DateTime.Today},{1},{2},{3})";

                cmd.CommandText = cmdtxt;
            }
            catch (MySqlException ex)
            {
                ErrorLabel.Visibility = Visibility.Visible;
                ErrorLabel.Content = ex.Message;
            }
            finally
            {
                sqlClient.Close();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
