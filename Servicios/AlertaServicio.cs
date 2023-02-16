using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestorRestReview.Servicios
{

    /// <summary>
    /// Clase para mostrar alertas y mensajes en ventanas emergentes.
    /// </summary>
    class AlertaServicio
    {

        /// <summary>
        /// Crea una nueva instancia de la clase AlertaServicio.
        /// </summary>
        public AlertaServicio()
        {
            
        }

        /// <summary>
        /// Muestra un mensaje de confirmación en una ventana emergente con los botones "Sí" y "No".
        /// </summary>
        /// <param name="pregunta">La pregunta a mostrar en el mensaje.</param>
        /// <returns>true si el usuario presionó "Sí"; de lo contrario, false.</returns>
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

        /// <summary>
        /// Muestra un mensaje de error en una ventana emergente con el botón "OK".
        /// </summary>
        /// <param name="mensajeError">El mensaje de error a mostrar.</param>
        /// <returns>true si el usuario presionó "OK"; de lo contrario, false.</returns>
        public bool MessageBoxError(string mensajeError)
        {
            MessageBoxResult result = MessageBox.Show(mensajeError, "OK", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            return true;
        }

    }
}


