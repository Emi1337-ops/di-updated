using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.Visualizers;
public interface IVisualizer
{
    public void GenerateImage(IEnumerable<RectangleWord> words);
}
