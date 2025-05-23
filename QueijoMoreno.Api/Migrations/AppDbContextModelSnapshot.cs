﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueijoMoreno.Api.Data;

#nullable disable

namespace QueijoMoreno.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("QueijoMoreno.Api.Models.Adicional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("preco")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Adicionais");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Fechado")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorFinal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorInicial")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Caixas");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.ItemPedidoAdicional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdicionalId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemPedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AdicionalId");

                    b.HasIndex("ItemPedidoId");

                    b.ToTable("ItensPedidoAdicional");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Motoboy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Motoboys");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CaixaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.Property<string>("EnderecoEntrega")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaEntrega")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaPagamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacoes")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PagarDepois")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Pago")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TaxaEntrega")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categoria")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.TaxaEntrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaxasEntrega");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.ItemPedido", b =>
                {
                    b.HasOne("QueijoMoreno.Api.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QueijoMoreno.Api.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.ItemPedidoAdicional", b =>
                {
                    b.HasOne("QueijoMoreno.Api.Models.Adicional", "Adicional")
                        .WithMany()
                        .HasForeignKey("AdicionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QueijoMoreno.Api.Models.ItemPedido", "ItemPedido")
                        .WithMany("Adicionais")
                        .HasForeignKey("ItemPedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adicional");

                    b.Navigation("ItemPedido");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Pedido", b =>
                {
                    b.HasOne("QueijoMoreno.Api.Models.Caixa", "Caixa")
                        .WithMany("Pedidos")
                        .HasForeignKey("CaixaId");

                    b.HasOne("QueijoMoreno.Api.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caixa");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Caixa", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.ItemPedido", b =>
                {
                    b.Navigation("Adicionais");
                });

            modelBuilder.Entity("QueijoMoreno.Api.Models.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
