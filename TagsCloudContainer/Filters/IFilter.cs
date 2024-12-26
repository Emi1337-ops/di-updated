namespace TagsCloudContainer.Filters;
public interface IFilter
{
    void AddStopWord(string word);
    void AddStopWords(string[] wordArray);
    bool Contains(string word);
    void RemoveStopWord(string word);
    void RemoveStopWords(string[] wordArray);
}