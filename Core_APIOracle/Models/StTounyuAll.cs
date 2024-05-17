using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaihoWebAPI.Models
{
    [Table("ST_TOUNYU_ALL")]
    public partial class StTounyuAll
    {
        [Key]
        public string INPT_NO { get; set; } = null!;
        [Key]
        public string CO_CD { get; set; } = null!;
        public string INST_NO { get; set; } = null!;
        public string? C_ITM_CD { get; set; }
        /*public string? AltGrpCd { get; set; }
        public string? CLotNo { get; set; }
        public string? AsstTyp { get; set; }
        public string? StkTyp { get; set; }
        public string? QualTyp { get; set; }
        public string ProcCd { get; set; } = null!;
        public string StkAllocTyp { get; set; } = null!;
        public string? ProvTyp { get; set; }
        public DateTime InptSchdDt { get; set; }
        public DateTime? InptTgtDt { get; set; }
        public byte? InptShtNo { get; set; }
        public decimal ReqQty { get; set; }
        public decimal InptSchdQty { get; set; }
        public string InptLocCd { get; set; } = null!;
        public string RackNo { get; set; } = null!;
        public string? OrdNo { get; set; }
        public int? BrNo { get; set; }
        public string InptAllocFlg { get; set; } = null!;
        public string SoAllocFlg { get; set; } = null!;
        public string ComplFlg { get; set; } = null!;
        public string? Sno { get; set; }
        public string? SnoWInst { get; set; }
        public string? SeibanTyp { get; set; }
        public string? SubSno { get; set; }
        public string? SubSnoWInst { get; set; }
        public string? SubSeibanTyp { get; set; }
        public int? StLt { get; set; }
        public string? StLtUnit { get; set; }
        public int? EndLt { get; set; }
        public string? EndLtUnit { get; set; }
        public string NonMrpFlg { get; set; } = null!;
        public string XpSnoFlg { get; set; } = null!;
        public string XpSubSnoFlg { get; set; } = null!;
        public string AtInptNonFlg { get; set; } = null!;
        public DateTime? InsTs { get; set; }
        public string? InsUsrCd { get; set; }
        public int UpdCntr { get; set; }
        public DateTime? UpdTs { get; set; }
        public string? UpdUsrCd { get; set; }*/
    }
}
