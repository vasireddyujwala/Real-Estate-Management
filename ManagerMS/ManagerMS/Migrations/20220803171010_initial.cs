using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerMS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignExecutives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    ExecutiveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignExecutives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Executives",
                columns: table => new
                {
                    ExecutiveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    Locality = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executives", x => x.ExecutiveId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignExecutives");

            migrationBuilder.DropTable(
                name: "Executives");
        }
    }
}
