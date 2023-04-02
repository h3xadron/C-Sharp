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
        ObservableCollection<Soldier> army;
        
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
           
            army = new ObservableCollection<Soldier>();

        }



        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            army.Add(soldiers[0]);
            lbox02.ItemsSource = army;
            
           // List<Soldier> valami =+ soldiers.ToList();
            //soldiers.Add(new Soldier());


            /*
            List<Soldier> list = new List<Soldier>();
            foreach (var item in soldiers)
            {
                lbox02.Items.Add(item);
            }
            */
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {

        }
    }
}
