using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarVenda(Venda venda)
        {
            venda.Status = "Aguardando Pagamento";

            _context.AddRange(venda);
            _context.SaveChanges();

            return Ok(venda);
        }

        [HttpPut("{vendaId}")]
        public IActionResult AtualizarStatus(int vendaId, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(vendaId);

            if (vendaBanco == null)
            {
                return NotFound();
            }

            Console.WriteLine(vendaBanco.Status);

            vendaBanco.Status = vendaBanco.AtualizarStatus(venda.Status);

            Console.WriteLine(vendaBanco.Status);
            
            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);
        }

        [HttpGet("{vendaId}")]
        public IActionResult BuscarVenda(int vendaId)
        {
            var vendaBanco = _context.Vendas.Find(vendaId);

            if(vendaBanco == null)
            {
                return NotFound();
            }

            return Ok(vendaBanco);
        }

    }
}