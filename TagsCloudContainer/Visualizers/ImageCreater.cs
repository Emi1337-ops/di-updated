﻿using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudContainer.Visualizers
{
    public class ImageCreater
    {
        private readonly int Width;
        private readonly int Height;

        public ImageCreater(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Generate(IEnumerable<Rectangle> items, string directory)
        {
            var image = new Bitmap(Width, Height);
            var g = Graphics.FromImage(image);
            var pen = new Pen(Brushes.AliceBlue, 2);
            var count = 0;
            foreach (var item in items)
            {
                count++;
                g.DrawRectangle(pen, item);
                g.DrawString("text", SystemFonts.DialogFont, Brushes.Aqua, item.Location);
            }

            image.Save(directory, ImageFormat.Jpeg);

        }
    }
}
