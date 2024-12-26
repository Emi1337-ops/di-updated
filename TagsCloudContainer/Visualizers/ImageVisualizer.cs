using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.Visualizers;

public class ImageVisualizer : IVisualizer
{
    private Config config;
    public ImageVisualizer(Config config)
    {
        this.config = config;
    }

    public void GenerateImage(IEnumerable<RectangleWord> words)
    {
        using var image = new Bitmap(config.PictureWidth, config.PictureWidth);
        using var g = Graphics.FromImage(image);
        var pen = new Pen(Brushes.AliceBlue, 2);

        foreach (var item in words)
        {
            g.DrawRectangle(pen, item.Bounds);
            g.DrawString(item.Value, item.font, Brushes.Orange, item.Bounds.Location);
        }

        image.Save(config.OutputDirectory, ImageFormat.Jpeg);
    }
}
