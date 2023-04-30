using Microsoft.AspNetCore.Mvc;

using MyBlogProject_Frontend.Models.DTOs;
using MyBlogProject_Frontend.Models.ViewModels;
using Newtonsoft.Json;

namespace MyBlogProject_Frontend.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {        

            HomePageVM _homePageVM = new();

            HttpClient Categoryclient = new HttpClient();
            Categoryclient.BaseAddress = new Uri("https://localhost:7147/api/Category/NonDeleted");
            HttpResponseMessage msg = Categoryclient.GetAsync(Categoryclient.BaseAddress).Result;
            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                };

                _homePageVM.Categories = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonString, settings);
            }
            


            HttpClient ArticleNameClient = new HttpClient();
            ArticleNameClient.BaseAddress = new Uri("https://localhost:7147/api/Article/NonDeleted");
            HttpResponseMessage msg2 = ArticleNameClient.GetAsync(ArticleNameClient.BaseAddress).Result;

            if (msg2.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString2 = msg2.Content.ReadAsStringAsync().Result;

                var settings2 = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                };

                _homePageVM.Articles = JsonConvert.DeserializeObject<List<ArticleDto>>(jsonString2, settings2);
            }

            

            return View(_homePageVM);
        }
    }
}
