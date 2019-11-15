using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.AuthenticationService.Migrations
{
    public partial class AuthenticationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    lastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    contactNumber = table.Column<long>(nullable: false),
                    registrationCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    linkedinUrl = table.Column<string>(type: "varchar(100)", nullable: true),
                    yearsOfExperience = table.Column<int>(nullable: false),
                    active = table.Column<bool>(nullable: false),
                    confirmedSignup = table.Column<bool>(nullable: false),
                    resetPasswordDate = table.Column<DateTime>(nullable: false),
                    resetPassword = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    lastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    contactNumber = table.Column<long>(nullable: false),
                    registrationCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    role = table.Column<string>(type: "varchar(1)", nullable: true),
                    linkedinUrl = table.Column<string>(type: "varchar(100)", nullable: true),
                    yearsOfExperience = table.Column<int>(nullable: false),
                    active = table.Column<bool>(nullable: false),
                    confirmedSignup = table.Column<bool>(nullable: false),
                    resetPasswordDate = table.Column<DateTime>(nullable: false),
                    resetPassword = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
