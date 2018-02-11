using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace autenticacaoefcookie.Controllers 
{
    [Authorize (Roles = "Recursos Humanos")]
    public class RecursosHumanosController : Controller 
    {
        public IActionResult Index () 
        {
            return View();
        }
    }
}