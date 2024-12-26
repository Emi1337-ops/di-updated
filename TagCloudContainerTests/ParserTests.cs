using FluentAssertions;
using TagsCloudContainer;
using TagsCloudContainer.FileReaders;
using TagsCloudContainer.Filters;
using TagsCloudContainer.Parsers;

namespace TagCloudContainerTests;

[TestFixture]
public class ParserTests
{
    private Config config;
    private WordsFilter defaultFilter;

    [SetUp]
    public void Setup()
    {
        config = new Config();
        defaultFilter = new WordsFilter(config);
    }

    [TestCase("Шла Саша шоссе")]
    [TestCase("Бублик Печенька")]
    [TestCase("Автобот качели")]
    [TestCase("мимино квадрат малевич")]
    public void Parser_CorrectWithSimpleWords(string text)
    {
        var parser = new SimpleParser(defaultFilter);

        var parsed = parser.Parse(text);

        foreach (var word in text.Split(' '))
        {
            parsed.ContainsKey(word.ToLower()).Should().BeTrue();
        }
    }

    [TestCase("Шла %1--Саша @#^%шоссе", "шла саша шоссе")]
    [TestCase("Бублик@ -Печенька", "бублик печенька")]
    [TestCase("()()()Автобот _+качели", "автобот качели")]
    [TestCase("мимино% квадрат$ #малевич++", "мимино квадрат малевич")]
    [TestCase("%:(*?кролик:%**)", "кролик")]
    public void Parser_CorrectWithNonLettericSymbols(string text, string correct)
    {
        var parser = new SimpleParser(defaultFilter);

        var parsed = parser.Parse(text);

        foreach (var word in correct.Split(' '))
        {
            parsed.ContainsKey(word).Should().BeTrue();
        }
    }


    [TestCase("шла я и саша по шоссе", "шла саша шоссе")]
    [TestCase("бублик под печенькой", "бублик печенькой")]
    [TestCase("автобот от качелей", "автобот качелей")]
    [TestCase("мимино оно как квадрат малевича", "мимино квадрат малевича")]
    public void Parser_FilterStopWords(string text, string correct)
    {
        var parser = new SimpleParser(defaultFilter);

        var parsed = parser.Parse(text);

        foreach (var word in correct.Split(' '))
        {
            parsed.ContainsKey(word).Should().BeTrue();
        }
    }

    [Test]
    public void Parser_GiveCorrectWeightToWords()
    {
        var parser = new SimpleParser(defaultFilter);
        var text = "один два два три три три четыре четыре четыре четыре";
        var correct = new Dictionary<string, int>
        {
            { "один", 1},
            { "два", 2},
            { "три", 3},
            { "четыре", 4},
        };

        var parsed = parser.Parse(text);

        parsed.Should().BeEquivalentTo(correct);
    }
}
