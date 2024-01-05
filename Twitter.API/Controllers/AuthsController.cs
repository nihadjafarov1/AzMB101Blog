using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.Services.Interfaces;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _service { get; }

        public AuthsController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterDto dto)
        {
            await _service.RegisterAsync(dto);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
