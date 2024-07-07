using Microsoft.SemanticKernel;

var apiKey = Environment.GetEnvironmentVariable("OPENAPI_KEY");

var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion("gpt-4", apiKey!);
var kernel = builder.Build();

string request = "Quantos tipos de orquideas existem?";
string prompt = $"What is the intent of this request? {request}";

Console.WriteLine(await kernel.InvokePromptAsync(prompt));
Console.WriteLine("-------------------------");
