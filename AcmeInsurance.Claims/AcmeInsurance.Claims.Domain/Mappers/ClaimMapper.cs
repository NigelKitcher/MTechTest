namespace AcmeInsurance.Claims.Domain.Mappers
{
    internal class ClaimMapper : IClaimMapper
    {
        public Repository.Entities.Claim ToEntity(Models.Claim claim)
        {
            if (claim == null) return null;

            return new Repository.Entities.Claim()
            {
                UCR = claim.UCR,
                AssuredName = claim.AssuredName,
                ClaimDate = claim.ClaimDate,
                Closed=claim.Closed,
                CompanyId = claim.CompanyId,
                IncurredLoss = claim.IncurredLoss,
                LossDate = claim.LossDate,
            };
        }

        public Models.Claim ToModel(Repository.Entities.Claim claim)
        {
            if (claim == null) return null;

            return new Models.Claim()
            {
                UCR = claim.UCR,
                LossDate = claim.LossDate,
                IncurredLoss = claim.IncurredLoss,
                AssuredName = claim.AssuredName,
                CompanyId = claim.CompanyId,
                Closed = claim.Closed,
                ClaimDate = claim.ClaimDate,
            };
        }
    }
}
