﻿using System.Drawing;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.Layouters;

public class CircularCloudLayouter : ILayouter
{
    public readonly List<RectangleWord> Rectangles = []; // public нужен для тестов
    public Point Center;
    private double angle;
    private const double spiralStep = 0.1;
    private const double radiusStep = 0.5;
    private readonly Config config;

    public CircularCloudLayouter(Config config)
    {
        this.config = config;
    }

    public IEnumerable<RectangleWord> GetLayout(IEnumerable<SizeWord> words)
    {
        Center = new Point(config.PictureWidth / 2, config.PictureHeight / 2);
        foreach (var (value, rectangleSize, font) in words)
        {
            Rectangle newRect;
            do
            {
                var location = GetNextLocation(rectangleSize);
                newRect = new Rectangle(location, rectangleSize);
            }
            while (IsIntersecting(newRect));
            Rectangles.Add(new RectangleWord(value, newRect, font));
        }
        return Rectangles;
    }

    private Point GetNextLocation(Size rectangleSize)
    {
        var radius = radiusStep * angle;
        var centerX = Center.X + (int)(radius * Math.Cos(angle));
        var centerY = Center.Y + (int)(radius * Math.Sin(angle));
        angle += spiralStep;
        return GetCornerPoint(new Point(centerX, centerY), rectangleSize);
    }

    public bool IsIntersecting(Rectangle rectangle)
    {
        return Rectangles.
            Any(existingRectangle => 
                existingRectangle.Bounds.IntersectsWith(rectangle));
    }

    public static Point GetCornerPoint(Point center, Size size)
    {
        return new Point(center.X - size.Width / 2, center.Y - size.Height / 2);
    }

    public static Point GetCenterPoint(Rectangle rect)
    {
        return new Point(rect.Location.X + rect.Width / 2, rect.Location.Y + rect.Height / 2);
    } 
}
