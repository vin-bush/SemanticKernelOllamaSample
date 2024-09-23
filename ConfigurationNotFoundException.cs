// Copyright (c) Microsoft. All rights reserved.
namespace SemanticKernelOllamaSample;

public sealed class ConfigurationNotFoundException : Exception
{
    public string? Section { get; }
    public string? Key { get; }

    public ConfigurationNotFoundException(string section, string key)
        : base($"Configuration key '{section}:{key}' not found")
    {
        Section = section;
        Key = key;
    }

    public ConfigurationNotFoundException(string section)
        : base($"Configuration section '{section}' not found")
    {
        Section = section;
    }

    public ConfigurationNotFoundException()
        : base() { }

    public ConfigurationNotFoundException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
