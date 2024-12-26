using TagsCloudContainer.FileReaders;

namespace TagsCloudContainer.Filters;

public class WordsFilter : IFilter
{
    private HashSet<string> words;

    public WordsFilter(Config config)
    {
        words = [];
        var reader = new TxtFileReader();
        var filterWords = reader.Read(Constants.FilterWordsDirectory);

        var matches = Constants.WordsSplitRegex.Matches(filterWords);

        for (var i = 0; i < matches.Count; i++)
        {
            words.Add(matches[i].Value);
        }

        AddStopWords(config.StopWords);
        RemoveStopWords(config.RightWords);
    }

    public bool Contains(string word)
    {
        return words.Contains(word);
    }

    public void AddStopWord(string word)
    {
        words.Add(word);
    }

    public void RemoveStopWord(string word)
    {
        words.Remove(word);
    }

    public void AddStopWords(string[] wordArray)
    {
        foreach (var word in wordArray)
            AddStopWord(word);
    }

    public void RemoveStopWords(string[] wordArray)
    {
        foreach (var word in wordArray)
            RemoveStopWord(word);
    }
}