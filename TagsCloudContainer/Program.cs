using Autofac;
using McMaster.Extensions.CommandLineUtils;
using TagsCloudContainer.Clients;
using TagsCloudContainer.FileReaders;
using TagsCloudContainer.Filters;
using TagsCloudContainer.Parsers;

public static class Program 
{
    public static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<WordsFilter>().As<IFilter>();
        builder.RegisterType<SimpleParser>().As<IParser>();
        builder.RegisterType<TxtFileReader>().As<IReader>();
        var container = builder.Build();

        var app = ConsoleClient.ParseArguments(args);
        Console.WriteLine(app.InputFile);
        Console.ReadLine();
    }
}