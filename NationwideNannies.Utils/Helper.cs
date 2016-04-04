using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NationwideNannies.Logging;
using System.Web;

namespace NationwideNannies.Utils
{
    public static class Helper
    {
        public static bool CreateFolder(string folderName, bool inAppFolder = true)
        {
            if (string.IsNullOrWhiteSpace(folderName))
            {
                return false;
            }

            if (inAppFolder)
            {
                folderName = HttpContext.Current.Server.MapPath(folderName);
            }

            try
            {
                Directory.CreateDirectory(folderName);
                return true;
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[Helper]CreateFolder()");
                return false;
            }
        }

        public static void SaveUploadedFile(string firstName, string LastName, HttpPostedFileBase uploadedFile, string folderName)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(LastName) ||                
                uploadedFile == null||
                 uploadedFile.InputStream == null||
                string.IsNullOrWhiteSpace(uploadedFile.FileName))
            {
                return;
            }

            string fileName = uploadedFile.FileName;

            string folder = HttpContext.Current.Server.MapPath("~/" + folderName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            string filePath = string.Format("{0}\\{1}_{2}_{3}_{4}{5}", folder, firstName, LastName, fileNameWithoutExt, DateTime.Now.ToString("MMddyyyyHHmmss"), ext);

            SaveToFile(filePath, uploadedFile.InputStream);
        }

        public static void SaveToFile(string fullFilePath, Stream stream)
        {
            try
            {
                if (stream == null || stream.Length == 0 || string.IsNullOrWhiteSpace(fullFilePath))
                {
                    return;
                }

                using (FileStream fileStream = File.Create(fullFilePath, (int)stream.Length))
                {
                    // Initialize the bytes array with the stream length and then fill it with data
                    byte[] bytesInStream = new byte[stream.Length];
                    stream.Read(bytesInStream, 0, bytesInStream.Length);
                    // Use write method to write to the file specified above
                    fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("[Helper]SaveToFile() fullFilePath:{0}", fullFilePath);
                Log4NetLogger.ExceptionTrace(ex, message);
            }
        }
    }
}
