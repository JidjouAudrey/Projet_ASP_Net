using SiteVitrineEbeniste.Models;

namespace SiteVitrineEbeniste.Datas.Services.Country
{
    public interface ICountryServices
    {
        Task Add(Models.Country country);
        void Remove(Models.Country country);
        Models.Country? Update(int id, Models.Country country);
        IEnumerable<Models.Country> GetAll();
        bool Exists(int id);
        bool Exists(string name);
        Models.Country? Find(string name);
        int Count();
        IEnumerable<Models.City> GetCities(int countryId);
    }
}
