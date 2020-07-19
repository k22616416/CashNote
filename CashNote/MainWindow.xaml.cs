using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using System.Collections.ObjectModel;



namespace CashNote
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public class CashData
    {
        public int iid { get; set; }
        public string date { get; set; }
        public string item { get; set; }
        public int cash { get; set; }
        public string remark { get; set; }
        public Button delete = new Button();

    }
    public partial class MainWindow : Window
    {


        const String CustomItemName = "CustomItem";

        public MainWindow()
        {
            InitializeComponent();
            Button[] btn = new Button[] { ItemBtn1, ItemBtn2, ItemBtn3, ItemBtn4 };
            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.ItemBtn_Click));

            //this.DataGrid1.ItemsSource = GetDataTable().DefaultView;
            ObservableCollection<CashData> DataGridInfo = new ObservableCollection<CashData>();
            DataGridInfo.Add(new CashData()
            {
                iid = 1,
                date = "0719",
                item = "test",
                cash = 100,
                remark = "test"
            });
            DataGridInfo.Add(new CashData()
            {
                iid = 2,
                date = "0719",
                item = "test",
                cash = 100,
                remark = "test"
            });
            DataGridInfo.Add(new CashData()
            {
                iid = 3,
                date = "0719",
                item = "test",
                cash = 100,
                remark = "test"
            });
            DataGrid1.DataContext = DataGridInfo;
        }

        public DataTable GetDataTable()
        {
            return null;
        }

        private void ItemBtn_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            string item, remark = InputRemark.Text != String.Empty ? InputRemark.Text : String.Empty;
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



                /*
                FrameworkElement feSource = e.Source as FrameworkElement;
                TestLabel.Content = feSource.ContextMenu;
                */



            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {



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


        }

        private void DeletBtn(object sender, RoutedEventArgs e)
        {

        }
        
    } 
}
