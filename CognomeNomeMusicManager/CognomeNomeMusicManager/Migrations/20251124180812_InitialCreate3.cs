using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CognomeNomeMusicManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etichetta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    SedeLegale = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etichetta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Festival",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festival", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cantante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeArte = table.Column<string>(type: "TEXT", nullable: false),
                    NomeReale = table.Column<string>(type: "TEXT", nullable: false),
                    EtichettaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cantante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cantante_Etichetta_EtichettaId",
                        column: x => x.EtichettaId,
                        principalTable: "Etichetta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abilità",
                columns: table => new
                {
                    StrumentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Livello = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilità", x => new { x.StrumentoId, x.CantanteId });
                    table.ForeignKey(
                        name: "FK_Abilità_Cantante_CantanteId",
                        column: x => x.CantanteId,
                        principalTable: "Cantante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abilità_Strumento_StrumentoId",
                        column: x => x.StrumentoId,
                        principalTable: "Strumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Esibizione",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    VotiGiuria = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdineUscita = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esibizione", x => new { x.FestivalId, x.CantanteId });
                    table.ForeignKey(
                        name: "FK_Esibizione_Cantante_CantanteId",
                        column: x => x.CantanteId,
                        principalTable: "Cantante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Esibizione_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilità_CantanteId",
                table: "Abilità",
                column: "CantanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abilità_StrumentoId",
                table: "Abilità",
                column: "StrumentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cantante_EtichettaId",
                table: "Cantante",
                column: "EtichettaId");

            migrationBuilder.CreateIndex(
                name: "IX_Esibizione_CantanteId",
                table: "Esibizione",
                column: "CantanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilità");

            migrationBuilder.DropTable(
                name: "Esibizione");

            migrationBuilder.DropTable(
                name: "Strumento");

            migrationBuilder.DropTable(
                name: "Cantante");

            migrationBuilder.DropTable(
                name: "Festival");

            migrationBuilder.DropTable(
                name: "Etichetta");
        }
    }
}
