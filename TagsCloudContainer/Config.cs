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
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public int PictureWidth { get; set; }
        public int PictureHeight { get; set; }
        public string Font { get; set; }
        public string[] StopWords { get; set; }
        public Color[] PictureColors { get; set; }
 
    }
}
