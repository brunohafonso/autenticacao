using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoefcookie.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 4)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(12, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        [Required]
        [StringLength(9, MinimumLength=7)]
        public string RF { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength=1)]
        public int Vinculo { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength=4)]
        public string Cargo { get; set; }
        
        [Required]
        [StringLength(13, MinimumLength=9)]
        public string RG { get; set; }
        
        [Required]
        [StringLength(15, MinimumLength=11)]
        public string CPF { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength=4)]
        public string EstadoCivil { get; set; }
        
        [Required]
        [StringLength(15, MinimumLength=8)]
        public string Telefone { get; set; }
        
        [Required]
        public Endereco Endereco { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength=4)]
        public string UnidadeDeLotacao { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength=4)]
        public string UnidadeDeExercicio { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }
        
        public ICollection<UsuarioPermissao> UsuarioPermissoes { get; set; }
        
        public Usuario()
        {

        }

        public Usuario(string Nome, string Email, string Senha, string RF, int Vinculo, string Cargo, string RG, string CPF, string EstadoCivil, string Telefone, DateTime DataNascimento, Endereco Endereco, string UnidadeDeExercicio, string UnidadeDeLotacao)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
            this.RF = RF;
            this.Vinculo = Vinculo;
            this.Cargo = Cargo;
            this.RG = RG;
            this.CPF = CPF;
            this.EstadoCivil = EstadoCivil;
            this.Telefone = Telefone;
            this.DataNascimento = DataNascimento;
            this.Endereco = Endereco;
            this.UnidadeDeExercicio = UnidadeDeExercicio;
            this.UnidadeDeLotacao = UnidadeDeLotacao;
        }
    }
}