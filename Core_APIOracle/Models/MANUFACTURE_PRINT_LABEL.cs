using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_APIOracle.Models
{
    [Table("MANUFACTURE_PRINT_LABEL")]
    public class MANUFACTURE_PRINT_LABEL
    {
        [Key]
        public string PRINT_ID_H { get; set; }
        public string TOUNYU_ID { get; set; }

        public string ITM_CD { get; set; }

        public string LOT { get; set; }
        public string PALLETE_ID { get; set; }
        //public string ORD_NO { get; set; }

        public DateTime PRINT_DT { get; set; }

        public string PRINT_LOC { get; set; }
        public string PRINT_FLG     { get; set; }

    }
}
