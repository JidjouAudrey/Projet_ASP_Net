namespace SiteVitrineEbeniste.Datas.Services.User
{
    public interface IUserServices
    {
        Task Add(Models.User viewer);
        IEnumerable<Models.User> GetAllViewers();
        void Remove(Models.User viewer);
        Models.User? Update(int id, Models.User viewer);
        IEnumerable<Models.User> FilterByUsername(string username);
        Task<bool> Exists(string username, string password);
        bool Exists(int id);
    }
}
