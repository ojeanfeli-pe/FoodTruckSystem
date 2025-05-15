# 🍔 Queijo Moreno Lanches – Sistema de Pedidos

Sistema web desenvolvido em **C# com ASP.NET Core** para gerenciamento de pedidos de um food truck.  
Permite clientes fazerem pedidos via link, operadores realizarem impressões, controle de caixa, adicionais e muito mais.

---

## 📌 Funcionalidades

- ✅ Cadastro e listagem de **clientes**, **produtos**, **adicionais**
- ✅ Montagem de pedidos com **itens, adicionais, observações**
- ✅ Cálculo automático do total com base em adicionais e taxa por bairro
- ✅ Marcar pedido para **"pagar depois"** e confirmar pagamento
- ✅ Controle de **caixa diário** (abertura, fechamento e relatório)
- ✅ Impressão em **formato térmico** do pedido
- ✅ Cadastro de **motoboys** para entregas

---

## 🚀 Como executar o projeto

### Pré-requisitos:

- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download)
- [SQLite](https://www.sqlite.org/download.html) (opcional, o EF cria o arquivo `.db`)
- [Postman](https://www.postman.com/) para testes

### Rodando localmente:

```bash
git clone https://github.com/seuusuario/QueijoMoreno.Api.git
cd QueijoMoreno.Api
dotnet restore
dotnet ef database update
dotnet run
Acesse: https://localhost:5001/swagger para explorar os endpoints.

🔗 Endpoints principais
Verbo	Rota	Descrição
POST	/api/pedido	Cria um novo pedido
GET	/api/pedido	Lista todos os pedidos
GET	/api/pedido/{id}	Retorna um pedido por ID
GET	/api/pedido/pendentes	Lista pedidos marcados para pagar depois
PUT	/api/pedido/{id}/confirmar-pagamento	Marca o pedido como pago
GET	/api/pedido/{id}/imprimir	Retorna texto pronto para impressão
POST	/api/cliente, /api/produto, /api/adicional, etc.	Cadastro de entidades
GET	/api/taxaentrega/{bairro}	Busca taxa por bairro
POST	/api/caixa/abrir	Abre o caixa do dia
PUT	/api/caixa/fechar	Fecha e calcula o total do caixa do dia

📄 Exemplo de JSON para criar um pedido
json
Copiar
Editar
{
  "clienteId": 1,
  "formaEntrega": "Entrega",
  "enderecoEntrega": "Rua das Palmeiras, 456",
  "bairro": "Centro",
  "formaPagamento": "Dinheiro",
  "pagarDepois": false,
  "itens": [
    {
      "produtoId": 1,
      "quantidade": 2,
      "observacao": "Com pouco sal",
      "adicionais": [
        { "adicionalId": 1 },
        { "adicionalId": 2 }
      ]
    }
  ]
}
🧱 Estrutura do banco (simplificada)
Cliente → Nome, telefone

Produto → Nome, categoria, preço

Adicional → Nome, preço

Pedido → Cliente, data, total, taxa, bairro

ItemPedido → Produto, quantidade, observação

ItemPedidoAdicional → Relaciona item com adicionais

Motoboy → Nome, telefone

Caixa → Valor inicial, valor final, data, pedidos

🛠️ Tecnologias utilizadas
ASP.NET Core 6 (Web API)

Entity Framework Core + SQLite

Swagger para testes de API

LINQ e Migrations

Impressão simulada com StringBuilder

🙌 Autor
Desenvolvido por Jean Moreira
📫 Contato: [jean.felipe.moreira12@gmail.com]

---
