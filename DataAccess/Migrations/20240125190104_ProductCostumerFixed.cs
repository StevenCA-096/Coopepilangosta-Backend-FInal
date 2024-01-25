using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductCostumerFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCostumer",
                table: "ProductCostumer");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductCostumer",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Margin",
                table: "ProductCostumer",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCostumer",
                table: "ProductCostumer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCostumer_ProductId",
                table: "ProductCostumer",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCostumer",
                table: "ProductCostumer");

            migrationBuilder.DropIndex(
                name: "IX_ProductCostumer_ProductId",
                table: "ProductCostumer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductCostumer");

            migrationBuilder.DropColumn(
                name: "Margin",
                table: "ProductCostumer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCostumer",
                table: "ProductCostumer",
                columns: new[] { "ProductId", "CostumerId" });
        }
    }
}
