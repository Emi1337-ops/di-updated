using TagsCloudContainer.FileReaders;
using TagsCloudContainer;
using TagsCloudContainer.Filters;
using FluentAssertions;

namespace TagCloudContainerTests;

[TestFixture]
public class FilterTests
{
    private Config config;
    private string filterWordsFile;

    [SetUp]
    public void Setup()
    {
        config = new Config();
        var folderPath = Path.Combine(Constants.ProjectDirectory, "TagCloudConrainerTests\\Files");
        filterWordsFile = Path.Combine(folderPath, "FilterWords.txt");
    }

    [Test]
    public void Filter_ReadWordsFromFile()
    {
        var filter = new WordsFilter(config);
        var reader = new TxtFileReader();

        var filterWords = 
            reader
            .Read(Constants.FilterWordsDirectory)
            .Split("\r\n")
            .ToArray();

        foreach (var word in filterWords)
        {
            filter.Contains(word).Should().BeTrue();
        }
    }

    [TestCase("Абрикос")]
    [TestCase("Яблоко")]
    [TestCase("Глицерин")]
    [TestCase("Сталин")]
    [TestCase("Car")]
    public void Filter_AddStopWord_FromMethod(string stopWord)
    {
        var filter = new WordsFilter(config);
        filter.AddStopWord(stopWord);
        
        filter.Contains(stopWord).Should().BeTrue();
    }


    public void Filter_AddStopWords_FromMethod()
    {
        var filter = new WordsFilter(config);
        var stopWord = new string[] { "Карамель", "Ирис", "Шоколадка", "Трансформер" };
        filter.AddStopWords(stopWord);

        foreach (var word in stopWord)
        {
            filter.Contains(word).Should().BeTrue();
        }
    }

    [TestCase("а")]
    [TestCase("в")]
    [TestCase("за")]
    [TestCase("под")]
    [TestCase("из")]
    public void Filter_RemoveRightWord_FromMethod(string stopWord)
    {
        var filter = new WordsFilter(config);
        filter.RemoveRightWord(stopWord);

        filter.Contains(stopWord).Should().BeFalse();
    }

    [Test]
    public void Filter_RemoveRightWords_FromMethod()
    {
        var filter = new WordsFilter(config);
        var rightWord = new string[] { "он", "она", "они", "оно" };
        filter.RemoveRightWords(rightWord);

        foreach (var word in rightWord)
        {
            filter.Contains(word).Should().BeFalse();
        }
    }

    [Test]
    public void Filter_AddStopWords_FromConfig()
    {
        config.StopWords = ["Моска", "Волгоград"];
        var filter = new WordsFilter(config);

        foreach (var word in config.StopWords)
        {
            filter.Contains(word).Should().BeTrue();
        }
    }

    public void Filter_RemoveRightWords_FromConfig()
    {
        config.StopWords = ["он", "она", "они", "оно"];
        var filter = new WordsFilter(config);

        foreach (var word in config.StopWords)
        {
            filter.Contains(word).Should().BeFalse();
        }
    }
}

