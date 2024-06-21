using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.Migrations
{
    /// <inheritdoc />
    public partial class PizzaTopping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pizza_topping",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pizza_id = table.Column<int>(type: "int", nullable: false),
                    topping_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza_topping", x => x.id);
                    table.ForeignKey(
                        name: "FK_pizza_topping_pizzas_pizza_id",
                        column: x => x.pizza_id,
                        principalTable: "pizzas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pizza_topping_toppings_topping_id",
                        column: x => x.topping_id,
                        principalTable: "toppings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_pizza_topping_pizza_id",
                table: "pizza_topping",
                column: "pizza_id");

            migrationBuilder.CreateIndex(
                name: "IX_pizza_topping_topping_id",
                table: "pizza_topping",
                column: "topping_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pizza_topping");
        }
    }
}
