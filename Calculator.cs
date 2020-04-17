using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	class Calculator
	{
		static string[] ops = {"+","-","*","/"};
		static void Main(string[] args)
		{
			Console.WriteLine("Calculator");
			OperationType op = OperationType.NULL;

			bool firstLoop = true;
			do {
				if(!firstLoop) Console.WriteLine("Invalid operation. Please try again");
				Console.WriteLine("Please choose an operation from the following list: +, -, *, /");
				int foundAt = Array.IndexOf(ops, Console.ReadLine());
				if(foundAt != -1) op = (OperationType) (foundAt+1); // +1 to account for the NULL OperationType
				firstLoop=false;
			} while(op == OperationType.NULL);
			firstLoop=true;
			do {
				if(!firstLoop) Console.WriteLine("That is not a number. Please try again");
				Console.WriteLine("Please choose first number");
				firstLoop=false;
			} while (!Double.TryParse(Console.ReadLine(), out double num1));
			firstLoop=true;
			double num2;
			bool success_parse,success_div0; success_parse=success_div0=true;
			do {
				if(!firstLoop) {
					if(!success_parse) Console.WriteLine("That is not a number. Please try again");
					if(!success_div0)  Console.WriteLine("Cannot divide by 0. Please try again");
				}
				Console.WriteLine("Please choose second number");
				firstLoop=false;
				success_parse = Double.TryParse(Console.ReadLine(), out num2);
				success_div0 = (num2==0&&op==OperationType.DIV);
			} while (!success_parse || !success_div0);
			
			Console.WriteLine($"{num1} {Op} {num2} = {RunOperation(num1,Op,num2)}");

			Console.WriteLine("Program finished. Press any key to close");
			Console.ReadKey();
		}
		public static double RunOperation(double a, OperationType op, double b) {
			switch(op) {
				case OperationType.ADD:
					return a+b;
				case OperationType.SUB:
					return a-b;
				case OperationType.MUL;
					return a*b;
				case OperationType.DIV:
					return a/b;
				default:
					throw new NotImplementedException($"The operation {op.ToString()} has not been implemented yet, sorry!");
			}
		}
	}
	enum OperationType {
		NULL,
		ADD,
		SUB,
		MUL,
		DIV
	}
}
