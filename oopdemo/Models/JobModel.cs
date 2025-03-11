namespace oop.demo;

/// <summary>
/// 執行工作 Job 模型
/// </summary>
public class JobModel : BaseClass
{
    /// <summary>
    /// 取得引用早餐資料模型列表
    /// </summary>
    /// <returns></returns>
    public List<Job> GetBreakFastJobList()
    {
        List<Job> model = new List<Job>();
        model.Add(new Job() { JobStep = 1, JobName = "倒杯咖啡", JobDelay = 2, TotalsSync = 2, TotalsAsync = 2 });
        model.Add(new Job() { JobStep = 2, JobName = "熱鍋", JobDelay = 3, TotalsSync = 5, TotalsAsync = 5 });
        model.Add(new Job() { JobStep = 3, JobName = "煎兩顆蛋", JobDelay = 6, TotalsSync = 11, TotalsAsync = 11 });
        model.Add(new Job() { JobStep = 4, JobName = "煎三片培根", JobDelay = 5, TotalsSync = 16, TotalsAsync = 0 });
        model.Add(new Job() { JobStep = 5, JobName = "烤兩片吐司", JobDelay = 4, TotalsSync = 20, TotalsAsync = 0 });
        model.Add(new Job() { JobStep = 6, JobName = "在吐司塗上奶油和果醬", JobDelay = 0, TotalsSync = 0, TotalsAsync = 0 });
        model.Add(new Job() { JobStep = 7, JobName = "  在吐司塗上奶油", JobDelay = 2, TotalsSync = 22, TotalsAsync = 13 });
        model.Add(new Job() { JobStep = 8, JobName = "  在吐司塗上果醬", JobDelay = 2, TotalsSync = 24, TotalsAsync = 15 });
        model.Add(new Job() { JobStep = 9, JobName = "倒杯柳橙汁", JobDelay = 6, TotalsSync = 30, TotalsAsync = 21 });
        return model;
    }

    /// <summary>
    /// 取得引用起床模型資料列表
    /// </summary>
    /// <returns></returns>
    public List<Job> GetGetUpJobList()
    {
        List<Job> model = new List<Job>();
        model.Add(new Job() { JobStep = 1, JobName = "刷牙", JobDelay = 2, TotalsSync = 2, TotalsAsync = 0 });
        model.Add(new Job() { JobStep = 2, JobName = "洗臉", JobDelay = 3, TotalsSync = 5, TotalsAsync = 0 });
        model.Add(new Job() { JobStep = 3, JobName = "洗澡", JobDelay = 4, TotalsSync = 9, TotalsAsync = 4 });
        model.Add(new Job() { JobStep = 4, JobName = "洗頭", JobDelay = 2, TotalsSync = 11, TotalsAsync = 0 });
        model.Add(new Job() { JobStep = 5, JobName = "吹乾頭髮", JobDelay = 1, TotalsSync = 12, TotalsAsync = 5 });
        model.Add(new Job() { JobStep = 6, JobName = "穿衣服", JobDelay = 2, TotalsSync = 14, TotalsAsync = 7 });
        model.Add(new Job() { JobStep = 7, JobName = "喝牛奶", JobDelay = 1, TotalsSync = 15, TotalsAsync = 0 });
        model.Add(new Job() { JobStep = 8, JobName = "吃麵包", JobDelay = 3, TotalsSync = 18, TotalsAsync = 10 });
        model.Add(new Job() { JobStep = 9, JobName = "坐公車", JobDelay = 6, TotalsSync = 24, TotalsAsync = 16 });
        model.Add(new Job() { JobStep = 10, JobName = "看書", JobDelay = 3, TotalsSync = 27, TotalsAsync = 0 });
        return model;
    }
}
