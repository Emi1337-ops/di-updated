using NPOI.OpenXmlFormats.Dml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.WordSizer
{
    public class SimpleSizer : ISizer
    {
        private readonly Config config;

        public SimpleSizer(Config config)
        {
            this.config = config;
        }

        public IEnumerable<SizeWord> GetSizes(IDictionary<string, int> words)
        {
            var screeenSize = config.PictureHeight * config.PictureWidth;
            var sum = words.Sum(x => x.Value);
            var list = new List<SizeWord>();

            foreach (var item in words.OrderByDescending(x => x.Value))
            {
                var part = (double)item.Value / sum;
                var maxHeight = (int)(config.PictureHeight * part);
                var maxWidth = (int)(config.PictureWidth * part);
                var maxSize = new Size(maxWidth, maxHeight);
                var (size, font) = GetFontSize(maxSize, config.Font, item.Key);
                list.Add(new SizeWord(item.Key, size, font));
                //list.Add(new SizeWord(item.Key, maxSize, new Font("Arial", 23)));
            }
            return list;
        }

        private static (Size, Font) GetFontSize(Size maxSize, string fontName, string text)
        {
            var maxFontSize = 200;
            var minFontSize = 1;

            var tempBitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(tempBitmap);
            Size textSize;
            Font font;

            for (var i = maxFontSize; i >= minFontSize; i--)
            {
                font = new Font(fontName, i);
                var t = graphics.MeasureString(text, font);
                textSize = t.ToSize();
                if (textSize.Width * textSize.Height <= maxSize.Width * maxSize.Height)
                {
                    return (textSize, font);
                }
            }

            font = new Font(fontName, 1);
            textSize = graphics.MeasureString(text, font).ToSize();
            return (textSize, font);
        }

    }
}
