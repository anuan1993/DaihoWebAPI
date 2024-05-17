using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaihoWebAPI.Models
{
    [Table("ASM_Z_ROLE")]
    public class ASM_Z_ROLES
    {
        [Key]
        public string ROLEID { get; set; }
        public string ROLENAME { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    }
}
