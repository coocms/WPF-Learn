using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Learn.Model
{
    internal class ButtonModel: INotifyPropertyChanged
    {
        public int height { get; set; } = 20;



        string _text = "";
        public string text 
        {
            get { return _text; }
            set 
            {
                _text = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            } 
        } 

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
