namespace Runner.Common
{
    public interface IConfigManager
    {
        string Cmd_Command_WorkingDirectory { get; }
        string Cmd_Command_CommandToExecute { get; }

        string File_FullPath { get; set; }
    }
}
