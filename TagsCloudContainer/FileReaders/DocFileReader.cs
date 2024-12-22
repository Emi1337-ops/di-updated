using Spire.Doc;

namespace TagsCloudContainer.FileReaders
{
    public class DocFileReader : IReader
    {
        public string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException("File not found.", path);

            var document = new Document();
            document.LoadFromFile(path);
            var text = document.GetText();
            return text;
        }
    }

}
