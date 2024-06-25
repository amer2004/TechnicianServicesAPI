using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalServicesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "OrderNumberSequence");

            migrationBuilder.AlterColumn<long>(
                name: "OrderNumber",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR OrderNumberSequence",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "OrderNumberSequence");

            migrationBuilder.AlterColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "NEXT VALUE FOR OrderNumberSequence");
        }
    }
}
