using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATTD",
                columns: table => new
                {
                    ATTD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Emp_ID = table.Column<int>(type: "int", nullable: false),
                    Holiday = table.Column<int>(type: "int", nullable: false),
                    ST = table.Column<int>(type: "time", nullable: false),
                    TR = table.Column<int>(type: "time", nullable: false),
                    nd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTD", x => x.ATTD_ID);
                    table.UniqueConstraint("AK_ATTD_Emp_ID", x => x.Emp_ID);
                });

            migrationBuilder.CreateTable(
                name: "DD",
                columns: table => new
                {
                    DD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DD", x => x.DD_ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Position_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position_ID", x => x.Position_ID);
                });

            migrationBuilder.CreateTable(
                name: "PS",
                columns: table => new
                {
                    PS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_ID = table.Column<int>(type: "int", nullable: false),
                    ATTD_ID = table.Column<int>(type: "int", nullable: false),
                    DD_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS", x => x.PS_ID);
                    table.UniqueConstraint("AK_PS_Emp_ID", x => x.Emp_ID);
                });

            migrationBuilder.CreateTable(
                name: "sys_acc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_acc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Emp_INFO",
                columns: table => new
                {
                    Emp_ID = table.Column<int>(type: "int", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    SSS_NO = table.Column<int>(type: "int", nullable: false),
                    PAGIBIG_NO = table.Column<int>(type: "int", nullable: false),
                    Position_ID = table.Column<int>(type: "int", nullable: false),
                    DD_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_INFO", x => x.Emp_ID);
                    table.ForeignKey(
                        name: "FK_Emp_INFO_ATTD",
                        column: x => x.Emp_ID,
                        principalTable: "ATTD",
                        principalColumn: "Emp_ID");
                    table.ForeignKey(
                        name: "FK_Emp_INFO_DD",
                        column: x => x.DD_ID,
                        principalTable: "DD",
                        principalColumn: "DD_ID");
                    table.ForeignKey(
                        name: "FK_Emp_INFO_Position",
                        column: x => x.Position_ID,
                        principalTable: "Position",
                        principalColumn: "Position_ID");
                    table.ForeignKey(
                        name: "FK_Emp_INFO_PS",
                        column: x => x.Emp_ID,
                        principalTable: "PS",
                        principalColumn: "Emp_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATTD",
                table: "ATTD",
                column: "Emp_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emp_INFO_DD_ID",
                table: "Emp_INFO",
                column: "DD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_INFO_Position_ID",
                table: "Emp_INFO",
                column: "Position_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PS",
                table: "PS",
                column: "Emp_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PS_1",
                table: "PS",
                column: "DD_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PS_2",
                table: "PS",
                column: "ATTD_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp_INFO");

            migrationBuilder.DropTable(
                name: "sys_acc");

            migrationBuilder.DropTable(
                name: "ATTD");

            migrationBuilder.DropTable(
                name: "DD");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "PS");
        }
    }
}
