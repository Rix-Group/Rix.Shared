using Rix.AutoMapper.Tests.Models;

namespace Rix.AutoMapper.Tests.Extensions;

internal static class MySimpleObjectExtensions
{
    extension(MySimpleObject obj)
    {
        internal MySimpleObjectDto ToDto() => new()
        {
            Name = obj.Name + "Dto",
            Age = obj.Age + 1,
            Height = obj.Height + 1
        };
    }
}