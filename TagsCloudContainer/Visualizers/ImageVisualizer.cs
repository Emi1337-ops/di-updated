using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.Visualizers
{
    public class ImageVisualizer : IVisualizer
    {
        private Config config;
        public ImageVisualizer(Config config)
        {
            this.config = config;
        }

        public void GenerateImage(IEnumerable<RectangleWord> words)
        {
            var image = new Bitmap(config.PictureWidth, config.PictureWidth);
            var g = Graphics.FromImage(image);
            var pen = new Pen(Brushes.AliceBlue, 2);
            var count = 0;
            foreach (var item in words)
            {
                count++;
                g.DrawRectangle(pen, item.Bounds);
                g.DrawString(item.Value, item.font, Brushes.Orange, item.Bounds.Location);
            }

            image.Save(config.OutputDirectory, ImageFormat.Jpeg);
        }
    }
}
