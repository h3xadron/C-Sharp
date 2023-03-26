using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Military_Division_Workshop03
{
    public class Soldier : INotifyPropertyChanged
    {
        private string type;
        private int power;
        private int staminate;
        private int soldier_value;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Staminate
        {
            get { return staminate; }
            set { staminate = value; }
        }
        public int Soldier_Value
        {
            get { return soldier_value; }
            set { soldier_value = value; }
        }

        
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
