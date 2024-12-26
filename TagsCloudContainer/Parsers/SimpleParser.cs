using TagsCloudContainer.Filters;

namespace TagsCloudContainer.Parsers;
public class SimpleParser : IParser
{
    private IFilter wordsFilter;
    public SimpleParser(IFilter wordsFilter) 
    {
        this.wordsFilter = wordsFilter;
    }

    public IDictionary<string, int> Parse(string text)
    {
        var dict = new Dictionary<string, int>();

        var words = Constants.wordsSplitRegex.Matches(text.ToLower());

        for (var i = 0; i < words.Count; i++)
        {
            var word = words[i].Value;
            if (!wordsFilter.Contains(word))
            {
                if (!dict.TryAdd(word, 1))
                {
                    dict[word]++;
                }
            }
        }
        return dict;
    }
}
