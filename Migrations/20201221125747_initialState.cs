using Microsoft.EntityFrameworkCore.Migrations;

namespace com_parsan_student.Migrations
{
    public partial class initialState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Family", "Name" },
                values: new object[,]
                {
                    { 4, "khalili", "StudentMahdi" },
                    { 1, "Alavi", "Ali" },
                    { 2, "Mohammadi", "Mohammad" },
                    { 3, "Mahmoodi", "Hadi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
