using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Spectre.Console;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion("gpt-4", apiKey!);
var kernel = builder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

while(true)
{
    var request = AnsiConsole.Ask<string>("[yellow]User >[/]");

    var result = chatCompletionService.GetStreamingChatMessageContentsAsync(request, kernel: kernel);

    string fullMessage = "";
    AnsiConsole.Markup("[cyan]Assistant > [/]");

    await foreach (var content in result)
    {
        Console.Write(content.Content);
        fullMessage += content.Content;
    }

    AnsiConsole.WriteLine();
}