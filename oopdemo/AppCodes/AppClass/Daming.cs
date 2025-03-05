namespace oop.demo;

public class Daming : Person
{
    public Daming()
    {
        Name = "王大明";
        Age = 30;
    }

    public override string hobby()
    {
        return $"Daming:打籃球_\nPerson:{base.hobby()}";
    }
}