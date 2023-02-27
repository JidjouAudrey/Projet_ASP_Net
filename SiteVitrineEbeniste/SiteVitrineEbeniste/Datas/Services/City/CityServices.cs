using SiteVitrineEbeniste.Datas.Services.User;

namespace SiteVitrineEbeniste.Datas.Services.City
{
    public class CityServices : ICityServices
    {

        private AppDbContext dbContext;

        private UserServices userServices;

        public CityServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            userServices = new UserServices(dbContext);
        }

        public async Task Add(Models.City city)
        {
            try
            {
                if (Exists(city.CityName))
                    throw new Exception("Ville déjà existante !");
                else
                {
                    await dbContext.Cities.AddAsync(city);
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
                return dbContext.Cities.Count();
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
                return dbContext.Cities.First(city => city.Id == id) != null;
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(string name)
        {
            try
            {
                try
                {
                    return dbContext.Cities.First(city => city.CityName == name) != null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erreur : " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.City? Find(string name)
        {
            try
            {
                try
                {
                    return dbContext.Cities.First(city => city.CityName == name);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erreur : " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.City> GetAll()
        {
            try
            {
                return dbContext.Cities.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.User> GetUsers(int cityId)
        {
            try
            {
                return userServices.GetAll().
                    Where(user => user.CityId == cityId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public void Remove(Models.City city)
        {
            try
            {
                if (!Exists(city.Id))
                    throw new Exception("Ville inexistante");
                else
                {
                    dbContext.Cities.Remove(city);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.City? Update(int id, Models.City city)
        {
            try
            {
                if (!Exists(city.Id))
                    throw new Exception("Ville inexistante");
                else
                {
                    dbContext.Cities.Update(city);
                    dbContext.SaveChanges();
                    return city;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
