using Azure.Storage.Blobs;
using GestorRestReview.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Servicios.BD
{
    class BlobService
    {
        public BlobService()
        {

        }


        public string upload(string path)
        {
            if (path == null)
            {
                return "";
            }



            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=trivialedu;AccountKey=ZLNCSVkZB/C4pBLnbUODrNZwNQOfYMq6Jo7MGAgQm2eSunYX/3eFWLAkzMCPtZwvjIZFTyduzis0+AStiwWiQw==;EndpointSuffix=core.windows.net";
            string nombreContenedorBlobs = "trivial";



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
