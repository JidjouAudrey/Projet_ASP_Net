namespace SiteVitrineEbeniste.Datas.Services.Message
{
    public class MessageServices : IMessageServices
    {

        private AppDbContext dbContext;

        public MessageServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Models.Message message)
        {
            try
            {
                await dbContext.Messages.AddAsync(message);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int id)
        {
            try
            {
                return dbContext.Messages.FirstOrDefault(message => message.Id == id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public bool Exists(int senderId, int receiverId, DateTime sentDate, string content)
        {
            try
            {
                return dbContext.Messages.FirstOrDefault
                    (
                        message => message.SenderId == senderId &&
                                   message.ReceiverId == receiverId &&
                                   message.SentDate == sentDate &&
                                   message.Content == content
                    ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Message? Find(int senderId, int receiverId, DateTime sentDate, string content)
        {
            try
            {
                return dbContext.Messages.FirstOrDefault
                    (
                        message => message.SenderId == senderId &&
                                   message.ReceiverId == receiverId &&
                                   message.SentDate == sentDate &&
                                   message.Content == content
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public IEnumerable<Models.Message> GetAll()
        {
            try
            {
                return dbContext.Messages.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public void Remove(Models.Message message)
        {
            try
            {
                if (Exists(message.Id))
                {
                    dbContext.Messages.Remove(message);
                    dbContext.SaveChanges();
                }
                else
                    throw new Exception("Message inexistant !");
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }

        public Models.Message? Update(int id, Models.Message message)
        {
            try
            {
                if (Exists(id))
                {
                    dbContext.Messages.Update(message);
                    dbContext.SaveChanges();
                    return message;
                }
                throw new Exception("Message inexistant !");
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : " + ex.Message);
            }
        }
    }
}
