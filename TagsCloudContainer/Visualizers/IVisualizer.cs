using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.Visualizers;

public interface IVisualizer
{
    public void GenerateImage(IEnumerable<RectangleWord> words);
}
