namespace Fluent.Service.Translator;

using Microsoft.Extensions.DependencyInjection;

public static class TranslatorServiceRegistration
{
    public static IServiceCollection AddTranslator(this IServiceCollection services)
    {
        services.AddTransient<ITranslatorService, TranslatorService>();
        return services;
    }
}