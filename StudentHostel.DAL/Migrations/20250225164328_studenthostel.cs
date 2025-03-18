using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentHostel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class studenthostel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Image",
                table: "apartments");

            migrationBuilder.AddColumn<byte[]>(
                name: "Apartment_Image",
                table: "apartments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apartment_Image",
                table: "apartments");

            migrationBuilder.AddColumn<string>(
                name: "Location_Image",
                table: "apartments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
