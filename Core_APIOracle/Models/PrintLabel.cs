using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaihoWebAPI.Models
{
    [Table("ST_ORDER_ALL")]
    public class PrintLabel
    {
        [Key]
        public string ORD_NO { get; set; }
        [Key]
        public string BR_NO  { get; set; }
        
        [Key]
        public string CO_CD { get; set; }
        public string ORD_TYP { get; set; }
        public  string ITM_CD { get; set; }
        public string ITM_NM { get; set; }
        public string PROD_LOC_CD { get; set; }
        //public string LINE_CD { get; set; }
        public DateTime PROD_ST_SCHD_DT { get; set; }   

    }
}
