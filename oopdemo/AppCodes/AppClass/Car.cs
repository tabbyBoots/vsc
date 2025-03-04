namespace oop.demo;

public class Car{

    #region 建構子及解構子
    public Car()
    {
        SetCarData("", "", "");
    }
    #endregion

    #region 屬性宣告
    /// <summary>
    /// 車牌號碼
    /// </summary>
    public string CarNo { get; set; } = "";
    /// <summary>
    /// 廠牌名稱
    /// </summary>
    public string BrandName { get; set; } = "";
    /// <summary>
    /// 車子的型號
    /// </summary>
    public string ModelNo { get; set; } = "";
    /// <summary>
    /// 設定車子資訊
    /// </summary>
    /// <param name="carNo">車牌號碼</param>
    /// <param name="brandName">廠牌名稱</param>
    /// <param name="modelNo">車子的型號</param>
    #endregion

    #region 事件
    public void SetCarData(string carNo, string brandName, string modelNo)
    {
        CarNo = carNo;
        BrandName = brandName;
        ModelNo = modelNo;
    }
    #endregion

    #region 函數
    /// <summary>
    /// 取得車子資訊
    /// </summary>
    /// <returns></returns>
    public string GetCarData()
    {
        return $"車號:{CarNo} 廠牌:{BrandName} 型號:{ModelNo}";
    }
    #endregion

}


