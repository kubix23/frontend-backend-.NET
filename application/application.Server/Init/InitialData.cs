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
        private static readonly int initSize = 20;
        static public void addContacts(DB context)
        {
            if (context.contacts.Any()){
                Console.WriteLine("Has data");
                return;
            }


            string[] names = ["służbowy", "prywatny", "inny"];

            foreach (var name in names)
            {
                context.category.Add(new Category() { name = name });
            }

            var faker1 = new Faker<Category>()
                .RuleFor(c => c.name, f => f.Lorem.Word())
                .RuleFor(c => c.parentCategoryId, f => f.Random.Number(1, 3));

            context.category.AddRange(faker1.Generate(initSize).ToArray());
            context.SaveChanges();

            var faker2 = new Faker<Contact>()
            .RuleFor(c => c.name, f => f.Name.FirstName())
            .RuleFor(c => c.surname, f => f.Name.LastName())
            .RuleFor(c => c.email, f => f.Internet.Email())
            .RuleFor(c => c.password, f => f.Internet.Password())
            .RuleFor(c => c.category, f => f.Random.Number(1,3))
            .RuleFor(c => c.subcategory, f => f.Random.Number(4, 13))
            .RuleFor(c => c.phone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.dateOfBirth, f => f.Date.PastDateOnly(refDate: new DateOnly(2000,01,01)));

            context.contacts.AddRange(faker2.Generate(initSize).ToArray());
            context.SaveChanges();
        }
    }
}
