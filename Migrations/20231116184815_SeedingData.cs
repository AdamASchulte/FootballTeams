using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballTeams.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "State" },
                values: new object[,]
                {
                    { new Guid("29422329-769d-4b8b-a106-b0237bd9a688"), "Cincinnati", "Ohio" },
                    { new Guid("64e36144-ff33-4ff0-b3d9-caf5fb09993b"), "New Orleans", "Louisiana" },
                    { new Guid("7d0e3e10-3c79-4273-9687-e18f004e2795"), "Dallas", "Texas" },
                    { new Guid("a7409d89-7f0a-44e0-880d-492dc1fc2d56"), "Foxborough", "Massachusetts" }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "MaxCapacity" },
                values: new object[,]
                {
                    { new Guid("53b635bd-fb4e-452e-8d3c-cdc35714dc50"), 76468 },
                    { new Guid("6f50bc14-f67d-4fa5-a778-bb7b8a4b687d"), 65515 },
                    { new Guid("83c59f7c-45e9-4f64-b0a0-2a46c649ea36"), 80000 },
                    { new Guid("b534c9e0-b131-4d66-950d-33fa57013afe"), 64628 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "DefensiveCoordinator", "HeadCoach", "OffensiveCoordinator", "SpecialTeamsCoordinator" },
                values: new object[,]
                {
                    { new Guid("1e5e3acc-21d5-450e-9a41-3e9fc83736bd"), "Jerod Mayo", "Bill Belichick", "Bill O'Brien", "Cameron Achord" },
                    { new Guid("40610af7-d116-46ec-9c78-0bdc81e0d251"), "Lou Anarumo", "Zac Taylor", "Brian Callahan", "Darrin Simmons" },
                    { new Guid("71da77c5-b700-4ada-8fec-ddbfb6686c96"), "Dan Quinn", "Mike McCarthy", "Brain Schottenheimer", "John Fassel" },
                    { new Guid("7b5cd5cb-4a2b-4a75-a73e-df2eaa3b3645"), "Joe Woods", "Dennis Allen", "Pete Carmichael Jr.", "Darren Rizzi" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LocationId", "Mascot", "Name", "OwnerName", "StadiumId", "StaffId" },
                values: new object[,]
                {
                    { new Guid("03d5a0cf-f03f-4226-adeb-6de9650ba333"), new Guid("7d0e3e10-3c79-4273-9687-e18f004e2795"), "Rowdy", "Dallas Cowboys", "Jerry Jones", new Guid("83c59f7c-45e9-4f64-b0a0-2a46c649ea36"), new Guid("71da77c5-b700-4ada-8fec-ddbfb6686c96") },
                    { new Guid("943b80ff-58d0-4d6b-9df8-e30191fc8b6a"), new Guid("64e36144-ff33-4ff0-b3d9-caf5fb09993b"), "Sir Saint", "New Orleans Saints", "Gayle Benson", new Guid("53b635bd-fb4e-452e-8d3c-cdc35714dc50"), new Guid("7b5cd5cb-4a2b-4a75-a73e-df2eaa3b3645") },
                    { new Guid("a750738e-3f01-4474-8cb9-aca46f6d2290"), new Guid("a7409d89-7f0a-44e0-880d-492dc1fc2d56"), "Pat Patriot", "New England Patriots", "Robert Kraft", new Guid("b534c9e0-b131-4d66-950d-33fa57013afe"), new Guid("1e5e3acc-21d5-450e-9a41-3e9fc83736bd") },
                    { new Guid("a94c19d6-b630-4a98-8c1b-8296786268c3"), new Guid("29422329-769d-4b8b-a106-b0237bd9a688"), "Who Dey", "Cincinnati Bengals", "Michael Brown", new Guid("6f50bc14-f67d-4fa5-a778-bb7b8a4b687d"), new Guid("40610af7-d116-46ec-9c78-0bdc81e0d251") }
                });

            migrationBuilder.InsertData(
                table: "TeamStats",
                columns: new[] { "Id", "Losses", "Season", "TeamId", "Wins" },
                values: new object[,]
                {
                    { new Guid("583698ac-ebc9-4343-83f6-a2f2f4daf0c0"), 4, 2022, new Guid("a94c19d6-b630-4a98-8c1b-8296786268c3"), 12 },
                    { new Guid("5b48a1db-15f4-4de8-b533-82a0a1404c0d"), 8, 2021, new Guid("943b80ff-58d0-4d6b-9df8-e30191fc8b6a"), 9 },
                    { new Guid("645cdff2-a5e4-4f45-a66a-3e5f51864bdd"), 7, 2021, new Guid("a94c19d6-b630-4a98-8c1b-8296786268c3"), 10 },
                    { new Guid("73434893-0bb0-49e4-abf3-43bdddeb0120"), 9, 2022, new Guid("a750738e-3f01-4474-8cb9-aca46f6d2290"), 8 },
                    { new Guid("767fee9d-01db-4f12-9149-f48416d8fa12"), 10, 2020, new Guid("03d5a0cf-f03f-4226-adeb-6de9650ba333"), 6 },
                    { new Guid("a1fba9fd-dff0-43ab-a982-df02b6ef13f6"), 11, 2020, new Guid("a94c19d6-b630-4a98-8c1b-8296786268c3"), 4 },
                    { new Guid("acabe807-0b9e-4a53-8146-739f4b31529e"), 10, 2022, new Guid("943b80ff-58d0-4d6b-9df8-e30191fc8b6a"), 7 },
                    { new Guid("be573535-c72a-416d-a890-d8368b74cbdb"), 4, 2020, new Guid("943b80ff-58d0-4d6b-9df8-e30191fc8b6a"), 12 },
                    { new Guid("ec0b8ebd-fd38-4aab-85f7-ca8ef5f83646"), 9, 2020, new Guid("a750738e-3f01-4474-8cb9-aca46f6d2290"), 7 },
                    { new Guid("efee7476-ec10-467e-8a22-cfbf0e33d130"), 5, 2022, new Guid("03d5a0cf-f03f-4226-adeb-6de9650ba333"), 12 },
                    { new Guid("fc57b8a8-af58-4113-a22e-9b73a3022708"), 7, 2021, new Guid("a750738e-3f01-4474-8cb9-aca46f6d2290"), 10 },
                    { new Guid("febc9d14-e9f4-49ec-a129-37d43c5c1000"), 5, 2021, new Guid("03d5a0cf-f03f-4226-adeb-6de9650ba333"), 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("583698ac-ebc9-4343-83f6-a2f2f4daf0c0"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("5b48a1db-15f4-4de8-b533-82a0a1404c0d"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("645cdff2-a5e4-4f45-a66a-3e5f51864bdd"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("73434893-0bb0-49e4-abf3-43bdddeb0120"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("767fee9d-01db-4f12-9149-f48416d8fa12"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("a1fba9fd-dff0-43ab-a982-df02b6ef13f6"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("acabe807-0b9e-4a53-8146-739f4b31529e"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("be573535-c72a-416d-a890-d8368b74cbdb"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("ec0b8ebd-fd38-4aab-85f7-ca8ef5f83646"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("efee7476-ec10-467e-8a22-cfbf0e33d130"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("fc57b8a8-af58-4113-a22e-9b73a3022708"));

            migrationBuilder.DeleteData(
                table: "TeamStats",
                keyColumn: "Id",
                keyValue: new Guid("febc9d14-e9f4-49ec-a129-37d43c5c1000"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("03d5a0cf-f03f-4226-adeb-6de9650ba333"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("943b80ff-58d0-4d6b-9df8-e30191fc8b6a"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("a750738e-3f01-4474-8cb9-aca46f6d2290"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("a94c19d6-b630-4a98-8c1b-8296786268c3"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("29422329-769d-4b8b-a106-b0237bd9a688"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("64e36144-ff33-4ff0-b3d9-caf5fb09993b"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("7d0e3e10-3c79-4273-9687-e18f004e2795"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("a7409d89-7f0a-44e0-880d-492dc1fc2d56"));

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: new Guid("53b635bd-fb4e-452e-8d3c-cdc35714dc50"));

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: new Guid("6f50bc14-f67d-4fa5-a778-bb7b8a4b687d"));

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: new Guid("83c59f7c-45e9-4f64-b0a0-2a46c649ea36"));

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: new Guid("b534c9e0-b131-4d66-950d-33fa57013afe"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("1e5e3acc-21d5-450e-9a41-3e9fc83736bd"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("40610af7-d116-46ec-9c78-0bdc81e0d251"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("71da77c5-b700-4ada-8fec-ddbfb6686c96"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("7b5cd5cb-4a2b-4a75-a73e-df2eaa3b3645"));
        }
    }
}
