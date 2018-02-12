using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using autenticacaoefcookie.Dados;
using autenticacaoefcookie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace autenticacao.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        readonly AutenticacaoContexto _contexto;

        public PerfilController(AutenticacaoContexto context)
        {
            _contexto = context;
        } 
                
        public IActionResult Index() 
        {
            int Id = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
            var usuario = _contexto.Usuarios.Where(u => u.IdUsuario == Id).FirstOrDefault();
            return View(usuario);
        }
    }
}