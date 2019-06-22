using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentDB.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    BussinesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationRatings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Published = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AccommodationTypeId = table.Column<long>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    FreeCancellation = table.Column<bool>(nullable: false),
                    CancellationDays = table.Column<int>(nullable: false),
                    CancellationPrice = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NumberOfPersons = table.Column<int>(nullable: false),
                    AgentId = table.Column<long>(nullable: true),
                    DefaultPrice = table.Column<decimal>(nullable: false),
                    LocationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_AccommodationTypes_AccommodationTypeId",
                        column: x => x.AccommodationTypeId,
                        principalTable: "AccommodationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accommodations_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accommodations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalServiceName = table.Column<string>(nullable: true),
                    AccommodationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalServices_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeriodPrices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    AccommodationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodPrices_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationLong",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<long>(nullable: false),
                    AccommodationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationLong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationLong_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AccommodationId = table.Column<long>(nullable: true),
                    UserID = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Realized = table.Column<bool>(nullable: false),
                    ReservationRatingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationRatings_ReservationRatingId",
                        column: x => x.ReservationRatingId,
                        principalTable: "ReservationRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unavailabilities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    AccommodationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unavailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unavailabilities_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Direction = table.Column<int>(nullable: false),
                    ReservationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AccommodationTypeId",
                table: "Accommodations",
                column: "AccommodationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AgentId",
                table: "Accommodations",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_LocationId",
                table: "Accommodations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServices_AccommodationId",
                table: "AdditionalServices",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReservationId",
                table: "Messages",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodPrices_AccommodationId",
                table: "PeriodPrices",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationLong_AccommodationId",
                table: "ReservationLong",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AccommodationId",
                table: "Reservations",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationRatingId",
                table: "Reservations",
                column: "ReservationRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Unavailabilities_AccommodationId",
                table: "Unavailabilities",
                column: "AccommodationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalServices");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PeriodPrices");

            migrationBuilder.DropTable(
                name: "ReservationLong");

            migrationBuilder.DropTable(
                name: "Unavailabilities");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "ReservationRatings");

            migrationBuilder.DropTable(
                name: "AccommodationTypes");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
