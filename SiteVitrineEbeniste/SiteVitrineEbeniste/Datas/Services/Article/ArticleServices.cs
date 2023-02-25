using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace SiteVitrineEbeniste.Datas.Services.Article
{
    public class ArticleServices : IArticleServices
    {
        private AppDbContext dbContext;

        public ArticleServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Models.Article article)
        {
            try
            {
                await dbContext.Articles.AddAsync(article);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public int Count()
        {
            try
            {
                return dbContext.Articles.Count();
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
                return dbContext.Articles.First(article => article.Name == name) != null;
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
                return dbContext.Articles.First(article => article.Id == id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Article? Find(string name)
        {
            try
            {
                return dbContext.Articles.First(article => article.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public async Task<IEnumerable<Models.Article>> GetAll()
        {
            try
            {
                return await dbContext.Articles.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.User> GetViewers()
        {
            throw new NotImplementedException();
        }

        public void Remove(Models.Article article)
        {
            try
            {
                if (!Exists(article.Id))
                    throw new Exception("Article inexistant !");
                else
                {
                    dbContext.Articles.Remove(article);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Article? Update(int id, Models.Article article)
        {
            try
            {
                if (!Exists(id))
                    throw new Exception("Article inexistant ! ");
                else
                {
                    dbContext.Articles.Update(article);
                    dbContext.SaveChanges();
                    return article;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
