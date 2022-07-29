using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Products.DataAccessLayer.Migrations
{
    public partial class initPro001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    PermaLink = table.Column<string>(type: "text", nullable: false, defaultValue: "http://www.msn.com"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    BannerUrl = table.Column<string>(type: "character varying(550)", maxLength: 550, nullable: false, defaultValue: "https://via.placeholder.com/350"),
                    IconUrl = table.Column<string>(type: "character varying(550)", maxLength: 550, nullable: false, defaultValue: "https://via.placeholder.com/850x350"),
                    ThumbnailUrl = table.Column<string>(type: "character varying(550)", maxLength: 550, nullable: false, defaultValue: "https://via.placeholder.com/300x100"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titile = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    PermaLink = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, defaultValue: "http://www.google.com"),
                    CoverImageUrl = table.Column<string>(type: "text", nullable: false, defaultValue: "https://via.placeholder.com/450x150"),
                    Price = table.Column<decimal>(type: "numeric", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerUrl", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IconUrl", "IsActive", "ParentCategoryId", "PermaLink", "Priority", "ThumbnailUrl", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1L, "https://via.placeholder.com/350x50", 0L, new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(6100), 0L, null, "CatDesc001", "https://via.placeholder.com/400x200", true, 1L, "http://wwww.microsoft.com", 0, "https://via.placeholder.com/150x250", "Cat001", 0L, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerUrl", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IconUrl", "IsActive", "ParentCategoryId", "PermaLink", "Priority", "ThumbnailUrl", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2L, "https://via.placeholder.com/8500x600", 0L, new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(6160), 0L, null, "CatDesc002", "https://via.placeholder.com/600x400", true, 1L, "http://wwww.mymap.com", 0, "https://via.placeholder.com/950x650", "Cat002", 0L, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "CoverImageUrl", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "PermaLink", "Price", "Titile", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1L, 1L, "https://via.placeholder.com/550x350", "https://via.placeholder.com/550x350", 0L, new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(8080), 0L, null, "Description001", "http://www.google.com", 1000m, "Title001", 0L, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "CoverImageUrl", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsActive", "PermaLink", "Price", "Titile", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2L, 1L, "https://via.placeholder.com/200x100", "https://via.placeholder.com/200x100", 0L, new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(8090), 0L, null, "Description002", true, "http://www.yahoo.com", 205m, "Title002", 0L, null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
