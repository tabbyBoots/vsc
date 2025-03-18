using Microsoft.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        ILoggerFactory factory = LoggerFactory.Create(builder =>
        {
            builder
                //.AddConsole()
                .AddColorConsoleLogger()
                .AddFileLogger();

        });

        int i = 0;
        ILogger logger = factory.CreateLogger(typeof(Program).Name);
        logger.LogInformation(1, "這是一個提示訊息!! 執行成功!!");
        logger.LogWarning(2, "這是一個警告訊息: {Description}.", "執行錯誤!!");
        logger.LogCritical(3, "這是一個嚴重錯誤訊息!!");
        logger.LogError(4, "這是一個錯誤訊息!!");
        logger.LogInformation(5, "變數 i 的值: {Number}", i);
        try
        {
            int j = 10 / i;
        }
        catch (Exception ex)
        {
            logger.LogError(6, ex, ex.Message);
        }
    }
}
