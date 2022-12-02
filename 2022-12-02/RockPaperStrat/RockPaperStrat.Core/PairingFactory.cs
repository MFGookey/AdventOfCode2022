using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperStrat.Core.Models;

namespace RockPaperStrat.Core
{
  public class PairingFactory
  {
    private readonly IReadOnlyDictionary<char, Move> _opponentMoveMapping;
    private readonly IReadOnlyDictionary<char, Move> _playerMoveMapping;

    public PairingFactory() : this(PairingFactory.DefaultOpponentMoveMapping, PairingFactory.DefaultPlayerMoveMapping) { }

    public PairingFactory(
      IReadOnlyDictionary<char, Move> opponentMoveMapping,
      IReadOnlyDictionary<char, Move> playerMoveMapping
    )
    {
      _opponentMoveMapping = opponentMoveMapping;
      _playerMoveMapping = playerMoveMapping;
    }

    public IEnumerable<Pairing> ParseStrategy(string strategy)
    {
      var strategems = strategy.Split('\n', StringSplitOptions.RemoveEmptyEntries);

      var pairings = new Queue<Pairing>();

      foreach (var strategem in strategems)
      {
        pairings.Enqueue(this.ParseStrategem(strategem));
      }

      return pairings;
    }

    public Pairing ParseStrategem(string strategem)
    {
      var moves = strategem.Split(' ', StringSplitOptions.RemoveEmptyEntries);
      if (moves.Length != 2 || moves.Any(m => m.Length != 1))
      {
        throw new ArgumentException($"strategem must be of the form \"x y\" where x and y are single characters and are separated by a single space.  Supplied strategem: \"{strategem}\"");
      }

      var opponentMove = MapMove(moves[0].ToCharArray()[0], _opponentMoveMapping);
      var playerMove = MapMove(moves[1].ToCharArray()[0], _playerMoveMapping);

      return new Pairing(playerMove, opponentMove);
    }

    public static readonly IReadOnlyDictionary<char, Move> DefaultOpponentMoveMapping = new Dictionary<char, Move>
    {
      { 'A', Move.Rock },
      { 'B', Move.Paper },
      { 'C', Move.Scissors }
    };

    public static readonly IReadOnlyDictionary<char, Move> DefaultPlayerMoveMapping = new Dictionary<char, Move>
    {
      { 'X', Move.Rock },
      { 'Y', Move.Paper },
      { 'Z', Move.Scissors }
    };

    private static Move MapMove(char unmappedMove, IReadOnlyDictionary<char, Move> mapping)
    {
      if (mapping.TryGetValue(unmappedMove, out var returnVal))
      {
        return returnVal;
      }

      throw new ArgumentOutOfRangeException(nameof(unmappedMove));
    }
  }
}
