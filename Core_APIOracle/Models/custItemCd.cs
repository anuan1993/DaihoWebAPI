using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_APIOracle.Models
{
    //[Table("HM_TOKUIH_ALL")]
    public class custItemCd
    {
        [Key]
        public string ITM_CD { get; set; }
    
        public string CST_CD { get; set; }
     
        public string CST_ITM_CD { get; set; }
        public string CST_ITM_NM { get; set; }

    }
}
