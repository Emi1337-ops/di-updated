using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.Layouters;

public interface ILayouter
{
    public IEnumerable<RectangleWord> GetLayout(IEnumerable<SizeWord> words);
}
