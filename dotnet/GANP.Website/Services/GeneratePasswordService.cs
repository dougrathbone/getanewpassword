using System;
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
        private IFileOperationService _reader;
        private IFilePathService _pathService;
        private Random _random;

        public GeneratePasswordService()
        {
            _reader = new FileOperationService();
            _pathService = new HttpFilePathService();
            _random = new Random((int)DateTime.UtcNow.Ticks);
        }

        public GeneratePasswordService(IFileOperationService fileOperationService, IFilePathService pathService)
        {
            _reader = fileOperationService;
            _pathService = pathService;
            _random = new Random((int)DateTime.UtcNow.Ticks);
        }

        private static string[] _wordCache;

        public string GeneratePassword(GeneratePasswordOptions options)
        {
            if (_wordCache == null) loadWords();

            return BuildPassword(_wordCache, options);
        }

        private void loadWords()
        {
            var words = _reader.ReadAllText(_pathService.GetRelativePath("\\App_Data\\wordlist.txt"));
            _wordCache = words.Split(',');
        }

        public string BuildPassword(string[] wordsArray, GeneratePasswordOptions options)
        {
            var output = new StringBuilder();
            for (int x = 0; x < options.MinWords; x++)
            {
                output.Append(SelectRandomWord(wordsArray, options.AddUppercase) + options.Separator);
            }
            if (options.AddNumber) output.Append(_random.Next(0, 9));
            return output.ToString();
        }

        public string SelectRandomWord(string[] wordsArray, bool pascalCase)
        {
            var rand = _random.Next(0, wordsArray.Length);
            var word = wordsArray[rand].Trim();
            return char.ToUpper(word[0]) + word.Substring(1, word.Length-1);
        }
    }
}