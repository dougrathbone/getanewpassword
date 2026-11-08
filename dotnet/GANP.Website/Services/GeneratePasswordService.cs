using System;
using System.Security.Cryptography;
using System.Text;
using GANP.Website.Models;

namespace GANP.Website.Services
{
    public interface IGeneratePasswordService
    {
        string GeneratePassword(GeneratePasswordOptions options);

        string BuildPassword(string[] wordsArray, GeneratePasswordOptions options);

        string SelectRandomWord(string[] wordsArray, bool pascalCase);
    }

    public class GeneratePasswordService : IGeneratePasswordService
    {
        private const string WordListPath = "App_Data/wordlist.txt";

        private readonly IFileOperationService _reader;
        private readonly IFilePathService _pathService;
        private static string[] _wordCache;
        private static readonly object CacheLock = new object();

        public GeneratePasswordService(IFileOperationService fileOperationService, IFilePathService pathService)
        {
            _reader = fileOperationService;
            _pathService = pathService;
        }

        public string GeneratePassword(GeneratePasswordOptions options)
        {
            if (_wordCache == null) LoadWords();

            return BuildPassword(_wordCache, options);
        }

        private void LoadWords()
        {
            lock (CacheLock)
            {
                if (_wordCache != null) return;
                var words = _reader.ReadAllText(_pathService.GetRelativePath(WordListPath));
                _wordCache = words.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            }
        }

        public string BuildPassword(string[] wordsArray, GeneratePasswordOptions options)
        {
            var output = new StringBuilder();
            for (int x = 0; x < options.MinWords; x++)
            {
                output.Append(SelectRandomWord(wordsArray, options.AddUppercase) + options.Separator);
            }
            // cryptographically secure digit 0-9
            if (options.AddNumber) output.Append(RandomNumberGenerator.GetInt32(0, 10));
            return output.ToString();
        }

        public string SelectRandomWord(string[] wordsArray, bool pascalCase)
        {
            // cryptographically secure selection (System.Random is predictable and unsuitable for passwords)
            var word = wordsArray[RandomNumberGenerator.GetInt32(0, wordsArray.Length)].Trim();
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
