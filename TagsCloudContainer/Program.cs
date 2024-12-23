using Autofac;
using TagsCloudContainer.FileReaders;
using TagsCloudContainer.Filters;
using TagsCloudContainer.Parsers;
using WeCantSpell.Hunspell;

public static class Program 
{
    public static void Main()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<WordsFilter>().As<IFilter>();
        builder.RegisterType<SimpleParser>().As<IParser>();
        builder.RegisterType<TxtFileReader>().As<IReader>();

        var container = builder.Build();
    }
}