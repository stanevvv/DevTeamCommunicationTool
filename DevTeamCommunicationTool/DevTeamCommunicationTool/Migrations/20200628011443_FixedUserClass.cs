using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTeamCommunicationTool.Migrations
{
    public partial class FixedUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SentById",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "SentToId",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SentToId",
                table: "Messages",
                column: "SentToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SentById",
                table: "Messages",
                column: "SentById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SentToId",
                table: "Messages",
                column: "SentToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SentById",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SentToId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SentToId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SentToId",
                table: "Messages");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SentById",
                table: "Messages",
                column: "SentById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
