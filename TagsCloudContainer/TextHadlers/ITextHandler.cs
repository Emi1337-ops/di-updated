using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudContainer.TextHadlers
{
    public interface ITextHandler
    {
        public string Handle(string text);
    }
}
