using System.ComponentModel.DataAnnotations;

namespace DaihoWebAPI.Models.DTO
{
    public class Users
    {
        public string userName{ get; set; }
        public string Password { get; set; }
        public string? USR_ID { get; internal set; }
    }
}
