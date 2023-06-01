using AcmeInsurance.Claims.Domain.Adapters;
using AcmeInsurance.Claims.Domain.Mappers;
using AcmeInsurance.Claims.Domain.Models;
using AcmeInsurance.Claims.Repository;

namespace AcmeInsurance.Claims.Domain.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly IClaimMapper _claimMapper;
        private readonly ICompanyMapper _companyMapper;
        private readonly AcmeDbContext _acmeDbContext;

        public ClaimsService(AcmeDbContext acmeDbContext, IClaimMapper claimMapper, ICompanyMapper companyMapper)
        {
            _acmeDbContext = acmeDbContext;
            _claimMapper = claimMapper;
            _companyMapper = companyMapper;
        }

        public Claim GetClaim(string ucr)
        {
            return _claimMapper.ToModel(_acmeDbContext.Claims.FirstOrDefault(c => c.UCR == ucr));
        }

        public IEnumerable<Claim> GetClaimsForCompany(int companyId)
        {
            foreach(Repository.Entities.Claim claim in _acmeDbContext.Claims.Where(c => c.CompanyId == companyId))
            {
                yield return _claimMapper.ToModel(claim);
            }
        }

        public Company GetCompany(int companyId)
        {
            return _companyMapper.ToModel(_acmeDbContext.Companies.FirstOrDefault(c => c.Id == companyId));
        }

        public bool UpdateClaim(string ucr, Claim updatedClaim)
        {
            var claim = _acmeDbContext.Claims.FirstOrDefault(c => c.UCR == ucr);
            if (claim == null)
            {
                return false;
            }

            claim.LossDate = updatedClaim.LossDate;
            claim.AssuredName = updatedClaim.AssuredName;
            claim.IncurredLoss = updatedClaim.IncurredLoss;
            claim.Closed = updatedClaim.Closed;

            _acmeDbContext.SaveChanges();

            return true;
        }
    }
}
