namespace Fluent.Service.Translator;

using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Fluent.Service.Translator.Models;

public class TranslatorService : ITranslatorService
{
    private readonly ILogger<TranslatorService> _logger;
    private readonly TranslatorOptions _options;
    private readonly HttpClient _httpClient;

    public TranslatorService(ILogger<TranslatorService> logger, HttpClient httpClient, IOptions<TranslatorOptions> options)
    {
        _logger = logger;
        _options = options.Value;
        _httpClient = httpClient;
    }

    public async Task<Translations?> GetTranslations(string word, Lang targetTranslationLanguage)
    {
        var parameters = new Dictionary<string, string> { { "auth_key", _options.AuthKey },
                                                    { "text", word },
                                                    { "target_lang", $"{targetTranslationLanguage}" }};
        _logger.LogInformation($"Target language: {targetTranslationLanguage}");
        var encodedContent = new FormUrlEncodedContent(parameters);
        var response = await _httpClient.PostAsync(_options.ApiUri, encodedContent).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        _logger.LogInformation(jsonString);
        Translations? translations = JsonSerializer.Deserialize<Translations>(jsonString);
        return translations;
    }
}