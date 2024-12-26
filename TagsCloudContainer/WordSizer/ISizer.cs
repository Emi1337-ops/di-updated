using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.WordSizer;

public interface ISizer
{
    public IEnumerable<SizeWord> GetSizes(IDictionary<string, int> words);
}
