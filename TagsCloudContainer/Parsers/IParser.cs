using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudContainer.Parsers
{
    public interface IParser
    {
        public IDictionary<string, int> Parse(string text);
    }
}
