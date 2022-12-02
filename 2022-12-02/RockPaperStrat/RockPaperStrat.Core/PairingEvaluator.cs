using System;
using System.Collections.Generic;
using System.Text;
using RockPaperStrat.Core.Models;

namespace RockPaperStrat.Core
{
  public class PairingEvaluator
  {
    private Func<Pairing, Func<Pairing, Outcome>, int> _scorer;
    private Func<Pairing, Outcome> _outcomeEvaluator;

    public PairingEvaluator() : this(
      PairingEvaluator.DefaultScoring,
      PairingEvaluator.DefaultOutcomeEvaluator
    )
    { }

    public PairingEvaluator(
      Func<Pairing, Func<Pairing, Outcome>, int> scorer,
      Func<Pairing, Outcome> outcomeEvaluator
    )
    {
      _scorer = scorer;
      _outcomeEvaluator = outcomeEvaluator;
    }

    public Outcome EvaluateOutcome(Pairing round)
    {
      return _outcomeEvaluator(round);
    }

    public int EvaluateScore(Pairing round)
    {
      return _scorer(round, _outcomeEvaluator);
    }

    public static Func<Pairing, Func<Pairing, Outcome>, int> DefaultScoring = (p, e) =>
    {
      return (int)e(p) + (int)p.PlayerMove;
    };

    public static Func<Pairing, Outcome> DefaultOutcomeEvaluator = (p) =>
    {
      switch (p.PlayerMove)
      {
        case Move.Rock:
          switch (p.OpponentMove)
          {
            case Move.Rock:
              return Outcome.Draw;
            case Move.Paper:
              return Outcome.PlayerLoss;
            case Move.Scissors:
              return Outcome.PlayerWin;
            default:
              throw new NotSupportedException($"OpponentMove {p.OpponentMove} not supported for PlayerMove {p.PlayerMove}");
          }

        case Move.Paper:
          switch (p.OpponentMove)
          {
            case Move.Rock:
              return Outcome.PlayerWin;
            case Move.Paper:
              return Outcome.Draw;
            case Move.Scissors:
              return Outcome.PlayerLoss;
            default:
              throw new NotSupportedException($"OpponentMove {p.OpponentMove} not supported for PlayerMove {p.PlayerMove}");
          }

        case Move.Scissors:
          switch (p.OpponentMove)
          {
            case Move.Rock:
              return Outcome.PlayerLoss;
            case Move.Paper:
              return Outcome.PlayerWin;
            case Move.Scissors:
              return Outcome.Draw;
            default:
              throw new NotSupportedException($"OpponentMove {p.OpponentMove.ToString()} not supported for PlayerMove {p.PlayerMove.ToString()}");
          }

        default:
          throw new NotSupportedException($"PlayerMove {p.PlayerMove.ToString()} not supported.");

      }
    };
  }
}
