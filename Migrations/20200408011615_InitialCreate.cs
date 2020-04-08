using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetapp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subreddit = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Json = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Submitted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subreddit = table.Column<string>(nullable: true),
                    CommentId = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: true),
                    Json = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Submitted = table.Column<DateTime>(nullable: false),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
