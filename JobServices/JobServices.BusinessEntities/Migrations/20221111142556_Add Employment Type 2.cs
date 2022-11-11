using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobServices.BusinessEntities.Migrations
{
    public partial class AddEmploymentType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RCMEmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RCMEmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RCMJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    ArchiveDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ClosingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RCMEmploymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RCMJobs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RCMEmploymentTypes");

            migrationBuilder.DropTable(
                name: "RCMJobs");
        }
    }
}
