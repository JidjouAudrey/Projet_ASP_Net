using SiteVitrineEbeniste.Datas.Services.City;
using System.Security.Cryptography.Xml;

namespace SiteVitrineEbeniste.Datas.Services.Country
{
    public class CountryServices : ICountryServices
    {

        private AppDbContext dbContext;

        private CityServices cityServices;

        public CountryServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            cityServices = new CityServices(dbContext);
        }
        
        public async Task Add(Models.Country country)
        {
            try
            {
                if (Exists(country.NameCountry))
                    throw new Exception("Pays déjà existant !");
                else
                {
                    await dbContext.Countries.AddAsync(country);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int Count()
        {
            try
            {
                return dbContext.Countries.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int id)
        {
            try
            {
                return dbContext.Countries.First(country => country.Id == id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(string name)
        {
            try
            {
                return dbContext.Countries.First(country => country.NameCountry == name) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Country? Find(string name)
        {
            try
            {
                return dbContext.Countries.First(country => country.NameCountry == name);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.Country> GetAll()
        {
            try
            {
                return dbContext.Countries.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.City> GetCities(int countryId)
        {
            try
            {
                return cityServices.GetAll().
                    Where(city => city.CountryId == countryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public void Remove(Models.Country country)
        {
            try
            {
                if (!Exists(country.Id))
                    throw new Exception("Pays inexistant !");
                else
                {
                    dbContext.Countries.Remove(country);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Country? Update(int id, Models.Country country)
        {
            try
            {
                if (!Exists(id))
                    throw new Exception("Pays inexistant !");
                else
                {
                    dbContext.Countries.Update(country);
                    dbContext.SaveChanges();
                    return country;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
