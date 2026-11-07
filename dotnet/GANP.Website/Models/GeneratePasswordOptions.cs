namespace GANP.Website.Models
{
    public class GeneratePasswordOptions
    {
        public int MinLength { get; set; } = 25;

        public int MinWords { get; set; } = 4;

        public string Separator { get; set; } = "-";

        public bool AddUppercase { get; set; } = true;

        public bool AddNumber { get; set; } = true;
    }
}
