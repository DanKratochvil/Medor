using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitcoinAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RateCZK",
                table: "BtcRateData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateCZK",
                table: "BtcRateData");
        }
    }
}
