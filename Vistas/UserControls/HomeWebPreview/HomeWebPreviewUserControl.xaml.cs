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

namespace GestorRestReview.Vistas.UserControls.HomeWebPreview
{
    /// <summary>
    /// Lógica de interacción para HomeWebPreviewUserControl.xaml
    /// </summary>
    public partial class HomeWebPreviewUserControl : UserControl
    {
        private HomeWebPreviewUserControlVM vm;
        public HomeWebPreviewUserControl()
        {
            InitializeComponent();
            vm = new HomeWebPreviewUserControlVM();
            this.DataContext = vm;
        }
    }
}
