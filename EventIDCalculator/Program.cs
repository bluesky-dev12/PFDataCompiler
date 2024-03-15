using System;
using System.Diagnostics;

class Program
{
    static int HexToDecimal(string hex)
    {
        return Convert.ToInt32(hex, 16);
    }

    static string DecimalToHex(int decimalNum)
    {
        return Convert.ToString(decimalNum, 16).ToUpper();
    }

    static Tuple<string, int> PerformBitwiseOR(string hexNum1, string hexNum2)
    {
        int decimalNum1 = HexToDecimal(hexNum1);
        int decimalNum2 = HexToDecimal(hexNum2);
        int resultDecimal = decimalNum1 | decimalNum2;
        string resultHex = DecimalToHex(resultDecimal);
        return Tuple.Create(resultHex, resultDecimal);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter you MPF-ID: ");
        string hexNum1 = Console.ReadLine();

        Console.Write("Now the hex eventID: ");
        string hexNum2 = Console.ReadLine();

        Tuple<string, int> result = PerformBitwiseOR(hexNum1, hexNum2);

        Console.WriteLine($"Your EventID: {result.Item2} copy this to you OGVI.");

        Process.GetCurrentProcess().WaitForExit();
    }
}