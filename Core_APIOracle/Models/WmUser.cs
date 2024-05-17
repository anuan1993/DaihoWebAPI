using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static DaihoWebAPI.Utilities.Helper;

namespace DaihoWebAPI.Models
{
    [Table("WM_USER")]
    public partial class WmUser
    {
        [Key]
        public string USR_ID { get; set; }
        public string USR_NM { get; set; }
        public string CO_CD { get; set; }

        public byte[] PASSWORD { get; set; }
        //public DateTime? PwdCngTs { get; set; }
        //public DateTime? StartTs { get; set; }
        //public DateTime? ExpireTs { get; set; }
        public string INVALIDATE_FLG { get; set; }
        //public DateTime? InvalidateTs { get; set; }
        //public string ADMIN_FLG { get; set; }
        //public string InsUsrId { get; set; }
        //public DateTime? InsTs { get; set; }
        //public int? UpdCntr { get; set; }
        //public string UpdUsrId { get; set; }
        //public DateTime? UpdTs { get; set; }
    }
}
