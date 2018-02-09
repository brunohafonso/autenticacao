using System.Linq;
using autenticacaoefcookie.Dados;
using autenticacaoefcookie.Models;

namespace autenticacaoefcookie
{
    public class IniciarBanco
    {
        public static void Inicializar(AutenticacaoContexto contexto)
        {
            contexto.Database.EnsureCreated();
            if (contexto.Usuarios.Any())
            {
                return;
            }

            var usuario = new Usuario("bruno afonso", "brunohafonso@gmail.com", "bbc259521");
            contexto.Usuarios.Add(usuario);

            var permissao = new Permissao("Adicionar");
            contexto.Permissoes.Add(permissao);

            var usuarioPermissao = new UsuarioPermissao(usuario.IdUsuario, permissao.IdPermissao);
            contexto.UsuariosPermissoes.Add(usuarioPermissao);

            contexto.SaveChanges();
        }
    }
}