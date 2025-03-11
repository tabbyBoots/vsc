/// <summary>
/// 韓國營業稅計算類別
/// </summary>
public class CountryKorea : ICountry
{
    /// <summary>
    /// 韓國營業稅計算類別建構子
    /// </summary>
    public CountryKorea()
    {
        CountryNo = "Korea";
        CountryName = "韓國";
        TaxRate = 10;
    }
    /// <summary>
    /// 國家代號
    /// </summary>
    public string CountryNo { get; set; } = "";
    /// <summary>
    /// 國家名稱
    /// </summary>
    public string CountryName { get; set; } = "";
    /// <summary>
    /// 營業稅率(%)
    /// </summary>
    public int TaxRate { get; set; } = 0;
    /// <summary>
    /// 計算含稅金額
    /// </summary>
    /// <param name="amount">未稅金額</param>
    /// <returns>含稅金額</returns>
    public int TaxedAmount(int amount)
    {
        double dbl_rate = Convert.ToDouble(TaxRate);
        double dbl_amount = Convert.ToDouble(amount);
        double dbl_tax = dbl_amount * dbl_rate / 100;
        int int_tax = (int)Math.Round(dbl_tax, 0);
        int int_amount = amount + int_tax;
        return int_amount;
    }
}
