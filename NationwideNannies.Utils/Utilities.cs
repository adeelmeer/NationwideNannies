using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NationwideNannies.Logging;
using System.Web;
using System.Net.Mail;

namespace NationwideNannies.Utils
{
    public static class Utilities
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
                Log4NetLogger.ExceptionTrace(ex, "[Utilities]CreateFolder()");
                return false;
            }
        }

        public static string RemoveIlleglCharsFromFileName(string filename)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(c.ToString(), string.Empty);
            }

            return filename.Trim();
        }

        public static string SaveUploadedFile(string fullName, HttpPostedFileBase uploadedFile, string folderName)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                 uploadedFile == null ||
                 uploadedFile.InputStream == null ||
                string.IsNullOrWhiteSpace(uploadedFile.FileName))
            {
                return string.Empty;
            }

            fullName = Utilities.RemoveIlleglCharsFromFileName(fullName);

            string fileName = uploadedFile.FileName;

            string folder = HttpContext.Current.Server.MapPath("~/" + folderName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            string finalFileName = string.Format("{0}_{1}_{2}_{3}", fullName, fileNameWithoutExt, DateTime.Now.ToString("MMddyyyyHHmmss"), ext);

            string filePath = string.Format("{0}\\{1}", folder, finalFileName);

            SaveToFile(filePath, uploadedFile.InputStream);

            return finalFileName;
        }

        public static string GetAbsoluteFilePath(string folderName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(folderName) || string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string folder = HttpContext.Current.Server.MapPath("~/" + folderName);
            string fullPath = string.Format("{0}\\{1}", folder, fileName);
            return fullPath;
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

        public static void SendEmail(string toEmail, string subject, string body, List<string> attachmentFilePaths = null)
        {
            try
            {
                using (var message = new MailMessage())
                {



                    message.IsBodyHtml = true;
                    body = body.Replace(System.Environment.NewLine, "<br />");

                    if (attachmentFilePaths != null)
                    {

                        foreach (var path in attachmentFilePaths)
                        {
                            if (!string.IsNullOrWhiteSpace(path))
                                message.Attachments.Add(new Attachment(path));
                        }
                    }

                    message.Body = body;
                    message.Subject = subject;
                    message.To.Add(toEmail);

                    var client = new SmtpClient();
                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.ExceptionTrace(ex, "[Utilities]SendEmail()");
            }
        }
    }
}
