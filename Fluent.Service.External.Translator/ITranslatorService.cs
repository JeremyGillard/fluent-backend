namespace Fluent.Service.Translator;

using Fluent.Service.Translator.Models;

public interface ITranslatorService
{
    public Task<Translations?> GetTranslations(string word, Lang targetTranslationLanguage);
}