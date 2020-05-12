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

namespace CashNote
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        const String CustomItemName = "CustomItem";
        public MainWindow()
        {
            InitializeComponent();
            Button[] btn = new Button[] { ItemBtn1, ItemBtn2, ItemBtn3, ItemBtn4 };
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
    }
}
