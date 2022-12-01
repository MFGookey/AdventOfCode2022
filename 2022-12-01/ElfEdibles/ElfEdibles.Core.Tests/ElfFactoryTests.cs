using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ElfEdibles.Core.Tests
{
  public class ElfFactoryTests
  {
    [Theory]
    [MemberData(nameof(SampleFileContent))]
    public void ElfFactory_GivenValidElfRecords_ReturnsExpectedElvesByCalories(string records, IEnumerable<int> expectedElfCalories)
    {
      var elves = ElfFactory.ParseInput(records);

      Assert.Equal(
        expectedElfCalories.OrderBy(x => x),
        elves.Select(
          e => e.GetCaloriesCarried()
        )
        .OrderBy(x => x)
      );
    }

    public static IEnumerable<object[]> SampleFileContent
    {
      get
      {

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000",
          new int[]
          {
            6000,
            4000,
            11000,
            24000,
            10000
          }
        };
      }
    }
  }
}
