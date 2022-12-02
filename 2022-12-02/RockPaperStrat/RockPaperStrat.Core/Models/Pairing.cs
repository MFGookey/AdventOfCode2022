using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperStrat.Core.Models
{
  public class Pairing
  {
    private readonly Move _playerMove;
    private readonly Move _opponentMove;

    public Move PlayerMove
    {
      get
      {
        return _playerMove;
      }
    }

    public Move OpponentMove
    {
      get
      {
        return _opponentMove;
      }
    }
    public Pairing(Move playerMove, Move opponentMove)
    {
      _playerMove = playerMove;
      _opponentMove = opponentMove;
    }
  }
}
