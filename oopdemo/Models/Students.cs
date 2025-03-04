namespace oop.demo;

public class Students{

    /// 學生編號
    public string No { get; set; } = "";

    /// 學生姓名
    public string Name { get; set; } = "";

    /// 性別: M=男, F=女
    public enGenders Gender { get; set; } = enGenders.M;

    /// 出生日期
    public DateTime Birthday { get; set; } = DateTime.MinValue;
    private string _FullDescription;
    public string CategoryName { get; set; } = "CAT";
    public string Description { get; set; } = "DES";   

    public string FullDescription { 
        get{
            if(string.IsNullOrWhiteSpace(this._FullDescription)){
                this._FullDescription = string.Format("{0} - {1}",
                this.CategoryName,
                this.Description);
            }

            _FullDescription = "STD" + "_cool_" + this._FullDescription;
            return this._FullDescription;
        }
    }

    

}