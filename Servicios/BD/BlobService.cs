using Azure.Storage.Blobs;
using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.BD
{
    class BlobService
    {
        public BlobService()
        {

        }
        public string download(string url)
        {
            string fileName = Path.GetFileName(new Uri(url).LocalPath);
            string path = "reciclebin/" + fileName;//Si la imagen del articulo tiene el mismo nombre
                                                   //que la foto de perfil del autor, da conflicto al guardarla

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
            return path;
        }
            
            
        

        public string upload(string path)
        {
            if (path == null)
            {
                return "";
            }

            if (!File.Exists(path))
            {
                return path;
            }



            string cadenaConexion = Properties.Resources.BlobCadenaConexion;
            string nombreContenedorBlobs = Properties.Resources.ContenedorDeBlobs;

            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            Stream streamFile = File.OpenRead(path);
            string filename = Path.GetFileName(path);

            try
            {

                clienteContenedor.UploadBlob(filename, streamFile);
            }
            catch (Azure.RequestFailedException)
            {
                // para que no salte la excepcion pero si es el mismo archivo se devolvera la misma url
            }



            var clienteBlobImagen = clienteContenedor.GetBlobClient(filename);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;


            return urlImagen;
        }
    }
}
