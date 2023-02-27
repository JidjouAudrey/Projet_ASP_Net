using SiteVitrineEbeniste.Datas.Services.Article;
using SiteVitrineEbeniste.Datas.Services.User;

namespace SiteVitrineEbeniste.Datas.Services.UserArticle
{
    public class UserArticleServices : IUserArticleServices
    {

        private AppDbContext dbContext;

        private UserServices userServices;

        private ArticleServices articleServices;

        public UserArticleServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            userServices = new UserServices(dbContext);

            articleServices = new ArticleServices(dbContext);
        }

        public async Task Add(Models.UserArticle userArticle)
        {
            try
            {
                await dbContext.UserArticles.AddAsync(userArticle);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int userId, int articleId, DateTime viewedDate)
        {
            try
            {
                return dbContext.UserArticles.FirstOrDefault
                    (
                        ua => ua.UserId == userId &&
                              ua.ArticleId == articleId &&
                              ua.ViewedPeriod == viewedDate
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.UserArticle? Find(int userId, int articleId, DateTime viewedDate)
        {
            try
            {
                return dbContext.UserArticles.FirstOrDefault
                    (
                        ua => ua.UserId == userId &&
                              ua.ArticleId == articleId &&
                              ua.ViewedPeriod == viewedDate
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.UserArticle> GetAll()
        {
            try
            {
                return dbContext.UserArticles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }

        }

        public void Remove(Models.UserArticle article)
        {
            throw new NotImplementedException();
        }
    }
}
