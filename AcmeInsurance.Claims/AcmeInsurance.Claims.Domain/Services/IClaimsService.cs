using AcmeInsurance.Claims.Domain.Models;

namespace AcmeInsurance.Claims.Domain.Services
{
    public interface IClaimsService
    {
        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        Company GetCompany(int companyId);

        /// <summary>
        /// Gets the claims for company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IEnumerable<Claim> GetClaimsForCompany(int companyId);

        /// <summary>
        /// Gets the claim.
        /// </summary>
        /// <param name="ucr">The ucr.</param>
        /// <returns></returns>
        Claim GetClaim(string ucr);

        /// <summary>
        /// Updates the claim.
        /// </summary>
        /// <param name="ucr">The ucr.</param>
        /// <param name="updatedClaim">The updated claim.</param>
        /// <returns></returns>
        bool UpdateClaim(string ucr, Claim updatedClaim);
    }
}