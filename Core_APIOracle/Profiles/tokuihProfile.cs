using AutoMapper;

namespace DaihoWebAPI.Profiles

{
    public class tokuihProfile:Profile
    {
        public tokuihProfile()
        {
            CreateMap<Models.HM_TOKUIH_ALL, Models.DTO.Tokuih>();
        }
    }
}
