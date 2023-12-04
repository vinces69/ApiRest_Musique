using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiRest_Musique_Bibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    idalbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nomalbum = table.Column<string>(type: "longtext", nullable: false),
                    decsalbum = table.Column<string>(type: "longtext", nullable: false),
                    artistealbum = table.Column<string>(type: "longtext", nullable: false),
                    groupealbum = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pochettealbum = table.Column<string>(type: "longtext", nullable: true),
                    compositeuralbum = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.idalbum);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "album");
        }
    }
}
