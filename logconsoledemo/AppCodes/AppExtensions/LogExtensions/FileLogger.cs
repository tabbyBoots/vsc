using Microsoft.Extensions.Logging;

/// <summary>
/// 自訂記錄器
/// </summary>
public sealed class FileLogger(string name) : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        WriteLogToFile(eventId.Id, Enum.GetName(logLevel), name, formatter(state, exception));
    }
    // 寫入日誌檔案
    private void WriteLogToFile(int eventId, string logLevel, string name, string message)
    {
        // 寫入檔案
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        string fileName = $"{DateTime.Now:yyyy-MM-dd}.log";
        string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{eventId}] {name}: {message}";
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        path = Path.Combine(path, logLevel);
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        File.AppendAllText(Path.Combine(path, fileName), log + Environment.NewLine);
    }
}
