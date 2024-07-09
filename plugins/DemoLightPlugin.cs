using System.ComponentModel;
using Microsoft.SemanticKernel;
using Spectre.Console;

public class DemoLightPlugin
{
    private DemoLightService demoLightService;

    public DemoLightPlugin()
    {
        demoLightService = new DemoLightService();
    }

    [KernelFunction]
    [Description("Gets the status of the Demo's light.")]
    [return: Description("When status is on, the light is turned on.")]
    public async Task<string> GetLightStatus()
    {
        var response = await demoLightService.GetLightStatus();
        AnsiConsole.MarkupLine($"[purple][bold]Getting the light status: [/]{response}[/]");
        return response;
    }

    [KernelFunction]
    [Description("Turn on the demo's light.")]
    [return: Description("When status = on, the light was turned on.")]
    public async Task<string> TurnOnTheLight()
    {
        var response = await demoLightService.TurnOnTheLight();
        AnsiConsole.MarkupLine($"[purple][bold]Turning on the light: [/]{response}[/]");
        return response;
    }

    [KernelFunction]
    [Description("Turn off the demo's light")]
    [return: Description("When return status = off, the light was turned off.")]
    public async Task<string> TurnOffTheLight()
    {
        var response = await demoLightService.TurnOffTheLight();
        AnsiConsole.MarkupLine($"[purple][bold]Turning off the light: [/]{response}[/]");
        return response;
    }
}