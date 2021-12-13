using System;
// Bring in System.IO so we can copy directories. Documentation referenced can be found here: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
using System.IO;

namespace NBS_Custom_JS_And_CSS_Helper
{
    class Program
    {

        // Create global variables to hold the names of the servers we will be working with
        public static string ServerName1 = "";
        public static string ServerName2 = "";
        public static string ServerName3 = "";
        public static string ServerName4 = "";


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
                    "1) Copy new JS and CSS files to all DEV servers.\n" +
                    "2) Copy new JS and CSS files to all TEST servers.\n" +
                    "3) Copy new JS and CSS files to all PRODUCTION servers.\n" +
                    "4) See the server configurations.\n" +
                    "5) Learn how to use this App.\n");

                // Get the user input
                WhatUserWantsToDo = Console.ReadLine();

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
         *  Configures the names of the servers
         *  
         * */
        static void ConfigureServers(string Environment)
        {
            // Tell the user what we're doing.
            Console.WriteLine("");
            Console.WriteLine($"Moving files to all servers for the {Environment} environment");
            Console.WriteLine("");

            // Configuer the names of the servers based off of the environment
            switch (Environment)
            {
                case "Dev":
                    /* PROODUCTION SERVER NAMES */
                    // Note that there are a ton of backslashes because you need two to insert 1
                    /* 
                    ServerName1 = "\\\\10.0.5.71\\common\\custom";
                    ServerName2 = "\\\\10.0.5.74\\common\\custom";
                    ServerName3 = "\\\\10.0.5.76\\common\\custom";
                    ServerName4 = "\\\\10.0.5.77\\common\\custom";
                    */

                    // For tesing, we prompt the user for the directory path
                    Console.WriteLine("For testing purposes, please provide the first server name");
                    ServerName1 = Console.ReadLine();
                    Console.WriteLine($"Server 1 name: {ServerName1}");
                    Console.WriteLine("For testing purposes, please provide the second server name");
                    ServerName2 = Console.ReadLine();
                    break;
            }

        }


        /**
         * Copies a directory. Method taken from Microsoft Docs: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
         * */
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
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
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
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
                        ConfigureServers(Environment: "Dev");
                        //Microsoft docs example: DirectoryCopy(".", @".\temp", true);
                        // Copy server 1 to server 2
                        DirectoryCopy(ServerName1, ServerName2, true);
                        // Call the method again for servers 3 and 4 here...
                        break;
                    case "2":
                        Console.WriteLine("Feature not available");
                        break;
                    case "3":
                        Console.WriteLine("Feature not available");
                        break;
                    case "4":
                        Console.WriteLine("Feature not available");
                        break;
                    case "5":
                        Console.WriteLine("Feature not available");
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
