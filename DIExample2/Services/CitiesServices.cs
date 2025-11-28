using ServiceContracts;

namespace Services
{
    public class CitiesServices : ICitiesService
    {
        private List<string> _cities;
        public Guid _Id;
        public Guid Id
        {
            get { return _Id; } 
        }
        public CitiesServices()
        {
            _Id = Guid.NewGuid();
            _cities = new List<string>()
            {
                "da hood",
                "da nigga" ,
                "da bro ",
                "da da da "
            };
        }


        public List<string> GetCities()
        {
            return _cities;
        }
    }
}
