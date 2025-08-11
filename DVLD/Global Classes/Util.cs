using System;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Text;

namespace DVLD.Global_Classes
{
    public static class Util
    {
        // Handle images
        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        public static bool CreateFolderIfDoesNotExist(string folderPath)
        {
            if(!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extension = fi.Extension;
            return GenerateGUID() + extension;
        }
        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string destinationFolder = @"C:\DVLD-People-Images\";

            if(!CreateFolderIfDoesNotExist(destinationFolder)) return false;
            
            string destinationFile = destinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }
    }
}
