namespace GANP.Website.Models
{
    public class GeneratePasswordModel
    {
        public GeneratePasswordModel() { }

        public GeneratePasswordModel(string password, GeneratePasswordOptions options)
        {
            Password = password;
            Options = options;
        }

        public string Password { get; set; }

        public GeneratePasswordOptions Options { get; set; }
    }
}