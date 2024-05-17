using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaihoWebAPI.Models
{

    public class Tounyu
    {
        public string INPT_NO { get; set; }
        public string CO_CD { get; set; }
        public string INST_NO { get; set; }
        public string C_ITM_CD { get; set;}


    }
}
