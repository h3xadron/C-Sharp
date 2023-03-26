using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Military_Division_Workshop03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Soldier> soldiers;
        public MainWindow()
        {
            InitializeComponent();

            soldiers = new ObservableCollection<Soldier>()
            {
                new Soldier() {Type = "Sniper", Power = 20, Staminate=40, Soldier_Value=10},
                new Soldier() {Type = "Marin", Power = 40, Staminate=50, Soldier_Value=20},
                new Soldier() {Type = "SEAL", Power = 70, Staminate=60, Soldier_Value=40}
            };
            lbox01.ItemsSource = soldiers;
        }

    

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            /* Itt kéne egy Lista amibe bele pakolászom a katonákat .
             * és akkor valahogy kiszedni  power stamina és value értékeket és össze szorozni az lesz majd a  lista ára
            */
            var a = new List<Soldier>();
            a.Add(new Soldier())
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {

        }
    }
}
