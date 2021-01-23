using System;
using AuthJwt.Repository;
using AuthJWT.Models;
using AuthJWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWT.Controllers
{
  [ApiController]
  [Route("v1/account")]
  public class HomeController : ControllerBase
  {
    [HttpPost]
    [Route("login")]
    public ActionResult<dynamic> Authenticate([FromBody] User model)
    {
      var user = UserRepository.GetUser(model.Username, model.Password);

      if (user == null)
        return NotFound(new { message = "Usuário ou senha inválidos" });

      /* Gera o Token */
      var token = TokenService.GenerateToken(user);

      /* Oculta a senha */
      user.Password = "";

      return new 
      {
        user = user,
        token = token
      };
    }

    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee,manager")]
    public string Employee() => "Empregado";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => "Gerente";
  }
}