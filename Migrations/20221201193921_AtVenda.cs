using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techtestpaymentapi.Migrations
{
    /// <inheritdoc />
    public partial class AtVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedidos_VendaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Itens",
                table: "Pedidos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Vendas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Vendas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendaId",
                table: "Pedidos",
                column: "VendaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedidos_VendaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "Vendas");

            migrationBuilder.AddColumn<string>(
                name: "Itens",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendaId",
                table: "Pedidos",
                column: "VendaId");
        }
    }
}
