using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class changeproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__product__exportdetail11",
                table: "ExportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__product__importdetail",
                table: "ImportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Products_ProductId_ProviderId",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__warehouse",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__product",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ImportDetail",
                table: "ImportDetails");

            migrationBuilder.DropIndex(
                name: "IX_ImportDetails_ProductId_ProviderId",
                table: "ImportDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ExportDetail",
                table: "ExportDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExportDetails_ProductId_ProviderId",
                table: "ExportDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "Warehouses",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK__warehouse",
                table: "Warehouses",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__product",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ImportDetail",
                table: "ImportDetails",
                columns: new[] { "ImportId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__ExportDetail",
                table: "ExportDetails",
                columns: new[] { "ExportId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetails_ProductId",
                table: "ImportDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_ProductId",
                table: "ExportDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK__product__exportdetail11",
                table: "ExportDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__product__importdetail",
                table: "ImportDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Products_ProductId",
                table: "Warehouses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__product__exportdetail11",
                table: "ExportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__product__importdetail",
                table: "ImportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Products_ProductId",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__warehouse",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__product",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ImportDetail",
                table: "ImportDetails");

            migrationBuilder.DropIndex(
                name: "IX_ImportDetails_ProductId",
                table: "ImportDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ExportDetail",
                table: "ExportDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExportDetails_ProductId",
                table: "ExportDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "Warehouses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__warehouse",
                table: "Warehouses",
                columns: new[] { "ProductId", "ProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__product",
                table: "Products",
                columns: new[] { "Id", "ProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__ImportDetail",
                table: "ImportDetails",
                columns: new[] { "ImportId", "ProductId", "ProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__ExportDetail",
                table: "ExportDetails",
                columns: new[] { "ExportId", "ProductId", "ProviderId" });

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetails_ProductId_ProviderId",
                table: "ImportDetails",
                columns: new[] { "ProductId", "ProviderId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_ProductId_ProviderId",
                table: "ExportDetails",
                columns: new[] { "ProductId", "ProviderId" });

            migrationBuilder.AddForeignKey(
                name: "FK__product__exportdetail11",
                table: "ExportDetails",
                columns: new[] { "ProductId", "ProviderId" },
                principalTable: "Products",
                principalColumns: new[] { "Id", "ProviderId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__product__importdetail",
                table: "ImportDetails",
                columns: new[] { "ProductId", "ProviderId" },
                principalTable: "Products",
                principalColumns: new[] { "Id", "ProviderId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Products_ProductId_ProviderId",
                table: "Warehouses",
                columns: new[] { "ProductId", "ProviderId" },
                principalTable: "Products",
                principalColumns: new[] { "Id", "ProviderId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
