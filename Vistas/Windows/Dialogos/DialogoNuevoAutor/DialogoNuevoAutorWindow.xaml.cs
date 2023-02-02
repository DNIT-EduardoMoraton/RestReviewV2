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
using System.Windows.Shapes;

namespace RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevoAutor
{
    /// <summary>
    /// Lógica de interacción para DialogoNuevoAutorWindow.xaml
    /// </summary>
    public partial class DialogoNuevoAutorWindow : Window
    {
        private DialogoNuevoAutorWindowVM vm;
        public DialogoNuevoAutorWindow()
        {
            
            InitializeComponent();
            vm = new DialogoNuevoAutorWindowVM();
            this.DataContext = vm;
        }

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
            vm.createFun();
            DialogResult = true;
        }
    }
}
