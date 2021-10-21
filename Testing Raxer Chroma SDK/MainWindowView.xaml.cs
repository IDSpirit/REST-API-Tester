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

namespace Testing_Raxer_Chroma_SDK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();

            Button_Click_Event += ((MainWindowViewModel)(this.DataContext)).OnButtonClickHandler;
            Clear_Button_Click_Event += ((MainWindowViewModel)(this.DataContext)).OnClearButtonClickHandler;

        }

        public delegate void Button_Click_Handler(RoutedEventArgs o);
        public static event Button_Click_Handler Button_Click_Event;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button_Click_Event(e);
        }

        public delegate void Clear_Button_Click_Handler(RoutedEventArgs o);
        public static event Clear_Button_Click_Handler Clear_Button_Click_Event;
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_Button_Click_Event(e);
        }
    }
}
