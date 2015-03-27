using System.ComponentModel.DataAnnotations;
namespace Runner.Models
{
    public class HomePage
    {
        public HomePage()
        {

        }

        public HomePage(string commandResult, string fileContent)
        {
            this.CommandResult = commandResult;
            this.FileContent = fileContent;
        }

        [DataType(DataType.MultilineText)]
        public string CommandResult { get; set; }

        [DataType(DataType.MultilineText)]
        public string FileContent { get; set; }
    }
}