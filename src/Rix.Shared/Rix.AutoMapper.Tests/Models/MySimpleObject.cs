namespace Rix.AutoMapper.Tests.Models;

internal class MySimpleObject
{
    internal required string Name { get; set; }
    internal int Age { get; set; }
    public long? Height { get; set; }

    private string NotCopied { get; set; } = "not copied";
}