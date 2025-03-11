using System.ComponentModel.DataAnnotations;

/// <summary>
/// 營業稅計算資料模型
/// </summary>
public class BusinessModel
{
    [Display(Name = "未稅金額")]
    [Required(ErrorMessage = "未稅金額不可空白!!")]
    [Range(0, 1000000, ErrorMessage = "未稅金額需在 0 - 1,000,000萬之間")]
    public int Amount { get; set; } = 0;
}
