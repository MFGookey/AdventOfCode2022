using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ElfEdibles.Core.Tests
{
  public class ElfCalcTests
  {
    [Theory]
    [MemberData(nameof(SampleFileContent))]
    public void FindSnackPackingestElf_GivenValidElfRecords_ReturnsExpectedElf(string record, int expectedElfCalories)
    {
      var sut = new ElfCalc(record);

      Assert.Equal(
        expectedElfCalories,
        sut.FindSnackPackingestElf().GetCaloriesCarried()
      );
    }

    public static IEnumerable<object[]> SampleFileContent
    {
      get
      {
        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000",
          24000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n10000",
          11000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n10000",
          10000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000",
          6000
        };

        yield return new object[]
        {
          "4000",
          4000
        };
      }
    }
  }
}
