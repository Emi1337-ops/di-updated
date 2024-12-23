using System;
using System.Drawing;
using McMaster.Extensions.CommandLineUtils;
using System.Linq;
using System.Runtime.InteropServices;

namespace TagsCloudContainer.Clients
{
    public class ConsoleClient
    {
        [Option("--input", "Path to the input file.", CommandOptionType.SingleValue)]
        public string InputFile { get; set; }

        [Option("--output", "Path to the output file.", CommandOptionType.SingleValue)]
        public string OutputFile { get; set; }

        [Option("--width", "Width of the picture.", CommandOptionType.SingleValue)]
        public int PictureWidth { get; set; }

        [Option("--height", "Height of the picture.", CommandOptionType.SingleValue)]
        public int PictureHeight { get; set; }

        [Option("--font", "Font for the picture text.", CommandOptionType.SingleValue)]
        public string Font { get; set; }

        [Option("--stopwords", "Comma-separated list of stop words.", CommandOptionType.SingleValue)]
        public string StopWordsInput { get; set; }

        [Option("--colors", "Comma-separated list of colors in ARGB format (0,0,255).", CommandOptionType.SingleValue)]
        public string ColorsInput { get; set; }

        public string[] StopWords => StopWordsInput?.Split(',') ?? Array.Empty<string>();

        public Color[] PictureColors =>
            ColorsInput?.Split(',').Select(color =>
            {
                var components = color.Split(' ').Select(int.Parse).ToArray();
                return Color.FromArgb(components[0], components[1], components[2]);
            }).ToArray() ?? Array.Empty<Color>();

        public static ConsoleClient ParseArguments(string[] args)
        {
            var app = new CommandLineApplication<ConsoleClient>();
            app.Conventions.UseDefaultConventions();
            app.Execute(args);
            return app.Model;
        }

        private void OnExecute()
        {
            Console.WriteLine($"Input File: {InputFile}");
            Console.WriteLine($"Output File: {OutputFile}");
            Console.WriteLine($"Picture Width: {PictureWidth}");
            Console.WriteLine($"Picture Height: {PictureHeight}");
            Console.WriteLine($"Font: {Font}");
            Console.WriteLine($"Stop Words: {string.Join(", ", StopWords)}");
            Console.WriteLine($"Picture Colors: {string.Join(", ", PictureColors.Select(c => c.ToString()))}");
        }
    }
}
