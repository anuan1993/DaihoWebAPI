using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaihoWebAPI.Models
{
   [Table("HM_TOKUIH_ALL")]
    public class HM_TOKUIH_ALL
    {
        [Key]
        public string? ITM_CD { get; set; }
        [Key]
        public string? CST_CD { get; set; }
        [Key]
        public string? CO_CD { get; set; }
        public string? CST_ITM_CD { get; set; }
        public string? CST_ITM_NM { get; set; }
        //public string CST_EXT_ITM_NM { get; set; }
        public string? INVALID_FLG { get; set; }
       // public string RMRKS { get; set; }
        public DateTime? INS_TS { get; set; }
        public string? INS_USR_CD { get; set; }
        public int? UPD_CNTR { get; set; }
        public DateTime? UPD_TS { get; set; }
        public string? UPD_USR_CD { get; set; }
    
    }
}
