using Microsoft.Extensions.Configuration;
using SemanticKernelOllamaSample;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .Build();

OllamaSettings settings =
    configuration.GetSection(OllamaSettings.SectionName).Get<OllamaSettings>()
    ?? throw new ConfigurationNotFoundException(OllamaSettings.SectionName);

string instructions = "You are a friendly chatbot. Respond to user input.";
OllamaAgent agent = new (settings, "Chatbot", instructions);
while (true)
{
    Console.Write("User: ");
    string? prompt = Console.ReadLine();
    if (string.IsNullOrEmpty(prompt))
    {
        break;
    }
    string response = await agent.RunAsync(prompt);
    Console.WriteLine($"Agent: {response}");
}
