using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.GuardarHTML
{
    class SaveService
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
    saveFileDialog.DefaultExt = ".html";

    if (saveFileDialog.ShowDialog() == true)
    {
        string htmlContent = GenerateHTML();

        using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
        {
            streamWriter.Write(htmlContent);
        }
    }
}
