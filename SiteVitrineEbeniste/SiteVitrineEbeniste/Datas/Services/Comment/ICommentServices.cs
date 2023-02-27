using System.Globalization;

namespace SiteVitrineEbeniste.Datas.Services.Comment
{
    public interface ICommentServices
    {
        Task Add(Models.Comment comment);
        void Remove(Models.Comment comment);
        Models.Comment? Update(Models.Comment comment);
        IEnumerable<Models.Comment> GetAll();
        Models.Comment? Find(int commenterId, int articleId, DateTime commentedDate);
        Models.Comment? Find(int commenterId, int articleId, string content);
        bool Exist(int commenterId, int articleId, DateTime commentedDate);
    }
}
