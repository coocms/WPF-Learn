using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Learn.Command;

namespace WPF_Learn.Model
{
    internal class WindowsViewModel
    {
        public BorderModel borderModel { get; set; } = new BorderModel();

        public ButtonModel buttonModel { get; set; } = new ButtonModel();

        public TextBoxModel textBoxModel { get; set; } = new TextBoxModel();
        public TextBoxModel textBoxModel2 { get; set; } = new TextBoxModel();

        //事件

        public ButtonCommand buttonCommand
        { 
            get 
            { 
                return new ButtonCommand(ButtonClick);
            }
        }



        private void ButtonClick()
        {
            buttonModel.text = textBoxModel.text + textBoxModel2.text;
            
        }
    }
}
