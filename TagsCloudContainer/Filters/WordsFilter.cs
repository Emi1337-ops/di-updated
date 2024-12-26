using Org.BouncyCastle.Asn1.Mozilla;
using System.IO;
using System.Text.RegularExpressions;
using TagsCloudContainer.FileReaders;

namespace TagsCloudContainer.Filters
{
    public class WordsFilter : IFilter
    {
        private HashSet<string> words;
        private Config config;
        public WordsFilter(Config config)
        {
            this.config = config;

            words = [];
            var reader = new TxtFileReader();
            var filterWords = reader.Read(Constants.FilterWordsDirectory);

            var matches = Constants.wordsSplitRegex.Matches(filterWords);

            for (var i = 0; i < matches.Count; i++)
            {
                if (!words.Contains(matches[i].Value))
                    words.Add(matches[i].Value);
            }

            AddStopWords(config.StopWords);
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
                AddStopWord(word);
        }

        public void RemoveStopWords(string[] wordArray)
        {
            foreach (var word in wordArray)
                RemoveStopWord(word);
        }
    }
}
