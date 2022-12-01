using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElfEdibles.Core
{
  public class Elf
  {
    private IEnumerable<int> _snacks;

    public Elf(string elfRecord)
    {
      _snacks = elfRecord.Split("\n", StringSplitOptions.RemoveEmptyEntries).Where(s => int.TryParse(s, out _)).Select(s => int.Parse(s));
    }

    public int GetCaloriesCarried()
    {
      return _snacks.Sum();
    }
  }
}
