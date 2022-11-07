using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobServices.BusinessEntities.Migrations
{
    public partial class UpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "RCMJobs",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RCMJobs",
                newName: "JobId");
        }
    }
}
