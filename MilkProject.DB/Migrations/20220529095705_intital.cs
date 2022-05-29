using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkProject.DB.Migrations
{
    public partial class intital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: true),
                    Village = table.Column<string>(maxLength: 256, nullable: false),
                    StreetName = table.Column<string>(maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DailyMilkSupply",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    MorningUnitInMilliLiter = table.Column<int>(nullable: false),
                    EveningUnitInMilliLiter = table.Column<int>(nullable: false),
                    BaseRatePerLitre = table.Column<int>(nullable: false),
                    MorningEntryTime = table.Column<DateTime>(nullable: false),
                    EveningEntryTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMilkSupply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyMilkSupply_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyMilkSupply_CustomerId",
                table: "DailyMilkSupply",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMilkSupply");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
