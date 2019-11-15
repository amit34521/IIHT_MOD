using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.TrainingService.Migrations
{
    public partial class TrainingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    TOC = table.Column<string>(type: "varchar(50)", nullable: true),
                    Prerequisites = table.Column<string>(type: "varchar(30)", nullable: true),
                    Fees = table.Column<int>(nullable: false),
                    duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(nullable: false),
                    mentorsId = table.Column<long>(nullable: false),
                    skillId = table.Column<long>(nullable: false),
                    userName = table.Column<string>(type: "varchar(100)", nullable: true),
                    mentorName = table.Column<string>(type: "varchar(100)", nullable: true),
                    skillName = table.Column<string>(type: "varchar(100)", nullable: true),
                    status = table.Column<string>(type: "varchar(1)", nullable: true),
                    progress = table.Column<int>(nullable: false),
                    rating = table.Column<float>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    startTime = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true),
                    amountReceived = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Skills_skillId",
                        column: x => x.skillId,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    resetPassword = table.Column<bool>(nullable: false),
                    TrainingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mentors_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_TrainingId",
                table: "Mentors",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_skillId",
                table: "Trainings",
                column: "skillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_userId",
                table: "Trainings",
                column: "userId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
