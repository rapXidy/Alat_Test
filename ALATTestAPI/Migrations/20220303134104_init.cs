using Microsoft.EntityFrameworkCore.Migrations;

namespace ALATTestAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "oTPs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otpvalue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oTPs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lGAs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lganame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stateid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lGAs", x => x.id);
                    table.ForeignKey(
                        name: "FK_lGAs_States_Stateid",
                        column: x => x.Stateid,
                        principalTable: "States",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lgaid = table.Column<int>(type: "int", nullable: true),
                    stateid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_customers_lGAs_lgaid",
                        column: x => x.lgaid,
                        principalTable: "lGAs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customers_States_stateid",
                        column: x => x.stateid,
                        principalTable: "States",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_lgaid",
                table: "customers",
                column: "lgaid");

            migrationBuilder.CreateIndex(
                name: "IX_customers_stateid",
                table: "customers",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_lGAs_Stateid",
                table: "lGAs",
                column: "Stateid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "oTPs");

            migrationBuilder.DropTable(
                name: "lGAs");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
