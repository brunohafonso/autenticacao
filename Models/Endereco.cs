using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoefcookie.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        
        public string Tipo { get; set; }
        
        public string Logradouro { get; set; }
        
        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }
        
        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Endereco()
        {
            
        }

        public Endereco(string Tipo, string Logradouro, int Numero, string Complemento, string Bairro, string Cidade, string Estado)
        {
            this.Tipo = Tipo;
            this.Logradouro = Logradouro;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.Bairro = Bairro;
        }
    }
}