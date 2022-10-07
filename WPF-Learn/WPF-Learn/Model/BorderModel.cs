using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_Learn.Model
{
    internal class BorderModel
    {
        public Brush color { get; set; } = new SolidColorBrush(System.Windows.Media.Color.FromRgb(1,0,0));
    }
}
