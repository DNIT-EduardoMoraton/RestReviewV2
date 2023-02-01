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

namespace GestorRestReview.Vistas.UserControls.Home
{
    /// <summary>
    /// Lógica de interacción para HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : UserControl
    {
        private HomeUserControlVM vm;
        public HomeUserControl()
        {
            InitializeComponent();
            vm = new HomeUserControlVM();
            this.DataContext = vm;
        }
    }
}
