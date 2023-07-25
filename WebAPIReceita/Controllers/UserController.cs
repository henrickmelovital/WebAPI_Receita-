using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebAPIReceita.Context;
using WebAPIReceita.Models;
using WebAPIReceita.Services;

namespace WebAPIReceita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppDbContext _context;

        public UserController(IUserService userService, AppDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userParam)
        {
            var user = await _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Usuário ou senha inválidos" });

            return Ok(new { message = "Autenticado com sucesso" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userParam)
        {
            try
            {
                if (string.IsNullOrEmpty(userParam.Username) || string.IsNullOrEmpty(userParam.Password))
                {
                    return BadRequest(new { message = "Nome de usuário e senha são obrigatórios" });
                }

                var isRegistered = await _userService.RegisterUser(userParam);

                if (!isRegistered)
                {
                    return BadRequest(new { message = "Nome de usuário já está em uso" });
                }

                return Ok(new { message = "Usuário registrado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocorreu um erro ao registrar o usuário", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarResultado(int id)
        {
            var pedido = await _context.Users.FindAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }
    }
}
