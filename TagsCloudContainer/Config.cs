using Org.BouncyCastle.Asn1.Esf;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

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

    public static bool TryValidateConfig(Config config)
    {
        if (!Path.Exists(config.InputDirectory))
            throw new FileNotFoundException("File not found.", config.InputDirectory);

        if (!Path.Exists(Path.Combine(config.OutputDirectory, @"..\")))
            throw new FileNotFoundException("File not found.", config.OutputDirectory);

        if (config.PictureWidth <= 0 || config.PictureWidth > 3000)
            throw new ArgumentException("Picture Width shoud be more than zero and less than 3000", config.OutputDirectory);

        if (config.PictureHeight <= 0 || config.PictureHeight > 3000)
            throw new ArgumentException("Picture Height shoud be more than zero and less than 3000", config.OutputDirectory);

        if (!IsFontAvailable(config.Font))
            throw new ArgumentException("Font doesn't exist in system", config.Font);

        return true;
    }

    private static bool IsFontAvailable(string fontName)
    {
        try
        {
            using (var font = new Font(fontName, 12))
            {
                return font.Name.Equals(fontName, StringComparison.InvariantCultureIgnoreCase);
            }
        }
        catch
        {
            return false;
        }
    }
}
