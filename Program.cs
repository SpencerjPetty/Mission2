using System.Diagnostics;
using System.Linq;
using Mission2;

// Welcome message
Console.WriteLine("Welcome to the Dice Throwing Simulator 9000!");

bool isValidInput = false; // Flag to track if input is valid
int dieRolls = 0;          // Declare dieRolls outside the if block

while (!isValidInput) // Loop until input is valid
{
    Console.WriteLine("How many dice would you like to throw today?");
    bool success = int.TryParse(Console.ReadLine(), out dieRolls); // Try to parse input

    if (success && dieRolls > 0) // Ensure a positive number
    {
        isValidInput = true; // Exit the loop if input is valid
        int[] rollResults = rollSimulator.SimulateRolls(dieRolls); // Call the SimulateRolls method and assign the result to rollResults
        int[] rollPercentage = rollResults.Select(x => x * 100 / dieRolls).ToArray(); // Calculate the percentage of each roll

        for (int i = 2; i < rollPercentage.Length; i++) // Loop through the rollPercentage array
        {
            string percentage = new string('*', rollPercentage[i]); // Create a string of '*' characters based on the percentage
            Console.WriteLine(i + ": " + percentage); // Display the roll number and the corresponding percentage
        }

        Console.WriteLine("\nWould you like to throw the dice again? (Y/N)"); // Check if the user wants to restart the program
        string response = Console.ReadLine().ToUpper(); // Convert the response to uppercase for case-insensitive comparison
        if (response == "Y") // Restart the program if the user enters 'Y'
        {
            RestartProgram();
        }
        else if (response != "N") // Display an error message for invalid input
        {
            Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
        }
        else // Exit the program if the user enters 'N'
        {
            Console.WriteLine("Thank you for using the Dice Throwing Simulator 9000!");
        }
    }
    else // Display an error message for invalid input
    {
        Console.WriteLine("Invalid input. Please enter a positive whole number.");
    }
}

static void RestartProgram() // Method to restart the program
{
    Console.WriteLine("\nRestarting program...");

    // Get the current process file path
    string filePath = Process.GetCurrentProcess().MainModule.FileName;

    // Start a new instance of the program
    Process.Start(filePath);

    // Exit the current instance
    Environment.Exit(0);
}
