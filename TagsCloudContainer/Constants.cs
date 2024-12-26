using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TagsCloudContainer
{
    public static class Constants
    {
        public static string InputDirectory
        {
            get
            {
                var projectDirectory =
                    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));
                return Path.Combine(projectDirectory, "TagsCloudContainer\\Files\\defaultTxt1.txt");
            }
        }

        public static string OutputDirectory { get
            {
                var projectDirectory =
                    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));
                return Path.Combine(projectDirectory, "TagsCloudContainer\\Files\\picture.jpg");
            } 
        }

        public static string FilterWordsDirectory
        {
            get
            {
                var projectDirectory =
                    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));
                return Path.Combine(projectDirectory, "TagsCloudContainer\\Files\\filterwords.txt");
            }
        }

        public static int PictureWidth { get { return 800; } }

        public static int PictureHeight { get { return 800; } }

        public static string Font { get { return "Arial"; } }

        public static string[] StopWords { get { return []; } }

        public static string[] PictureColors { get { return []; } }

        public static Regex wordsSplitRegex = new(pattern: @"\b[а-яА-ЯёЁa-zA-Z]+\b",
            options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    }
}
