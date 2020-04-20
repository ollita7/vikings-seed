using AutoMapper;
using Viking.DataAccess;
using Viking.Sdk;

namespace Viking.Api.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users,LoginDataIn>();
        }
    }
}