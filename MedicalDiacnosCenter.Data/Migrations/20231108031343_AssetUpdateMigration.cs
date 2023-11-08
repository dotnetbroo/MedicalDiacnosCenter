using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalDiacnosCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssetUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Assets",
                newName: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Assets",
                newName: "ImagePath");
        }
    }
}
