using AcmeInsurance.Claims.Repository.Entities;

namespace AcmeInsurance.Claims.Repository.Seed
{
    public class Seeder
    {
        private readonly AcmeDbContext _context;
        
        public Seeder(AcmeDbContext context)
        {
            _context = context;
        }

        public void Initialise()
        {
            _context.Database.EnsureDeleted();
            _context.Claims.AddRange(GetClaimEntities());
            _context.ClaimTypes.AddRange(GetClaimTypeEntities());
            _context.Companies.AddRange(GetCompanyEntities());
            _context.SaveChanges();
        }

        private IEnumerable<Claim> GetClaimEntities()
        {
            return new[]
            {
                new Claim()
                {
                    UCR = "C0001",
                    CompanyId = 2,
                    ClaimDate = DateTime.Now,
                    LossDate = DateTime.Now,
                    AssuredName = "Elmer Fudd",
                    IncurredLoss  = 10.0M,
                    Closed = true,
                },
                new Claim()
                {
                    UCR = "C0002",
                    CompanyId = 2,
                    ClaimDate = DateTime.Now,
                    LossDate = DateTime.Now,
                    AssuredName = "Elmer Fudd",
                    IncurredLoss  = 15.0M,
                    Closed = true,
                },
                new Claim()
                {
                    UCR = "C0003",
                    CompanyId = 2,
                    ClaimDate = DateTime.Now,
                    LossDate = DateTime.Now,
                    AssuredName = "Elmer Fudd",
                    IncurredLoss  = 20.0M,
                    Closed = false,
                },
                new Claim()
                {
                    UCR = "C0004",
                    CompanyId = 3,
                    ClaimDate = DateTime.Now,
                    LossDate = DateTime.Now,
                    AssuredName = "Tweety Pie",
                    IncurredLoss  = 30.0M,
                    Closed = false,
                },

            };
        }

        private IEnumerable<ClaimType> GetClaimTypeEntities()
        {
            return new[]
            {
                new ClaimType()
                {
                     Id = 1,
                     Name = "Fire",
                },
                new ClaimType()
                {
                     Id = 2,
                     Name = "Theft",
                },
            };
        }

        private IEnumerable<Company> GetCompanyEntities()
        {
            return new[]
            {
                new Company()
                {
                    Id = 1,
                    Name = "Marvins Martian Tours",
                    Active = true,
                    Address1 = "58 Hillside Road,",
                    Address2 = "West Kirby",
                    Address3 = "Chester",
                    Country = "Wales",
                    InsuranceEndDate = new DateTime(2023, 10, 1),
                    Postcode = "CH48 8BB",
                },
                new Company()
                {
                    Id = 2,
                    Name = "Elmer Fudd Pest Control",
                    Active = true,
                    Address1 = "101 Empress Avenue",
                    Address2 = "London",
                    Address3 = "",
                    Country = "England",
                    InsuranceEndDate = new DateTime(2023, 1, 1),
                    Postcode = "E12 5SA",
                },
                new Company()
                {
                    Id = 3,
                    Name = "Tweety Bird Surveillance Systems",
                    Active = true,
                    Address1 = "4 Rayners Falgate",
                    Address2 = "Caston",
                    Address3 = "Norwich",
                    Country = "England",
                    InsuranceEndDate = new DateTime(2023, 2, 1),
                    Postcode = "NR17 1DW",
                },
            };
        }
    }
}
