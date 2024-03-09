using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentNulInSellers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Department_Departmentid",
                table: "Sellers");

            migrationBuilder.AlterColumn<int>(
                name: "Departmentid",
                table: "Sellers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Department_Departmentid",
                table: "Sellers",
                column: "Departmentid",
                principalTable: "Department",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Department_Departmentid",
                table: "Sellers");

            migrationBuilder.AlterColumn<int>(
                name: "Departmentid",
                table: "Sellers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Department_Departmentid",
                table: "Sellers",
                column: "Departmentid",
                principalTable: "Department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
