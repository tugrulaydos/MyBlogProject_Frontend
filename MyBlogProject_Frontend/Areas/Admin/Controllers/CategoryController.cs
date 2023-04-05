using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;
using MyBlogProject_Frontend.Areas.Admin.Models.ViewModels.CategoryViewModels;
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
		private static bool _DetailPage = false;

		public IActionResult Index()
        {
            

            List<ApiCategoryGetDto> CategoryList = new();
           

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

                CategoryList = JsonConvert.DeserializeObject<List<ApiCategoryGetDto>>(jsonString,settings);
            }

            _DetailPage = true;
            return View(CategoryList);
            
        }
        
        public IActionResult Delete([FromBody]int Id)
        {
			var patchDoc = new JsonPatchDocument<CategorySoftDeleteDto>();
			patchDoc.Replace(e => e.IsDeleted, true);

			HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Category/SoftDelete?Id="+Id);
            string jsonContent = JsonConvert.SerializeObject(patchDoc);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json-patch+json");
           

            HttpResponseMessage msg = client.PatchAsync(client.BaseAddress,content).Result;
            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Json(new { isSuccess = true });

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
            
            CategoryDetailsVM VM = new();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7147/api/Category/" + id);

            HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string jsonString = msg.Content.ReadAsStringAsync().Result;
                VM.categoryDto = JsonConvert.DeserializeObject<ApiCategoryGetDto>(jsonString);
            }

            VM.DetailPage = _DetailPage;

            return View(VM);


        }

        public IActionResult DeletedCategory() 
        {
			List<ApiCategoryGetDto> CategoryList = new();

			HttpClient Categoryclient = new HttpClient();
			Categoryclient.BaseAddress = new Uri("https://localhost:7147/api/Category");

			HttpResponseMessage msg = Categoryclient.GetAsync(Categoryclient.BaseAddress).Result;

			if (msg.StatusCode == System.Net.HttpStatusCode.OK)
			{
				string jsonString = msg.Content.ReadAsStringAsync().Result;

				var settings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					MissingMemberHandling = MissingMemberHandling.Ignore,
				};

				CategoryList = JsonConvert.DeserializeObject<List<ApiCategoryGetDto>>(jsonString, settings);
			}

            _DetailPage = false;
			return View(CategoryList);

		}

		public IActionResult Save([FromBody] int id)
		{
			var patchDoc = new JsonPatchDocument<CategorySaveDto>();
			patchDoc.Replace(e => e.IsDeleted, false);

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7147/api/Category/Save?id="+id);
			string jsonContent = JsonConvert.SerializeObject(patchDoc);
			StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json-patch+json");
			HttpResponseMessage msg = client.PatchAsync(client.BaseAddress, content).Result;

			if (msg.StatusCode == System.Net.HttpStatusCode.OK)
				return Json(new { isSuccess = true });

			return Json(new { isSuccess = false });


		}

        public IActionResult HardDelete([FromBody] int id) 
        {
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7147/api/Category/HardDelete?id=" + id);

			HttpResponseMessage msg = client.DeleteAsync(client.BaseAddress).Result;

			if (msg.StatusCode == System.Net.HttpStatusCode.OK)
				return Json(new { isSuccess = true });

			return Json(new { isSuccess = false });


		}

	}
}
