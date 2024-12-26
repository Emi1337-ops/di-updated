namespace TagsCloudContainer.Parsers;

public interface IParser
{
    public IDictionary<string, int> Parse(string text);

    public string BringWordsToOriginalForm(string text);

    public string TakeOnlyOnePartOfSpeech(string text, string partOfSpeech);
}
