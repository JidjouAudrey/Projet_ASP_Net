namespace SiteVitrineEbeniste.Datas.Services.Message
{
    public interface IMessageServices
    {
        Task Add(Models.Message message);
        void Remove(Models.Message message);
        Models.Message? Update(int id, Models.Message message);
        IEnumerable<Models.Message> GetAll();
        bool Exists(int id);
        bool Exists(int senderId, int receiverId, DateTime sentDate, string content);
        Models.Message? Find(int senderId, int receiverId, DateTime sentDate, string content);
    }
}
