using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;
using Newtonsoft.Json;
using System.Text;

namespace MyBlogProject_Frontend.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ArticleController : Controller
    {
        public IActionResult Index() 
        {

            List<ApiArticleGetDto> Listdto = new();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Article");

          

            HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                };
                

                Listdto = JsonConvert.DeserializeObject<List<ApiArticleGetDto>>(jsonString,settings);
            }

            return View(Listdto);
        }


        [HttpGet]
        public IActionResult Add()
        {
            List<CategoryDto> CategoryListDto = new();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Category/NonDeleted");
            HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;
            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result;
                CategoryListDto = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonString);
            }
            return View(new ArticleAddDto { Categories = CategoryListDto});   
            
        }

        [HttpPost]
        public IActionResult Add(ArticleAddDto articleAddDto)
        {

            articleAddDto.ImageId = 2;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Article");
            string jsonString = JsonConvert.SerializeObject(articleAddDto);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;
            return RedirectToAction("Index", "Article");

        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            ArticleUpdateDto articleUpdateDto = new ArticleUpdateDto();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7147/api/Article/"+id);

            HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;

            if(msg.StatusCode==System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result; 
                articleUpdateDto = JsonConvert.DeserializeObject<ArticleUpdateDto>(jsonString);
            }

            //Category için
            var CategoryDto = new List<CategoryDto>();
            HttpClient client2 = new HttpClient();       
            client2.BaseAddress = new Uri("https://localhost:7147/api/Category/NonDeleted");
            HttpResponseMessage msg2 = client2.GetAsync(client2.BaseAddress).Result;
            if (msg2.StatusCode == System.Net.HttpStatusCode.OK)            {
                string jsonString = msg2.Content.ReadAsStringAsync().Result;
                CategoryDto = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonString);  
            }

            articleUpdateDto.Categories = CategoryDto;      

            return View(articleUpdateDto);
        }


        [HttpPost]
        public IActionResult Update(ArticleUpdateDto articleUpdateDto)
        {
            articleUpdateDto.ImageId = 2;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Article/");

            string JsonString = JsonConvert.SerializeObject(articleUpdateDto);
            StringContent content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = client.PutAsync(client.BaseAddress, content).Result;
            return RedirectToAction("Index", "Article"); 
           
        }
        
        public IActionResult Delete(int id)
        {
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7147/api/Article/SoftDelete?Id=" + id);
			string jsonContent = JsonConvert.SerializeObject(id);
			StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
			//HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

			HttpResponseMessage msg = client.DeleteAsync(client.BaseAddress).Result;
			return RedirectToAction("Index", "Article");

		}

        public IActionResult Details(int id)
        {
			ApiArticleGetDto articleGetDto = new ApiArticleGetDto();

			HttpClient client = new HttpClient();

			client.BaseAddress = new Uri("https://localhost:7147/api/Article/" + id);

			HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;

			if (msg.StatusCode == System.Net.HttpStatusCode.OK)
			{
				string jsonString = msg.Content.ReadAsStringAsync().Result;
				articleGetDto = JsonConvert.DeserializeObject<ApiArticleGetDto>(jsonString);
			}

            return View(articleGetDto);

		}



    }
}
