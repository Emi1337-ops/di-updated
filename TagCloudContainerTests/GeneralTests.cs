using FluentAssertions;
using System.Drawing;
using TagsCloudContainer;
using TagsCloudContainer.FileReaders;
using TagsCloudContainer.Filters;
using TagsCloudContainer.Layouters;
using TagsCloudContainer.Parsers;
using TagsCloudContainer.Visualizers;
using TagsCloudContainer.WordClasses;
using TagsCloudContainer.WordSizer;

namespace TagCloudContainerTests
{
    [TestFixture]
    public class GeneralTests
    {
        private Config config;
        private string[] stopWords;
        

        [SetUp]
        public void Setup()
        {
            config = new Config();
            config.InputDirectory = @"C:\Users\dima0\source\repos\di-updated\TagsCloudContainer\Files\General.txt";
            config.OutputDirectory = @"C:\Users\dima0\source\repos\di-updated\TagsCloudContainer\Pictures\general.jpg";
            config.PictureWidth = 600;
            config.PictureHeight = 700;
            config.Font = "Impact";
            config.StopWords = ["отпуск", "птица", "любовь"];
            config.RightWords = ["я"];

            stopWords = config.StopWords;
        }

        [Test]
        public void CircularCloudContainer_GeneralTest()
        {
            var reader = new TxtFileReader();
            var filter = new WordsFilter(config);
            var parser = new SimpleParser(filter);
            var sizer = new SimpleSizer(config);
            var layouter = new CircularCloudLayouter(config);
            var visualizer = new ImageVisualizer(config);

            var words = reader.Read(config.InputDirectory);
            var filteredWords = parser.Parse(words);
            var wordSizes = sizer.GetSizes(filteredWords);
            var layout = layouter.GetLayout(wordSizes);
            visualizer.GenerateImage(layout);

            stopWords.All(x => filter.Contains(x)).Should().BeTrue();
            filter.Contains("я").Should().BeFalse();

            wordSizes.All(x => filter.Contains(x.Value)).Should().BeFalse();
            wordSizes.All(x => x.font.Name == "Impact").Should().BeTrue();
            wordSizes.Any(x => x.Value == "я").Should().BeTrue();

            layout.All(x => filter.Contains(x.Value)).Should().BeFalse();
            layout.All(x => x.font.Name == "Impact").Should().BeTrue();
            layout.Any(x => x.Value == "я").Should().BeTrue();

            using Image image = Image.FromFile(config.OutputDirectory);
            image.Width.Should().Be(600);
            image.Height.Should().Be(700);
        }
    }
}
