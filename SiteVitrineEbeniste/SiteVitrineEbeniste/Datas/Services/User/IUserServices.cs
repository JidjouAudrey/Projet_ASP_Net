namespace SiteVitrineEbeniste.Datas.Services.User
{
    public interface IUserServices
    { 
        Task Add(Models.User viewer);
        IEnumerable<Models.User> GetAll();
        IEnumerable<Models.User> GetAllViewers();
        void Remove(Models.User viewer);
        Models.User? Update(int id, Models.User viewer);
        IEnumerable<Models.User> FilterByUsername(string username);
        bool Exists(string email, string password);
        bool Exists(int id);
        Models.User? Find(string email, string password);
        int CountViewers();
        IEnumerable<Models.UserArticle> GetViewedArticles(int userId);
        IEnumerable<Models.Message> GetDiscussion(int senderId, int receiverId);
        IEnumerable<Models.Article> GetPublishedArticles(int publisherId);
    }
}
