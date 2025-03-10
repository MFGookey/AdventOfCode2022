using System;
using Common.Utilities.IO;
//using PortOfHanoi.Core;

namespace PortOfHanoi.Cmd
{
  /// <summary>
  /// The entrypoint for PortOfHanoi.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// PortOfHanoi.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();
      Console.WriteLine(reader.ReadFile(filePath).Length);
      _ = Console.ReadLine();
    }
  }
}
