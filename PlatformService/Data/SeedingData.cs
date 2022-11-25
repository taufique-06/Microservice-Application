namespace PlatformService.Data
{
    public class SeedingData
    {
        public static void PrepForPopulatingData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<PlatfromDbContext>());
            }
        }

        private static void SeedData(PlatfromDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("Seeding Data Started.........");

                context.Platforms.AddRange(
                    new Models.Platform { Name="Gang of Four", Cost = "$12.22", Publisher = "N/A"},
                    new Models.Platform { Name = "Microsoft", Cost = "$244.12", Publisher = "Taufique" },
                    new Models.Platform { Name = "Google", Cost = "free", Publisher = "Dave" });

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We already have data");
            }
        }
    }
}
