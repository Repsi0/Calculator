using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	class Calculator
	{
		static const string[] ops = {"+","-","*","/"}; // List of valid strings to look for when inputting operation
		static void Main(string[] args) // Main method
		{
			Console.WriteLine("Calculator"); // State the name of the application
			OperationType op = OperationType.NULL; // Initialize op to later store operation we are performing

			bool firstLoop = true; // This is the first time going through this loop, so yes
			do {
				if(!firstLoop) Console.WriteLine("Invalid operation. Please try again"); // If this wasn't our first time through this loop, then we've failed before
				Console.WriteLine("Please choose an operation from the following list: +, -, *, /"); // Tell the user what operations are available
				int foundAt = Array.IndexOf(ops, Console.ReadLine()); // What index is the inputted operation at in the ops string above?
				if(foundAt != -1) op = (OperationType) (foundAt+1); // If found, op is set to foundAt(+1 to account for the NULL OperationType)
				firstLoop=false; // This is no longer our first loop as we (possibly) move into the next
			} while(op == OperationType.NULL); // Repeat the previous code until op is no longer NULL
			firstLoop=true; // Reset firstLoop status
			do {
				if(!firstLoop) Console.WriteLine("That is not a number. Please try again"); // If this wasn't our first time through this loop, then we've failed before
				Console.WriteLine("Please choose first number"); // Tell the user what input is expected
				firstLoop=false; // No longer our first loop
			} while (!Double.TryParse(Console.ReadLine(), out double num1)); // Repeat the previous code until we actually can parse the number
			firstLoop=true; // Reset status
			double num2; // num2 variable to store the output
			bool success_parse,success_div0; success_parse=success_div0=true; // Declare two success states and set them both to default to true
			do {
				if(!firstLoop) { // If this wasn't our first loop (we had an error)
					if(!success_parse) Console.WriteLine("That is not a number. Please try again"); // ...And we failed due to parsing, tell the user what happened
					if(!success_div0)  Console.WriteLine("Cannot divide by 0. Please try again");   // ...OR  we failed due to a divide by zero error, tell the user what happened
				}
				Console.WriteLine("Please choose second number"); // Tell the user what input is expected
				success_parse = Double.TryParse(Console.ReadLine(), out num2); // Try to parse the output, and if we fail, set success_parse to false
				success_div0 = !(num2==0&&op==OperationType.DIV); // If num2 is 0 and we're dividing, then that's a divide by zero error, set success_div0 to false
				firstLoop=false; // No longer our first loop
			} while (!success_parse || !success_div0); // Repeat the above 
			
			Console.WriteLine($"{num1} {Op} {num2} = {RunOperation(num1,Op,num2)}"); // Run the operation and format it for human readability
			
			Console.WriteLine("Program finished. Press any key to close"); // Tell user that the program is done, and how to exit
			Console.ReadKey(); // Pause until a key is typed
		}
		public static double RunOperation(double a, OperationType op, double b) { // Runs a given operation on a and b
			switch(op) { // If op==... 
				case OperationType.ADD: // OperationType.ADD
					return a+b; // Then add the numbers and return the result as output
				case OperationType.SUB: // OperationType.SUB
					return a-b; // Then subtract the numbers and return the result as output
				case OperationType.MUL; // OperationType.MUL
					return a*b; // Then multiply the numbers and return the result as output
				case OperationType.DIV: // OperationType.DIV
					return a/b; // Then divide the numbers and return the result as output
				default: // Else, it must be either NULL (which can't get here), or an unimplemented operationtype
					throw new NotImplementedException($"The operation {op.ToString()} has not been implemented yet, sorry!");
			}
		}
	}
	// Enum containing all types of operations
	enum OperationType {
		NULL, // NULL = 0
		ADD, // ADD = 1
		SUB, // SUB = 2
		MUL, // MUL = 3
		DIV  // DIV = 4
	}
}
