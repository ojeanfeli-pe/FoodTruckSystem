using System.Security.Cryptography.X509Certificates;
namespace QueijoMoreno.Api.Models
{
    public class Motoboy 
    {
        public int Id {get;set;} // Identificador único
        public string? Nome {get;set;}  // Nome do motoboy

        public string? Telefone {get;set;} //Telefone do motoboy
        public bool Ativo { get;set; } // Indica se o motoboy está ativo ou não

    }
}