namespace Rix.AutoMapper.Tests.Models;

internal class MySimpleObjectDto
{
    internal required string Name { get; set; }
    internal int Age { get; set; }
    public long? Height { get; set; }

    public string? NotCopied { get; set; }
}