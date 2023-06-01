namespace AcmeInsurance.Claims.Domain.Adapters
{
    internal class TimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
