using Microsoft.Extensions.Logging;

/// <summary>
/// LogService 日誌服務
/// </summary>
/// <typeparam name="T">日誌對象類別</typeparam>
public class LogService<T> where T : class
{
    private readonly ILogger _logger; // 日誌物件
    /// <summary>
    /// 建構子
    /// </summary>
    public LogService()
    {
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        _logger = factory.CreateLogger(typeof(T).Name);
    }
    /// <summary>
    /// 輸出提示訊息
    /// </summary>
    /// <param name="message">訊息文字</param>
    /// <param name="Description">詳細說明</param>
    public void LogInformation(string message, string Description = "")
    {
        _logger.LogInformation(message + Description);
    }
    /// <summary>
    /// 輸出警告訊息
    /// </summary>
    /// <param name="message">訊息文字</param>
    /// <param name="Description">詳細說明</param>
    public void LogWarning(string message, string Description = "")
    {
        _logger.LogWarning(message + Description);
    }
    /// <summary>
    /// 輸出嚴重錯誤訊息
    /// </summary>
    /// <param name="message">訊息文字</param>
    /// <param name="Description">詳細說明</param>
    public void LogCritical(string message, string Description = "")
    {
        _logger.LogCritical(message + Description);
    }
    /// <summary>
    /// 輸出錯誤訊息
    /// </summary>
    /// <param name="message">訊息文字</param>
    /// <param name="Description">詳細說明</param>
    public void LogError(string message, string Description = "")
    {
        _logger.LogError(message + Description);
    }
    /// <summary>
    /// 靜態方法輸出日誌
    /// </summary>
    /// <param name="logLevel">日誌類型</param>
    /// <param name="message">訊息文字</param>
    /// <param name="Description">詳細說明</param>
    public static void LogMessage(LogLevel logLevel, string message, string Description = "")
    {
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger(typeof(T).Name);
        if (logLevel == LogLevel.Information)
            logger.LogInformation(message + Description);
        else if (logLevel == LogLevel.Warning)
            logger.LogWarning(message + Description);
        else if (logLevel == LogLevel.Critical)
            logger.LogCritical(message + Description);
        else if (logLevel == LogLevel.Error)
            logger.LogError(message + Description);
    }
}
