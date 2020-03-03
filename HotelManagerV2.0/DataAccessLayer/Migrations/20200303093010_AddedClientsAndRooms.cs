using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddedClientsAndRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    AdultPrice = table.Column<double>(nullable: false),
                    ChildPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
