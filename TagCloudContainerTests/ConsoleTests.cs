using TagsCloudContainer;
using TagsCloudContainer.Filters;
using TagsCloudContainer.Parsers;

namespace TagCloudContainerTests
{
    [TestFixture]
    class ConsoleTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConsoleClient_CorrectCommandsRead()
        {
            var input = "--input file ";
            var output = "--output outfile ";
            var width = "--width 1000 ";
            var height = "--height 900 ";
            var font = "--font Arial ";
            var stopwords = "--stopwords car,lemon,granade ";
            var rightwords = "--rightwords tomato,king ";
            var colors = "--colors 150,150,150,0 ";

            var args = new string[] 
            { 
                input, 
                output,
                width,
                height,
                font,
                stopwords,
                rightwords,
                colors
            };

            
            ConsoleClient.Main(args.ToArray());
        }
    }
}
