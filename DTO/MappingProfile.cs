using AutoMapper;
using DTO.TimeEntryDTOs;
using DTO.UserDTOs;
using Entity;

namespace DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserListDTO>();

        CreateMap<UserCreateDTO, User>();
        CreateMap<UserDisplayDTO, UserCreateDTO>();

        CreateMap<UserListDTO, UserDisplayDTO>();

        CreateMap<UserUpdateDTO, User>();
        CreateMap<UserDisplayDTO, UserUpdateDTO>();

        CreateMap<TimeEntry, TimeEntryDisplayDTO>().
            ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}")).
            ForMember(dest => dest.WorkedTime, opt => opt.MapFrom(src => ((src.Exit == null ? DateTime.Now : src.Exit) - src.Entry).Value.TotalHours));
    }
}
