using System;
using System.Collections.Generic;
using System.IO;
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

namespace Memoria_Jatek_Workshop02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
            for (int i = 0; i < 2; i++)
            {
                for ( int j = 1; j < 4; j++)
                {
                    Label Kartya = new Label();
                    Kartya.Width = ActualWidth / 2;
                    Kartya.Height = ActualHeight / 2;
                    Kartya.Background = new SolidColorBrush(Colors.LightBlue);
                    Kartya.Padding = new Thickness(20);
                    Kartya.Margin = new Thickness(20);
                    Kartya.Tag = j;
                    WrapKartya.Children.Add(Kartya);
                    Kartya.MouseLeftButtonDown += Kartya_MouseLeftButtonDown;
                    if (j == 4) { j = 1; }
               }
             
            }
        }

        private void Kartya_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label kattintas = (Label)sender;
            var megjelnito = kattintas.Tag.ToString();
            MessageBox.Show(megjelnito);
        }
    }
}
