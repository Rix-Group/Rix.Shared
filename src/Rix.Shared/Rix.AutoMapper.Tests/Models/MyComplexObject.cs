namespace Rix.AutoMapper.Tests.Models;

internal class MyComplexObject
{
    internal required string Name { get; set; }
    internal required List<MySimpleObject> SimpleObjects { get; set; }
}