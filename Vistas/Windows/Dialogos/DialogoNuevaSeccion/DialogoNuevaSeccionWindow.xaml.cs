using RestReviewV2.Vistas.Windows.Dialogos.DialogoNuevaSeccion;
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

namespace GestorRestReview.Vistas.Windows.Dialogos.DialogoNuevaSeccion
{
    /// <summary>
    /// Lógica de interacción para DialogoNuevaSeccionWindow.xaml
    /// </summary>
    public partial class DialogoNuevaSeccionWindow : Window
    {
        DialogoNuevaSeccionVM vm;
        public DialogoNuevaSeccionWindow()
        {
            vm = new DialogoNuevaSeccionVM();
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
