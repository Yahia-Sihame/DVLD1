using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DVLD_Buisness_Layer
{
    public static class ClsGlobalUser
    {
        static public ClsUser GlobalUser;

        static public bool RememberUsernameAndPassword(string UserName, string Password)
        {
            try
            {
                string _CurrentPath = System.IO.Directory.GetCurrentDirectory();

                string Path = _CurrentPath + @"\data.txt";

                if (UserName == string.Empty && File.Exists(Path))
                {
                    File.Delete(Path);
                    return true;
                }

                string dataToSave = UserName + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(Path))
                {
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        static public bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + @"\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        }
}
