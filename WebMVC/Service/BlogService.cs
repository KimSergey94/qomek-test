using WebMVC.Models.DTO;
using WebMVC.Service.IService;
using WebMVC.Utils;

namespace WebMVC.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBaseService _baseService;

        public BlogService(IBaseService baseService)
        {
            _baseService = baseService;
        }


        public async Task<ResponseDTO?> CreatePost(PostRequestDTO postRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.BlogAPIBase + "/api/blog",
                Data = postRequestDTO
            });
        }

        public async Task<ResponseDTO?> DeletePost(PostRequestDTO postRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.BlogAPIBase + "/api/blog",
                Data = postRequestDTO
            });
        }

        public async Task<ResponseDTO?> EditPost(PostRequestDTO postRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.BlogAPIBase + "/api/blog",
                Data = postRequestDTO
            });
        }

        public async Task<ResponseDTO?> GetPostsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BlogAPIBase + "/api/blog"
            });
        }

        public async Task<ResponseDTO?> GetPostById(int Id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BlogAPIBase + $"/api/blog/{Id}"
            });
        }
    }
}
