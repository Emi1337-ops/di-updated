using Autofac;
using TagsCloudContainer.FileReaders;
using TagsCloudContainer.Filters;
using TagsCloudContainer.Layouters;
using TagsCloudContainer.Parsers;
using TagsCloudContainer.Visualizers;
using TagsCloudContainer.WordSizer;

namespace TagsCloudContainer;
public static class Program
{
    public static void Main()
    {
    }
    public static void Main(Config config)
    {
        var builder = new ContainerBuilder();
        builder.RegisterInstance(config).As<Config>();
        builder.RegisterType<TxtFileReader>().As<IReader>();
        builder.RegisterType<WordsFilter>().As<IFilter>();
        builder.RegisterType<SimpleParser>().As<IParser>();
        builder.RegisterType<SimpleSizer>().As<ISizer>();
        builder.RegisterType<CircularCloudLayouter>().As<ILayouter>();
        builder.RegisterType<ImageVisualizer>().As<IVisualizer>();
        var container = builder.Build();

        var reader = container.Resolve<IReader>();
        var parser = container.Resolve<IParser>();
        var sizer = container.Resolve<ISizer>();
        var layouter = container.Resolve<ILayouter>();
        var visualizer = container.Resolve<IVisualizer>();

        visualizer.GenerateImage(
            layouter.GetLayout(
                sizer.GetSizes(
                    parser.Parse(
                        reader.Read(
                            config.InputDirectory
                        )
                    )
                )
            )
        );
    }
}
