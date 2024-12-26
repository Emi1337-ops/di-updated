using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using TagsCloudContainer;

public class ConsoleClient
{
    [Option("--input", "Path to the input file.", CommandOptionType.SingleValue)]
    public string InputDirectory { get; set; }

    [Option("--output", "Path to the output file.", CommandOptionType.SingleValue)]
    public string OutputDirectory { get; set; }

    [Option("--width", "Width of the picture.", CommandOptionType.SingleValue)]
    public int PictureWidth { get; set; }

    [Option("--height", "Height of the picture.", CommandOptionType.SingleValue)]
    public int PictureHeight { get; set; }

    [Option("--font", "Font for the picture text.", CommandOptionType.SingleValue)]
    public string Font { get; set; }

    [Option("--stopwords", "Comma-separated list of stop words.", CommandOptionType.SingleValue)]
    public string StopWordsInput { get; set; }

    [Option("--colors", "Comma-separated list of colors in ARGB format (e.g., 255,0,0,255).", CommandOptionType.SingleValue)]
    public string ColorsInput { get; set; }

    public string[] StopWords => StopWordsInput?.Split(',').Select(x => x.ToLower()).ToArray() ?? Array.Empty<string>();

    public string[] PictureColors => ColorsInput?.Split(',') ?? Array.Empty<string>();

    public static int Main(string[] args)
    {
        return CommandLineApplication.Execute<ConsoleClient>(args);
    }

    private void OnExecute()
    {
        var config = new Config(
            InputDirectory is null ? Constants.InputDirectory : InputDirectory,
            OutputDirectory is null ? Constants.OutputDirectory : OutputDirectory,
            PictureWidth == default ? Constants.PictureWidth : PictureWidth,
            PictureHeight == default ? Constants.PictureHeight : PictureHeight,
            Font is null ? Constants.Font : Font,
            StopWords is null ? Constants.StopWords : StopWords,
            PictureColors is null ? Constants.PictureColors : PictureColors
           );

        TagsCloudContainer.Program.Main(config);
        Console.WriteLine(config);
    }
}

