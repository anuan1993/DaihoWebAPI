using AutoMapper;

namespace DaihoWebAPI.Profiles

{
    public class authProfile:Profile
    {
        public authProfile()
        {
            CreateMap<Models.WmUser, Models.DTO.Users>();
        }
    }
}
