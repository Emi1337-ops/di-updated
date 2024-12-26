using McMaster.Extensions.CommandLineUtils;
using Autofac;
using TagsCloudContainer;

public class ConsoleClient
{
    [Option("--input", "Path to the input file.", CommandOptionType.SingleValue)]
    public string? InputDirectory { get; set; }

    [Option("--output", "Path to the output file.", CommandOptionType.SingleValue)]
    public string? OutputDirectory { get; set; }

    [Option("--width", "Width of the picture.", CommandOptionType.SingleValue)]
    public int PictureWidth { get; set; }

    [Option("--height", "Height of the picture.", CommandOptionType.SingleValue)]
    public int PictureHeight { get; set; }

    [Option("--font", "Font for the picture text.", CommandOptionType.SingleValue)]
    public string? Font { get; set; }

    [Option("--stopwords", "Comma-separated list of stop words.", CommandOptionType.SingleValue)]
    public string? StopWordsInput { get; set; }

    [Option("--rightwords", "Comma-separated list of right words.", CommandOptionType.SingleValue)]
    public string? RightWordsInput { get; set; }

    [Option("--colors", "Comma-separated list of colors in ARGB format (e.g., 255,0,0,255).", CommandOptionType.SingleValue)]
    public string? ColorsInput { get; set; }

    public static int Main(string[] args)
    {
        return RunConsoleClient(args);
    }

    private static int RunConsoleClient(string[] args)
    {
        return CommandLineApplication.Execute<ConsoleClient>(args);
    }

    private void OnExecute()
    {
        var config = new Config(
            InputDirectory ?? Constants.InputDirectory,
            OutputDirectory ?? Constants.OutputDirectory,
            PictureWidth == default ? Constants.PictureWidth : PictureWidth,
            PictureHeight == default ? Constants.PictureHeight : PictureHeight,
            Font ?? Constants.Font,
            StopWordsInput?.Split(',').Select(x => x.ToLower()).ToArray() ?? Constants.StopWords,
            RightWordsInput?.Split(',').Select(x => x.ToLower()).ToArray() ?? Constants.RightWords,
            ColorsInput?.Split(',') ?? Constants.PictureColors
        );

        var container = ApplicationRunner.BuildContainer(config);

        using var scope = container.BeginLifetimeScope();
        var runner = scope.Resolve<IApplicationRunner>();
        runner.Run();
    }

    
}


