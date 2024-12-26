using TagsCloudContainer.FileReaders;

namespace TagCloudContainerTests;

[TestFixture]
public class SizerTests
{
    private static readonly VerifySettings Settings = new();
    private IReader Reader;
    private string FolderPath;

    [SetUp]
    public void Setup()
    {
        Settings.UseDirectory("Snapshots");
        var projectDirectory =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        FolderPath = Path.Combine(projectDirectory, "Files");
    }

    [Test]
    public Task Reader_TxtReading()
    {
        Reader = new TxtFileReader();

        var filePath = Path.Combine(FolderPath, "wordsTXT.txt");
        var actual = Reader.Read(filePath);

        return Verify(actual, Settings);
    }

    [Test]
    public Task Reader_DocxReading()
    {
        Reader = new DocxFileReader();

        var filePath = Path.Combine(FolderPath, "wordsDOCX.docx");
        var actual = Reader.Read(filePath);

        return Verify(actual, Settings);
    }

    [Test]
    public Task Reader_DocReading()
    {
        Reader = new DocFileReader();

        var filePath = Path.Combine(FolderPath, "wordsDOC.doc");
        var actual = Reader.Read(filePath);

        return Verify(actual, Settings);
    }
}