using backend.Controllers;
using backend.Data.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Xml.Linq;
using System.Data.Entity;
using backend.Data.Database;
using Bogus;

namespace application.Server.Init
{
    public class InitialData
    {
        static public void addContacts(DBContact context)
        {
            if (context.contacts.Any()){
                Console.WriteLine("Has data");
                return;
            }
            var faker = new Faker<Contact>()
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Surname, f => f.Name.LastName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Password, f => f.Internet.Password())
            .RuleFor(c => c.Category, f => f.PickRandom(new[] { "Służbowy", "Prywatny", "inny" }))
            .RuleFor(c => c.Subcategory, f => f.Lorem.Word())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber());

            context.contacts.AddRange(faker.Generate(20).ToArray());
            context.SaveChanges();
        }
    }
}
