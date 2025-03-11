namespace oop.demo;

public class FruitCarton : BaseClass, ICarton
{
    public int Length { get; set; } = 0;
    public int Width { get; set; } = 0;

    public int Height { get; set; } = 0;

    public int Weight { get; set; } = 0;


    public string CartonInfo{
        get
        {
            string str_message = "紙箱資訊：";
            str_message += $"長度：{Length} ";
            str_message += $"寛度：{Width} ";
            str_message += $"高度：{Height} ";
            str_message += $"空重：{Weight} ";
            str_message += $"體積：{Length * Width * Height} ";
            return str_message;
        }
    }

    public void Package()
    {
        Length = 40;
        Width = 60;
        Height = 50;
        Weight = 20;
    }
}