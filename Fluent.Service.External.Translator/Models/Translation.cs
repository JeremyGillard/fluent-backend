namespace Fluent.Service.Translator.Models;

using System.Text.Json.Serialization;

public record Translation
{
    [JsonPropertyName("detected_source_language")]
    public string DetectedSourceLanguage { get; set; } = null!;
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;
}