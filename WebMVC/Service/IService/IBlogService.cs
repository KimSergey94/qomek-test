using WebMVC.Models.DTO;

namespace WebMVC.Service.IService
{
    public interface IBlogService
    {
        Task<ResponseDTO?> GetPostsAsync();
        Task<ResponseDTO?> CreatePost(PostRequestDTO postRequestDTO);
        Task<ResponseDTO?> EditPost(PostRequestDTO postRequestDTO);
        Task<ResponseDTO?> DeletePost(PostRequestDTO postRequestDTO);
        Task<ResponseDTO?> GetPostById(int Id);
    }
}
