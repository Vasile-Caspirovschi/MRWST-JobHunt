using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHunt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantIdInJobApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicantEmail",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantFullname",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantEmail",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ApplicantFullname",
                table: "JobApplications");
        }
    }
}
