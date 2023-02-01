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

namespace GestorRestReview.Vistas.UserControls.Articulos
{
    /// <summary>
    /// Lógica de interacción para ArticulosUserControl.xaml
    /// </summary>
    public partial class ArticulosUserControl : UserControl
    {
        private ArticulosUserControlVM vm;
        public ArticulosUserControl()
        {
            InitializeComponent();
            vm = new ArticulosUserControlVM();
            this.DataContext = vm;
        }
    }
}
