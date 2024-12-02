using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab_app_web_servidor_istea.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosMesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosMesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadosMesaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesas_EstadosMesas_EstadosMesaId",
                        column: x => x.EstadosMesaId,
                        principalTable: "EstadosMesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSector = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Sectores_IdSector",
                        column: x => x.IdSector,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Sectores_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comandas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEmpleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroEmpleado_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    EstadosPedidoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_EstadosPedidos_EstadosPedidoId",
                        column: x => x.EstadosPedidoId,
                        principalTable: "EstadosPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "IdSector", "Nombre", "Password", "RolId", "Usuario" },
                values: new object[] { 1, 0, "Enzo Francescoli", "river1", 0, "elenzo" });

            migrationBuilder.InsertData(
                table: "EstadosMesas",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "ClienteEsperandoPedido" },
                    { 2, "ClienteComiendo" },
                    { 3, "ClientePagando" },
                    { 4, "Cerrada" }
                });

            migrationBuilder.InsertData(
                table: "EstadosPedidos",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "EnPreparacion" },
                    { 3, "ListoParaServir" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Bartender" },
                    { 2, "Cervecero" },
                    { 3, "Cocinero" },
                    { 4, "Mozo" },
                    { 5, "Socio" }
                });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Barra de tragos y vinos" },
                    { 2, "Barra de choperas de cerveza artesanal" },
                    { 3, "Cocina" },
                    { 4, "Candy Bar" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "IdSector", "Nombre", "Password", "RolId", "Usuario" },
                values: new object[,]
                {
                    { 2, 1, "Angel Labruna", "river2", 1, "angelito" },
                    { 3, 2, "Marcelo Gallardo", "river3", 2, "elmunie" },
                    { 4, 3, "Norberto Alonso", "river4", 3, "elbeto" },
                    { 5, 3, "Amadeo Carrizo", "river5", 4, "elpulpo" }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "EstadosMesaId", "Nombre" },
                values: new object[,]
                {
                    { 1, 3, "Mesa101" },
                    { 2, 3, "Mesa102" },
                    { 3, 3, "Mesa104" },
                    { 4, 3, "Mesa103" },
                    { 5, 3, "Mesa201" },
                    { 6, 3, "Mesa202" },
                    { 7, 3, "Mesa203" },
                    { 8, 3, "Mesa204" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Precio", "SectorId", "Stock" },
                values: new object[,]
                {
                    { 1, "Hamburguesa Clasica", 8000m, 3, 100 },
                    { 2, "Hamburguesa Completa", 10000m, 3, 200 },
                    { 3, "Hamburguesa con Hongos", 12000m, 3, 300 },
                    { 4, "Hamburguesa Doble Carne Doble Queso", 12000m, 3, 300 },
                    { 5, "Hamburguesa BBQ", 12000m, 3, 100 },
                    { 6, "Hamburguesa Vegetariana", 9000m, 3, 500 },
                    { 7, "Nonthue Kolsch", 4500m, 2, 10 },
                    { 8, "Nonthue Bitter", 4500m, 2, 20 },
                    { 9, "Nonthue Ipa", 4500m, 2, 15 },
                    { 10, "Nonthue Porter", 4500m, 2, 10 },
                    { 11, "Patagonia Session IPA", 6000m, 2, 15 },
                    { 12, "Patagonia Vera IPA", 6000m, 2, 20 },
                    { 13, "La Vaquita Santa Julia", 16000m, 1, 5 },
                    { 14, "El Zorrito Santa Julia", 16000m, 1, 5 },
                    { 15, "Bizcocho de Chocolate", 6000m, 4, 5 },
                    { 16, "Bizcocho de Vainilla", 6000m, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MesaId",
                table: "Comandas",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdSector",
                table: "Empleados",
                column: "IdSector");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolId",
                table: "Empleados",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_EstadosMesaId",
                table: "Mesas",
                column: "EstadosMesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ComandaId",
                table: "Pedidos",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EstadosPedidoId",
                table: "Pedidos",
                column: "EstadosPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SectorId",
                table: "Productos",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEmpleado_IdEmpleado",
                table: "RegistroEmpleado",
                column: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "RegistroEmpleado");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "EstadosPedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "EstadosMesas");
        }
    }
}
