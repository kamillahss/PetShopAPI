using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Web;
using UsuarioApi.Dtos;
using UsuarioApi.Models;
using UsuarioApi.Requests;

namespace UsuarioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private UserManager<Usuario> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public RegisterController(UserManager<Usuario> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            var resultIdentity = _userManager.CreateAsync(usuario, usuarioDto.Password);

            if (!resultIdentity.Result.Succeeded)
                return StatusCode(500);

            var tokenString = _userManager.GenerateEmailConfirmationTokenAsync(usuario).Result;

            var encodedTokenString = HttpUtility.UrlEncode(tokenString);

            string[] destinatarios = new string[] { usuario.Email };

            Mensagem mensagem = new Mensagem(destinatarios, "Confirmação de conta", usuario.Id, encodedTokenString);

            MimeMessage mensagemDeEmail = CriarCorpoDoEmail(mensagem);

            EnviarEmail(mensagemDeEmail);

            return Ok(new Token(tokenString));
        }


        private void EnviarEmail(MimeMessage mensagemDeEmail)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));

                    client.Send(mensagemDeEmail);

                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriarCorpoDoEmail(Mensagem mensagem)
        {
            MimeMessage mensagemDeEmail = new MimeMessage();

            mensagemDeEmail.From.Add(new MailboxAddress("PetShopFoursys", _configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatarios);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }




        [HttpGet("ativa")]
        public IActionResult Ativa([FromQuery]AtivaContaRequest request)
        {
            Usuario usuario = _userManager.Users.Where(u => u.Id == request.UsuarioId).FirstOrDefault();

            var resultIdentity = _userManager.ConfirmEmailAsync(usuario, request.CodigoDeAtivacao).Result;

            if (!resultIdentity.Succeeded)
                return StatusCode(500);

            return Ok();
        }
    }
}
