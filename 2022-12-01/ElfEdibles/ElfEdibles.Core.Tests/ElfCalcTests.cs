using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ElfEdibles.Core.Tests
{
  public class ElfCalcTests
  {
    [Theory]
    [MemberData(nameof(SnackPackingestElfData))]
    public void FindSnackPackingestElf_GivenValidElfRecords_ReturnsExpectedElf(string record, int expectedElfCalories)
    {
      var sut = new ElfCalc(record);

      Assert.Equal(
        expectedElfCalories,
        sut.FindSnackPackingestElf().GetCaloriesCarried()
      );
    }

    [Theory]
    [MemberData(nameof(NthSnackPackingestElfData))]
    public void FindNthSnackPackingestElf_GivenValidElfRecords_ReturnsExpectedElf(string record, int skip, int expectedElfCalories)
    {
      var sut = new ElfCalc(record);

      Assert.Equal(
        expectedElfCalories,
        sut.FindNthSnackPackingestElf(skip).GetCaloriesCarried()
      );
    }


    public static IEnumerable<object[]> SnackPackingestElfData
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

    public static IEnumerable<object[]> NthSnackPackingestElfData
    {
      get
      {
        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000",
          0,
          24000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n10000",
          0,
          11000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n10000",
          0,
          10000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000",
          0,
          6000
        };

        yield return new object[]
        {
          "4000",
          0,
          4000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000",
          1,
          11000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000",
          2,
          10000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000",
          3,
          6000
        };

        yield return new object[]
        {
          "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000",
          4,
          4000
        };
      }
    }
  }
}
