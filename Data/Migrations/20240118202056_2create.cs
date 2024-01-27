using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class _2create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e31deeff-21f1-42b6-bfde-7693168c671c", "1dfffe03-ede9-4440-ba5e-7e6a54fcad2f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a4f0ad8e-553c-48b3-8542-5ff232d47ee6", "f2dbc8ee-f43a-46c9-8c1c-5069c98c25ac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4f0ad8e-553c-48b3-8542-5ff232d47ee6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e31deeff-21f1-42b6-bfde-7693168c671c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dfffe03-ede9-4440-ba5e-7e6a54fcad2f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2dbc8ee-f43a-46c9-8c1c-5069c98c25ac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3881ea95-854e-42fc-a619-99c79281d890", null, "user", "USER" },
                    { "e4a90d44-c685-4b2b-bcc3-5e55315f4147", "e4a90d44-c685-4b2b-bcc3-5e55315f4147", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "90852290-0253-4178-abff-fe437255e29c", 0, "cbb113ef-b404-494c-aa4d-0becd7a7661a", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAIAAYagAAAAEC5vo/4quomCJJVXzLouefbMBxy1ldgvVraZfT0gOx7ot2FySVDIhn6SqbQ14wWdhg==", null, false, "27bf25d0-8c43-4031-8065-4c8000592bef", false, "adam" },
                    { "c76afa90-4f58-4cff-8aba-ff5d58ed64ff", 0, "84e1e6c4-fb20-445c-86d2-dbe7a8d8179b", "ewa@wsei.edu.pl", true, false, null, "EWA@WSEI.EDU.PL", "EWA", "AQAAAAIAAYagAAAAEF3UZdjbCR9XiTxIlfWK5nKQboftQYqDJAHDAguxel4KulaRK2sHZqkFImcduoG3dw==", null, false, "48a38d9c-15fc-45e3-ba93-20aacae21487", false, "ewa" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 18, 20, 20, 56, 853, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 18, 20, 20, 56, 853, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e4a90d44-c685-4b2b-bcc3-5e55315f4147", "90852290-0253-4178-abff-fe437255e29c" },
                    { "3881ea95-854e-42fc-a619-99c79281d890", "c76afa90-4f58-4cff-8aba-ff5d58ed64ff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e4a90d44-c685-4b2b-bcc3-5e55315f4147", "90852290-0253-4178-abff-fe437255e29c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3881ea95-854e-42fc-a619-99c79281d890", "c76afa90-4f58-4cff-8aba-ff5d58ed64ff" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3881ea95-854e-42fc-a619-99c79281d890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4a90d44-c685-4b2b-bcc3-5e55315f4147");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90852290-0253-4178-abff-fe437255e29c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c76afa90-4f58-4cff-8aba-ff5d58ed64ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4f0ad8e-553c-48b3-8542-5ff232d47ee6", null, "user", "USER" },
                    { "e31deeff-21f1-42b6-bfde-7693168c671c", "e31deeff-21f1-42b6-bfde-7693168c671c", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1dfffe03-ede9-4440-ba5e-7e6a54fcad2f", 0, "208dad0d-fa9b-4f2b-aadf-8748ae943b5a", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAIAAYagAAAAEDGbsu4J4oPUpysA9D5zjFQs7FnudzUfcLJN1nM5gfJsX4iP5ibZCChRK0FhWDq7LA==", null, false, "ce7edbed-9d4f-4730-b6c6-c57f2f049dd8", false, "adam" },
                    { "f2dbc8ee-f43a-46c9-8c1c-5069c98c25ac", 0, "3fc568d4-c623-4ab9-a8db-e4ce544d59b5", "ewa@wsei.edu.pl", true, false, null, "EWA@WSEI.EDU.PL", "EWA", "AQAAAAIAAYagAAAAEKna6MbsJ+dHG0yT8UrP8am8InN3Hjg5YuQyd221DxslCfP1tav9SWInI4yhX4VQyA==", null, false, "e6a47eb7-b445-483e-9797-649eb1588743", false, "ewa" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 17, 18, 50, 53, 21, DateTimeKind.Utc).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 1, 17, 18, 50, 53, 21, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e31deeff-21f1-42b6-bfde-7693168c671c", "1dfffe03-ede9-4440-ba5e-7e6a54fcad2f" },
                    { "a4f0ad8e-553c-48b3-8542-5ff232d47ee6", "f2dbc8ee-f43a-46c9-8c1c-5069c98c25ac" }
                });
        }
    }
}
