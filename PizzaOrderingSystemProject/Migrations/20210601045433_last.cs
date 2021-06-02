using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaOrderingSystemProject.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_CustomerDetails_DetailsId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pizzas_PizzaId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DetailsId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PizzaId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DetailsId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CustomerDetails",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PizzaId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DetailsId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "CustomerDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DetailsId",
                table: "Order",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PizzaId",
                table: "Order",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CustomerDetails_DetailsId",
                table: "Order",
                column: "DetailsId",
                principalTable: "CustomerDetails",
                principalColumn: "DetailsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pizzas_PizzaId",
                table: "Order",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "PizzaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
