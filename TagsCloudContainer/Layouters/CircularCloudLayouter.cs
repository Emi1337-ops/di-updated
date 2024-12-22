using System.Drawing;

namespace TagsCloudContainer.Layouters
{
    public class CircularCloudLayouter : ILayouter
    {
        public readonly List<RectangleWord> rectangles;
        public readonly Point center;
        private double angle;
        private double spiralStep = 0.1;
        private double radiusStep = 0.5;

        public CircularCloudLayouter(Point center)
        {
            this.center = center;
            rectangles = new List<RectangleWord>();
        }

        public IEnumerable<RectangleWord> GetLayout(IOrderedEnumerable<SizeWord> words)
        {
            foreach (var word in words)
            {
                var rectangleSize = word.Size;
                Rectangle newRect;
                do
                {
                    var location = GetNextLocation(rectangleSize);
                    newRect = new Rectangle(location, rectangleSize);
                }
                while (IsIntersecting(newRect));
                rectangles.Add(new RectangleWord(word.Value, newRect));
            }
            return rectangles;
        }


        private Point GetNextLocation(Size rectangleSize)
        {
            var radius = radiusStep * angle;
            var centerX = center.X + (int)(radius * Math.Cos(angle));
            var centerY = center.Y + (int)(radius * Math.Sin(angle));
            angle += spiralStep;
            return GetCornerPoint(new Point(centerX, centerY), rectangleSize);
        }

        private bool IsIntersecting(Rectangle rectangle)
        {
            foreach (var existingRectangle in rectangles)
            {
                if (existingRectangle.IntersectsWith(rectangle))
                    return true;
            }
            return false;
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
}
