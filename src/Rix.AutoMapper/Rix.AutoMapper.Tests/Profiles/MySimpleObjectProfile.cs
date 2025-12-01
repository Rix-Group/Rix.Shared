using Rix.AutoMapper.Profile;
using Rix.AutoMapper.Tests.Extensions;
using Rix.AutoMapper.Tests.Models;

namespace Rix.AutoMapper.Tests.Profiles;

internal class MySimpleObjectProfile : IMappingProfile<MySimpleObject, MySimpleObjectDto>
{
    public MySimpleObjectDto Map(MySimpleObject o)
        => o.ToDto();
}