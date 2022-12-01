using System;
using System.Linq;
using Common.Utilities.IO;
using ElfEdibles.Core;

namespace ElfEdibles.Cmd
{
  /// <summary>
  /// The entrypoint for ElfEdibles.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// ElfEdibles.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();

      var calc = new ElfCalc(reader.ReadFile(filePath));
      Console.WriteLine(calc.FindSnackPackingestElf().GetCaloriesCarried());

      Console.WriteLine(Enumerable.Range(0, 3).Select(x => calc.FindNthSnackPackingestElf(x).GetCaloriesCarried()).Sum());
      _ = Console.ReadLine();
    }
  }
}
