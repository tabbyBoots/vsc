namespace oop.demo;

public class Job
{
    public int JobStep { get; set; }   =0;
    public string JobName { get; set; } ="";
    public int JobDelay { get; set; } = 0;
    public int TotalsSync { get; set; } = 0;
    public int TotalsAsync { get; set; } = 0;
}