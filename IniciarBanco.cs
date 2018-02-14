using System;
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

            var usuario = new Usuario("bruno afonso", "brunohafonso@gmail.com", "bbc259521", "828.720.1", 1, "Aux. Técnico de Educação", "48.976.343.1", "440.630.768.06", "Solteiro", "(11) 94855-2364", DateTime.Parse("25/04/1995"), new Endereco("Rua do Capitarizinho", 33, "Casa 05", "Vila Liviero", "São Paulo", "SP"), "Cei Jardim Climax II", "Cei Jardim Climax II");
            usuario.Endereco.IdUsuario = usuario.IdUsuario;
            contexto.Usuarios.Add(usuario);

            var permissao = new Permissao("Financeiro");
            contexto.Permissoes.Add(permissao);

            var usuarioPermissao = new UsuarioPermissao(usuario.IdUsuario, permissao.IdPermissao);
            contexto.UsuariosPermissoes.Add(usuarioPermissao);

            contexto.SaveChanges();
        }
    }
}