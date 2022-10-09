using AzureTest.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace AzureTest.Model
{
    internal class ViewModel: INotifyPropertyChanged
    {
        private InkCanvas _inkCanvas;
        public ViewModel(InkCanvas inkCanvas)
        {
            _inkCanvas = inkCanvas;
        }
        public ICommand buttonCommand => new ButtonCommand(MyAction);
        public ICommand visionCommand => new VisionCommand(_inkCanvas);


        string text = "";
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void MyAction(string value)
        {
            Text = value;


        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//供外部调用的方法，这里用特性来省略参数，取此方法的caller
        }


    }
}
