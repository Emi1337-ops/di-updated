using TagsCloudContainer;
using TagsCloudContainer.FileReaders;

namespace TagCloudContainerTests
{
    [TestFixture]
    public class GeneralTests
    {
        private Config config;

        [SetUp]
        public void Setup()
        {
            config = new Config();
            config.InputDirectory = @"C:\Users\dima0\source\repos\di-updated\TagsCloudContainer\Files\General.txt";
            config.OutputDirectory = @"C:\Users\dima0\source\repos\di-updated\TagsCloudContainer\Pictures\general.jpg";
            config.PictureWidth = 600;
            config.PictureHeight = 700;
            config.StopWords = ["отпуск", "птица", "любовь"];
            config.RightWords = ["я"];
        }


        
    }
}
