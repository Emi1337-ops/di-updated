using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.WordSizer
{
    public class SimpleSizer : ISizer
    {
        public IOrderedEnumerable<SizeWord> GetSizes(IDictionary<string, int> words)
        {
            var orderedKeys = words.OrderByDescending(x => x.Key).ToDictionary().Keys;
            return default;
        }

        static SizeF GetTextSize(string text, string fontName, float fontSize)
        {
            using (var font = new Font(fontName, fontSize))
            {
                using (var tempBitmap = new Bitmap(1, 1))
                {
                    using (var graphics = Graphics.FromImage(tempBitmap))
                    {
                        return graphics.MeasureString(text, font);
                    }
                }
            }
        }
    }
}
