using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestorRestReview.Servicios
{
    class AlertaServicio
    {
        public AlertaServicio()
        {
            
        }

        public bool MessageBoxCambio(string pregunta)
        {
            MessageBoxResult result = MessageBox.Show(pregunta, "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MessageBoxError(string mensajeError)
        {
            MessageBoxResult result = MessageBox.Show(mensajeError, "OK", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            return true;
        }

    }
}


