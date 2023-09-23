using BlogAPI.Models.DTO;

namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
    }

    public static class PostExtensions
    {
        public static IEnumerable<PostResponseDTO> ConvertToPostResponseDTOList(this List<Post> posts)
        {
            List<PostResponseDTO> postResponseDTOs = new List<PostResponseDTO>();
            foreach(var post in posts)
            {
                postResponseDTOs.Add(new PostResponseDTO()
                {
                    Body = post.Body,
                    Title = post.Title,
                    Id = post.Id,
                    UserId = post.UserId
                });
            }
            return postResponseDTOs;
        }
    }
}
