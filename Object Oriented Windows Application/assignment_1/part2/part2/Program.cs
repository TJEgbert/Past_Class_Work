using System;

namespace part2
{
    /// <summary>
    /// Runs the Main function to run the program
    /// </summary>
    class Program
    {
        static void Main()
        {
            // variables to store users passed in integers
            int num1;
            int num2;
            
            // Asks user for input and stores it in num1
            Console.Write("Please enter first number: ");
            num1 = int.Parse(Console.ReadLine());

            // Asks user for input and stores it in num2
            Console.Write("Please enter second number: ");
            num2 = int.Parse(Console.ReadLine());

            // Perform math operations on num1 and num 2
            Console.WriteLine("Math operations on " + num1 + " and " + num2);
            Console.WriteLine(num1.ToString() + " + " + num2.ToString() + " = " + (num1 + num2));
            Console.WriteLine(num1.ToString() + " - " + num2.ToString() + " = " + (num1 - num2));
            Console.WriteLine(num1.ToString() + " * " + num2.ToString() + " = " + (num1 * num2));
            Console.WriteLine(num1.ToString() + " / " + num2.ToString() + " = " + (num1 / num2));
            Console.WriteLine(num1.ToString() + " % " + num2.ToString() + " = " + (num1 % num2));

            // If num1 greater than or equal to num2 
            if (num1 > num2)
            {
                Console.WriteLine(num1 + " is not less than " + num2); 
                Console.WriteLine(num1 + " is greater than " + num2);
                Console.WriteLine(num1 + " Does not equal" + num2);
            }
        }
    }
}
