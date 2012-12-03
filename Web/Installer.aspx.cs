using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;
using System.IO;

namespace Installer
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] == "compress")
            {
                //GZip.Compress(Server.MapPath("/"), Server.MapPath("/"), "/web.zip");
            }
            else
            {
                //GZip.Decompress(Server.MapPath("/"), Server.MapPath("/"), "/web.zip");
                //Decompress(Server.MapPath("/web.zip"), Server.MapPath("/"));
            }
        }

        public static void Compress(string filePath, string zipPath)
        {
            FileStream sourceFile = File.OpenRead(filePath);
            FileStream destinationFile = File.Create(zipPath);
            byte[] buffer = new byte[sourceFile.Length];
            GZipStream zip = null;
            try
            {
                sourceFile.Read(buffer, 0, buffer.Length);
                zip = new GZipStream(destinationFile, CompressionMode.Compress);
                zip.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                zip.Close();
                sourceFile.Close();
                destinationFile.Close();
            }
        }

        public static void Decompress(string zipPath, string filePath)
        {
            FileStream sourceFile = File.OpenRead(zipPath);

            string path = filePath.Replace(Path.GetFileName(filePath), "");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileStream destinationFile = File.Create(filePath);
            GZipStream unzip = null;
            byte[] buffer = new byte[sourceFile.Length];
            try
            {
                unzip = new GZipStream(sourceFile, CompressionMode.Decompress, true);
                int numberOfBytes = unzip.Read(buffer, 0, buffer.Length);

                destinationFile.Write(buffer, 0, numberOfBytes);
            }
            catch
            {
                throw;
            }
            finally
            {
                sourceFile.Close();
                destinationFile.Close();
                unzip.Close();
            }
        }


        public static void CompressFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException();
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] buffer = new byte[sourceStream.Length];
                int checkCounter = sourceStream.Read(buffer, 0, buffer.Length);
                if (checkCounter != buffer.Length) throw new ApplicationException();
                using (FileStream destinationStream = new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (GZipStream compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true))
                    {
                        compressedStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        public static void DecompressFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException();
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
            {
                byte[] quartetBuffer = new byte[4];
                int position = (int)sourceStream.Length - 4;
                sourceStream.Position = position;
                sourceStream.Read(quartetBuffer, 0, 4);
                sourceStream.Position = 0;
                int checkLength = BitConverter.ToInt32(quartetBuffer, 0);
                byte[] buffer = new byte[checkLength + 100];
                using (GZipStream decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true))
                {
                    int total = 0;
                    for (int offset = 0; ; )
                    {
                        int bytesRead = decompressedStream.Read(buffer, offset, 100);
                        if (bytesRead == 0) break;
                        offset += bytesRead;
                        total += bytesRead;
                    }
                    using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create))
                    {
                        destinationStream.Write(buffer, 0, total);
                        destinationStream.Flush();
                    }
                }
            }
        }
    }
}