using System.Linq;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();


            if (context.Users.Any())
            {
                return;
            }

            var Users = new User[]
            {
                new User{Name="Amrit Subedi", PhoneNumber="9856875314"},
                new User{Name="Bibesh KC", PhoneNumber="9859564088"}
            };

            foreach (User u in Users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
