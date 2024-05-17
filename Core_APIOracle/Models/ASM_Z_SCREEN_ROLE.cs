using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaihoWebAPI.Models
{
    [Table("ASM_Z_SCREEN_ROLE")]
    public class ASM_Z_SCREEN_ROLE
    {
       
        public string SCREENID { get; set; }
        public string ROLEID { get; set; }


        public string SCREENACCESS { get; set; }
        public string UPDATEDBY { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime UPDATEDDATE { get; set; }
        public DateTime CREATEDDATE { get; set; }

        //internal Task CreateAsync(ASM_Z_SCREEN_ROLE aSM_Z_SCREEN_ROLE)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
