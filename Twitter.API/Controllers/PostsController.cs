using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Services.Interfaces;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService _service {  get; }

        public PostsController(IPostService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostCreateDto dto)
        {
            await _service.Create(dto);
            return Ok();
        }
    }
}
