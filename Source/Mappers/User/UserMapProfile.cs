using AutoMapper;
using TFirewall.Source.Dtos.User;
using TFirewall.Source.UserAppConfig.Entities;

namespace TFirewall.Source.Mappers.User;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<UserAppConfig.Entities.User, UserCreationDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

        CreateMap<UserCreationDto, UserAppConfig.Entities.User>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<UserRole>(src.Role)));

        CreateMap<UserProfile, UserProfileCreationDto>().ReverseMap();
        CreateMap<UserProfile, UserProfileEditDto>().ReverseMap();
        CreateMap<UserProfile, UserProfileFetchDto>().ReverseMap();
        CreateMap<UserProfile, UserProfileUpdateResponseDto>().ReverseMap();
        CreateMap<UserProfile, UserProfileCreationResponseDto>().ReverseMap();
        CreateMap<UserAppConfig.Entities.User, UserFetchResponseDto>().ReverseMap();
    }
}