using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticBackend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ExperienceStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryNumber = table.Column<string>(type: "text", nullable: false),
                    LicensePlate = table.Column<string>(type: "text", nullable: false),
                    VIN = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    InitialCost = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrentBookValue = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Mileage = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    MileageAtExpense = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuelTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Liters = table.Column<float>(type: "real", nullable: false),
                    PricePerLiter = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelTransactions_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FuelTransactions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IntervalMileage = table.Column<float>(type: "real", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ServiceCompany = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartMileage = table.Column<int>(type: "integer", nullable: false),
                    EndMileage = table.Column<int>(type: "integer", nullable: true),
                    CargoDescription = table.Column<string>(type: "text", nullable: false),
                    CargoWeight = table.Column<float>(type: "real", nullable: false),
                    FuelSpent = table.Column<float>(type: "real", nullable: true),
                    Route = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripTransactions_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripTransactions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "ExperienceStart", "FullName", "IsActive", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 5, 9, 21, 0, 0, 0, DateTimeKind.Utc), "Иванов Иван Иванович", true, "+375291234567" },
                    { 2, new DateTime(2018, 3, 21, 21, 0, 0, 0, DateTimeKind.Utc), "Петров Петр Петрович", true, "+375441234567" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CurrentBookValue", "FuelType", "InitialCost", "InventoryNumber", "LicensePlate", "Mileage", "Model", "Status", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, "Volvo", 70000m, "Diesel", 90000m, "INV-001", "1234 AB-7", 150000f, "FH16", 1, "VIN00000000000001", 2018 },
                    { 2, "Scania", 85000m, "Diesel", 105000m, "INV-002", "5678 AC-7", 120000f, "R500", 2, "VIN00000000000002", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "Date", "Description", "MileageAtExpense", "VehicleId" },
                values: new object[,]
                {
                    { 1, 350m, new DateTime(2024, 1, 9, 21, 0, 0, 0, DateTimeKind.Utc), "Замена масла", 150500f, 1 },
                    { 2, 500m, new DateTime(2024, 1, 14, 21, 0, 0, 0, DateTimeKind.Utc), "Техническое обслуживание", 121000f, 2 }
                });

            migrationBuilder.InsertData(
                table: "FuelTransactions",
                columns: new[] { "Id", "Date", "DriverId", "Liters", "PricePerLiter", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 11, 21, 0, 0, 0, DateTimeKind.Utc), 1, 150f, 2.1m, 1 },
                    { 2, new DateTime(2024, 1, 19, 21, 0, 0, 0, DateTimeKind.Utc), 2, 180f, 2.05m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Maintenances",
                columns: new[] { "Id", "Cost", "Date", "Description", "IntervalMileage", "IsCompleted", "Mileage", "ServiceCompany", "VehicleId" },
                values: new object[,]
                {
                    { 1, 800m, new DateTime(2024, 2, 4, 21, 0, 0, 0, DateTimeKind.Utc), "ТО-2", 15000f, true, 151000, "ТехСервис", 1 },
                    { 2, 600m, new DateTime(2024, 2, 9, 21, 0, 0, 0, DateTimeKind.Utc), "ТО-1", 20000f, true, 121500, "АвтоМастер", 2 }
                });

            migrationBuilder.InsertData(
                table: "TripTransactions",
                columns: new[] { "Id", "CargoDescription", "CargoWeight", "DriverId", "EndDateTime", "EndMileage", "FuelSpent", "Notes", "Number", "Route", "StartDateTime", "StartMileage", "Status", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Молочная продукция", 5000f, 1, null, null, null, "Без происшествий", "TRIP-001", "Минск — Брест", new DateTime(2025, 12, 3, 5, 0, 0, 0, DateTimeKind.Utc), 150000, 2, 1 },
                    { 2, "Мясная продукция", 3000f, 2, new DateTime(2024, 1, 7, 19, 0, 0, 0, DateTimeKind.Utc), 120380, 90f, "", "TRIP-002", "Минск — Гродно", new DateTime(2024, 1, 7, 4, 0, 0, 0, DateTimeKind.Utc), 120000, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_FullName",
                table: "Drivers",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Phone",
                table: "Drivers",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_VehicleId",
                table: "Expenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelTransactions_DriverId",
                table: "FuelTransactions",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelTransactions_VehicleId",
                table: "FuelTransactions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_VehicleId",
                table: "Maintenances",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTransactions_DriverId",
                table: "TripTransactions",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTransactions_Number",
                table: "TripTransactions",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripTransactions_VehicleId",
                table: "TripTransactions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InventoryNumber",
                table: "Vehicles",
                column: "InventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LicensePlate",
                table: "Vehicles",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VIN",
                table: "Vehicles",
                column: "VIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "FuelTransactions");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "TripTransactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
