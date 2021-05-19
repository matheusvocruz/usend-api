using AutoMapper;
using USend.Application.Responses.User;
using USend.Domain.Entities;

namespace USend.Api.Configuration.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<Infra.Data.ValueObjects.TokenResponse, TokenResponse>();
        }
    }
}
