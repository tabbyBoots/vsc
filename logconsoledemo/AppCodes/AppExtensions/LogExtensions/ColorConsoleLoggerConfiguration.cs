using Microsoft.Extensions.Logging;

/// <summary>
/// 自定義記錄器組態
/// </summary>
public sealed class ColorConsoleLoggerConfiguration
{
    /// <summary>
    /// 事件識別碼
    /// </summary>
    public int EventId { get; set; }
    /// <summary>
    /// 根據每個記錄層級和事件識別碼建立不同顏色的控制台項目
    /// </summary>
    public Dictionary<LogLevel, ConsoleColor> LogLevelToColorMap { get; set; } = new()
    {
        [LogLevel.Information] = ConsoleColor.Green,
        [LogLevel.Warning] = ConsoleColor.Yellow,
        [LogLevel.Error] = ConsoleColor.Red,
        [LogLevel.Critical] = ConsoleColor.Magenta
    };
}
