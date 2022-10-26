using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Author = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 1, "Halloweenie Parties" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 2, "Video Gaymezzzzz" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 3, "Locate the PSL goodies" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Author", "Body", "Date", "GroupId", "Title" },
                values: new object[,]
                {
                    { 1, "GhostiniLinguini", "I'm looking for the spookiest party of all, please help???", new DateTime(2006, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Scary Party???" },
                    { 2, "NoScariesPlease", "I hate ghosts!!!  I want to go to a halloween party but if I see a ghost I'll p** my pants, please don't recommend parties w/ ghosts", new DateTime(2010, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "No ghosts please" },
                    { 5, "WitchyTwitchy123", "I'm looking for a magician that serves alchemical potions for all my spooky spells.", new DateTime(1700, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Magical Drinks Needed!" },
                    { 3, "DewForMeAndU", "Holy CRUD I love gaming, particularly as a non-heterosexual/non-binary person.  It RULES!!!  I love Mountain Dew, also (unrelated).", new DateTime(2003, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Gaming!!!!" },
                    { 4, "DewForMeAndU", "It's been ten years and I'm still gaming.  Darn, it still rules so hard.  Still not straight btw.", new DateTime(2013, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "GAMING!!!!" },
                    { 6, "PSLlov3rkissessxoxo", "I'm looking for the best Trader Joe's PSL treats. Please Help!!", new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Trader Joes PSL?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
