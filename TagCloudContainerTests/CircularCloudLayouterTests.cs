using FluentAssertions;
using NUnit.Framework.Interfaces;
using System.Drawing;
using TagsCloudContainer;
using TagsCloudContainer.Layouters;
using TagsCloudContainer.Visualizers;
using TagsCloudContainer.WordClasses;

namespace TagCloudContainerTests;

[TestFixture]
public class CircularCloudLayouterTests
{

    private CircularCloudLayouter layouter;
    private Config config;
    private IVisualizer visualizer;

    private readonly string text = "text";
    private readonly Font font = new("Arial", 15);

    [SetUp]
    public void Setup()
    {
        config = new Config();
        layouter = new CircularCloudLayouter(config);
        visualizer = new ImageVisualizer(config);
    }

    [TearDown]
    public void Teardown()
    {
        var testResult = TestContext.CurrentContext.Result.Outcome;
        var testName = TestContext.CurrentContext.Test.Name;
        if (Equals(testResult, ResultState.Failure) ||
            Equals(testResult == ResultState.Error))
        {
            var drawer = visualizer;
            var directory = Path.Combine(Constants.ProjectDirectory, $"FailedTestTagCloud.{testName}.jpeg");
            config.OutputDirectory = directory;
            drawer.GenerateImage(layouter.Rectangles);
            Console.WriteLine($"Tag cloud visualization saved to file {directory}");
        }
    }

    private SizeWord GetDefaultSizeWord(Size size)
    {
        return new SizeWord(text, size, font);
    }

    [Test]
    public void CircularCloudLayouter_Constructor_CorrectlySetCenter()
    {
        layouter.GetLayout([]);

        layouter.Center
            .Should()
            .Be(new Point(config.PictureWidth / 2, config.PictureHeight / 2));
    }

    [Test]
    public void PutNextRectangle_PlacesFirstRectangleToCenter()
    {
        var size = new Size(50, 50);

        var rectangles = layouter.GetLayout([GetDefaultSizeWord(size)]);
        var centerRecLocation = CircularCloudLayouter.
            GetCornerPoint(layouter.Center, size);

        rectangles
            .First()
            .Bounds
            .Location
            .Should()
            .Be(centerRecLocation);
    }

    [Test]
    public void PutNextRectangle_RectanglesDoesNotIntersect()
    {
        var sizeList = new List<SizeWord>();

        for (int i = 10; i < 100; i += 10)
            for (int j = 5; j < 50; j += 5)
                sizeList.Add(GetDefaultSizeWord(new Size(i, j)));
            
        var rectangles = layouter.GetLayout(sizeList);
        var length = layouter.Rectangles.Count;
        for (int i = 0; i < length - 1; i++)
            for (int j = 0; j < length - 1; j++)
            {
                if (i != j)
                    layouter.Rectangles[i]
                        .Bounds
                        .IntersectsWith(layouter.Rectangles[j].Bounds)
                        .Should().BeFalse();
            }
    }

    [Test]
    public void PutNextRectangle_IncreaseDistanceFromCenter_WithMoreRectangles()
    {
        var sizeList = new List<SizeWord>
        {
            GetDefaultSizeWord(new Size(20,10))
        };

        for (int i = 10; i < 100; i += 10)
            for (int j = 10; j < 50; j += 10)
                sizeList.Add(GetDefaultSizeWord(new Size(i, j)));
        sizeList.Add(GetDefaultSizeWord(new (20, 30)));

        var rectangles = layouter.GetLayout(sizeList);
        var firstRectangle = rectangles.First();
        var lastRectangle = rectangles.Last();

        var firstDistance = FindDistance(layouter.Center, firstRectangle.Bounds.Location);
        var lastDistance = FindDistance(layouter.Center, lastRectangle.Bounds.Location);

        lastDistance.Should().BeGreaterThan(firstDistance);
    }

    private double FindDistance(Point r1, Point r2)
    {
        return Math.Sqrt(Math.Pow(r2.X - r1.X, 2) + Math.Pow(r2.Y - r1.Y, 2));
    }

    [Test]
    public void PutNextRectangle_ShouldPlaceRectanglesInSpiral()
    {
        var sizeList = new List<SizeWord>
        {
            GetDefaultSizeWord(new Size(10,10)),
            GetDefaultSizeWord(new Size(10,10)),
            GetDefaultSizeWord(new Size(10,10)),
            GetDefaultSizeWord(new Size(10,10)),
            GetDefaultSizeWord(new Size(10,10))
        };

        var rectangles = layouter.GetLayout(sizeList);
        var firstRectangle = rectangles.First().Bounds;

        CircularCloudLayouter.GetCenterPoint(firstRectangle).Should().Be(layouter.Center);
        for (int i = 1; i < 4; i++)
        {
            var rect = layouter.Rectangles[i];
            FindDistance(firstRectangle.Location, rect.Bounds.Location).Should().BeLessThan(30);
        }
    }
}
