using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElfEdibles.Core
{
  public class ElfCalc
  {
    private IEnumerable<Elf> _elves;
    public ElfCalc(string elves)
    {
      _elves = ElfFactory.ParseInput(elves);
    }

    public Elf FindSnackPackingestElf()
    {
      return FindNthSnackPackingestElf(0);
    }

    public Elf FindNthSnackPackingestElf(int skip)
    {
      return _elves.OrderByDescending((e) => e.GetCaloriesCarried()).Skip(skip).FirstOrDefault();
    }
  }
}
