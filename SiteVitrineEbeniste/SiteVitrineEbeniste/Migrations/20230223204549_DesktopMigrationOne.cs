using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteVitrineEbeniste.Migrations
{
    public partial class DesktopMigrationOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserArticles",
                table: "UserArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserArticles",
                table: "UserArticles",
                columns: new[] { "UserId", "ArticleId", "ViewedPeriod" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "CommenterId", "ArticleId", "CommentDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserArticles",
                table: "UserArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserArticles",
                table: "UserArticles",
                columns: new[] { "UserId", "ArticleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "CommenterId", "ArticleId" });
        }
    }
}
