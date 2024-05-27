using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Xml.Linq;
using System.Data.Entity;
using Bogus;
using application.Server.Data.Database;
using application.Server.Data.Model;

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
            .RuleFor(c => c.name, f => f.Name.FirstName())
            .RuleFor(c => c.surname, f => f.Name.LastName())
            .RuleFor(c => c.email, f => f.Internet.Email())
            .RuleFor(c => c.password, f => f.Internet.Password())
            .RuleFor(c => c.category, f => f.PickRandom(new[] { "Służbowy", "Prywatny", "inny" }))
            .RuleFor(c => c.subcategory, f => f.Lorem.Word())
            .RuleFor(c => c.phone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.dateOfBirth, f => f.Date.PastDateOnly(refDate: new DateOnly(2000,01,01)));

            context.contacts.AddRange(faker.Generate(20).ToArray());
            context.SaveChanges();
        }
    }
}
