using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_3.Migrations
{
    /// <inheritdoc />
    public partial class MovieFranchiseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FranchiseId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Franchise_FranchiseId",
                table: "Movie",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Franchise_FranchiseId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Movie");
        }
    }
}
