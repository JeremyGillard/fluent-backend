namespace Fluent.Service.Translator.Models;

using System.Collections;
using System.Text.Json.Serialization;

public record Translations
{
    [JsonPropertyName("translations")]
    public IList<Translation> Values { get; set; } = null!;
}