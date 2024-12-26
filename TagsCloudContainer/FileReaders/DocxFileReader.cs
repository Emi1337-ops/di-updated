using NPOI.XWPF.UserModel;

namespace TagsCloudContainer.FileReaders;
public class DocxFileReader : IReader
{
    public string Read(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Path cannot be null or empty.", nameof(path));

        if (!File.Exists(path))
            throw new FileNotFoundException("File not found.", path);

        using var stream = File.OpenRead(path);
        using var writer = new StringWriter();

        var docx = new XWPFDocument(stream);
        foreach (var paragraph in docx.Paragraphs)
        {
            writer.WriteLine(paragraph.Text);
        }
        return writer.ToString();
    }
}
