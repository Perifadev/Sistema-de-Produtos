using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Produtos.Model
{
    public class Produtos
    {
       
        public int Id { get; set; }
        public string? Nome { get; set; }

        public double Preco { get; set; }
    }
}
