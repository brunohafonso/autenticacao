using System;
using autenticacaoefcookie.Dados;
using autenticacaoefcookie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace autenticacaoefcookie.Controllers 
{
    public class ContaController : Controller 
    {
        readonly AutenticacaoContexto _contexto;

        public ContaController (AutenticacaoContexto context) 
        {
            _contexto = context;
        }

        [HttpGet]
        public IActionResult Login () 
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction ("Index", "Financeiro");
            } else {
                return View ();
            }
        }

        [HttpPost]
        public IActionResult Login (Usuario usuario)
        {
            try 
            {
                Usuario user = _contexto.Usuarios.Include ("UsuarioPermissoes").Include ("UsuarioPermissoes.Permissao").FirstOrDefault (c => c.Email == usuario.Email && c.Senha == usuario.Senha);
                if (user != null) 
                {
                    var claims = new List<Claim> ();

                    claims.Add (new Claim (ClaimTypes.Email, user.Email));
                    claims.Add (new Claim (ClaimTypes.Name, user.Nome));
                    claims.Add (new Claim (ClaimTypes.Sid, user.IdUsuario.ToString ()));
                    foreach (var item in user.UsuarioPermissoes) 
                    {
                        claims.Add (new Claim (ClaimTypes.Role, item.Permissao.Nome));
                    }

                    var claimIdentity = new ClaimsIdentity (
                        claims, CookieAuthenticationDefaults.AuthenticationScheme
                    );

                    HttpContext.SignInAsync (CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal (claimIdentity));

                    return RedirectToAction ("Index", "Financeiro");
                }

                return View (usuario);
            } catch (System.Exception) 
            {
                return View (usuario);
            }
        }

        public IActionResult Logout () 
        {
            HttpContext.SignOutAsync (CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction ("Login");
        }
    }
}