using System.ComponentModel.DataAnnotations;


/// <summary>
/// 個人的類別
/// </summary>
public class Person
{
    /// <summary>
    /// 個人的 ID
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// 個人的編號
    /// </summary>
    [Display(Name = "個人編號")]/// 
    public string PersonNo { get; set; } = "";
    /// <summary>
    /// 個人的姓名
    /// </summary>
    [Display(Name = "個人姓名")] 
    public string PersonName { get; set; } = "";
}
