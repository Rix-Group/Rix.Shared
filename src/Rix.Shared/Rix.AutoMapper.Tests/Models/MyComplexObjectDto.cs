namespace Rix.AutoMapper.Tests.Models;

internal class MyComplexObjectDto
{
    internal required string Name { get; set; }
    internal MySimpleObjectDto[] SimpleObjects { get; set; } = [];
}