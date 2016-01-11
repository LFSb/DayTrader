using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DayTrader
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = args[0];

      Console.WriteLine("The best trades are {0}", DayTrade(
        input.Split(' ').Select(value => float.Parse(value, CultureInfo.InvariantCulture)
      )));

      Console.ReadLine();
    }


    private static String DayTrade(IEnumerable<float> convertedInput)
    {
      var inputArray = convertedInput.ToArray();

      var lowest = convertedInput.Min();

      var highestAfterLowest = inputArray.Skip(Array.IndexOf(inputArray, lowest) + 2).Max();

      return String.Format("{0} {1}", lowest.ToString(CultureInfo.InvariantCulture), highestAfterLowest.ToString(CultureInfo.InvariantCulture));
    }
  }
}
