using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Spectre.Console;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion("gpt-4", apiKey!);
builder.Plugins.AddFromType<DatetimePlugin>();
var kernel = builder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

var executionSettings = new OpenAIPromptExecutionSettings
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

ChatHistory history = [] ;
history.AddSystemMessage("You should answer as a 80's TV series robot");

while (true)
{
    var request = AnsiConsole.Ask<string>("[yellow]User >[/]");
    history.AddUserMessage(request);

    var result = chatCompletionService.GetStreamingChatMessageContentsAsync(history, executionSettings, kernel: kernel);

    string fullMessage = "";
    AnsiConsole.Markup("[cyan]Assistant > [/]");

    await foreach (var content in result)
    {
        Console.Write(content.Content);
        fullMessage += content.Content;
    }

    history.AddAssistantMessage(fullMessage);

    AnsiConsole.WriteLine();
}