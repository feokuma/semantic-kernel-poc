using Microsoft.SemanticKernel;
using Spectre.Console;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion("gpt-4", apiKey!);
var kernel = builder.Build();

string request = "A lâmpada da minha demo está acesa?";
string prompt = $"What is the intent of this request? {request}";
WriteDivider("Teste básico do prompt com o Semantic Kernel", request);
WriteResponse($"{await kernel.InvokePromptAsync(prompt)}");


prompt = @$"What is the intent of this request? {request}
You can choose between GetLightStatus, TurnOnTheLight, TurnOffTheLight";
WriteDivider("Melhorando o teste com Prompt Engineering", request);
WriteResponse($"{await kernel.InvokePromptAsync(prompt)}");


prompt = @$"Instructions: What is the intent of this request?
Choices: GetLightStatus, TurnOnTheLight, TurnOffTheLight
User Input: {request}
Intent: ";
WriteDivider("Adicionando estrutura para o output", request);
WriteResponse($"{await kernel.InvokePromptAsync(prompt)}");


prompt = $$"""
## Instructions
Provide the intent of the request using de following format:

```json
{
    "intent": {intent}
}
```

## Choices
You can choose between the following intents:

```json
["GetLightStatus", "TurnOnTheLight", "TurnOffTheLight"]
```

## User Input
The user input is:

```json
{
    "request": "{{request}}"
}
```

## Intent";
""";
WriteDivider("Prompt com instruções de formato", request);
WriteResponse($"{await kernel.InvokePromptAsync(prompt)}");


prompt = @$"Instructions: What is the intent of this request?
Choices: GetLightStatus, TurnOnTheLight, TurnOffTheLight

User Input: Qual é o status da lampâda da demo? 
Intent: GetLightStatus

User Input: Liga a lâmpada da demo.
Intent: TurnOnTheLight

User Input: Desligue a lâmpada da demo.
Intent: TurnOffTheLight

User Input: {request}
Intent: ";
WriteDivider("Exemplos com few-shot prompting", request);
WriteResponse($"{await kernel.InvokePromptAsync(prompt)}");


static void WriteDivider(string title, string question)
{
    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Rule($"[white]{title}[/]").RuleStyle("grey").LeftJustified());
    AnsiConsole.MarkupLine($"[yellow]{question}[/]");
}

static void WriteResponse(string text)
{
    AnsiConsole.MarkupLine($"[green]{text}[/]");
}