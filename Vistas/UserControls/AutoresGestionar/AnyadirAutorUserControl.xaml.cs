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

namespace RestReviewV2.Vistas.UserControls.AutoresGestionar
{
    /// <summary>
    /// Lógica de interacción para AnyadirAutorUserControl.xaml
    /// </summary>
    public partial class AnyadirAutorUserControl : UserControl
    {
        AnyadirAutorUserControlVM vm;
        public AnyadirAutorUserControl()
        {
            InitializeComponent();
            vm = new AnyadirAutorUserControlVM();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.createFun();
        }
    }
}
