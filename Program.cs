using System;
using System.Numerics;
using System.Collections.Generic;

namespace TDETestTask3b
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Complex> complexNumbers = new List<Complex>();

			complexNumbers.Add(new Complex(12, 35));
			complexNumbers.Add(new Complex(1, 5));
			complexNumbers.Add(new Complex(20, 3));
			complexNumbers.Add(new Complex(120, 100));
			complexNumbers.Add(new Complex(9, 24));
			complexNumbers.Add(new Complex(21, 53));
			complexNumbers.Add(new Complex(39, 63));
			complexNumbers.Add(new Complex(17, 55));

			Console.WriteLine("(real, imag) : Abs");

			foreach (Complex complexNumber in complexNumbers)
			{
				Console.WriteLine(complexNumber +" : "+ Complex.Abs(complexNumber));
			}

			Console.WriteLine();
			Console.WriteLine(complexNumbers.Count);
			Console.WriteLine();

			PARCalculator calculator = new PARCalculator();
			double par = calculator.ParCalculation(complexNumbers);

			Console.WriteLine();
			Console.WriteLine(par + " dB");
		}
	}
}
