namespace GANP.Website.Models
{
    public class GeneratePasswordOptions
    {
        public int MinLength = 25;

        public int MinWords = 4;

        public string Separator = "-";

        public bool AddUppercase = true;

        public bool AddNumber = true;
    }
}