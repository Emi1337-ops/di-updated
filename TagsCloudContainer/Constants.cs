using System.Text.RegularExpressions;

namespace TagsCloudContainer;
public static partial class Constants
{
    public static string InputDirectory
        => Path.Combine(ProjectDirectory, "TagsCloudContainer\\Files\\defaultTxt.txt");

    public static string OutputDirectory 
        => Path.Combine(ProjectDirectory, "TagsCloudContainer\\Pictures\\picture4.jpg");

    public static string FilterWordsDirectory 
        => Path.Combine(ProjectDirectory, "TagsCloudContainer\\Files\\filterwords.txt");

    public static string ProjectDirectory
        => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));

    public static int PictureWidth => 800;

    public static int PictureHeight => 800;

    public static string Font => "Arial";

    public static string[] StopWords => [];

    public static string[] RightWords => [];

    public static string[] PictureColors => [];

    public readonly static Regex WordsSplitRegex = new(
        pattern: @"\b[а-яА-ЯёЁa-zA-Z]+\b",
        options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public readonly static Regex OnlyLettersRegex = new(
        pattern: @"^[a-zA-Z]+$",
        options: RegexOptions.Compiled | RegexOptions.IgnoreCase);
}
