using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloudContainer.WordClasses;

namespace TagsCloudContainer.WordSizer
{
    public interface ISizer
    {
        public IOrderedEnumerable<SizeWord> GetSizes(IDictionary<string, int> words);
    }
}
