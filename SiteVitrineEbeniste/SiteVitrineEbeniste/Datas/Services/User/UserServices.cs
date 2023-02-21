using Microsoft.EntityFrameworkCore;

namespace SiteVitrineEbeniste.Datas.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext dbContext;

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

        public async Task<bool> Exists(string username, string password)
        {
            try
            {
                return await dbContext.Users.FirstOrDefaultAsync
                    (
                        user => user.Name == username &&
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

        public IEnumerable<Models.User> GetAllViewers()
        {
            try
            {
                return dbContext.Users.ToList().FindAll
                    (user => user.IsAdmin = false);
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
                dbContext.Users.Remove(viewer);
                dbContext.SaveChanges();
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
                    return null;
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
