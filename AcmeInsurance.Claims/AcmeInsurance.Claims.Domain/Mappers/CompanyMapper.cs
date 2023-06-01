namespace AcmeInsurance.Claims.Domain.Mappers
{
    internal class CompanyMapper : ICompanyMapper
    {
        public Models.Company ToModel(Repository.Entities.Company company)
        {
            if (company == null) return null;

            return new Models.Company()
            {
                Id = company.Id,
                Name = company.Name,
                Active = company.Active,
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                Country = company.Country,
                Postcode = company.Postcode,
                InsuranceEndDate = company.InsuranceEndDate,
            };
        }
    }
}
