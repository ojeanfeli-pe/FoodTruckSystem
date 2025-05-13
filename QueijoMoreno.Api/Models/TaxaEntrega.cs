namespace QueijoMoreno.Api.Models
{
    public class TaxaEntrega
    {
        public int Id { get; set; } // Identificador da taxa

        public string? Bairro { get; set; } // Nome do bairro

        public decimal Valor { get; set; } // Valor da taxa para esse bairro

        public bool Ativo { get; set; } = true; // Permite ativar/desativar o bairro sem excluir
    }
}
