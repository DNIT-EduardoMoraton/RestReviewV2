using Microsoft.Win32;
using RestReviewV2.Servicios.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.GuardarHTML
{
    class SaveService
    {
        public void MostrarSaveDialog()
        {
            GenerarHTML generar = new GenerarHTML();
            string htmlContent = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".html";

            if (saveFileDialog.ShowDialog() == true)
            {
                htmlContent = generar.ReturnHTML();

            }

            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
            {
                streamWriter.Write(htmlContent);
            }
        }

    }
}
