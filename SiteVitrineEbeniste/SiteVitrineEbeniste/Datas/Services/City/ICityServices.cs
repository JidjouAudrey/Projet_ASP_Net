namespace SiteVitrineEbeniste.Datas.Services.City
{
    public interface ICityServices
    {
        Task Add(Models.City city);
        void Remove(Models.City city);
        Models.City? Update(int id, Models.City city);
        IEnumerable<Models.City> GetAll();
        bool Exists(int id);
        bool Exists(string name);
        Models.City? Find(string name);
        int Count();
        IEnumerable<Models.User> GetUsers(int cityId);
    }
}
