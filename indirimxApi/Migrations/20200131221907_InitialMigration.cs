using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace indirimxApi.Migrations
{
    public partial class InitialMigration : Migration
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
                name: "CustomUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    user_name = table.Column<string>(nullable: true),
                    user_sure_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
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
                    table.PrimaryKey("PK_ProductImages", x => x.id);
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
                    name = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    store = table.Column<string>(nullable: true),
                    like = table.Column<int>(nullable: false),
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
                        name: "FK_Products_ProductImages_imageid",
                        column: x => x.imageid,
                        principalTable: "ProductImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_CustomUsers_userid",
                        column: x => x.userid,
                        principalTable: "CustomUsers",
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
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "CustomUsers");
        }
    }
}
