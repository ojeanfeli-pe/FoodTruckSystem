using System;
using System.Collections.Generic;

namespace QueijoMoreno.Api.Models
{
    public class Caixa
    {
        public int Id { get; set; }

        public DateTime Data { get; set; } = DateTime.Today; // Um caixa por dia

        public decimal ValorInicial { get; set; } // Dinheiro em caixa ao abrir
        public decimal ValorFinal { get; set; }   // Calculado ao fechar

        public bool Fechado { get; set; } = false;

        public List<Pedido>? Pedidos { get; set; } // Lista de pedidos do dia
    }
}
