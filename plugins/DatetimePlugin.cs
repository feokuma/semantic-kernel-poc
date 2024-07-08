using System.ComponentModel;
using Microsoft.SemanticKernel;
using Spectre.Console;

public class DatetimePlugin
{
    [KernelFunction]
    [Description("Gets the current time.")]
    public TimeSpan GetTime()
    {
        var time = TimeProvider.System.GetLocalNow().TimeOfDay;
        AnsiConsole.MarkupLine($"[purple][bold]Getting the current time: [/]{time}[/]");
        return time;
    }

    [KernelFunction]
    [Description("Gets the current date.")]
    public DateTime GetDate()
    {
        var date = TimeProvider.System.GetLocalNow().Date;
        AnsiConsole.MarkupLine($"[purple][bold]Getting the current date: [/]{date}[/]");
        return date;
    }
}