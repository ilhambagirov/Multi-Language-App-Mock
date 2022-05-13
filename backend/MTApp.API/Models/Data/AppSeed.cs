using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MTApp.API.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTApp.API.Models.Data
{
    public static class AppSeed
    {
        public async static Task<IApplicationBuilder> Seed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (!db.Languages.Any() && !db.NewsLanguages.Any() && !db.News.Any())
                {
                    List<Language> languages = new();

                    languages.Add(new Language { Name = "Azerbaijan", Label = "az" });
                    languages.Add(new Language { Name = "Russian", Label = "ru" });
                    languages.Add(new Language { Name = "English", Label = "en" });

                    List<News> news = new();

                    List<NewsLanguage> newsLanguages = new();

                    newsLanguages.Add(new NewsLanguage
                    {
                        Title = "Olimpiya mükafatçısından sərt tənqid: “Bu məşqçini Azərbaycana yenidən gətirən üçüncü qüvvə kimdir?”",
                        Context = "“Milli komandada məşqçi dəyişikliyi oldu." +
                        " Yenə kubalını gətirdilər. Sonuncu dəfə Boks Federasiyasının rəhbərliyi ilə görüşdə hamı xahiş etdi ki," +
                        " milliyə əcnəbi gətirilməsin. Federasiya prezidenti Sahil Babayev də söz verdi ki," +
                        " məsələ ilə bağlı müzakirə aparacaqlar və çalışacaqlar ki, əcnəbi olmasın." +
                        " Amma yenə əcnəbi məşqçi təyin olundu”.",
                        NewsId = 1,
                        LanguageId = 1
                    });
                    newsLanguages.Add(new NewsLanguage
                    {
                        Title = "Strict criticism from the Olympic medalist: Who is the third force that brought this coach back to Azerbaijan ? ",
                        Context = "There was a change of coach in the national team. " +
                        "They brought the Cuban again. At the last meeting with the leadership of the Boxing Federation, everyone asked that." +
                        "No foreigners should be brought to the national team. The president of the federation Sahil Babayev also promised that" +
                        "They will discuss the issue and try not to be a foreigner." +
                        "But again, a foreign coach was appointed",
                        NewsId = 1,
                        LanguageId = 3
                    });
                    newsLanguages.Add(new NewsLanguage
                    {
                        Title = "Жесткая критика от призера Олимпийских игр: Кто является третьей силой, которая вернула этого тренера в Азербайджан?",
                        Context = "В сборной произошла смена тренера. " +
                        "Привезли снова кубинца.На последней встрече с руководством Федерации бокса все об этом спрашивали" +
                       "Иностранцев в сборную брать нельзя.Это пообещал и президент федерации Сахиль Бабаев" +
                        "Они обсудят этот вопрос и постараются не быть иностранцем" +
                        "Но опять же" +
                        "тренера - иностранца назначили",
                        NewsId = 1,
                        LanguageId = 2
                    });

                    news.Add(new News { NewsLanguages = newsLanguages });

                    await db.Languages.AddRangeAsync(languages);
                    await db.SaveChangesAsync();
                    await db.News.AddRangeAsync(news);
                    await db.SaveChangesAsync();
                }
                return app;
            }
        }
    }
}
