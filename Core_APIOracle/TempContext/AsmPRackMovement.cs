using System;
using System.Collections.Generic;

namespace DaihoWebAPI.TempContext;

public partial class AsmPRackMovement
{
    public string MovementId { get; set; } = null!;

    public string CoCd { get; set; } = null!;

    public decimal? RevNo { get; set; }

    public DateTime? MovementDate { get; set; }

    public string? MovementStatus { get; set; }

    public string? MovementType { get; set; }

    public string? MovementReason { get; set; }

    public string? ScrCompanyCd { get; set; }

    public string? SrcLocCd { get; set; }

    public string? SrcRackCd { get; set; }

    public string? DestCompanyCd { get; set; }

    public string? DestLocCd { get; set; }

    public string? DescRackCd { get; set; }

    public string Remarks { get; set; } = null!;

    public decimal Isactived { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }
}
