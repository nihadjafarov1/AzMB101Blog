using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.Dtos.CommentDtos;
using Twitter.Business.Services.Interfaces;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _service {  get; }

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }
        [HttpPost]
        public async Task<IActionResult> Post(CommentCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(dto);
        }
    }
}
