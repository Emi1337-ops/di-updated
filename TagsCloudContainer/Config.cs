using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudContainer
{
    public class Config
    {
        public string InputDirectory { get; init; }
        public string OutputDirectory { get; init; }
        public int PictureWidth { get; init; }
        public int PictureHeight { get; init; }
        public string Font { get; init; }
        public string[] StopWords { get; init; }
        public string[] PictureColors { get; init; }

        public Config(
        string inputDirectory,
        string outputDirectory,
        int pictureWidth,
        int pictureHeight,
        string font,
        string[] stopWords,
        string[] pictureColors)
        {
            InputDirectory = inputDirectory;
            OutputDirectory = outputDirectory;
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            Font = font;
            StopWords = stopWords;
            PictureColors = pictureColors;
        }
    }
}
