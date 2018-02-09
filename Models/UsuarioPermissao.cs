using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoefcookie.Models
{
    public class UsuarioPermissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioPermissao { get; set; }

        public int IdUsuario { get; set; }
        
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public int IdPermissao { get; set; }
        
        [ForeignKey("IdPermissao")]
        public Permissao Permissao { get; set; }
        

        public UsuarioPermissao()
        {
            
        }

        public UsuarioPermissao(int IdUsuario, int IdPermissao)
        {
            this.IdUsuario = IdUsuario;
            this.IdPermissao = IdPermissao;
        }
    }
}