using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Seedingdata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a18ac75-cb20-46be-bf19-f151cb966658");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29420ee1-4ce9-4b40-a73b-b7f4d8b12466", 0, "411315b0-2068-45a4-8bcc-6198b4a44bae", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEMRZTZlVbqK7JW+FxDmdxl79PIAX5aMS55proHGXTeWM86w1azyqerEf3EOjPZEGMA==", null, false, "759a2e3b-3a23-44d9-8dd8-7846def1e126", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29420ee1-4ce9-4b40-a73b-b7f4d8b12466");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9a18ac75-cb20-46be-bf19-f151cb966658", 0, "8e1e62dd-6720-44bb-a5fe-787cad81da01", "admin@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAxqc+TDPsnlxUNfLsOBz6yFY/3XbmoDry+N/HKVg9N1BvZgJL1scE6Sp6Mx/aQ0Dg==", null, false, "f794a2c2-c704-4307-8d74-2dc2e1bcbaad", false, "admin" });
        }
    }
}
