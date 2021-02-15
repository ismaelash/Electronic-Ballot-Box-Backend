using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class change_language : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Voto");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCandidate = table.Column<string>(type: "varchar(255)", nullable: false),
                    NameViceCandidate = table.Column<string>(type: "varchar(255)", nullable: false),
                    DataCreation = table.Column<DateTime>(type: "datetime", nullable: false),
                    Legend = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    DatetimeVote = table.Column<DateTime>(type: "datetime", nullable: false),
                    Legend = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Image = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    Legenda = table.Column<int>(type: "int", nullable: false),
                    NomeCandidato = table.Column<string>(type: "varchar(255)", nullable: false),
                    NomeVice = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVoto = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdCandidato = table.Column<int>(type: "int", nullable: false),
                    NumeroLegenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voto", x => x.Id);
                });
        }
    }
}
