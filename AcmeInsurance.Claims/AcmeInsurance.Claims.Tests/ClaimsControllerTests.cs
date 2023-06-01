using AcmeInsurance.Claims.Controllers;
using AcmeInsurance.Claims.Domain.Adapters;
using AcmeInsurance.Claims.Domain.Mappers;
using AcmeInsurance.Claims.Domain.Models;
using AcmeInsurance.Claims.Domain.Services;
using AcmeInsurance.Claims.Repository;
using AcmeInsurance.Claims.Repository.Seed;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AcmeInsurance.Claims.Tests
{
    [TestClass]
    public class ClaimsControllerTests
    {
        [TestMethod]
        public void GIVEN_company_with_InsuranceEndDate_after_now_WHEN_queried_for_that_company_THEN_company_details_are_returned_and_has_active_insurance_is_true()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AcmeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
            var claimMapper = new ClaimMapper();
            var companyMapper = new CompanyMapper();
            var mockTimeProvider = new Mock<ITimeProvider>();
            mockTimeProvider.Setup(x => x.Now).Returns(new DateTime(2023, 1, 1));

            using (var dbContext = new AcmeDbContext(options))
            {
                var seeder = new Seeder(dbContext);
                seeder.Initialise();

                var claimsService = new ClaimsService(dbContext, claimMapper, companyMapper);

                var claimsController = new ClaimsController(claimsService, mockTimeProvider.Object);

                // Act
                var okObjectResult = (OkObjectResult)claimsController.GetCompany(1);

                var company = (Company)okObjectResult.Value.GetType().GetProperty("Company").GetValue(okObjectResult.Value);
                var hasActiveInsurance = (bool)okObjectResult.Value.GetType().GetProperty("HasActiveInsurance").GetValue(okObjectResult.Value);

                // Assert
                Assert.AreEqual(1, company.Id);
                Assert.AreEqual("Marvins Martian Tours", company.Name);
                Assert.AreEqual(true, company.Active);
                Assert.AreEqual("58 Hillside Road,", company.Address1);
                Assert.AreEqual("West Kirby", company.Address2);
                Assert.AreEqual("Chester", company.Address3);
                Assert.AreEqual("Wales", company.Country);
                Assert.AreEqual(new DateTime(2023, 10, 1), company.InsuranceEndDate);
                Assert.AreEqual("CH48 8BB", company.Postcode);

                Assert.IsTrue(hasActiveInsurance);
            }
        }

        [TestMethod]
        public void GIVEN_company_with_InsuranceEndDate_before_now_WHEN_queried_for_that_company_THEN_company_details_are_returned_and_has_active_insurance_is_false()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AcmeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
            var claimMapper = new ClaimMapper();
            var companyMapper = new CompanyMapper();
            var mockTimeProvider = new Mock<ITimeProvider>();
            mockTimeProvider.Setup(x => x.Now).Returns(new DateTime(2024, 1, 1));

            using (var dbContext = new AcmeDbContext(options))
            {
                var seeder = new Seeder(dbContext);
                seeder.Initialise();

                var claimsService = new ClaimsService(dbContext, claimMapper, companyMapper);

                var claimsController = new ClaimsController(claimsService, mockTimeProvider.Object);

                // Act
                var okObjectResult = (OkObjectResult)claimsController.GetCompany(1);

                var company = (Company)okObjectResult.Value.GetType().GetProperty("Company").GetValue(okObjectResult.Value);
                var hasActiveInsurance = (bool)okObjectResult.Value.GetType().GetProperty("HasActiveInsurance").GetValue(okObjectResult.Value);

                // Assert
                Assert.AreEqual(1, company.Id);
                Assert.AreEqual("Marvins Martian Tours", company.Name);
                Assert.AreEqual(true, company.Active);
                Assert.AreEqual("58 Hillside Road,", company.Address1);
                Assert.AreEqual("West Kirby", company.Address2);
                Assert.AreEqual("Chester", company.Address3);
                Assert.AreEqual("Wales", company.Country);
                Assert.AreEqual(new DateTime(2023, 10, 1), company.InsuranceEndDate);
                Assert.AreEqual("CH48 8BB", company.Postcode);

                Assert.IsFalse(hasActiveInsurance);
            }
        }

    }
}