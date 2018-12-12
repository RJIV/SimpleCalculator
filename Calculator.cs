/******************************************************************************
Simple calculator program that keeps a running tally of previous calculations.
Continuously takes user input until prompted to quit. Supports +, -, *, /, and
exponentiation of floating point and integer numbers. Also has a built-in 
feature to catch divide by zero exceptions.

@author R.J. Hamilton
@version December 2019
******************************************************************************/

using System;
using System.Collections.Generic;

namespace SampleCalculator
{
    public class Calculator
    {
        List<float> tally;        //Tally of the computation results.
        bool isRunning;           //Check to see if the calculator is running

        public Calculator()
        {
            this.tally = new List<float>();
            isRunning = true;
        }

        
        /**********************************************************************
        Main method that creates a calculator object and executes the
        starting procedure.
        **********************************************************************/
        public static void Main(string[] args)
        {
            Calculator calc1 = new Calculator();
            while (calc1.isRunning)
            {
                calc1.Start();
            }
        }

        /**********************************************************************
        Start method displays the text that presents the user with all of the
        different options to use the calculator.
        **********************************************************************/
        public void Start()
        {
            Console.WriteLine("Please enter values that you wish to compute.\n" +
                              "Please use the following format: 3 + 5\n\n" +
                              "To quit press q.\nTo show the running tally, press t.\n" +
                              "------------------------------------------------");
            string userInput = Console.ReadLine();
            Console.Write("\n");

            if (userInput == "q")
            {
                Quit();
            }
            else if (userInput == "t")
            {
                ShowTally();
            }
            else if (userInput == "clear")
            {
                Console.Clear();
            }
            else
            {
                try
                {
                    //Reads the input from the user and attemps to split the string into
                    //usable pieces for our calculator.
                    string[] seperatedInput = userInput.Split(null);
                    float x = float.Parse(seperatedInput[0]);
                    float y = float.Parse(seperatedInput[2]);
                    string mathOperator = seperatedInput[1];

                    Compute(x, mathOperator, y);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nPlease use the following examples as the proper format:\n" +
                                      "1 + 1\n2 - 2\n4 / 2\n5 * 5\n");
                }
            }
        }

        /**********************************************************************
        Displays all of the previous results from our computations.
        **********************************************************************/
        public void ShowTally()
        {
            if (tally.Count == 0)
            {
                Console.WriteLine("There are currently no values in the tally.");
            }
            else
            {
                Console.WriteLine("The values stored in the tally are:\n");
                tally.ForEach(Console.WriteLine);
                Console.WriteLine("\n");
            }
        }

        /**********************************************************************
        Performs the math involved with the desired operation selected by the 
        user. Also displays the result as an output.
        **********************************************************************/
        public void Compute(float x, string mathOperator, float y)
        {
            switch (mathOperator)
            {
                case "+":
                    float total = Addition(x, y);
                    Console.WriteLine("Result: " + x + " + " + y + " = " + total + "\n");
                    tally.Add(total);
                    break;
                case "-":
                    total = Subtract(x, y);
                    Console.WriteLine("Result: " + x + " - " + y + " = " + total + "\n");
                    tally.Add(total);
                    break;
                case "*":
                    total = Multiply(x, y);
                    Console.WriteLine("Result: " + x + " * " + y + " = " + total + "\n");
                    tally.Add(total);
                    break;
                case "/":
                    total = Divide(x, y);
                    Console.WriteLine("Result: " + x + " / " + y + " = " + total + "\n");
                    tally.Add(total);
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }
        
        public float Addition(float x, float y)
        {
            float sum = x + y;
            return sum;
        }

        public float Subtract(float x, float y)
        {
            float sum = x - y;
            return sum;
        }

        public float Multiply(float x, float y)
        {
            float sum = x * y;
            return sum;
        }

        public float Divide(float x, float y)
        {
            if (y == 0)
            {
                Console.WriteLine("Cannot divide by zero.\n");
                Start();
                return 0;
            }
            else
            {
                float sum = x / y;
                return sum;
            }
        }

        public void Quit()
        {
            Console.WriteLine("Are you sure you want to quit? (y/n)");
            string decision = Console.ReadLine();
            if (decision == "y" || decision == "Y")
            {
                System.Environment.Exit(1);
            }
        }
    }
}
