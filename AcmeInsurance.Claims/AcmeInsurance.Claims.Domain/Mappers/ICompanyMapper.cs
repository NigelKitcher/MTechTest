namespace AcmeInsurance.Claims.Domain.Mappers
{
    public interface ICompanyMapper
    {
        /// <summary>
        /// Converts to model.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Models.Company ToModel(Repository.Entities.Company company);
    }
}