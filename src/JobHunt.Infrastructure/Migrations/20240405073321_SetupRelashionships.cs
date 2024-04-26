using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHunt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetupRelashionships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobCategories_JobCategoryId",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobCategoryId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                table: "JobPosts");

            migrationBuilder.AddColumn<Guid>(
                name: "JobPostId",
                table: "JobCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_JobPostId",
                table: "JobCategories",
                column: "JobPostId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCategories_JobPosts_JobPostId",
                table: "JobCategories",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCategories_JobPosts_JobPostId",
                table: "JobCategories");

            migrationBuilder.DropIndex(
                name: "IX_JobCategories_JobPostId",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "JobPostId",
                table: "JobCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "JobCategoryId",
                table: "JobPosts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobCategoryId",
                table: "JobPosts",
                column: "JobCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobCategories_JobCategoryId",
                table: "JobPosts",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
