using Microsoft.EntityFrameworkCore;

namespace SiteVitrineEbeniste.Datas.Services.User
{
    public class UserServices : IUserServices
    {
        private AppDbContext dbContext;

        public UserServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Models.User viewer)
        {
            try
            {
                await dbContext.Users.AddAsync(viewer);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int CountViewers()
        {
            try
            {
                return dbContext.Users.Count(user => user.IsAdmin == false);
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(string email, string password)
        {
            try
            {
                return dbContext.Users.FirstOrDefault
                    (
                        user => user.Email == email &&
                                user.Password == password
                    ) != null;
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int id)
        {
            try
            {
                return dbContext.Users.FirstOrDefault
                    (
                        user => user.Id == id
                    ) != null;
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.User> FilterByUsername(string username)
        {
            try
            {
                return dbContext.Users.ToList().FindAll
                    (user => (user.Name + user.Surname).IndexOf
                        (
                            username,
                            StringComparison.OrdinalIgnoreCase
                        ) != -1
                    ).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.User? Find(string email, string password)
        {
            try
            {
                return dbContext.Users.Find(delegate (Models.User user)
                {
                    if (user.Email == email && user.Password == password)
                        return user;
                    return null;
                });
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.User> GetAllViewers()
        {
            try
            {
                return dbContext.Users.ToList().FindAll
                    (user => user.IsAdmin == false);
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public void Remove(Models.User viewer)
        {
            try
            {
                if (!Exists(viewer.Id))
                    throw new Exception("Utilisateur inexistant !");
                else
                {
                    dbContext.Users.Remove(viewer);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }



        public Models.User? Update(int id, Models.User viewer)
        {
            try
            {
                if (!Exists(id))
                    throw new Exception("Utilisateur inexistant !");
                else
                {
                    dbContext.Users.Update(viewer);
                    dbContext.SaveChanges();
                    return viewer;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
