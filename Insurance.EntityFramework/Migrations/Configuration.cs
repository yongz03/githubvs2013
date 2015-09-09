using Insurance.EntityFramework;
using Insurance.Rates;

namespace Insurance.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<InsuranceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InsuranceDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Rates.AddOrUpdate<Rate>(new[]
            {
                new Rate{Id = 1, Gender = "M", MinAge = 18, MaxAge = 30, PricePerThousandCover = (decimal) 0.05, IsProtect=false}, 
                new Rate{Id = 2, Gender = "F", MinAge = 18, MaxAge = 28, PricePerThousandCover = (decimal) 0.045, IsProtect=false},
                new Rate{Id = 3, Gender = "M", MinAge = 31, MaxAge = 49, PricePerThousandCover = (decimal) 0.1, IsProtect=false},
                new Rate{Id = 4, Gender = "F", MinAge = 29, MaxAge = 44, PricePerThousandCover = (decimal) 0.15, IsProtect=false},
                new Rate{Id = 5, Gender = "M", MinAge = 50, MaxAge = 65, PricePerThousandCover = (decimal) 0.16, IsProtect=false},
                new Rate{Id = 6, Gender = "F", MinAge = 45, MaxAge = 65, PricePerThousandCover = (decimal) 0.13, IsProtect=false},
                
                new Rate{Id = 13, Gender = "M", MinAge = 18, MaxAge = 30, PricePerThousandCover = (decimal) 0.1, Smoker = true, IsProtect=true}, 
                new Rate{Id = 14, Gender = "F", MinAge = 18, MaxAge = 28, PricePerThousandCover = (decimal) 0.09, Smoker = true, IsProtect=true},
                new Rate{Id = 15, Gender = "M", MinAge = 31, MaxAge = 49, PricePerThousandCover = (decimal) 0.2, Smoker = true, IsProtect=true},
                new Rate{Id = 16, Gender = "F", MinAge = 29, MaxAge = 44, PricePerThousandCover = (decimal) 0.21, Smoker = true, IsProtect=true},
                new Rate{Id = 17, Gender = "M", MinAge = 50, MaxAge = 65, PricePerThousandCover = (decimal) 0.3, Smoker = true, IsProtect=true},
                new Rate{Id = 18, Gender = "F", MinAge = 45, MaxAge = 65, PricePerThousandCover = (decimal) 0.25, Smoker = true, IsProtect=true},
                new Rate{Id = 19, Gender = "M", MinAge = 18, MaxAge = 32, PricePerThousandCover = (decimal) 0.08, Smoker = false, IsProtect=true}, 
                new Rate{Id = 20, Gender = "F", MinAge = 18, MaxAge = 31, PricePerThousandCover = (decimal) 0.09, Smoker = false, IsProtect=true},
                new Rate{Id = 21, Gender = "M", MinAge = 33, MaxAge = 55, PricePerThousandCover = (decimal) 0.17, Smoker = false, IsProtect=true},
                new Rate{Id = 22, Gender = "F", MinAge = 32, MaxAge = 51, PricePerThousandCover = (decimal) 0.2, Smoker = false, IsProtect=true},
                new Rate{Id = 23, Gender = "M", MinAge = 56, MaxAge = 65, PricePerThousandCover = (decimal) 0.25, Smoker = false, IsProtect=true},
                new Rate{Id = 24, Gender = "F", MinAge = 52, MaxAge = 65, PricePerThousandCover = (decimal) 0.23, Smoker = false, IsProtect=true}

            });
        }
    }
}
