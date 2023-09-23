using BlogAPI.Data;
using BlogAPI.Models;
using BlogAPI.Models.DTO;
using BlogAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Service
{
    public class PostHandler : IPostHandler
    {
        private readonly BlogAPIContext _db;

        public PostHandler(BlogAPIContext db)
        {
            _db = db;
        }
 
        public async Task<string> CreatePost(PostRequestDTO postRequestDTO)
        {
            try
            {
                var post = new Post()
                {
                    Title = postRequestDTO.Title,
                    Body = postRequestDTO.Body,
                    UserId = postRequestDTO.UserId,
                };
                _db.Posts.Add(post);
                await _db.SaveChangesAsync();
                return await Task.Run(() => { return ""; });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message) ? ex.InnerException.Message + "." : "";
                return await Task.Run(() => { return $"Error during saving new post to database: {ex.Message}; {innerException}"; });
            }
        }

        public async Task<string> DeletePost(PostRequestDTO postRequestDTO)
        {
            try
            {
                var post = await _db.Posts.FirstOrDefaultAsync(post => post.Id == postRequestDTO.Id);
                if (post == null) return $"Post with Id = {post.Id} not found.";
                else
                {
                    _db.Posts.Remove(post);
                    await _db.SaveChangesAsync();
                }
                return await Task.Run(() => { return ""; });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message) ? ex.InnerException.Message + "." : "";
                return await Task.Run(() => { return "Unexpected error occurred"; });
            }
        }

        public async Task<string> EditPost(PostRequestDTO postRequestDTO)
        {
            try
            {
                var post = await _db.Posts.FirstOrDefaultAsync(post => post.Id == postRequestDTO.Id);
                if (post == null) return $"Post with Id = {post.Id} not found.";
                else
                {
                    post.Body = postRequestDTO.Body;
                    post.Title = postRequestDTO.Title;
                    await _db.SaveChangesAsync();
                }
                
                return await Task.Run(() => { return ""; });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message) ? ex.InnerException.Message + "." : "";
                return await Task.Run(() => { return "Unexpected error occurred."; });

            }
        }

        public async Task<IEnumerable<PostResponseDTO>> GetPosts()
        {
            var posts = _db.Posts.ToList();
            IEnumerable<PostResponseDTO> postsResponse = new List<PostResponseDTO>();
            return await Task.Run(posts.ConvertToPostResponseDTOList);
        }
    }
}
