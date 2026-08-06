using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Utils
{
    internal class ClsUtils
    {
        static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

         static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }
        static string GenerateFolderPath(string FileName)
        {
            FileInfo fileInfo = new FileInfo(FileName);

            string Ex = fileInfo.Extension;

            return (GenerateGUID() + Ex);
        }

        public static bool SaveImageInOurFile(ref string OldPathImage)
        {
            string PathFolder = @"C:\Users\Hp\Desktop\DVLD\DVLD\DVLD-Image\";

            if (!CreateFolderIfDoesNotExist(PathFolder))
                return false;


            string newImagePath = PathFolder + GenerateFolderPath(OldPathImage);

            try
            {
                File.Copy(OldPathImage, newImagePath, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            OldPathImage = newImagePath;

            return true;
        }
    }
}
