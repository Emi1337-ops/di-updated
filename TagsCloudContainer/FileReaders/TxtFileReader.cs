namespace TagsCloudContainer.FileReaders;
public class TxtFileReader : IReader
{
    public string Read(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Path cannot be null or empty.", nameof(path));

        if (!File.Exists(path))
            throw new FileNotFoundException("File not found.", path);
            

        return File.ReadAllText(path);
    }
}
