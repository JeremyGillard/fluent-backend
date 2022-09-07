namespace Fluent.Service.Translator;

public class TranslatorOptions
{
    public const string Translator = "Translator";
    public Uri ApiUri { get; set; } = null!;
    public string AuthKey { get; set; } = null!;
}