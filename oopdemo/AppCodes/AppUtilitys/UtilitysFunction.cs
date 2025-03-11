using System.Diagnostics;
using System.Text;

namespace oop.demo;

/// <summary>
/// 輔助工具類別-函數數相關
/// </summary>
public partial class Utilitys
{
    /// <summary>
    /// 開始時間
    /// </summary>
    public static DateTime StartTime { get; set; }
    /// <summary>
    /// 結束時間
    /// </summary>
    public static DateTime EndTime { get; set; }
    /// <summary>
    /// 時間監控物件
    /// </summary>
    public static Stopwatch stopwatch { get; set; } = new Stopwatch();
    /// <summary>
    /// 執行的步驟
    /// </summary>
    public static int JobStep { get; set; } = 0;
    /// <summary>
    /// 執行步驟的時間(單位:秒)
    /// </summary>
    public static int JobDelay { get; set; } = 0;
    /// <summary>
    /// 執行步驟的名稱
    /// </summary>
    public static string JobName { get; set; } = string.Empty;

    /// <summary>
    /// 步驟執行的訊息
    /// </summary>
    public static string JobMessage { get; set; } = string.Empty;

    /// <summary>
    /// 取得現在時間與開始時間中間差的秒數
    /// </summary>
    /// <returns></returns>
    public static int TotalSeconds { get { return (int)(stopwatch.ElapsedMilliseconds / 1000); } }
    /// <summary>
    /// 設定開始時時
    /// </summary>
    public static void SetStartTime()
    {
        StartTime = DateTime.Now;
    }
    /// <summary>
    /// 設定結束時間
    /// </summary>
    public static void SetEndTime()
    {
        EndTime = DateTime.Now;
    }
    /// <summary>
    /// 取得不足長度中的空白
    /// </summary>
    /// <param name="sourceText">指定文字</param>
    /// <param name="lengText">固定長度</param>
    /// <returns></returns>
    public static string GetPadTextSpace(string sourceText, int lengText)
    {
        Encoding coding = Encoding.GetEncoding("big5");
        int index = 0;
        foreach (char ch in sourceText.ToCharArray())
        {
            index++;
            if (coding.GetByteCount(ch.ToString()) == 2) index++;
        }
        if (index >= lengText) return "";
        string str_text = "";
        int int_space = (lengText - index);
        for (int i = 0; i < int_space; i++) { str_text += " "; }
        return str_text;
    }

    /// <summary>
    /// 取得在指定文字右方補足固定長度的空白之文字
    /// </summary>
    /// <param name="sourceText">指定文字</param>
    /// <param name="lengText">固定長度</param>
    /// <returns></returns>
    public static string GetPadRightText(string sourceText, int lengText)
    {
        return GetPadRightText(sourceText, lengText, ' ');
    }
    /// <summary>
    /// 取得在指定文字右方補足固定長度的字元之文字
    /// </summary>
    /// <param name="sourceText">指定文字</param>
    /// <param name="lengText">固定長度</param>
    /// <param name="fillChar">字元</param>
    /// <returns></returns>
    public static string GetPadRightText(string sourceText, int lengText, char fillChar)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding coding = Encoding.GetEncoding("big5");
        int index = 0;
        foreach (char ch in sourceText.ToCharArray())
        {
            if (coding.GetByteCount(ch.ToString()) == 2)
                index++;
        }
        string w = sourceText.PadRight(lengText - index, fillChar);
        return w;
    }
    /// <summary>
    /// 取得在指定文字左方補足固定長度的空白之文字
    /// </summary>
    /// <param name="sourceText">指定文字</param>
    /// <param name="lengText">固定長度</param>
    /// <returns></returns>
    public static string GetPadLeftText(string sourceText, int lengText)
    {
        return GetPadLeftText(sourceText, lengText, ' ');
    }
    /// <summary>
    /// 取得在指定文字左方補足固定長度的字元之文字
    /// </summary>
    /// <param name="sourceText">指定文字</param>
    /// <param name="lengText">固定長度</param>
    /// <param name="fillChar">字元</param>
    /// <returns></returns>
    public static string GetPadLeftText(string sourceText, int lengText, char fillChar)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding coding = Encoding.GetEncoding("big5");
        int index = 0;
        foreach (char ch in sourceText.ToCharArray())
        {
            if (coding.GetByteCount(ch.ToString()) == 2)
                index++;
        }
        string w = sourceText.PadLeft(lengText - index, fillChar);
        return w;
    }
    /// <summary>
    /// 同步執行指定的延遲時間
    /// </summary>
    public static void DelaySync()
    {
        DelaySync(JobDelay);
    }
    /// <summary>
    /// 同步執行指定的延遲時間
    /// </summary>
    /// <param name="delay">延遲時間(單位:秒)</param>
    public static void DelaySync(int delay)
    {
        Task.Delay(delay * 1000).Wait();
    }
    /// <summary>
    /// 非同步執行指定的延遲時間
    /// </summary>
    public async static Task DelayAsync()
    {
        await Task.Delay(JobDelay * 1000);
    }
    /// <summary>
    /// 非同步執行指定的延遲時間
    /// </summary>
    /// <param name="delay">延遲時間(單位:秒)</param>
    public async static Task DelayAsync(int delay)
    {
        await Task.Delay(delay * 1000);
    }
    /// <summary>
    /// 動作開始
    /// </summary>
    /// <param name="jobStep">步驟</param>
    /// <param name="jobName">動作名稱</param>
    /// <param name="delay">延遲秒數</param>
    /// <param name="startTime">是否指定開始時間</param>
    public static void SetJobStepStart(int jobStep, string jobName, int delay, bool startTime)
    {
        JobStep = jobStep;
        if (startTime) SetStartTime();
        JobName = jobName;
        JobDelay = delay;
        JobMessage = GetPadRightText(jobStep.ToString(), 2);
        JobMessage += string.Format(" {0}", Utilitys.StartTime.ToString("HH:mm:ss"));
        JobMessage += " ";
        JobMessage += jobName;
        Console.Write(JobMessage);
    }
    /// <summary>
    /// 動作結束
    /// </summary>
    public static void SetJobStepEnd()
    {
        string str_space = GetPadTextSpace(JobName, 30);
        string str_delay = GetPadLeftText(JobDelay.ToString(), 4);
        string str_total = GetPadLeftText(TotalSeconds.ToString(), 4);

        SetEndTime();
        JobMessage = str_space;
        JobMessage += string.Format(" {0}", EndTime.ToString("HH:mm:ss"));
        if (JobDelay > 0)
        {
            JobMessage += string.Format(" {0} {1}", str_delay, str_total);
            Console.Write(JobMessage);
        }
        Console.WriteLine();
    }
    /// <summary>
    /// 動作結束
    /// </summary>
    /// <param name="jobStep">步驟</param>
    /// <param name="jobName">動作名稱</param>
    /// <param name="delay">延遲秒數</param>
    public static void SetJobStepEnd(int jobStep, string jobName, int delay)
    {
        string str_seq = GetPadRightText(jobStep.ToString(), 2);
        string str_name = GetPadRightText(jobName, 30);
        string str_start = StartTime.ToString("HH:mm:ss");
        string str_end = DateTime.Now.ToString("HH:mm:ss");
        string ls_delay = GetPadLeftText(delay.ToString(), 4);
        string ls_total = GetPadLeftText(Utilitys.TotalSeconds.ToString(), 4);
        JobMessage = string.Format("{0} {1} {2} {3} {4} {5}", str_seq, str_start, str_name, str_end, ls_delay, ls_total);
        Console.Write(JobMessage);
        Console.WriteLine();
    }
}
