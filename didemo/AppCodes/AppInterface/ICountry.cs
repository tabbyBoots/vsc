/// <summary>
/// 國家的介面
/// </summary>
public interface ICountry
{
    /// <summary>
    /// 國家代號
    /// </summary>
    string CountryNo { get; set; }
    /// <summary>
    /// 國家名稱
    /// </summary>
    string CountryName { get; set; }
    /// <summary>
    /// 營業稅率(%)
    /// </summary>
    int TaxRate { get; set; }
    /// <summary>
    /// 計算含稅金額
    /// </summary>
    /// <param name="amount">未稅金額</param>
    /// <returns>含稅金額</returns>
    int TaxedAmount(int amount);
}
