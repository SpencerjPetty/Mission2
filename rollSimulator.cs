using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission2
{
    public static class rollSimulator // Create a static class for the roll simulator
    {
        public static int[] SimulateRolls(int numRolls) // Method to simulate dice rolls
        {
            Random random = new Random(); // Create a new instance of the Random class

            int[] rolls = new int[13]; // Create an array to store the roll results

            for (int i = 0; i < numRolls; i++) // Loop through the number of die rolls
            {
                int tempRoll1 = random.Next(1, 7);// Generate a random number between 1 and 6 for the first die
                int tempRoll2 = random.Next(1, 7);// Generate a random number between 1 and 6 for the second die
                int rollSum = tempRoll1 + tempRoll2; // Calculate the sum of the two dice rolls
                rolls[rollSum]++; // Increment the corresponding index in the rolls array
            }
            return rolls; // Return the array of roll results to the main program
        }
    }
}
