using Rix.AutoMapper.Mapper;
using Rix.AutoMapper.Tests.Models;
using Rix.AutoMapper.Tests.Profiles;

namespace Rix.AutoMapper.Tests.Features;

public class SimpleTests
{
    [Fact]
    public void MapsWithoutProfile()
    {
        // ARRANGE
        MySimpleObject obj = new()
        {
            Name = "Test",
            Age = 1,
            Height = 2
        };

        IRixMapper mapper = new RixMapper();

        // ACT
        MySimpleObjectDto result = mapper.Map<MySimpleObject, MySimpleObjectDto>(obj);

        // ASSERT
        Assert.Equal("Test", result.Name);
        Assert.Equal(1, result.Age);
        Assert.Equal(2L, result.Height);
        Assert.Null(result.NotCopied);
    }

    [Fact]
    public void MapsWithProfile()
    {
        // ARRANGE
        MySimpleObject obj = new()
        {
            Name = "Test",
            Age = 1,
            Height = 2
        };

        IRixMapper mapper = new RixMapper(new MySimpleObjectProfile());

        // ACT
        MySimpleObjectDto result = mapper.Map<MySimpleObject, MySimpleObjectDto>(obj);

        // ASSERT
        Assert.Equal("TestDto", result.Name);
        Assert.Equal(2, result.Age);
        Assert.Equal(3L, result.Height);
        Assert.Null(result.NotCopied);
    }
}