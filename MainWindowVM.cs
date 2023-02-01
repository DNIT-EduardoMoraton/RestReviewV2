using CommunityToolkit.Mvvm.ComponentModel;
using GestorRestReview.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestorRestReview
{
    class MainWindowVM : ObservableRecipient
    {
        private UserControl actualUserControl;

        public UserControl ActualUserControl
        {
            get { return actualUserControl; }
            set { SetProperty(ref actualUserControl, value); }
        }


        // Servicios

        private NavegacionServicio servicioNavegacion;

        public MainWindowVM()
        {
            servicioNavegacion = new NavegacionServicio();
            ActualUserControl = servicioNavegacion.IrHomeUSerControl();
        }
    }
}
