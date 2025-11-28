namespace ServiceContracts
{
    public interface ICitiesService
    {
        Guid Id { get; }
        List<string> GetCities ();
    }
}
