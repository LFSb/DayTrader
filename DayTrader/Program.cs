using System;
using System.Globalization;
using System.Linq;

namespace DayTrader
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = args[0];

      Console.WriteLine("The best trades are {0}", 
        DayTrade(
          input.Split(' ').Select(value => float.Parse(value, CultureInfo.InvariantCulture)).ToArray()
        )
      );

      Console.ReadLine();
    }


    private static String DayTrade(float[] convertedInput)
    {
      var lowest = convertedInput.Min();

      var highestAfterLowest = convertedInput.Skip(Array.IndexOf(convertedInput, lowest) + 2).Max(); // + 1 to begin searching after the lowest value, +1 to take into account it can never be the next value.

      return String.Format(CultureInfo.InvariantCulture, "{0} {1}", lowest, highestAfterLowest);
    }
  }
}
