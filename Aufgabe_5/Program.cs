using System;
using System.Collections.Generic;

namespace Aufgabe_5
{
    // Author: Dirk Mueller
    // Date: 15.03.2021
    //
    // Algorithm:
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("* This program draws an isosceles triangle onto the console                    *");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine();

            string strInput;
            int heightTriangle;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Give the height - less than 100 - of the triangle (exit with 0): ");
                strInput = Console.ReadLine();

                // The case for exit:
                if (strInput == "0")
                    break;

                // When input was not acceptable:
                if (!Input_Accepted(strInput))
                {
                    Console.WriteLine("Input not accepted. Please try again!");
                    continue;
                }
                heightTriangle = Int32.Parse(strInput);
                Console.WriteLine();
                string lineString;

                for (int i = 1; i <= heightTriangle; i++)
                {
                    lineString = "";
                    for (int j = heightTriangle - i; j > 0; j--)
                    { 
                        // Draw spaces:
                        lineString += " ";
                    }
                    for (int j = i * 2 - 1; j > 0; j--)
                    { 
                        // Draw star symbols:
                        lineString += "*";
                    }
                    Console.WriteLine(lineString);
                }
            }
        }
        // Return false if input cannot be processed, and true when input was correct:
        static Boolean Input_Accepted(string strInput)
        {
            int number;
            bool result = Int32.TryParse(strInput, out number);

            // Catch the case where the number is beyond the range ±5.0 × 10−^324 to ±1.7 × 10^308:
            if (number >= 100)
            {
                Console.WriteLine("Number is beyond the upper limit of 100.");
                return false;
            }

            if (number < 0)
            {
                Console.WriteLine("Number is negative.");
                return false;
            }

            // Input from the parsing function accepted:
            if (result)
            {
                Console.WriteLine("Your input was {0}", number);
                return true;
            }

            // Return false when input contained at least one character that is not a number:
            else
            {
                Console.WriteLine("Your input was not an integer.");
                return false;
            }
        }
    }
}
