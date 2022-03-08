using System;
using System.Collections.Generic;
using System.Numerics;

namespace TDETestTask3b
{
	enum coefs : int
	{
		W = 10,
		Z = 20
	}
	class PARCalculator
	{
		public double ParCalculation(List<Complex> inputIQ)
		{
			double rmsVal = getRMSPower(inputIQ);
			double peakVal = getPeakPower(inputIQ);

			//convert both values to dB based on impedance
			//if inputIQ was based on voltage, then use "v" taking into account the Vin
			rmsVal = dBConverter(rmsVal, "Z");
			peakVal = dBConverter(peakVal, "Z");

			Console.WriteLine();
			Console.WriteLine(rmsVal + " dB");
			Console.WriteLine(peakVal + " dB");

			double par = peakVal - rmsVal; //PAR in dB

			return par;
		}

		private double dBConverter(double rawVal, string unit = "")
		{
			const int RefZ = 50;
			const int RefP = 1;
			const int RefV = 1;
			double output = 0;

			//default case assumes voltage values
			if (unit.Contains(coefs.W.ToString()))
			{
				output = Math.Log10(rawVal / RefP);
				output = ((int)coefs.W) * output;
			}
			else if (unit.Equals(coefs.Z.ToString()))
			{
				output = Math.Log10(rawVal / RefZ);
				output = ((int)coefs.Z) * output;
			}
			else
			{
				output = Math.Log10(rawVal / RefV);
				output = ((int)coefs.Z) * output; //coef for Z and V are the same
			}

			return output;
		}

		private double getRMSPower(List<Complex> inputIQ)
		{
			double meanVal = 0;
			double sumVal = 0;
			double rmsVal = 0;
			
			foreach(Complex cn in inputIQ)
			{
				sumVal += Complex.Abs(cn);
			}

			meanVal = sumVal / inputIQ.Count;
			rmsVal = Math.Sqrt(meanVal);
			Console.WriteLine(rmsVal);

			return rmsVal;
		}

		private double getPeakPower(List<Complex> inputIQ)
		{
			List<Double> absData = new List<Double>(inputIQ.Count);

			foreach(Complex iqData in inputIQ)
			{
				absData.Add(Complex.Abs(iqData));
			}

			absData.Sort();
			absData.Reverse();

			double peakPower = absData[0];
			Console.WriteLine(peakPower);

			return peakPower;
		}
	}
}
