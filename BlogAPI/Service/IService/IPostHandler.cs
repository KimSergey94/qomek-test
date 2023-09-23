using BlogAPI.Models;
using BlogAPI.Models.DTO;

namespace BlogAPI.Service.IService
{
    public interface IPostHandler
    {
        Task<IEnumerable<PostResponseDTO>> GetPosts();
        Task<string> CreatePost(PostRequestDTO postRequestDTO);
        Task<string> EditPost(PostRequestDTO postRequestDTO);
        Task<string> DeletePost(PostRequestDTO postRequestDTO);
    }
}