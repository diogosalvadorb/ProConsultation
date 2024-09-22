using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proconsultation.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomePaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "259cdea0-c8b1-4702-b8ff-abcab5644c7c", "AQAAAAIAAYagAAAAEJQgybpBBQaUjq1jZGu3AwWomh28AfRZvsLogj7dJTp1p+MQJcDIV6mgEMkwgZSfqw==", "5bcad1ac-d411-4a40-b968-c92a1124675b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b99aad1-5f5d-49f7-844e-0c996e0cf61d", "AQAAAAIAAYagAAAAEIQHwyrB06IdcaSuu+9EUMUh1eBrqSYdLNEnpLGOxXh/jtz/6wSSBaCjiOPncsmPKQ==", "681173fc-1760-4b42-a2b5-a49847637545" });
        }
    }
}
