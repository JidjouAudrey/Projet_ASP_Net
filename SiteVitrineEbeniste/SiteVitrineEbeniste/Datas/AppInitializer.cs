using Microsoft.Extensions.DependencyInjection;
using SiteVitrineEbeniste.Models;
using SiteVitrineEbeniste.Datas.Enums;
using SiteVitrineEbeniste.Datas.Enum;

namespace SiteVitrineEbeniste.Datas
{
    public class AppInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Ajouter country
                if(!context.Countries.Any())
                {
                    context.Countries.AddRange(new List<Country>()
                    { 
                        new Country()
                        {
                            NameCountry="Cameroun",
                            CountryCode="+237"
                        }
                    });
                    context.SaveChanges();
                }

                //Ajouter cities
                if(!context.Cities.Any())
                {
                    context.Cities.AddRange(new List<City>()
                    {
                        new City()
                        {
                            CityName="Douala",
                            CountryId=1
                        },
                        new City()
                        {
                            CityName="Yaounde",
                            CountryId=1
                        }

                    });
                    context.SaveChanges();
                }

                //ajouter user
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            Name="Lamoire",
                            Surname="pierre",
                            Email="Lamoirep@gmail.com",
                            Password="LamoirePierre",
                            Biography="menusier depuis 2000 specialisé en bois rare",
                            Phone="678524146",
                            CityId=1,
                            IsAdmin=true
                        },
                        new User()
                        {
                            Name="Elouga",
                            Surname="Raoul",
                            Email="Raoul@gmail.com",
                            Password="elougaraoul",
                            Phone="685457172",
                            CityId=1,
                            IsAdmin=false
                        }
                    });
                    context.SaveChanges();
                }

                //ADD Message
                if (!context.Messages.Any())
                {
                    context.Messages.AddRange(new List<Message>()
                    {
                        new Message()
                        {
                             SenderId= 4,
                             Content="j'aimerais connaitre vos modaliter de renovation",
                             ReceiverId=3,
                             SentDate= DateTime.Now.AddDays(-2)
                        },
                        new Message()
                        {
                            SenderId= 3,
                            Content="Tout depend de ce que vous voulez renovez",
                            ReceiverId=4,
                            SentDate= DateTime.Now.AddDays(-2).AddHours(3)
                        },
                        new Message()
                        {
                             SenderId= 4,
                             Content="Merci",
                             ReceiverId=3,
                             SentDate= DateTime.Now.AddDays(-2).AddHours(4)
                        }
                    });
                    context.SaveChanges();
                }

                //Ajouter Article
                if (!context.Articles.Any())
                {
                    context.Articles.AddRange(new List<Article>()
                    {
                        new Article()
                        {
                            Name= "Armoir GT",
                            Category= Category.Fabrication,
                            Material= Material.Ebene,
                            Description="Fabriquer avec le materiel dur et bien traiter",
                            UrlImage="https://media.istockphoto.com/id/172931561/fr/photo/centre-g%C3%A9riatrique-chambre.jpg?b=1&s=170667a&w=0&k=20&c=MLmqeKn4Bcf1_frKHhPuyM0L3M2mq_rI7ikLDmWDrto=",
                            Price=150000,
                            PublisherId=3,
                            PublishedDate= DateTime.Now
                        },
                        new Article()
                        {
                            Name="Range Tout",
                            Category= Category.Fabrication,
                            Material= Material.Ebene,
                            Description = "fait a base de bois rouge du sud",
                            UrlImage="https://media.istockphoto.com/id/1444357949/fr/photo/bo%C3%AEte-%C3%A0-bijoux-en-bois-antique-isol%C3%A9e-sur-fond-blanc.jpg?b=1&s=170667a&w=0&k=20&c=Pzo8su3ti8YUsJGzlHUt9yteYGQ2FTgAaOAiztqblcY=",
                            Price=90000,
                            PublisherId=3,
                            PublishedDate= DateTime.Now
                        }
                    });
                    context.SaveChanges();
                }

                //Ajouter userArticles
                if (!context.UserArticles.Any()) 
                {
                    context.UserArticles.AddRange(new List<UserArticle>()
                    {
                        new UserArticle()
                        {
                            UserId= 3,
                            ArticleId= 1,
                            ViewedPeriod= DateTime.Now.AddDays(1)
                        },
                        new UserArticle()
                        {
                            UserId= 3,
                            ArticleId= 2,
                            ViewedPeriod=DateTime.Now.AddDays(2)
                        },
                        new UserArticle()
                        {
                            UserId= 3,
                            ArticleId= 1,
                            ViewedPeriod= DateTime.Now.AddDays(9)
                        }
                    });
                    context.SaveChanges();
                }

                
                if (!context.Comments.Any())
                {
                    context.Comments.AddRange(new List<Comment>
                    {
                        new Comment()
                        {
                            ArticleId= 1,
                            CommenterId=4,
                            Comments="tres jolie cette penderie",
                            CommentDate= DateTime.Now.AddDays(3)
                        }
                    });
                    context.SaveChanges();
                }

            }
        }

    }
}
