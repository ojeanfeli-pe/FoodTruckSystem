namespace QueijoMoreno.Api.Models
{
    public class Adicional 
    {
        public int Id { get; set; } // Identificador único
        public string? Nome { get; set; }  // Nome do adicional (ex: bacon, ovo)
        public decimal Preco { get; set; }  // Preço do adicional
        public bool Ativo { get; set; } = true; // Pode ser ativado/desativado
    }
}