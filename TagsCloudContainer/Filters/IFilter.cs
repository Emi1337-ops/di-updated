namespace TagsCloudContainer.Filters;

public interface IFilter
{
    void AddStopWord(string word);
    void AddStopWords(string[] wordArray);
    bool Contains(string word);
    void RemoveRightWord(string word);
    void RemoveRightWords(string[] wordArray);
}