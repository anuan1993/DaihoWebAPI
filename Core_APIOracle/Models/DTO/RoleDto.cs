namespace DaihoWebAPI.Models.DTO
{
    public class RoleScreenListDTO
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<ScreenAccessDTO> ScreenAccess { get; set; }
    }
}
