namespace TagsCloudContainer.Parsers;

public interface IParser
{
    public IDictionary<string, int> Parse(string text);
}
