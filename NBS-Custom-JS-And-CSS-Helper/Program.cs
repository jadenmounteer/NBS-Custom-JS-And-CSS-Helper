using System;

namespace NBS_Custom_JS_And_CSS_Helper
{
    class Program
    {

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

            return WhatUserWantsToDo;

        }


        /**
         * The Main Method
         */
        static void Main(string[] args)
        {
            // Ask the user what they want to do
            Console.WriteLine("Welcome to the NBS-Custom-JS-And-CSS-Helper");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("");
            
            // Define a variable to track the user's input
            string WhatUserWantsToDo = "";

            // Call the ShowUserOptions method to get the user's input on how they would like to proceed
            WhatUserWantsToDo = ShowUserOptions();


            // Using the user's input, call the necessary method
            switch (WhatUserWantsToDo)
            {
                case "1":
                    Console.WriteLine("User wants to dev");
                    break;
            }


        }






    }
}
