using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DaihoWebAPI.Models
{
    [Table("ASM_Z_USER_ROLES")]
    public class userRole
    {
        
        public string? ROLEID { get; set; }
        public string? USERID { get; set; }
        public string? UPDATEDBY { get; set; }
        public string? CREATEDBY { get; set; }
        public DateTime UPDATEDDATE { get; set; }
        public DateTime CREATEDDATE { get; set; }
        [Key]
        public string ID { get; set; }

    }
}
