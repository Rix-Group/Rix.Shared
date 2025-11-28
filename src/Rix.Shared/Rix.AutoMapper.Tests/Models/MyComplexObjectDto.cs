namespace Rix.AutoMapper.Tests.Models;

internal class MyComplexObjectDto
{
    internal required string Name { get; set; }
    internal List<MySimpleObjectDto> SimpleObjects { get; set; } = [];
}