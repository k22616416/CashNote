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
<<<<<<< HEAD
<<<<<<< HEAD
=======
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
=======
>>>>>>> 0710
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;

<<<<<<< HEAD
=======
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
>>>>>>> origin/master
=======
>>>>>>> 4adc96c6c7c5a3dd421983e1ef471a81df899f77
>>>>>>> 0710

namespace CashNote
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
        String connetStr = "server=60.249.179.122;user=	klionfr2_app;password=123; database=klionfr2_cashnote;";
        MySqlConnectionStringBuilder sqlInfo = new MySqlConnectionStringBuilder();
        MySqlConnection sqlClient;

=======
>>>>>>> 0710
        /*
        String connetStr = "server=60.249.179.122;user=klionfr2_cashnote;password=kk013579@gmail.com; database=klionfr2_cashnote;";
        MySqlConnectionStringBuilder sqlInfo = new MySqlConnectionStringBuilder();
        MySqlConnection sqlClient = new MySqlConnection();
        */
<<<<<<< HEAD
=======
        String connetStr = "server=60.249.179.122;user=	klionfr2_app;password=123; database=klionfr2_cashnote;";
        MySqlConnectionStringBuilder sqlInfo = new MySqlConnectionStringBuilder();
        MySqlConnection sqlClient;

>>>>>>> origin/master
=======
>>>>>>> 4adc96c6c7c5a3dd421983e1ef471a81df899f77
>>>>>>> 0710
        const String CustomItemName = "CustomItem";

        public MainWindow()
        {
            InitializeComponent();
            Button[] btn = new Button[] { ItemBtn1, ItemBtn2, ItemBtn3, ItemBtn4 };
<<<<<<< HEAD
<<<<<<< HEAD
=======
            sqlInfo.Server = "127.0.0.1";
            sqlInfo.UserID = "root";
            //sqlInfo.Password = "2vCICyfiqsmrPFg8";
            sqlInfo.Database = "cashnote";
            //sqlInfo.Port = 3306;
=======
>>>>>>> 0710
            /*
            sqlInfo.Server = "60.249.179.122";
            sqlInfo.UserID = "klionfr2_cashnote";
            sqlInfo.Password = "kk013579@gmail.com";
            sqlInfo.Database = "klionfr2_cashnote";
            sqlInfo.Port = 3306;
            */
<<<<<<< HEAD
=======
            sqlInfo.Server = "127.0.0.1";
            sqlInfo.UserID = "root";
            //sqlInfo.Password = "2vCICyfiqsmrPFg8";
            sqlInfo.Database = "cashnote";
            //sqlInfo.Port = 3306;
>>>>>>> origin/master
=======
>>>>>>> 4adc96c6c7c5a3dd421983e1ef471a81df899f77
>>>>>>> 0710
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
            
            try
=======
>>>>>>> 0710
            /*
            //string json = "{\"user\":\"test\"," +"\"n\":\"2\"}";
            string json = "";
            var webAddr = "http://www.google.com/";
            //var webAddr = "http://www.k22616416.lionfree.net/sqltest.php";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = json.Length;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result.ToString());
                //return result;

            }*/
            var client = new RestClient("http://www.k22616416.lionfree.net/sqltest.php");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("postman-token", "d925f52d-48de-7882-65af-a898ed9f4e4b");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"test\"\r\n\r\n123\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            
            /*
            using (var conn = new MySqlConnection(sqlInfo.ToString()))
<<<<<<< HEAD
=======
            
            try
>>>>>>> origin/master
=======
>>>>>>> 4adc96c6c7c5a3dd421983e1ef471a81df899f77
>>>>>>> 0710
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
            */
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
