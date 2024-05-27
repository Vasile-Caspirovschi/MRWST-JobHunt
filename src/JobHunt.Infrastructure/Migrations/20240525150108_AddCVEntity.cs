using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHunt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCVEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CVId",
                table: "JobSeekers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_CVId",
                table: "JobSeekers",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_CVs_CVId",
                table: "JobSeekers",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_CVs_CVId",
                table: "JobSeekers");

            migrationBuilder.DropTable(
                name: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_CVId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "JobSeekers");
        }
    }
}
