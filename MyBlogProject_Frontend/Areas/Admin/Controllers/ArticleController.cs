using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;
using MyBlogProject_Frontend.Areas.Admin.Models.ViewModels.ArticleViewModels;
using Newtonsoft.Json;
using System.Text;


namespace MyBlogProject_Frontend.Areas.Admin.Controllers
{
    

    [Area("admin")]
    public class ArticleController : Controller
    {
        private static bool _DetailPage = false;
        private readonly IWebHostEnvironment _webHostEnvironment;
	

		public ArticleController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment= webHostEnvironment;

        }
        public IActionResult Index() 
        {

            List<ApiArticleGetDto> ListDto = new();            

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
                

                ListDto = JsonConvert.DeserializeObject<List<ApiArticleGetDto>>(jsonString,settings);
            }

            _DetailPage = true;
            return View(ListDto);
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
			#region Photo Transactions
			var file = articleAddDto.ArticlePhoto;

            var fileName = Path.GetFileName(file.FileName);
            var fileExtension = Path.GetExtension(fileName);

            //Unique ID
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

            //Resmin Kaydedileceği Yolu Ayarla
            var uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath,"ArticlePhotos");
            var filePath = Path.Combine(uploadsDirectory,uniqueFileName);

            //if There is no folder, Create it
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            //Save the Directory to the disk
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }


            articleAddDto.PhotoPath = uniqueFileName;

            #endregion


            articleAddDto.ImageId = 2;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7147/api/Article");

            string jsonString = JsonConvert.SerializeObject(articleAddDto);

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Json(new { isSuccess = true });

            }

            return Json(new { isSuccess = false });

			

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
        public IActionResult Update([FromBody] ArticleUpdateDto articleUpdateDto)
        {
            articleUpdateDto.ImageId = 2;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Article/");

            string JsonString = JsonConvert.SerializeObject(articleUpdateDto);
            StringContent content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage msg = client.PutAsync(client.BaseAddress, content).Result;
            if(msg.StatusCode== System.Net.HttpStatusCode.OK)
            {
				return Json(new { isSuccess = true });
			}

            return Json(new {isSuccess = false });
            
           
        }

        
        public IActionResult Delete([FromBody]int id)
        {            

            var patchDoc = new JsonPatchDocument<ArticleSoftDeleteDto>();
            patchDoc.Replace(e => e.IsDeleted, true);

            

            HttpClient client= new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Article/SoftDelete?id="+id);
            string jsonContent = JsonConvert.SerializeObject(patchDoc);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json-patch+json");

            HttpResponseMessage msg = client.PatchAsync(client.BaseAddress, content).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
                return Json(new { isSuccess = true });

            return Json(new { isSuccess = false });

        }

        public IActionResult Details(int id)
        {
            DetailsVM _detailsVM = new DetailsVM();		        
            			

			HttpClient client = new HttpClient();

			client.BaseAddress = new Uri("https://localhost:7147/api/Article/" + id);

			HttpResponseMessage msg = client.GetAsync(client.BaseAddress).Result;

			if (msg.StatusCode == System.Net.HttpStatusCode.OK)
			{
				string jsonString = msg.Content.ReadAsStringAsync().Result;
				_detailsVM.articleGetDto = JsonConvert.DeserializeObject<ApiArticleGetDto>(jsonString);
			}

            
            _detailsVM.DetailPage = _DetailPage;
            return View(_detailsVM);

		}

        public IActionResult DeletedArticles() 
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

                _DetailPage = false;
                Listdto = JsonConvert.DeserializeObject<List<ApiArticleGetDto>>(jsonString, settings);
			}
			return View(Listdto);
		}

       
        public IActionResult Save([FromBody] int id) 
        {
            var patchDoc = new JsonPatchDocument<ArticleSaveDto>();
            patchDoc.Replace(e => e.IsDeleted, false);


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Article/Save?id="+id);
            string jsonContent = JsonConvert.SerializeObject(patchDoc);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json-patch+json");
            HttpResponseMessage msg = client.PatchAsync(client.BaseAddress, content).Result;

			if (msg.StatusCode == System.Net.HttpStatusCode.OK)
				return Json(new { isSuccess = true });

			return Json(new { isSuccess = false });


		}


        public IActionResult HardDelete([FromBody]int id) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7147/api/Article/HardDelete?id=" + id);       

            HttpResponseMessage msg = client.DeleteAsync(client.BaseAddress).Result;

            if (msg.StatusCode == System.Net.HttpStatusCode.OK)
                return Json(new { isSuccess = true });

            return Json(new { isSuccess = false });
            
        }

    }
}
