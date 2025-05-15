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
