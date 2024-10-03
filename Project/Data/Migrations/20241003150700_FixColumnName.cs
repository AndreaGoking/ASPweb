using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaiId",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "SanPham",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "TheLoaiId",
                table: "SanPham",
                newName: "TheLoaild");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_TheLoaiId",
                table: "SanPham",
                newName: "IX_SanPham_TheLoaild");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TheLoai",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaild",
                table: "SanPham",
                column: "TheLoaild",
                principalTable: "TheLoai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaild",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "SanPham",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "TheLoaild",
                table: "SanPham",
                newName: "TheLoaiId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_TheLoaild",
                table: "SanPham",
                newName: "IX_SanPham_TheLoaiId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TheLoai",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_TheLoai_TheLoaiId",
                table: "SanPham",
                column: "TheLoaiId",
                principalTable: "TheLoai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
