using Autofac;
using TagsCloudContainer;
using TagsCloudContainer.FileReaders;
using TagsCloudContainer.Filters;
using TagsCloudContainer.Layouters;
using TagsCloudContainer.Parsers;
using TagsCloudContainer.Visualizers;
using TagsCloudContainer.WordSizer;
//using TagsCloudContainer.FileReaders;
//using TagsCloudContainer.Filters;
//using TagsCloudContainer.Layouters;
//using TagsCloudContainer.Parsers;
//using TagsCloudContainer.Visualizers;
//using TagsCloudContainer.WordSizer;

//namespace TagsCloudContainer;
//public static class Program
//{
//    public static void Main()
//    {
//    }
//    public static void Main(Config config)
//    {
//        var builder = new ContainerBuilder();
//        builder.RegisterInstance(config).As<Config>();
//        builder.RegisterType<TxtFileReader>().As<IReader>();
//        builder.RegisterType<WordsFilter>().As<IFilter>();
//        builder.RegisterType<SimpleParser>().As<IParser>();
//        builder.RegisterType<SimpleSizer>().As<ISizer>();
//        builder.RegisterType<CircularCloudLayouter>().As<ILayouter>();
//        builder.RegisterType<ImageVisualizer>().As<IVisualizer>();
//        var container = builder.Build();

//        var reader = container.Resolve<IReader>();
//        var parser = container.Resolve<IParser>();
//        var sizer = container.Resolve<ISizer>();
//        var layouter = container.Resolve<ILayouter>();
//        var visualizer = container.Resolve<IVisualizer>();

//        visualizer.GenerateImage(
//            layouter.GetLayout(
//                sizer.GetSizes(
//                    parser.Parse(
//                        reader.Read(
//                            config.InputDirectory
//                        )
//                    )
//                )
//            )
//        );
//    }
//}



public class ApplicationRunner : IApplicationRunner
{
    private readonly Config config;
    private readonly IReader reader;
    private readonly IParser parser;
    private readonly ISizer sizer;
    private readonly ILayouter layouter;
    private readonly IVisualizer visualizer;

    public ApplicationRunner(
        Config config,
        IReader reader,
        IParser parser,
        ISizer sizer,
        ILayouter layouter,
        IVisualizer visualizer)
    {
        this.config = config;
        this.reader = reader;
        this.parser = parser;
        this.sizer = sizer;
        this.layouter = layouter;
        this.visualizer = visualizer;
    }

    public void Run()
    {
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

    public static IContainer BuildContainer(Config config)
    {
        var builder = new ContainerBuilder();

        builder.RegisterInstance(config).As<Config>();
        builder.RegisterType<TxtFileReader>().As<IReader>();
        builder.RegisterType<WordsFilter>().As<IFilter>();
        builder.RegisterType<SimpleParser>().As<IParser>();
        builder.RegisterType<SimpleSizer>().As<ISizer>();
        builder.RegisterType<CircularCloudLayouter>().As<ILayouter>();
        builder.RegisterType<ImageVisualizer>().As<IVisualizer>();

        builder.RegisterType<ApplicationRunner>().As<IApplicationRunner>();

        return builder.Build();
    }
}
