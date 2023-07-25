using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIReceita.Context;
using WebAPIReceita.Models;

namespace WebAPIReceita.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarPedido([FromBody] string cnpj)
        {
            // Realizar a solicitação de extração na ReceitaWS usando o CNPJ informado
            // Salvar o dado bruto no pedido

            // Exemplo de como salvar o pedido no banco de dados
            var pedido = new Pedido { CNPJ = cnpj };
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Pedido realizado com sucesso" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarResultado(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }
    }
}
