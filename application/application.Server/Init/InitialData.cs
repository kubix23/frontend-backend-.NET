using backend.Controllers;
using backend.Data.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Xml.Linq;

namespace application.Server.Init
{
    public class InitialData
    {
        ContactsController controler;
        public InitialData(ContactsController controler)
        {
            this.controler = controler;
        }

        public async void addContacts()
        {
            await controler.PostContact(new Contact()
            {
                Id = 0,
                Name = "test",
                Surname = "bigtest",
                Email = "test",
                Password = "qwerty",
                Category = "Private",
                Phone = "null",
            });
        }
    }
}
