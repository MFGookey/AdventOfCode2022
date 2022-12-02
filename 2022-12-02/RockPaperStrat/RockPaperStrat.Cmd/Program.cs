using System;
using System.Linq;
using Common.Utilities.IO;
using RockPaperStrat.Core;

namespace RockPaperStrat.Cmd
{
  /// <summary>
  /// The entrypoint for RockPaperStrat.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// RockPaperStrat.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();
      var pairingFactory = new PairingFactory();
      var evaluator = new PairingEvaluator();
      var fileContent = reader.ReadFile(filePath);
      var pairings = pairingFactory.ParseStrategy(fileContent);
      Console.WriteLine(pairings.Select(p => evaluator.EvaluateScore(p)).Sum());

      var directedPairings = pairingFactory.ParseDirectedStrategy(fileContent);
      Console.WriteLine(directedPairings.Select(p => evaluator.EvaluateScore(p)).Sum());
      _ = Console.ReadLine();
    }
  }
}
