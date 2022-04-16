using Microsoft.EntityFrameworkCore.Migrations;

namespace OdersWebApp.Migrations
{
    public partial class UsersOrderedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Username = table.Column<string>(maxLength: 25, nullable: false),
                    Program = table.Column<string>(maxLength: 65, nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerID",
                        column: x => x.UserID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                }) ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
