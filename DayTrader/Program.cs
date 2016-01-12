using System;
using System.Globalization;
using System.Linq;

namespace DayTrader
{
  internal class Program
  {
    private static void Main(string[] args)
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

      var lowestIndex = Array.IndexOf(convertedInput, lowest);

      if (lowestIndex >= convertedInput.Length - 2)
        //If the index of the smallest value within the sequence is either the second to last or the last value, there can never be a bigger value afterwards, so return the lowest.
        return String.Format(CultureInfo.InvariantCulture, "{0}, no highest was found.", lowest);

      var highestAfterLowest = convertedInput.Skip(Array.IndexOf(convertedInput, lowest) + 2).Max();
      // + 1 to begin searching after the lowest value, +1 to take into account it can never be the next value.

      return String.Format(CultureInfo.InvariantCulture, "{0} {1}", lowest, highestAfterLowest);
    }
  }
}