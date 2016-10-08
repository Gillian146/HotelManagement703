using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Hotel_Management.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgencyAddress = table.Column<string>(nullable: true),
                    AgencyCellPhoneNumber = table.Column<string>(nullable: true),
                    AgencyCity = table.Column<string>(nullable: true),
                    AgencyContactName = table.Column<string>(nullable: true),
                    AgencyEmail = table.Column<string>(nullable: true),
                    AgencyName = table.Column<string>(nullable: true),
                    AgencySuburb = table.Column<string>(nullable: true),
                    AgencyWorkPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailabilityStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "BedType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BedTypeName = table.Column<string>(nullable: true),
                    BedTypeNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedType", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "CreditCardDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditCardCVC = table.Column<int>(nullable: false),
                    CreditCardExpiryMonth = table.Column<int>(nullable: false),
                    CreditCardExpiryYear = table.Column<int>(nullable: false),
                    CreditCardName = table.Column<string>(nullable: true),
                    CreditCardNotes = table.Column<string>(nullable: true),
                    CreditCardNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardDetails", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelCity = table.Column<string>(nullable: true),
                    HotelName = table.Column<string>(nullable: true),
                    HotelPostalAddress = table.Column<string>(nullable: true),
                    HotelStreetAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatePrepared = table.Column<DateTime>(nullable: false),
                    GSTRate = table.Column<double>(nullable: false),
                    TotalDue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobDescription = table.Column<string>(nullable: true),
                    JobPositionHourlyRate = table.Column<string>(nullable: true),
                    JobPositionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomTypeName = table.Column<string>(nullable: true),
                    RoomTypeNotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "CustomerGuest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgencyID = table.Column<int>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    CustomerCellPhoneNumber = table.Column<string>(nullable: true),
                    CustomerCity = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerFirstName = table.Column<string>(nullable: true),
                    CustomerHomePhone = table.Column<string>(nullable: true),
                    CustomerLastName = table.Column<string>(nullable: true),
                    CustomerSuburb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGuest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerGuest_Agency_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "Agency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Carpark",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarparkLocation = table.Column<string>(nullable: true),
                    CarparkName = table.Column<string>(nullable: true),
                    CarparkNumber = table.Column<string>(nullable: true),
                    HotelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carpark", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Carpark_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FloorName = table.Column<string>(nullable: true),
                    FloorNumber = table.Column<int>(nullable: false),
                    HotelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Floor_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditCardDetailsID = table.Column<int>(nullable: true),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: true),
                    ReceiptNumber = table.Column<int>(nullable: false),
                    TotalPaid = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_CreditCardDetails_CreditCardDetailsID",
                        column: x => x.CreditCardDetailsID,
                        principalTable: "CreditCardDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelID = table.Column<int>(nullable: true),
                    JobPositionID = table.Column<int>(nullable: true),
                    StaffAddress = table.Column<string>(nullable: true),
                    StaffCellPhoneNumber = table.Column<string>(nullable: true),
                    StaffCity = table.Column<string>(nullable: true),
                    StaffEmail = table.Column<string>(nullable: true),
                    StaffFirstName = table.Column<string>(nullable: true),
                    StaffHomePhone = table.Column<string>(nullable: true),
                    StaffLastName = table.Column<string>(nullable: true),
                    StaffPhoto = table.Column<string>(nullable: true),
                    StaffSuburb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staff_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_JobPosition_JobPositionID",
                        column: x => x.JobPositionID,
                        principalTable: "JobPosition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "BedToRoom",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BedTypeID = table.Column<int>(nullable: true),
                    Quanitity = table.Column<int>(nullable: false),
                    RoomTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedToRoom", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BedToRoom_BedType_BedTypeID",
                        column: x => x.BedTypeID,
                        principalTable: "BedType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BedToRoom_RoomType_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Alarm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlarmAlertNotes = table.Column<string>(nullable: true),
                    AlarmDate = table.Column<DateTime>(nullable: false),
                    AlarmDateReceived = table.Column<DateTime>(nullable: false),
                    AlarmDelivered = table.Column<bool>(nullable: false),
                    AlarmTime = table.Column<DateTime>(nullable: false),
                    AlarmTitle = table.Column<string>(nullable: true),
                    CustomerGuestID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alarm_CustomerGuest_CustomerGuestID",
                        column: x => x.CustomerGuestID,
                        principalTable: "CustomerGuest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "ChargeBack",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChargeBackLocation = table.Column<string>(nullable: true),
                    ChargeBackTotal = table.Column<double>(nullable: false),
                    CustomerGuestID = table.Column<int>(nullable: true),
                    InvoiceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeBack", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChargeBack_CustomerGuest_CustomerGuestID",
                        column: x => x.CustomerGuestID,
                        principalTable: "CustomerGuest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChargeBack_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "MessageAlert",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CMessageAlertNotes = table.Column<string>(nullable: true),
                    CustomerGuestID = table.Column<int>(nullable: true),
                    MessageAlertDateDelivered = table.Column<DateTime>(nullable: false),
                    MessageAlertDateReceived = table.Column<DateTime>(nullable: false),
                    MessageAlertDelivered = table.Column<bool>(nullable: false),
                    MessageAlertMessage = table.Column<string>(nullable: true),
                    MessageAlertTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageAlert", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MessageAlert_CustomerGuest_CustomerGuestID",
                        column: x => x.CustomerGuestID,
                        principalTable: "CustomerGuest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "CarParkAvailability",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailabilityID = table.Column<int>(nullable: true),
                    CarparkID = table.Column<int>(nullable: true),
                    DateBookingMade = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarParkAvailability", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarParkAvailability_Availability_AvailabilityID",
                        column: x => x.AvailabilityID,
                        principalTable: "Availability",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarParkAvailability_Carpark_CarparkID",
                        column: x => x.CarparkID,
                        principalTable: "Carpark",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FloorID = table.Column<int>(nullable: true),
                    RoomName = table.Column<string>(nullable: true),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomRate = table.Column<double>(nullable: false),
                    RoomTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Room_Floor_FloorID",
                        column: x => x.FloorID,
                        principalTable: "Floor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    BookingMade = table.Column<DateTime>(nullable: false),
                    CreditCardDetailsID = table.Column<int>(nullable: true),
                    CustomerGuestID = table.Column<int>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: true),
                    RoomID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_CreditCardDetails_CreditCardDetailsID",
                        column: x => x.CreditCardDetailsID,
                        principalTable: "CreditCardDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_CustomerGuest_CustomerGuestID",
                        column: x => x.CustomerGuestID,
                        principalTable: "CustomerGuest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "RoomAvailability",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailabilityID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    RoomID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAvailability", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomAvailability_Availability_AvailabilityID",
                        column: x => x.AvailabilityID,
                        principalTable: "Availability",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomAvailability_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropTable("Alarm");
            migrationBuilder.DropTable("BedToRoom");
            migrationBuilder.DropTable("Booking");
            migrationBuilder.DropTable("CarParkAvailability");
            migrationBuilder.DropTable("ChargeBack");
            migrationBuilder.DropTable("MessageAlert");
            migrationBuilder.DropTable("Payment");
            migrationBuilder.DropTable("RoomAvailability");
            migrationBuilder.DropTable("Staff");
            migrationBuilder.DropTable("State");
            migrationBuilder.DropTable("BedType");
            migrationBuilder.DropTable("Carpark");
            migrationBuilder.DropTable("CustomerGuest");
            migrationBuilder.DropTable("CreditCardDetails");
            migrationBuilder.DropTable("Invoice");
            migrationBuilder.DropTable("Availability");
            migrationBuilder.DropTable("Room");
            migrationBuilder.DropTable("JobPosition");
            migrationBuilder.DropTable("Agency");
            migrationBuilder.DropTable("Floor");
            migrationBuilder.DropTable("RoomType");
            migrationBuilder.DropTable("Hotel");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
