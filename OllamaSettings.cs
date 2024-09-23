namespace SemanticKernelOllamaSample;

public class OllamaSettings
{
    public const string SectionName = "Ollama";
    public string ModelId { get; set; } = string.Empty;
    public string EmbeddingModelId { get; set; } = string.Empty;
    public string Endpoint { get; set; } = "http://localhost:11434";
}
