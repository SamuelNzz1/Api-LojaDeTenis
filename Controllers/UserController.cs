using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ApiLoja.Context;
using ApiLoja.Models;
using System.Threading.Tasks;
using ApiLoja.Dtos;

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

        [HttpPost("cadastro")]

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

        [HttpPost("login")]

        public async Task <IActionResult> Login(LoginDto loginDto) {
            try
            {
                if (!ModelState.IsValid) { 
                    return BadRequest(ModelState);
                }

                var userExists = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

                if (userExists == null)
                {
                    return BadRequest("Usuário não encontrado");
                }   


                if (userExists.Password != loginDto.Password)
                {
                    return BadRequest("Senha incorreta");
                }

                HttpContext.Session.SetString("UserName", userExists.UserName);

                return Ok("Usuário logado com sucesso");    






            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno no servidor. Verifique os logs para mais detalhes.");         
            }
        }

        [HttpGet("user-session")]
        public ActionResult GetUserSession()
        {
            var userName = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("Nenhuma sessão ativa.");
            }

            return Ok(new { UserName = userName });
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { message = "Sessão encerrada com sucesso." });
        }



    }
}
