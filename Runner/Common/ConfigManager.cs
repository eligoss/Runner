using System.Configuration;

namespace Runner.Common
{
    public class ConfigManager : IConfigManager
    {
        public string Cmd_Command_WorkingDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["Cmd_Command_WorkingDirectory"];
            }
        }

        public string Cmd_Command_CommandToExecute
        {
            get
            {
                return ConfigurationManager.AppSettings["Cmd_Command_CommandToExecute"];
            }
        }

        public string File_FullPath
        {
            get
            {
                return ConfigurationManager.AppSettings["File_FullPath"];
            }
            set
            {
                ConfigurationManager.AppSettings["File_FullPath"] = value;
            }
        }
    }
}