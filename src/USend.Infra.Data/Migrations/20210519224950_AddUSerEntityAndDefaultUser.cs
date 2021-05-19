using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace USend.Infra.Data.Migrations
{
    public partial class AddUSerEntityAndDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(100)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(100)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "BirthDate", "Cpf", "Email", "Name", "Password", "Phone" },
                values: new object[] { 1L, true, new DateTime(2021, 5, 19, 19, 49, 49, 852, DateTimeKind.Local).AddTicks(2236), "43118341017", "user@user.com", "User USend", "MzI=.k+PFvaEuLOjy/tV01s5HL5vXzDTlOEd2CgFehK3Gvx4=.vLkLe/IZCX/l7WYUt0yqilrJr4AXjQBZtfrix+YNDeA=", "11999999999" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
