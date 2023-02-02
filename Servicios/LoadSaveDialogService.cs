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
    class LoadSaveDialogService
    {
        public string MostrarSaveDialogHTML()
        {
            GenerarHTML generar = new GenerarHTML();
            string htmlContent = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".html";

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;

            }

            return null;
        }


        public string MostrarOpenDialogImages()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return null;
        }
    }
}
