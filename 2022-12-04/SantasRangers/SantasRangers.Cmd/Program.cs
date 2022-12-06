using System;
using Common.Utilities.IO;
using SantasRangers.Core;
using System.Linq;

namespace SantasRangers.Cmd
{
  /// <summary>
  /// The entrypoint for SantasRangers.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// SantasRangers.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();

      var ranges = reader.ReadFile(filePath).Split('\n', StringSplitOptions.RemoveEmptyEntries);

      var count = ranges.Where(r => RangeCalculator.RangesFullyOverlap(r)).Count();

      Console.WriteLine(count);

      count = ranges.Where(r => RangeCalculator.RangesOverlap(r)).Count();

      Console.WriteLine(count);

      _ = Console.ReadLine();
    }
  }
}
