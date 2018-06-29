using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SrsWebsite.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ShootingTypes",
                columns: table => new
                {
                    ShootingTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootingTypes", x => x.ShootingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CaliberTypes",
                columns: table => new
                {
                    CaliberTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaliberName = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaliberTypes", x => x.CaliberTypeId);
                    table.ForeignKey(
                        name: "FK_CaliberTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shootings",
                columns: table => new
                {
                    ShootingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaliberTypeId = table.Column<int>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    NumberOfShoots = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    ShootingTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shootings", x => x.ShootingId);
                    table.ForeignKey(
                        name: "FK_Shootings_CaliberTypes_CaliberTypeId",
                        column: x => x.CaliberTypeId,
                        principalTable: "CaliberTypes",
                        principalColumn: "CaliberTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shootings_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shootings_ShootingTypes_ShootingTypeId",
                        column: x => x.ShootingTypeId,
                        principalTable: "ShootingTypes",
                        principalColumn: "ShootingTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shootings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaliberTypes_UserId",
                table: "CaliberTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shootings_CaliberTypeId",
                table: "Shootings",
                column: "CaliberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shootings_PaymentTypeId",
                table: "Shootings",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shootings_ShootingTypeId",
                table: "Shootings",
                column: "ShootingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shootings_UserId",
                table: "Shootings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shootings");

            migrationBuilder.DropTable(
                name: "CaliberTypes");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "ShootingTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
