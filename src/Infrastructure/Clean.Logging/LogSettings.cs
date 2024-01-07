using System.Reflection;

namespace Clean.Logging;

public class LogSettings
{
    public bool WriteToConsole { get; set; }
    public bool WriteToFile { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
