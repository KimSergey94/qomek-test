using BlogAPI.Models.DTO;
using BlogAPI.Service;
using BlogAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogAPIController : ControllerBase
    {
        private readonly IPostHandler _postHandler;
        protected ResponseDTO _response;

        public BlogAPIController(IPostHandler postHandler) 
        {
            _postHandler = postHandler;
            _response = new();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postHandler.GetPosts();
            _response.Result = posts;
            return Ok(_response);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postHandler.GetPostById(id);
            _response.Result = post;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostRequestDTO model)
        {
            var errorMessage = await _postHandler.CreatePost(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> EditPost([FromBody] PostRequestDTO model)
        {
            var errorMessage = await _postHandler.EditPost(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromBody] PostRequestDTO model)
        {
            var errorMessage = await _postHandler.DeletePost(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
