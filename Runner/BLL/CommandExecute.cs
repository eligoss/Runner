using Runner.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Runner.BLL
{
    public class CommandExecute : IComandExecute
    {
        private readonly char[] whitespace = new char[] { ' ', '\n', '\t', '\r', '\f', '\v' };
        private readonly IConfigManager _configManager;

        public CommandExecute(IConfigManager configManager)
        {
            this._configManager = configManager;
        }

        public string ExecuteComand()
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    WorkingDirectory = _configManager.Cmd_Command_WorkingDirectory,
                    Arguments = "/c " + _configManager.Cmd_Command_CommandToExecute,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();

            return proc.StandardOutput.ReadToEnd();
        }

        private string Normalize(string source)
        {
            return String.Join(" ", source.Split(whitespace, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}