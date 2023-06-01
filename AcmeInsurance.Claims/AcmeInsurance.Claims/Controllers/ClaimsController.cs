using AcmeInsurance.Claims.Domain.Adapters;
using AcmeInsurance.Claims.Domain.Models;
using AcmeInsurance.Claims.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcmeInsurance.Claims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService _claimsService;
        private readonly ITimeProvider _timeProvider;

        public ClaimsController(IClaimsService claimsService, ITimeProvider timeProvider)
        {
            _claimsService = claimsService;
            _timeProvider = timeProvider;
        }

        [HttpGet("companies/{companyId}")]
        public IActionResult GetCompany(int companyId)
        {
            var company = _claimsService.GetCompany(companyId);
            if (company == null)
                return NotFound();

            var hasActiveInsurance = company.InsuranceEndDate >= _timeProvider.Now;
            var result = new
            {
                Company = company,
                HasActiveInsurance = hasActiveInsurance
            };

            return Ok(result);
        }

        [HttpGet("companies/{companyId}/claims")]
        public IActionResult GetClaimsForCompany(int companyId)
        {
            var claims = _claimsService.GetClaimsForCompany(companyId);
            if (!claims.Any())
            {
                return NotFound();
            }

            return Ok(claims);
        }

        [HttpGet("claims/{ucr}")]
        public IActionResult GetClaim(string ucr)
        {
            var claim = _claimsService.GetClaim(ucr);
            if (claim == null)
            {
                return NotFound();
            }

            var daysSinceClaim = (_timeProvider.Now - claim.ClaimDate).Days;
            var result = new
            {
                Claim = claim,
                DaysSinceClaim = daysSinceClaim
            };

            return Ok(result);
        }

        [HttpPut("claims/{ucr}")]
        public IActionResult UpdateClaim(string ucr, Claim updatedClaim)
        {
            if (_claimsService.UpdateClaim(ucr, updatedClaim))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}