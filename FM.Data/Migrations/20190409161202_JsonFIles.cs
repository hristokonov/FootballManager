using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FM.Data.Migrations
{
    public partial class JsonFIles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    Country = table.Column<string>(maxLength: 30, nullable: false),
                    Capacity = table.Column<int>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    Country = table.Column<string>(maxLength: 30, nullable: true),
                    Owner = table.Column<string>(maxLength: 30, nullable: true),
                    Budget = table.Column<decimal>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    GoalsScored = table.Column<int>(nullable: false),
                    GoalsConcede = table.Column<int>(nullable: false),
                    GoalDifference = table.Column<int>(nullable: false),
                    LeagueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(maxLength: 30, nullable: false),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeTeamId = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    IsMatchPlayed = table.Column<bool>(nullable: false),
                    HomeTeamGoals = table.Column<int>(nullable: false),
                    AwayTeamGoals = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StadiumId = table.Column<int>(nullable: false),
                    LeagueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(maxLength: 30, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Premier" },
                    { 2, "Primera" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Goalkeeper" },
                    { 2, "Defender" },
                    { 3, "Midfielder" },
                    { 4, "Striker" }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Capacity", "City", "Country", "Name" },
                values: new object[,]
                {
                    { 1, 45000, "Sofia", "Bulgaria", "Vasil Levski" },
                    { 2, 15000, "Blagoevgrad", "Bulgaria", "Hristo Botev" },
                    { 3, 75000, "London", "England", "Wembly" },
                    { 4, 75000, "Madrid", "Spain", "Bernabeu" },
                    { 5, 90000, "Barcelona", "Spain", "Knou Camp" },
                    { 6, 50000, "Torino", "Italy", "Juventus Stadium" },
                    { 7, 65000, "Munchen", "Germany", "Alianz Arena" },
                    { 8, 60000, "Instambul", "Turkey", "Ataturk" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Budget", "City", "Country", "GoalDifference", "GoalsConcede", "GoalsScored", "LeagueId", "Name", "Owner", "Points" },
                values: new object[,]
                {
                    { 1, 5000000m, "Sofia", "Bulgaria", 0, 0, 0, 1, "Cunami", "Hristo Konov", 0 },
                    { 2, 5000000m, "Stara Zagora", "Bulgaria", 0, 0, 0, 1, "Athletic SMU", "Petar Botev", 0 },
                    { 3, 5000000m, "Blagoevgrad", "Bulgaria", 0, 0, 0, 1, "Pirin", "Dimitar Georgiev", 0 },
                    { 4, 5000000m, "Sofia", "Bulgaria", 0, 0, 0, 1, "Levski", "Nasko Sirakov", 0 },
                    { 5, 5000000m, "Sofia", "Bulgaria", 0, 0, 0, 1, "CSKA", "Hristo Stoichkov", 0 },
                    { 6, 5000000m, "Razgrad", "Bulgaria", 0, 0, 0, 1, "Ludogorez", "Kiril Domuschiev", 0 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FirstName", "LastName", "Nationality", "TeamId" },
                values: new object[,]
                {
                    { 1, "Hristo", "Konov", "Bulgarian", 1 },
                    { 3, "Dimitar", "Georgiev", "Bulgarian", 3 },
                    { 5, "Hristo", "Stoichkov", "Bulgarian", 5 },
                    { 2, "Petar", "Botev", "Bulgarian", 2 },
                    { 6, "Dimitar", "Dimitrov", "Bulgarian", 6 },
                    { 4, "Nasko", "Sirakov", "Bulgarian", 4 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "Nationality", "PositionId", "Price", "Rating", "TeamId" },
                values: new object[,]
                {
                    { 30, "Mladen", false, "Yordanov", "Bulgarian", 4, 950000m, 95, 5 },
                    { 32, "Kozmin", false, "Mozi", "Romanina", 2, 800000m, 80, 6 },
                    { 29, "Valentin", false, "Yordanov", "Bulgarian", 3, 1000000m, 100, 5 },
                    { 28, "Ivan", false, "Todorov", "Bulgarian", 3, 600000m, 60, 5 },
                    { 19, "Dimitar", false, "Ivankov", "Bulgarian", 1, 900000m, 90, 4 },
                    { 26, "Georgi", false, "Bodurov", "Bulgarian", 2, 650000m, 65, 5 },
                    { 25, "Teodosii", false, "Ivankov", "Bulgarian", 1, 500000m, 50, 5 },
                    { 33, "Tervel", false, "Pulev", "Bulgarian", 2, 600000m, 60, 6 },
                    { 34, "Kubrat", false, "Pulev", "Bulgarian", 3, 800000m, 80, 6 },
                    { 24, "Georgi", false, "Ivanov", "Bulgarian", 4, 950000m, 95, 4 },
                    { 23, "Dimitar", false, "Mihov", "Bulgarian", 3, 900000m, 90, 4 },
                    { 22, "Ivo", false, "Dilov", "Bulgarian", 3, 400000m, 40, 4 },
                    { 21, "Filip", false, "Todorov", "Bulgarian", 2, 700000m, 70, 4 },
                    { 20, "Stanimir", false, "Stoilov", "Bulgarian", 2, 740000m, 74, 4 },
                    { 31, "Ivan", false, "Kirqkov", "Bulgarian", 1, 900000m, 90, 6 },
                    { 27, "Daniel", false, "Petrov", "Bulgarian", 2, 400000m, 40, 5 },
                    { 18, "Stefan", false, "Yordanov", "Bulgarian", 4, 910000m, 91, 3 },
                    { 17, "Nikolay", false, "Tenev", "Bulgarian", 3, 740000m, 74, 3 },
                    { 1, "Dimitar", false, "Georgiev", "Bulgarian", 1, 900000m, 90, 1 },
                    { 2, "Hristo", false, "Konov", "Bulgarian", 2, 1000000m, 100, 1 },
                    { 3, "Todor", false, "Todorov", "Bulgarian", 2, 800000m, 80, 1 },
                    { 4, "Yordan", false, "Konov", "Bulgarian", 3, 1000000m, 100, 1 },
                    { 5, "Cvetan", false, "Konov", "Bulgarian", 3, 900000m, 90, 1 },
                    { 6, "Borislav", false, "Stoimenov", "Bulgarian", 4, 1000000m, 100, 1 },
                    { 7, "Petar", false, "Botev", "Bulgarian", 4, 1000000m, 100, 2 },
                    { 35, "Georgi", false, "Yordanov", "Bulgarian", 3, 900000m, 90, 6 },
                    { 8, "Stefan", false, "Georgiev", "Bulgarian", 1, 900000m, 90, 2 },
                    { 10, "Teodor", false, "Todorov", "Bulgarian", 2, 800000m, 80, 2 },
                    { 11, "Ivan", false, "Konov", "Bulgarian", 3, 1000000m, 100, 2 },
                    { 12, "Kiril", false, "Konov", "Bulgarian", 3, 850000m, 85, 2 },
                    { 13, "Tedi", false, "Salparov", "Bulgarian", 1, 700000m, 70, 3 },
                    { 14, "Shefket", false, "Islqmov", "Bulgarian", 2, 700000m, 70, 3 },
                    { 15, "Tihomir", false, "Todorov", "Bulgarian", 2, 840000m, 84, 3 },
                    { 16, "Kiril", false, "Stanoev", "Bulgarian", 3, 1000000m, 100, 3 },
                    { 9, "Georgi", false, "Konov", "Bulgarian", 2, 1000000m, 100, 2 },
                    { 36, "Mladen", false, "Stefanov", "Bulgarian", 4, 760000m, 76, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_TeamId",
                table: "Managers",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LeagueId",
                table: "Matches",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StadiumId",
                table: "Matches",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
