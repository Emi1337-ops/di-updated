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
        RemoveRightWords(config.RightWords);
    }

    public bool Contains(string word)
    {
        return words.Contains(word);
    }

    public void AddStopWord(string word)
    {
        if (Constants.OnlyLettersRegex.IsMatch(word))
            words.Add(word);
    }

    public void RemoveRightWord(string word)
    {
        words.Remove(word);
    }

    public void AddStopWords(string[] wordArray)
    {
        foreach (var word in wordArray)
            AddStopWord(word);
    }

    public void RemoveRightWords(string[] wordArray)
    {
        foreach (var word in wordArray)
            RemoveRightWord(word);
    }
}