using FluentAssertions;
using System.Drawing;
using TagsCloudContainer;
using TagsCloudContainer.WordSizer;

namespace TagCloudContainerTests;

[TestFixture]
public class SizerTests
{
    private Config config;
    private Dictionary<string, int> defaultDictionary;

    [SetUp]
    public void Setup()
    {
        config = new Config();

        defaultDictionary = new Dictionary<string, int>
        {
            { "один", 1},
            { "два", 2},
            { "три", 3},
            { "четыре", 4},
        };

        var folderPath = Path.Combine(Constants.ProjectDirectory, "TagCloudConrainerTests\\Files");
    }

    [Test]
    public void Sizer_ReturnSizeForAllWords()
    {
        var sizer = new SimpleSizer(config);

        var sized = sizer.GetSizes(defaultDictionary);

        sized.Count().Should().Be(defaultDictionary.Keys.Count);
        sized.All(x => defaultDictionary.ContainsKey(x.Value)).Should().BeTrue();
    }

    [Test]
    public void Sizer_GiveBiggerSizeToHeavierWord()
    {
        var sizer = new SimpleSizer(config);

        var sized = sizer.GetSizes(defaultDictionary).ToArray();
        for (var i = 0; i < sized.Length - 2; i++)
        {
            var heavierWord = GetSizeSquare(sized[i].Size);
            var lighterWord = GetSizeSquare(sized[i + 1].Size);
            heavierWord.Should().BeGreaterThan(lighterWord);
        }
    }

    private int GetSizeSquare(Size size)
    {
        return size.Width * size.Height;
    }

}