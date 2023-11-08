using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalDiacnosCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImagePathMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "MedicalRecords");
        }
    }
}
