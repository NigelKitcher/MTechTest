namespace AcmeInsurance.Claims.Domain.Mappers
{
    public interface IClaimMapper
    {
        /// <summary>
        /// Converts to model.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        Models.Claim ToModel(Repository.Entities.Claim claim);

        /// <summary>
        /// Converts to entity.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        Repository.Entities.Claim ToEntity(Models.Claim claim);
    }
}