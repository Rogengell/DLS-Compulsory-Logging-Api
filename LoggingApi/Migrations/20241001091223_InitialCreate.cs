using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoggingApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logging",
                columns: table => new
                {
                    SpanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraceId = table.Column<int>(type: "int", nullable: false),
                    ParentSpanId = table.Column<int>(type: "int", nullable: true),
                    LoggingString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logging", x => x.SpanId);
                    table.ForeignKey(
                        name: "FK_logging_logging_ParentSpanId",
                        column: x => x.ParentSpanId,
                        principalTable: "logging",
                        principalColumn: "SpanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_logging_ParentSpanId",
                table: "logging",
                column: "ParentSpanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logging");
        }
    }
}
