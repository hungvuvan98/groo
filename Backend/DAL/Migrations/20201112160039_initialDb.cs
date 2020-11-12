using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 15, nullable: false),
                    Birthday = table.Column<DateTime>(maxLength: 30, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    ProviderId = table.Column<string>(maxLength: 10, nullable: false),
                    ProductCategoryId = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    PriceIn = table.Column<float>(nullable: false),
                    PriceOut = table.Column<float>(nullable: false),
                    PromotionPrice = table.Column<float>(nullable: true),
                    Wanrranty = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    ModifiedByUserId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product", x => new { x.Id, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exports",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    CustomerName = table.Column<string>(maxLength: 200, nullable: true),
                    CustomerPhone = table.Column<string>(maxLength: 15, nullable: true),
                    ExportDate = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalMoney = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Export", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exports_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Imports",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImportDate = table.Column<DateTime>(nullable: true),
                    TotalMoney = table.Column<float>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Import", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imports_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 10, nullable: false),
                    ToTalMoney = table.Column<float>(nullable: false),
                    Bonus = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__salary", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Salaries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 10, nullable: false),
                    RoleId = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    ProductId = table.Column<string>(maxLength: 10, nullable: false),
                    ProviderId = table.Column<string>(maxLength: 10, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__warehouse", x => new { x.ProductId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_Warehouses_Products_ProductId_ProviderId",
                        columns: x => new { x.ProductId, x.ProviderId },
                        principalTable: "Products",
                        principalColumns: new[] { "Id", "ProviderId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetails",
                columns: table => new
                {
                    ExportId = table.Column<string>(maxLength: 10, nullable: false),
                    ProductId = table.Column<string>(maxLength: 10, nullable: false),
                    ProviderId = table.Column<string>(maxLength: 10, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExportDetail", x => new { x.ExportId, x.ProductId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ExportDetails_Exports_ExportId",
                        column: x => x.ExportId,
                        principalTable: "Exports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__product__exportdetail11",
                        columns: x => new { x.ProductId, x.ProviderId },
                        principalTable: "Products",
                        principalColumns: new[] { "Id", "ProviderId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportDetails",
                columns: table => new
                {
                    ImportId = table.Column<string>(maxLength: 10, nullable: false),
                    ProviderId = table.Column<string>(maxLength: 10, nullable: false),
                    ProductId = table.Column<string>(maxLength: 10, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ImportDetail", x => new { x.ImportId, x.ProductId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ImportDetails_Imports_ImportId",
                        column: x => x.ImportId,
                        principalTable: "Imports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__product__importdetail",
                        columns: x => new { x.ProductId, x.ProviderId },
                        principalTable: "Products",
                        principalColumns: new[] { "Id", "ProviderId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_ProductId_ProviderId",
                table: "ExportDetails",
                columns: new[] { "ProductId", "ProviderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Exports_CreatedByUserId",
                table: "Exports",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetails_ProductId_ProviderId",
                table: "ImportDetails",
                columns: new[] { "ProductId", "ProviderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Imports_CreatedByUserId",
                table: "Imports",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportDetails");

            migrationBuilder.DropTable(
                name: "ImportDetails");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Exports");

            migrationBuilder.DropTable(
                name: "Imports");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
