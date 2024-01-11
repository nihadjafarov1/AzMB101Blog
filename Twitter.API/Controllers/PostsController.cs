using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Dtos.TopicDtos;
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
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }
    }
}
