using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class AddingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.InsertData(
        table: "AspNetRoles",
        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        columnTypes: new[] { "nvarchar(450)", "nvarchar(256)", "nvarchar(256)", "nvarchar(max)" },
        values: new object[] { "6D401989-2634-4F9D-B10D-1CE6CEEDB26E", "Admin", "ADMIN", null },
        schema: "dbo");

        migrationBuilder.InsertData(
        table: "AspNetRoles",
        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        columnTypes: new[] { "nvarchar(450)", "nvarchar(256)", "nvarchar(256)", "nvarchar(max)" },
        values: new object[] { "455B7622-6D9C-43EF-8840-D78FBC8DA381", "Client", "CLIENT", null },
        schema: "dbo");
        




    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
