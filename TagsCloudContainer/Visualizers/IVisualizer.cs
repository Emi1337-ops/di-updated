using System.Drawing;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.Visualizers;

public interface IVisualizer
{
    public void GenerateImage(IEnumerable<RectangleWord> words);

    public Color GetWordColor(RectangleWord word);

    public string GetImageFotmat();
}
