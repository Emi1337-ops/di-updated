using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloudContainer.WordClasses;
using TagsCloudContainer.WordSizer;

namespace TagsCloudContainer.Layouters;
public interface ILayouter
{
    public IEnumerable<RectangleWord> GetLayout(IEnumerable<SizeWord> words);
}
