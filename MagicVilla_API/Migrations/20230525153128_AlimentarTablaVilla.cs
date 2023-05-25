using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    public partial class AlimentarTablaVilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenURL", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[] { 1, "", "Villa del Real Madrid", new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2913), new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2895), "", 2000, "Villa Real", 100, 220.0 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenURL", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[] { 2, "", "Villa con buena vista", new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2920), new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2918), "", 200, "Villa Rica", 10, 120.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
