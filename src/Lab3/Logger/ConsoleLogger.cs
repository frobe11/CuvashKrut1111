using System;
using System.Globalization;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class ConsoleLogger : ILogger
{
    public void Log(string info)
    {
        var logBuilder = new StringBuilder();
        logBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture))
            .Append(": ")
            .Append(info);
        Console.WriteLine(logBuilder.ToString());
    }
}