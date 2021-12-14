using System;
// Bring in System.IO so we can copy directories. Documentation referenced can be found here: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
using System.IO;

namespace NBS_Custom_JS_And_CSS_Helper
{
    class Program
    {

        // Create global variables to hold the names of the servers we will be working with
 

        /* DEV SERVER NAMES */
        // Note that there are a ton of backslashes because you need two to insert 1
        public static string DevServer1 = "\\\\10.0.5.71\\common\\custom";
        public static string DevServer2 = "\\\\10.0.5.74\\common\\custom";
        public static string DevServer3 = "\\\\10.0.5.76\\common\\custom";
        public static string DevServer4 = "\\\\10.0.5.77\\common\\custom";

        /**
         * Show the user the options.
         * Validate the user input.
         * Return the number of their response.
         * */
        static string ShowUserOptions()
        {
            // Define a variable to hold the user's choice
            string WhatUserWantsToDo = "";

            // Define a variable to check if the user's input is valid
            bool UserInputCorrect = false;

            // While the user input is not correct...
            while (!UserInputCorrect)
            {
                // Display the options to the user
                Console.WriteLine("TYPE THE NUMBER OF YOUR CHOICE AND PRESS ENTER \n" +
                    "1) Copy new JS and CSS files from one Dev server to all other DEV servers.\n" +
                    "2) Copy JS and CSS files from DEV servers to TEST servers.\n" +
                    "3) Copy JS and CSS files from TEST to PRODUCTION servers.\n" +
                    "4) See the server configurations.\n" +
                    "5) Learn how to use this App.\n");
                    
                // Get the user input
                WhatUserWantsToDo = Console.ReadLine();
                Console.WriteLine("");

                // Check if the user's input is valid
                switch (WhatUserWantsToDo)
                {
                    case "1":
                        UserInputCorrect = true;
                        break;
                    case "2":
                        UserInputCorrect = true;
                        break;
                    case "3":
                        UserInputCorrect = true;
                        break;

                    case "4":
                        UserInputCorrect = true;
                        break;

                    case "5":
                        UserInputCorrect = true;
                        break;
                }

                // If the user's input is not valid, display a message
                // and go through the loop again
                if (!UserInputCorrect)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please type a number from 1-5");
                    Console.WriteLine("");
                }

            }

            // Return the number of the user's choice
            return WhatUserWantsToDo;

        }



        /**
         * Copies a directory. Method taken from Microsoft Docs: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
         * */
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, string Environment)
        {

            // Tell the user what we're doing.
            Console.WriteLine("");
            Console.WriteLine($"Moving files to the {destDirName} server in the {Environment} environment...");
            Console.WriteLine("");

            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                try
                {
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("All other files are being copied over/overwritten...");
                }

            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs, Environment);
                }
            }
            
        }


        /**
         * Show the user the instructions on how to use the app.
         */
        static void ShowUserInstructions()
        {
            Console.WriteLine("");
            Console.WriteLine(
                "This app is meant to aid you in copying custom JavaScript and CSS files to and from different environments and servers.\n" +
                "First, choose the option needed for you. The options are as follows:\n" +
                "1) Copy new JS and CSS files from one Dev server to all other DEV servers. - This option copies the JS and CSS files you have manually created\n" +
                $"in the {DevServer1} server and copies them to the other 3 DEV servers for you.\n" +
                "2) Copy JS and CSS files from DEV servers to TEST servers. - This option copies the files from the DEV servers to all of the TEST servers.\n" +
                "3) Copy JS and CSS files from TEST to PRODUCTION servers.  - This option copies the files from the DEV servers to all of the TEST servers.\n" +
                "4) See the server configurations. - This option shows you the current filepaths the app is pointing to for each server.\n"
                );
            Console.WriteLine("");

        }



        /**
         * The Main Method
         */
        static void Main(string[] args)
        {
            bool ApplicationRunning = true;

            while(ApplicationRunning) {

                // Ask the user what they want to do
                Console.WriteLine("Welcome to the NBS-Custom-JS-And-CSS-Helper");
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("");

                // Call the ShowUserOptions method to get the user's input on how they would like to proceed
                string WhatUserWantsToDo = ShowUserOptions();

                // Using the user's input, call the necessary method
                switch (WhatUserWantsToDo)
                {
                    case "1":
                        // Copy contents of server 1 to the other 3 servers
                        DirectoryCopy(DevServer1, DevServer2, true, Environment: "Dev");
                        DirectoryCopy(DevServer1, DevServer3, true, Environment: "Dev");
                        DirectoryCopy(DevServer1, DevServer4, true, Environment: "Dev");
                        Console.WriteLine("");
                        Console.WriteLine("All Dev servers are now up to date.");
                        Console.WriteLine("");
                        break;
                    case "2":
                        // Copy contents of DEV server 1 to all TEST servers
                        Console.WriteLine("Feature not available");
                        break;
                    case "3":
                        // Copy contents of TEST server 1 to all PRODUCTION servers
                        Console.WriteLine("Feature not available");
                        break;
                    case "4":
                        Console.WriteLine($"The server configurations are as follows... \n" +
                            $"Dev Servers: {DevServer1}, {DevServer2}, {DevServer3}, and {DevServer4}");
                        break;
                    case "5":
                        ShowUserInstructions();
                        break;
                }

                // Check if user wants to keep app running...
                Console.WriteLine("Would you like to do something else? y/n");
                string UserWantsToKeepAppRunning = Console.ReadLine();
                if (UserWantsToKeepAppRunning == "n")
                {
                    // Close the app
                    ApplicationRunning = false;
                }
                

            }
            

        }






    }
}
