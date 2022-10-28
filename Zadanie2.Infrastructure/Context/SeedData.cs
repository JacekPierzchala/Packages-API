using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;

namespace Zadanie2.Infrastructure
{
    public static class DataExtensions
    {
        public static void SeedData(this ApplicationDbContext context)
        {
            context.Recipients.Add(new Recipient 
            { 
                 Id=1,
                 Name="Jan Kowalski",
                 Address="Dluga 8/44 56-454 Rowne"
            });

            context.Recipients.Add(new Recipient {
                Id = 2,
                Name = "James Hetfield",
                Address = "15 High Street LE23 14h Orange Park"

            });
            context.Recipients.Add(new Recipient {
                Id = 3,
                Name = "Kerry King",
                Address = "18 South Road ew23 14h Old Brigdge"
            });
            context.Recipients.Add(new Recipient
            {
                Id = 4,
                Name = "Adam Nowak",
                Address = "Prosta 5/8 45-887 Strzelce"
            });
            context.Packages.Add(new Package
            {
                Id = 1,
                Name = "Package with clohtes",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eu varius null",
                PackageIdentifier =  Guid.NewGuid().ToString(),
                RecipientId=1,
                LastUpdated=DateTime.Now.AddDays(-1).AddHours(-8).AddMinutes(-7),
                Status= "DELIVERED"
            }) ;
            context.Packages.Add(new Package
            {
                Id = 2,
                Name = "Package with food",
                Description = "Sed hendrerit lorem sit amet turpis commodo, at finibus justo pretium.l",
                PackageIdentifier = Guid.NewGuid().ToString(),
                RecipientId = 2,
                LastUpdated = DateTime.Now.AddDays(-2).AddHours(-12).AddMinutes(-19),
                Status = "DELIVERED"
            });
            context.Packages.Add(new Package
            {
                Id = 3,
                Name = "Package with tools",
                Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra",
                PackageIdentifier = Guid.NewGuid().ToString(),
                RecipientId = 2,
                LastUpdated = DateTime.Now.AddDays(-12).AddHours(-2).AddMinutes(-39),
                Status = "RECEIVED"
            });
            context.Packages.Add(new Package
            {
                Id = 4,
                Name = "Package with drinks",
                Description = "ugue vel vestibulum fringilla, nibh elit hendrerit sem, ac varius nisi orci vel leo. In ",
                PackageIdentifier = Guid.NewGuid().ToString(),
                RecipientId = 1,
                LastUpdated = DateTime.Now.AddDays(-1).AddHours(-2).AddMinutes(-39),
                Status = "RECEIVED"
            });
            context.Packages.Add(new Package
            {
                Id = 5,
                Name = "Package with flowers",
                Description = "In vitae luctus nisl. Vestibulum fermentum venenatis imperdiet. Nam eget elit et eni",
                PackageIdentifier = Guid.NewGuid().ToString(),
                RecipientId = 3,
                LastUpdated = DateTime.Now.AddDays(-1).AddHours(-2).AddMinutes(-39),
                Status = "DELIVERED"
            });
            context.Packages.Add(new Package
            {
                Id = 6,
                Name = "Package with flowers",
                Description = "Morbi a imperdiet erat. Duis consequat sollicitudin magna, ut consectetur ex tincidunt nec.",
                PackageIdentifier = Guid.NewGuid().ToString(),
                RecipientId = 4,
                LastUpdated = DateTime.Now.AddDays(-14).AddHours(-7).AddMinutes(-39),
                Status = "DELIVERED"
            });

            context.SaveChanges();
        }
    }
}
