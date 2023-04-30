using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Models.DTOs;
using MyBlogProject_Frontend.Models.ViewModels;
using Newtonsoft.Json;

namespace MyBlogProject_Frontend.Controllers
{
	public class PostDetailPageController : Controller
	{
		public IActionResult Index(int ID)
		{
            //Article İçin
            HomePageVM homePageVM= new HomePageVM();
            ArticleDto articleDto = new ArticleDto();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:7147/api/Article/" + ID);
            HttpResponseMessage msg1 = client1.GetAsync(client1.BaseAddress).Result;
            if (msg1.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString1 = msg1.Content.ReadAsStringAsync().Result;
                articleDto = JsonConvert.DeserializeObject<ArticleDto>(jsonString1);
            }

            homePageVM.articleDto = articleDto;

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://localhost:7147/api/Article");
            HttpResponseMessage msg2 = client2.GetAsync(client2.BaseAddress).Result;
            if(msg2.StatusCode==System.Net.HttpStatusCode.OK)
            {
                string jsonString2 = msg2.Content.ReadAsStringAsync().Result;
                homePageVM.Articles = JsonConvert.DeserializeObject<List<ArticleDto>>(jsonString2);
            }

            HttpClient client3 = new HttpClient();
            client3.BaseAddress = new Uri("https://localhost:7147/api/Category");
            HttpResponseMessage msg3 = client3.GetAsync(client3.BaseAddress).Result;
            if(msg3.StatusCode==System.Net.HttpStatusCode.OK)
            {
                string jsonString3 = msg3.Content.ReadAsStringAsync().Result;
                homePageVM.Categories = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonString3);
            }

            return View(homePageVM);
		}
	}
}
