using System;
using System.Collections.Generic;

namespace Aufgabe_5
{
    // Author: Dirk Mueller
    // Date: 15.03.2021
    //
    // Algorithm:
    // 1. Take the input from the user and check the validity of it
    // 2. Each row (starting with 1) to be printed is a combination of spaces and star symbols
    // 3. There are spaces as much as triangle height minus row number
    // 4. The amount of stars is 1, 3, 5, 7,... in rows 1, 2, 3, 4, 5, respectively
    //
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
            // String to be constructed for each row on the screen printout:
            string rowString;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Give the height - not more than 60 - of the triangle (exit with 0): ");
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

                // Thi outer loop addresses each row of the triangle:
                for (int rowNumber = 1; rowNumber <= heightTriangle; rowNumber++)
                {
                    // Empty the string always at the beginning:
                    rowString = "";
                    // Depending on the row number draw spaces, the further up in the triangle the more:
                    for (int j = heightTriangle - rowNumber; j > 0; j--)
                    {
                        // Append a space in front of the star(s):
                        rowString += " ";
                    }
                    // Create a sequence of 1, 3, 5, 7, 9, ... stars:
                    // 
                    for (int j = rowNumber * 2 - 1; j > 0; j--)
                    {
                        // Append a star symbol to any existing star:
                        rowString += "*";
                    }
                    // Draw the whole line:
                    Console.WriteLine(rowString);
                }
            }
        }
        // Return false if input cannot be processed, and true when input was correct:
        static Boolean Input_Accepted(string strInput)
        {
            int number;
            bool result = Int32.TryParse(strInput, out number);

            // Catch the case where the number is beyond the range ±5.0 × 10−^324 to ±1.7 × 10^308:
            if (number > 60)
            {
                Console.WriteLine("Number is beyond the upper limit of 60.");
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
