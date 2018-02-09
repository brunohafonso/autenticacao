using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoefcookie.Models
{
    public class Permissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermissao { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nome { get; set; }

        public Permissao()
        {
            
        }

        public Permissao(string Nome)
        {
            this.Nome = Nome;
        }
        
    }
}