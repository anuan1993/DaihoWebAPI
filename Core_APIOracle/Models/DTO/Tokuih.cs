using System.ComponentModel.DataAnnotations;

namespace DaihoWebAPI.Models.DTO
{
    public class Tokuih
    {
        public string ITM_CD { get; set; }
        public string CST_CD { get; set; }
        public string CO_CD { get; set; }
        public string CST_ITM_CD { get; set; }
        public string CST_ITM_NM { get; set; }
        /*public string CST_EXT_ITM_NM { get; set; }
        public string INVALID_FLG { get; set; }
        // public string RMRKS { get; set; }
        public DateTime INS_TS { get; set; }
        public string INS_USR_CD { get; set; }
        public int UPD_CNTR { get; set; }
        public DateTime UPD_TS { get; set; }
        public string UPD_USR_CD { get; set; }*/
    }
}
