using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC.Models.DTO;
using WebMVC.Service.IService;

namespace WebMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            List<PostDTO> posts = new();
            ResponseDTO? result = await _blogService.GetPostsAsync();

            if (result != null && result.IsSuccess)
            {
                posts = JsonConvert.DeserializeObject<List<PostDTO>>(Convert.ToString(result.Result));
            }
            return View(posts);
        }

        public async Task<IActionResult> CreatePost()
        {
            return View();
        }

        public async Task<IActionResult> EditPost()
        {
            return View();
        }
        
    }
}
