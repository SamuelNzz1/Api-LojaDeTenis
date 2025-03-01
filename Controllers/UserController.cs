using ApiLoja.Context;
using ApiLoja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

namespace ApiLoja.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        
        public UserController(AppDbContext context)
        {
            _context = context;
            
        }

        [HttpPost("cadastrar")]

        public async Task<IActionResult> Cadastrar(User user)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (user is null)
                {
                    return BadRequest("Nada foi enviado/Não foi enviado informações o suficiente");
                }

                var userExist = await _context.Users.AnyAsync(u => u.UserName == user.UserName);

                if (userExist)
                {
                    return BadRequest("O nome de usuário já existe");
                }

                var resultado = await _context.Users.AddAsync(user);
               
                await _context.SaveChangesAsync();

               
                var carrinho = new Carrinho
                {
                    UserId = resultado.Entity.UserId
                };

                await _context.Carrinhos.AddAsync(carrinho);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();


                return Ok("Usuário cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                // Log detalhado do erro
               
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor. Verifique os logs para mais detalhes.");
            }
        }



    }
}
