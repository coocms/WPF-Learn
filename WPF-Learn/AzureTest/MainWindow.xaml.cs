using AzureTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AzureTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawingAttributes drawingAttributes = new DrawingAttributes();
        public MainWindow()
        {
            InitializeComponent();
            //drawingAttributes.FitToCurve = true;
            //inkCanvas.DefaultDrawingAttributes = drawingAttributes;
            
            this.DataContext = new ViewModel(inkCanvas);
        }


    }
}
