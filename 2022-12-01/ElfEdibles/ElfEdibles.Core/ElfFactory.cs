using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElfEdibles.Core
{
  public static class ElfFactory
  {
    public static IEnumerable<Elf> ParseInput(string file)
    {
      return file.Split("\n\n", StringSplitOptions.RemoveEmptyEntries).Select(row => new Elf(row));
    }
  }
}
