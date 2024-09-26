using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCodeFirstTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Authors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        LastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
            //        Bio = table.Column<string>(type: "nchar(250)", fixedLength: true, maxLength: 250, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Authors__3214EC07CF34E876", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "CodeFirstTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeFirstTables", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Year = table.Column<int>(type: "int", nullable: true),
            //        ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Summary = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
            //        AuthorId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Books__3214EC07215A2322", x => x.Id);
            //        table.ForeignKey(
            //            name: "Author_Book_FK",
            //            column: x => x.AuthorId,
            //            principalTable: "Authors",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Books_AuthorId",
            //    table: "Books",
            //    column: "AuthorId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Books__447D36EABB67EC95",
            //    table: "Books",
            //    column: "ISBN",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Books");

            migrationBuilder.DropTable(
                name: "CodeFirstTables");

            //migrationBuilder.DropTable(
            //    name: "Authors");
        }
    }
}
