namespace SiteVitrineEbeniste.Datas.Services.Article
{
    public interface IArticleServices
    {
        Task Add(Models.Article article);
        void Remove(Models.Article article);
        Models.Article? Update(int id, Models.Article article);
        bool Exists(string name);
        bool Exists(int id);
        Models.Article? Find(string name);
        Task<IEnumerable<Models.Article>> GetAll();
        int Count();
        IEnumerable<Models.User> GetViewers();
        IEnumerable<Models.Comment> GetComments();
    }
}
