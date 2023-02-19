using Microsoft.Extensions.DependencyInjection;
using SiteVitrineEbeniste.Models;
using SiteVitrineEbeniste.Datas.Enums;
using SiteVitrineEbeniste.Datas.Enum;

namespace SiteVitrineEbeniste.Datas
{
    public class InitializeApp
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
                            CountryCode="237"
                        }
                    });
                }

                //Ajouter cities
                if(context.Cities.Any())
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
                            IsAdmin=true,
                        }
                    });
                }
                
                //Ajouter Article
                if(!context.Articles.Any())
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
                            PublishedDate= DateTime.Now,
                        }
                    });
                }

                //Ajouter userArticles
                if (context.UserArticles.Any()) 
                {
                    context.UserArticles.AddRange(new List<UserArticle>()
                    {
                        new UserArticle()
                        {
                            UserId= 1,
                            ArticleId= 1,
                        }
                    });
                }

                if(context.Messages.Any())
                {
                    context.Messages.AddRange(new List<Message>()
                    {
                        new Message()
                        {
                             Containt="cette armoir coute combien"
                        }
                    });
                }

            }
        }

    }
}
