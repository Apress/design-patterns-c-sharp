using System;
using System.Collections.Generic;

namespace InterpreterPattern
{
    public class Context
    {
        //We will interpret an integer
        private int getInput;
        private string getStringInput;
        //We are printing it in the word form i.e. in String representation
        private string setOutput;
        //Flag-whether it is a valid input or not
        private bool canProceed = false;
        public bool CanProceed
        {
            get { return canProceed; }
        }
        //Using properties to get the input(readonly)
        public int GetInput
        {
            get { return getInput; }
            //set { input = value; }
        }

        //Using properties to get and set output
        public string SetOutput
        {
            get { return setOutput; }
            set { setOutput = value; }
        }
        //Our constructor
        public Context(string input)
        {
            this.getStringInput = input;
        }
        //We'll check whether it is a valid input that lies between 100 and 999
        public int ValidateUserInputBeforeProceedings(string inputString)
        {
            if (int.TryParse(inputString, out getInput))
            {
                Console.WriteLine("You have entered {0}", getInput);
                //Some basic validations
                if ((getInput < 100) || (getInput > 999))
                {
                    Console.WriteLine("Please enter a number between 100 and 999 and try again.");
                    //Just returning a 4-digit negative number to indicate a wrong input
                    return -9999;
                }
            }
            canProceed = true;
            return getInput;
        }
    }
    //abstract class-will hold the common code
    abstract class InputExpression
    {       
        public abstract void Interpret(Context context);        
    }

    class HundredExpression : InputExpression
    {
        public override void Interpret(Context context)
        {
            if (context.CanProceed)
            {
                int hundreds = context.GetInput / 100;
                switch (hundreds)
                {
                    case 1:
                        context.SetOutput += "One Hundred ";
                        break;
                    case 2:
                        context.SetOutput += "Two Hundred ";
                        break;
                    case 3:
                        context.SetOutput += "Three Hundred ";
                        break;
                    case 4:
                        context.SetOutput += "Four Hundred ";
                        break;
                    case 5:
                        context.SetOutput += "Five Hundred ";
                        break;
                    case 6:
                        context.SetOutput += "Six Hundred ";
                        break;
                    case 7:
                        context.SetOutput += "Seven Hundred ";
                        break;
                    case 8:
                        context.SetOutput += "Eight Hundred ";
                        break;
                    case 9:
                        context.SetOutput += "Nine Hundred ";
                        break;
                    default:
                        context.SetOutput += "* ";
                        break;
                }
            }
                
        }   
    }
    class TensExpression : InputExpression
    {
    public override void Interpret(Context context)
    {
            if (context.CanProceed)
            {
                int tens = context.GetInput % 100;
                //Process further by dividing it by 10
                tens = tens / 10;
                switch (tens)
                {
                    case 1:
                        context.SetOutput += "One Ten and ";
                        break;
                    case 2:
                        context.SetOutput += "Twenty ";
                        break;
                    case 3:
                        context.SetOutput += "Thirty ";
                        break;
                    case 4:
                        context.SetOutput += "Forty ";
                        break;
                    case 5:
                        context.SetOutput += "Fifty ";
                        break;
                    case 6:
                        context.SetOutput += "Sixty ";
                        break;
                    case 7:
                        context.SetOutput += "Seventy ";
                        break;
                    case 8:
                        context.SetOutput += "Eighty ";
                        break;
                    case 9:
                        context.SetOutput += "Ninety ";
                        break;
                    default:
                        context.SetOutput += String.Empty;
                        break;
                }
            }
        }
}        
    class UnitExpression : InputExpression
 {
        public override void Interpret(Context context)
        {
            if (context.CanProceed)
            {
                int units = context.GetInput % 100;
                //Process further to get the unit digit
                units = units % 10;
                switch (units)
                {
                    case 1:
                        context.SetOutput += "One";
                        break;
                    case 2:
                        context.SetOutput += "Two";
                        break;
                    case 3:
                        context.SetOutput += "Three";
                        break;
                    case 4:
                        context.SetOutput += "Four ";
                        break;
                    case 5:
                        context.SetOutput += "Five ";
                        break;
                    case 6:
                        context.SetOutput += "Six ";
                        break;
                    case 7:
                        context.SetOutput += "Seven ";
                        break;
                    case 8:
                        context.SetOutput += "Eight";
                        break;
                    case 9:
                        context.SetOutput += "Nine";
                        break;
                    default:
                        context.SetOutput += String.Empty;
                        break;
                }
            }
        }
 }

    //Client Class
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("***Interpreter Pattern Demo***\n");
            string inputString;
            //int userInput;
            Console.WriteLine("Enter a 3 digit number only (i.e. 100 to 999)");
            inputString = Console.ReadLine();
            //Context context = new Context(userInput);
            Context context = new Context(inputString);
            //Some basic validations before we proceed
            //Checking whether we can parse the string as an integer
            if (context.ValidateUserInputBeforeProceedings(inputString)!= -9999)
            {
                // Build the 'parse tree'
                List<InputExpression> expTree = new List<InputExpression>();
                expTree.Add(new HundredExpression());
                expTree.Add(new TensExpression());
                expTree.Add(new UnitExpression());            
                // Interpret the valid input
                foreach (InputExpression inputExp in expTree)
                {
                    inputExp.Interpret(context);
                }
                Console.WriteLine("Original Input {0} is interpreted as {1}", context.GetInput, context.SetOutput);
            }
            Console.ReadLine();
        }        
    }
}
