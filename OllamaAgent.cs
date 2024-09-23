using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;

namespace SemanticKernelOllamaSample;

public class OllamaAgent(OllamaSettings settings, string Name, string Instructions)
{
    public async Task<string> RunAsync(string UserPrompt)
    {
        // Create a kernel with Ollama chat completion
#pragma warning disable SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        ChatCompletionAgent agent =
            new()
            {
                Name = Name,
                Instructions = Instructions,
                Kernel = Kernel
                    .CreateBuilder()
                    .AddOllamaChatCompletion(
                        endpoint: new Uri(settings.Endpoint),
                        modelId: settings.ModelId
                    )
                    .Build(),
            };

        // Create the chat history to capture the agent interaction.
        ChatHistory chat = [];

        // Respond to user input
        chat.Add(new ChatMessageContent(AuthorRole.User, UserPrompt));

        string? result = null;
        await foreach (ChatMessageContent content in agent.InvokeAsync(chat))
        {
            result = content.Content;
            chat.Add(content);
        }
#pragma warning restore SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        return result ?? "Nothing to say";
    }
}
