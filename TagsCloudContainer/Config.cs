using Spire.Doc.Documents;

namespace TagsCloudContainer;

public class Config
{
    public string InputDirectory { get; set; }
    public string OutputDirectory { get; set; }
    public int PictureWidth { get; set; }
    public int PictureHeight { get; set; }
    public string Font { get; set; }
    public string[] StopWords { get; set; }
    public string[] RightWords { get; set; }
    public string[] PictureColors { get; set; }

    public Config(
        string inputDirectory,
        string outputDirectory,
        int pictureWidth,
        int pictureHeight,
        string font,
        string[] stopWords,
        string[] rightWords,
        string[] pictureColors)
    {
        InputDirectory = inputDirectory;
        OutputDirectory = outputDirectory;
        PictureWidth = pictureWidth;
        PictureHeight = pictureHeight;
        Font = font;
        StopWords = stopWords;
        RightWords = rightWords;
        PictureColors = pictureColors;
    }

    public Config()
    {
        InputDirectory = Constants.InputDirectory;
        OutputDirectory = Constants.OutputDirectory;
        PictureWidth = Constants.PictureWidth;
        PictureHeight = Constants.PictureHeight;
        Font = Constants.Font;
        StopWords = Constants.StopWords;
        RightWords = Constants.RightWords;
        PictureColors = Constants.PictureColors;
    }
}
