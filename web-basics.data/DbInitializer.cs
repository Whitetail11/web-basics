using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data
{
    public static class DbInitializer
    {
        public static void Initialize(WebBasicsDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cats.Any())
            {
                if (context.Dogs.Any())
                {
                    return;
                }
                context.Dogs.AddRange(new Entities.Dog[] {
                new Entities.Dog() { Name = "Dog1", Age = 4 },
                new Entities.Dog() { Name = "Dog2", Age = 6 },
                new Entities.Dog() { Name = "Dog3", Age = 7 },
                new Entities.Dog() { Name = "Dog4", Age = 9 }
            });
                context.SaveChanges();
                return;
            }

            context.Cats.AddRange(new Entities.Cat[] { 
                new Entities.Cat() { Name = "Barsik", Age = 3 },
                new Entities.Cat() { Name = "Kozkii", Age = 4 },
                new Entities.Cat() { Name = "Murka", Age = 13 },
                new Entities.Cat() { Name = "Bony", Age = 2 }
            });

            context.SaveChanges();
        }
    }
}
