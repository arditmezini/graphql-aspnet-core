using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore.GraphQL.Api.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Department",
                columns: new[] { "Id", "Location", "Number" },
                values: new object[] { 1, "Building 1, First Floor, Door 10", 101 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Department",
                columns: new[] { "Id", "Location", "Number" },
                values: new object[] { 2, "Building 1, First Floor, Door 11", 102 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Department",
                columns: new[] { "Id", "Location", "Number" },
                values: new object[] { 3, "Building 1, First Floor, Door 12", 103 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "FirstName", "HireDate", "JobTitle", "LastName" },
                values: new object[] { 1, 1, "Jan", new DateTime(2019, 9, 9, 11, 7, 22, 385, DateTimeKind.Local).AddTicks(4782), "Prof.", "Sauer" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "FirstName", "HireDate", "JobTitle", "LastName" },
                values: new object[] { 3, 1, "Henry", new DateTime(2019, 9, 9, 11, 7, 22, 387, DateTimeKind.Local).AddTicks(1525), "Ass.", "Duncan" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "FirstName", "HireDate", "JobTitle", "LastName" },
                values: new object[] { 2, 2, "Jack", new DateTime(2019, 9, 9, 11, 7, 22, 387, DateTimeKind.Local).AddTicks(1506), "Prof.", "Ford" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "dbo");
        }
    }
}
