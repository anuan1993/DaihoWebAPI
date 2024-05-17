using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaihoWebAPI.Models
{
    [Table("ASM_Z_SCREENS")]
    public class ASM_Z_SCREEN
    {
        [Key]
        public string SCREENID { get; set; }
        public string SCREENNAME { get; set; }
        public string UPDATEDBY { get; set; }
        public string  CREATEDBY { get; set; }
        public DateTime UPDATEDDATE { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public string  MODULE { get; set; } 

    }
}
