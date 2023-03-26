using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;
using MyBlogProject_Frontend.Areas.Admin.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NuGet.Configuration;
using NuGet.Protocol.Plugins;
using System.Net;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MyBlogProject_Frontend.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {

        public IActionResult Index()
        {

            CategoryIndexVM vm = new CategoryIndexVM();

            HttpClient Categoryclient = new HttpClient();
            Categoryclient.BaseAddress = new Uri("https://localhost:7147/api/Category");

            HttpResponseMessage msg = Categoryclient.GetAsync(Categoryclient.BaseAddress).Result;

            if(msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                };

                vm.Categories = JsonConvert.DeserializeObject<List<ApiCategoryGetDto>>(jsonString,settings);
            }


            HttpClient ArticleClient = new HttpClient();
            ArticleClient.BaseAddress = new Uri("https://localhost:7147/api/Article");

            HttpResponseMessage msg2 = ArticleClient.GetAsync(ArticleClient.BaseAddress).Result;

            if(msg2.StatusCode==System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg2.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                };

                vm.Articles = JsonConvert.DeserializeObject<List<ApiArticleGetDto>>(jsonString,settings);               
            }

            return View(vm);
            
        }
        
        public IActionResult Delete([FromBody]int Id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Category/SoftDelete?Id="+Id);
            string jsonContent = JsonConvert.SerializeObject(Id);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            //HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

			HttpResponseMessage msg = client.DeleteAsync(client.BaseAddress).Result;
            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Json(new {isSuccess= true});

            }
            return Json(new {isSuccess= false});		

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add([FromBody] CategoryAddDto categoryAddDto) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Category");
            string jsonString = JsonConvert.SerializeObject(categoryAddDto);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Json(new { isSuccess = true });
            }




            return Json(new { isSuccess = false});

        }

        [HttpPost]
        public IActionResult AddWithAjax([FromBody]CategoryAddDto categoryAddDto)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Category");
            string jsonString = JsonConvert.SerializeObject(categoryAddDto);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Json(new { isSuccess = true, Message = "Ürün başarıyla kaydedildi" });
            }

            return Json(new { isSuccess = false });            

        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {           

            CategoryUpdateDto categoryUpdateDto = new CategoryUpdateDto();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7147/api/Category/" + id);

            HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;

            if(msg.StatusCode==System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result;
                categoryUpdateDto = JsonConvert.DeserializeObject<CategoryUpdateDto>(jsonString);
            }


            return View(categoryUpdateDto);

        }


        [HttpPost]
        public IActionResult CategoryUpdate([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Category");

            string jsonString = JsonConvert.SerializeObject(categoryUpdateDto);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage msg = client.PutAsync(client.BaseAddress, content).Result;

            if(msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Json(new { isSuccess = true });
            }

            return Json(new { isSuccess = false });

          

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            CategoryAddDto categoryAddDto = new CategoryAddDto();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7147/api/Category/" + id);

            HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result;
                categoryAddDto = JsonConvert.DeserializeObject<CategoryAddDto>(jsonString);
            }

            return View(categoryAddDto);


        }


    }
}
