using Cocona;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Fluent.Service.Translator;
using Fluent.Service.Translator.Models;

var builder = CoconaApp.CreateBuilder();

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddTransient<HttpClient>();
builder.Services.Configure<TranslatorOptions>(builder.Configuration.GetSection(TranslatorOptions.Translator));
builder.Services.AddTranslator();

var app = builder.Build();

app.AddCommand("translate", async (string word, [Option("target-language")] Lang targetTranslationLanguage, ITranslatorService translator, ILogger<Program> logger) =>
{

    var translations = await translator.GetTranslations(word, targetTranslationLanguage);
    for (int i = 0; i < translations?.Values.Count; i++)
    {
        logger.LogInformation(translations?.Values[i].Text);
    }
});

app.Run();