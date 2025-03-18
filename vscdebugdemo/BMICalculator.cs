/// <summary>
/// BMI 計算類別
/// </summary>
public class BMICalculator
{
    /// <summary>
    /// 身高(公分)
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// 體重(公斤)
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// 計算 BMI
    /// </summary>
    /// <returns>BMI</returns>
    public double Calculate()
    {
        return Calculate(Height, Weight);
    }

    /// <summary>
    /// 計算 BMI
    /// </summary>
    /// <param name="height">身高(公分)</param>
    /// <param name="weight">體重(公斤)</param>
    /// <returns>BMI</returns>
    public double Calculate(double height, double weight)
    {
        //BMI 計算公式是以體重 (公斤) 除以身高 (公尺) 的平方
        Height = height;
        Weight = weight;
        double dbl_height = Height/100;
        return Weight / (dbl_height * dbl_height);
    }

    /// <summary>
    /// 取得 BMI 結果
    /// </summary>
    /// <returns></returns>
    public string Result()
    {
        double bmi = Calculate();
        if (bmi < 18.5) { return "過輕"; }
        else if (bmi < 24) { return "正常"; }
        else if (bmi < 27) { return "過重"; }
        else if (bmi < 30) { return "輕度肥胖"; }
        else if (bmi < 35) { return "中度肥胖"; }
        else { return "重度肥胖"; }
    }
}
