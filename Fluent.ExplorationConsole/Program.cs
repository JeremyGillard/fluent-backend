// using Microsoft.Extensions.Configuration;

// IConfigurationRoot configuration = new ConfigurationBuilder()
//     .AddUserSecrets<Program>()
//     .Build();
// string connectionString = configuration.GetConnectionString("FluentDatabase");
// Console.WriteLine(connectionString);

using Fluent.Data;
using Fluent.Models;

using FluentContext context = new FluentContext();

FlashCard hello = new FlashCard()
{
    Word = "Hello",
    Translation = "Bonjour"
};
context.FlashCards.Add(hello);

FlashCard hi = new FlashCard()
{
    Word = "Hi",
    Translation = "Salut"
};
context.Add(hi);

context.SaveChanges();