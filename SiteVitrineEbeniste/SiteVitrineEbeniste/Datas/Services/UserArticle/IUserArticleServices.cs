namespace SiteVitrineEbeniste.Datas.Services.UserArticle
{
    public interface IUserArticleServices
    {
        Task Add(Models.UserArticle article);
        void Remove(Models.UserArticle article);
        bool Exists(int userId, int articleId, DateTime viewedDate);
        Models.UserArticle? Find(int userId, int articleId, DateTime viewedDate);
        IEnumerable<Models.UserArticle> GetAll();
    }
}
