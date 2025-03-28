using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace adonetdemo.Models;

/// <summary>
/// 使用者的類別
/// </summary>
public partial class Users
{
    [Key]
    public int Id { get; set; } = 0;
    [Display(Name = "合法")]
    public bool IsValid { get; set; } = false;
    [Display(Name = "使用者編號")]
    [Required(ErrorMessage = "使用者編號不可空白!!")]
    public string? UserNo { get; set; } = "";
    [Display(Name = "姓名")]
    [Required(ErrorMessage = "姓名不可空白!!")]
    public string? UserName { get; set; } = "";
    [Display(Name = "密碼")]
    public string? Password { get; set; } = "";
    [Display(Name = "類別代號")]
    public string? CodeNo { get; set; } = "";
    [NotMapped]
    [Display(Name = "類別")]
    public string? CodeName { get; set; } = "";
    [Display(Name = "角色代號")]
    public string? RoleNo { get; set; } = "";
    [NotMapped]
    [Display(Name = "角色")]
    public string? RoleName { get; set; } = "";
    [Display(Name = "性別代號")]
    public string? GenderCode { get; set; } = "";
    [NotMapped]
    [Display(Name = "性別")]
    public string? GenderName { get; set; } = "";
    [Display(Name = "部門代號")]
    public string? DeptNo { get; set; } = "";
    [NotMapped]
    [Display(Name = "部門")]
    public string? DeptName { get; set; } = "";
    [Display(Name = "職稱代號")]
    public string? TitleNo { get; set; } = "";
    [NotMapped]
    [Display(Name = "職稱")]
    public string? TitleName { get; set; } = "";
    [Display(Name = "出生日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? Birthday { get; set; }
    [Display(Name = "到職日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? OnboardDate { get; set; }
    [Display(Name = "離職日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? LeaveDate { get; set; }
    [Display(Name = "電子信箱")]
    [EmailAddress(ErrorMessage = "電子信箱格式不正確!!")]
    public string? ContactEmail { get; set; } = "";
    [Display(Name = "連絡電話")]
    public string? ContactTel { get; set; } = "";
    [Display(Name = "連絡地址")]
    public string? ContactAddress { get; set; } = "";
    [Display(Name = "驗證碼")]
    public string? ValidateCode { get; set; } = "";
    [Display(Name = "通知代碼")]
    public string? NotifyPassword { get; set; } = "";
    [Display(Name = "備註")]
    public string? Remark { get; set; } = "";
}
