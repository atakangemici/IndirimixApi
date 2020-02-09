using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace indirimxApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    product_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    like = table.Column<string>(nullable: true),
                    product_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    sure_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    userid = table.Column<int>(nullable: true),
                    imageid = table.Column<int>(nullable: true),
                    commentid = table.Column<int>(nullable: true),
                    likeid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    store = table.Column<string>(nullable: true),
                    likes_count = table.Column<int>(nullable: false),
                    comments_count = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Comments_commentid",
                        column: x => x.commentid,
                        principalTable: "Comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Images_imageid",
                        column: x => x.imageid,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Likes_likeid",
                        column: x => x.likeid,
                        principalTable: "Likes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    productid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorites_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_productid",
                table: "Favorites",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_commentid",
                table: "Products",
                column: "commentid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_imageid",
                table: "Products",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_likeid",
                table: "Products",
                column: "likeid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_userid",
                table: "Products",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
