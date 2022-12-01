using System.Collections.Generic;
using Xunit;

namespace ElfEdibles.Core.Tests
{
  public class ElfTests
  {
    [Theory]
    [MemberData(nameof(SampleElfRecords))]
    public void Elf_GivenValidElfRecord_ReturnsExpectedCalories(string record, int expectedCalories)
    {
      var sut = new Elf(record);
      Assert.Equal(expectedCalories, sut.GetCaloriesCarried());
    }

    public static IEnumerable<object[]> SampleElfRecords
    {
      get
      {

        yield return new object[]
        {
          "1000\n2000\n3000",
          6000
        };

        yield return new object[]
        {
          "4000",
          4000
        };

        yield return new object[]
        {
          "5000\n6000",
          11000
        };

        yield return new object[]
        {
          "7000\n8000\n9000",
          24000
        };

        yield return new object[]
        {
          "10000",
          10000
        };
      }
    } 
  }
}
