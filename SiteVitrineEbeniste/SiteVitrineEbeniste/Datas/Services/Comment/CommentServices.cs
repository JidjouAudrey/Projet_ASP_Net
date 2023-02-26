namespace SiteVitrineEbeniste.Datas.Services.Comment
{
    public class CommentServices : ICommentServices
    {

        private AppDbContext dbContext;

        public CommentServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task Add(Models.Comment comment)
        {
            try
            {
                await dbContext.Comments.AddAsync(comment);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exist(int commenterId, int articleId, DateTime commentedDate)
        {
            try
            {
                return dbContext.Comments.FirstOrDefault
                    (
                        comment => comment.CommenterId == commenterId &&
                                   comment.ArticleId == articleId &&
                                   comment.CommentDate == commentedDate
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Comment? Find(int commenterId, int articleId, DateTime commentedDate)
        {
            try
            {
                return dbContext.Comments.FirstOrDefault
                    (
                        comment => comment.CommenterId == commenterId &&
                                   comment.ArticleId == articleId &&
                                   comment.CommentDate == commentedDate
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Comment? Find(int commenterId, int articleId, string content)
        {
            try
            {
                return dbContext.Comments.FirstOrDefault
                    (
                        comment => comment.CommenterId == commenterId &&
                                   comment.ArticleId == articleId &&
                                   comment.Comments == content
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.Comment> GetAll()
        {
            try
            {
                return dbContext.Comments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public void Remove(Models.Comment comment)
        {
            try
            {
                if (!Exist(comment.CommenterId, comment.ArticleId, comment.CommentDate))
                    throw new Exception("Commentaire inexistant ! ");
                else
                {
                    dbContext.Comments.Remove(comment);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Comment? Update(Models.Comment comment)
        {
            try
            {
                if (!Exist(comment.CommenterId, comment.ArticleId, comment.CommentDate))
                    throw new Exception("Commentaire inexistant ! ");
                else
                {
                    dbContext.Comments.Update(comment);
                    dbContext.SaveChanges();
                    return comment;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
