using Org.BouncyCastle.Asn1.Mozilla;
using System.IO;
using System.Text.RegularExpressions;

namespace TagsCloudContainer.Filters
{
    public class WordsFilter : IFilter
    {
        private HashSet<string> words;
        public WordsFilter()
        {
            words = new HashSet<string>();

            var projectDirectory =
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            var path = Path.Combine(projectDirectory, "Parsers\\stopwords.txt");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден.", path);
            }

            string text = File.ReadAllText(path);

            string pattern = @"\b[а-яА-ЯёЁa-zA-Z]+\b";

            var matches = Regex.Matches(text, pattern);

            for (var i = 0; i < matches.Count; i++)
            {
                if (!words.Contains(matches[i].Value))
                    words.Add(matches[i].Value);
            }
        }

        public bool Contains(string word)
        {
            return words.Contains(word);
        }

        public void AddStopWord(string word)
        {
            if (!words.Contains(word))
                words.Add(word);
        }

        public void RemoveStopWord(string word)
        {
            if (words.Contains(word))
                words.Remove(word);
        }

        public void AddStopWords(string[] wordArray)
        {
            foreach (var word in wordArray)
            {
                if (!words.Contains(word))
                    words.Add(word);
            }
        }

        public void RemoveStopWords(string[] wordArray)
        {
            foreach (var word in wordArray)
            {
                if (words.Contains(word))
                    words.Remove(word);
            }
        }
    }
}
