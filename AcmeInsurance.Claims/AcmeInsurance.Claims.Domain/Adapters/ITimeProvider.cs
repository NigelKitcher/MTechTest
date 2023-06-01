namespace AcmeInsurance.Claims.Domain.Adapters
{
    public interface ITimeProvider
    {
        /// <summary>
        /// Returns a DateTime representing the current date and time.
        /// </summary>
        /// <returns></returns>
        DateTime Now { get; }
    }
}
