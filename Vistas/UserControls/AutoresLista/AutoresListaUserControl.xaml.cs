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

namespace RestReviewV2.Vistas.UserControls.AutoresLista
{
    /// <summary>
    /// Lógica de interacción para AutoresListaUserControl.xaml
    /// </summary>
    public partial class AutoresListaUserControl : UserControl
    {
        AutoresListaUserControlVM vm;
        public AutoresListaUserControl()
        {
            InitializeComponent();
            vm = new AutoresListaUserControlVM();
            this.DataContext = vm;
        }
    }
}
