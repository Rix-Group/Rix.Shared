using Rix.AutoMapper.Mapper;
using Rix.AutoMapper.Tests.Models;

namespace Rix.AutoMapper.Tests.Features;

public class ComplexTests
{
    [Fact]
    public void MapsWithoutProfile()
    {
        // ARRANGE
        MyComplexObject obj = new()
        {
            Name = "Complex 🙂", // Testing UTF16
            SimpleObjects = [new()
            {
                Name = "Test",
                Age = 1,
                Height = 2
            }]
        };

        // Check circular references are not copied
        obj.Reference = obj;

        IRixMapper mapper = new RixMapper();

        // ACT
        MyComplexObjectDto result = mapper.Map<MyComplexObject, MyComplexObjectDto>(obj);

        // ASSERT
        Assert.Equal("Complex 🙂", result.Name);
        Assert.Null(result.Reference);
        Assert.Single(result.SimpleObjects);

        MySimpleObjectDto simple = result.SimpleObjects[0];
        Assert.Equal("Test", simple.Name);
        Assert.Equal(1, simple.Age);
        Assert.Equal(2L, simple.Height);
        Assert.Null(simple.NotCopied);
    }
}