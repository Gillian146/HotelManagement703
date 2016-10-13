using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Hotel_Management.Models;

namespace Hotel_Management.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161013063315_reset1")]
    partial class reset1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hotel_Management.Models.Agency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AgencyAddress");

                    b.Property<string>("AgencyCellPhoneNumber");

                    b.Property<string>("AgencyCity");

                    b.Property<string>("AgencyContactName");

                    b.Property<string>("AgencyEmail");

                    b.Property<string>("AgencyName");

                    b.Property<string>("AgencySuburb");

                    b.Property<string>("AgencyWorkPhone");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Alarm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlarmAlertNotes");

                    b.Property<DateTime>("AlarmDate");

                    b.Property<DateTime>("AlarmDateReceived");

                    b.Property<bool>("AlarmDelivered");

                    b.Property<DateTime>("AlarmTime");

                    b.Property<string>("AlarmTitle");

                    b.Property<int?>("CustomerGuestID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Hotel_Management.Models.Availability", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvailabilityStatus");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.BedToRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BedTypeID");

                    b.Property<int>("Quanitity");

                    b.Property<int?>("RoomTypeID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.BedType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BedTypeName");

                    b.Property<string>("BedTypeNotes");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<DateTime>("BookingMade");

                    b.Property<string>("BookingRange");

                    b.Property<int?>("CheckInStatusID");

                    b.Property<int?>("CreditCardDetailsID");

                    b.Property<int?>("CustomerGuestID");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int?>("InvoiceID");

                    b.Property<int>("NumberofNights");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CalendarToRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BookRoom");

                    b.Property<int?>("BookingID");

                    b.Property<bool>("IsBooked");

                    b.Property<int?>("RoomID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Carpark", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarparkLocation");

                    b.Property<string>("CarparkName");

                    b.Property<string>("CarparkNumber");

                    b.Property<int?>("HotelID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CarParkAvailability", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AvailabilityID");

                    b.Property<int?>("CarparkID");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateBookingMade");

                    b.Property<bool>("IsAvailable");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.ChargeBack", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChargeBackLocation");

                    b.Property<double>("ChargeBackTotal");

                    b.Property<int?>("CustomerGuestID");

                    b.Property<int?>("InvoiceID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CheckInStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GuestStatusinRoom");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CreditCardDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreditCardCVC");

                    b.Property<int>("CreditCardExpiryMonth");

                    b.Property<int>("CreditCardExpiryYear");

                    b.Property<string>("CreditCardName")
                        .IsRequired();

                    b.Property<string>("CreditCardNotes");

                    b.Property<int>("CreditCardNumber");

                    b.Property<int?>("CustomerGuestID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CustomerGuest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgencyID");

                    b.Property<string>("CustomerAddress");

                    b.Property<string>("CustomerCellPhoneNumber");

                    b.Property<string>("CustomerCity");

                    b.Property<string>("CustomerEmail");

                    b.Property<string>("CustomerFirstName");

                    b.Property<string>("CustomerFullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("Relational:GeneratedValueSql", "[CustomerFirstName] + ' ' + [CustomerLastName]");

                    b.Property<string>("CustomerHomePhone");

                    b.Property<string>("CustomerLastName");

                    b.Property<string>("CustomerSuburb");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Floor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FloorName");

                    b.Property<int>("FloorNumber");

                    b.Property<int?>("HotelID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HotelCity");

                    b.Property<string>("HotelName");

                    b.Property<string>("HotelPostalAddress");

                    b.Property<string>("HotelStreetAddress");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePrepared");

                    b.Property<double>("GST");

                    b.Property<double>("GSTRate");

                    b.Property<double>("TotalDue");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.JobPosition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobPositionHourlyRate");

                    b.Property<string>("JobPositionName");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Maintenance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateEntered");

                    b.Property<bool>("MaintenanceCompleted");

                    b.Property<string>("MaintenanceDescription");

                    b.Property<string>("MaintenanceName");

                    b.Property<string>("MaintenanceNotes");

                    b.Property<int?>("RoomID");

                    b.Property<int?>("StaffID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.MessageAlert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CMessageAlertNotes");

                    b.Property<int?>("CustomerGuestID");

                    b.Property<DateTime>("MessageAlertDateDelivered");

                    b.Property<DateTime>("MessageAlertDateReceived");

                    b.Property<bool>("MessageAlertDelivered");

                    b.Property<string>("MessageAlertMessage");

                    b.Property<string>("MessageAlertTitle");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreditCardDetailsID");

                    b.Property<DateTime>("DatePaid");

                    b.Property<int?>("InvoiceID");

                    b.Property<int>("ReceiptNumber");

                    b.Property<double>("TotalPaid");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FloorID");

                    b.Property<string>("RoomName");

                    b.Property<int>("RoomNumber");

                    b.Property<double>("RoomRate");

                    b.Property<int?>("RoomTypeID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.RoomAvailability", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AvailabilityID");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsAvailable");

                    b.Property<int?>("RoomID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.RoomType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoomTypeName");

                    b.Property<int>("RoomTypeNotes");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HotelID");

                    b.Property<int?>("JobPositionID");

                    b.Property<string>("StaffAddress");

                    b.Property<string>("StaffCellPhoneNumber");

                    b.Property<string>("StaffCity");

                    b.Property<string>("StaffEmail");

                    b.Property<string>("StaffFirstName");

                    b.Property<string>("StaffFullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasAnnotation("Relational:GeneratedValueSql", "[StaffFirstName] + ' ' + [StaffLastName]");

                    b.Property<string>("StaffHomePhone");

                    b.Property<string>("StaffLastName");

                    b.Property<string>("StaffPhoto");

                    b.Property<string>("StaffSuburb");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Hotel_Management.Models.State", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StateDescription");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Hotel_Management.Models.Alarm", b =>
                {
                    b.HasOne("Hotel_Management.Models.CustomerGuest")
                        .WithMany()
                        .HasForeignKey("CustomerGuestID");
                });

            modelBuilder.Entity("Hotel_Management.Models.BedToRoom", b =>
                {
                    b.HasOne("Hotel_Management.Models.BedType")
                        .WithMany()
                        .HasForeignKey("BedTypeID");

                    b.HasOne("Hotel_Management.Models.RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Booking", b =>
                {
                    b.HasOne("Hotel_Management.Models.CheckInStatus")
                        .WithMany()
                        .HasForeignKey("CheckInStatusID");

                    b.HasOne("Hotel_Management.Models.CreditCardDetails")
                        .WithMany()
                        .HasForeignKey("CreditCardDetailsID");

                    b.HasOne("Hotel_Management.Models.CustomerGuest")
                        .WithMany()
                        .HasForeignKey("CustomerGuestID");

                    b.HasOne("Hotel_Management.Models.Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CalendarToRoom", b =>
                {
                    b.HasOne("Hotel_Management.Models.Booking")
                        .WithMany()
                        .HasForeignKey("BookingID");

                    b.HasOne("Hotel_Management.Models.Room")
                        .WithMany()
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Carpark", b =>
                {
                    b.HasOne("Hotel_Management.Models.Hotel")
                        .WithMany()
                        .HasForeignKey("HotelID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CarParkAvailability", b =>
                {
                    b.HasOne("Hotel_Management.Models.Availability")
                        .WithMany()
                        .HasForeignKey("AvailabilityID");

                    b.HasOne("Hotel_Management.Models.Carpark")
                        .WithMany()
                        .HasForeignKey("CarparkID");
                });

            modelBuilder.Entity("Hotel_Management.Models.ChargeBack", b =>
                {
                    b.HasOne("Hotel_Management.Models.CustomerGuest")
                        .WithMany()
                        .HasForeignKey("CustomerGuestID");

                    b.HasOne("Hotel_Management.Models.Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CreditCardDetails", b =>
                {
                    b.HasOne("Hotel_Management.Models.CustomerGuest")
                        .WithMany()
                        .HasForeignKey("CustomerGuestID");
                });

            modelBuilder.Entity("Hotel_Management.Models.CustomerGuest", b =>
                {
                    b.HasOne("Hotel_Management.Models.Agency")
                        .WithMany()
                        .HasForeignKey("AgencyID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Floor", b =>
                {
                    b.HasOne("Hotel_Management.Models.Hotel")
                        .WithMany()
                        .HasForeignKey("HotelID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Maintenance", b =>
                {
                    b.HasOne("Hotel_Management.Models.Room")
                        .WithMany()
                        .HasForeignKey("RoomID");

                    b.HasOne("Hotel_Management.Models.Staff")
                        .WithMany()
                        .HasForeignKey("StaffID");
                });

            modelBuilder.Entity("Hotel_Management.Models.MessageAlert", b =>
                {
                    b.HasOne("Hotel_Management.Models.CustomerGuest")
                        .WithMany()
                        .HasForeignKey("CustomerGuestID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Payment", b =>
                {
                    b.HasOne("Hotel_Management.Models.CreditCardDetails")
                        .WithMany()
                        .HasForeignKey("CreditCardDetailsID");

                    b.HasOne("Hotel_Management.Models.Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Room", b =>
                {
                    b.HasOne("Hotel_Management.Models.Floor")
                        .WithMany()
                        .HasForeignKey("FloorID");

                    b.HasOne("Hotel_Management.Models.RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeID");
                });

            modelBuilder.Entity("Hotel_Management.Models.RoomAvailability", b =>
                {
                    b.HasOne("Hotel_Management.Models.Availability")
                        .WithMany()
                        .HasForeignKey("AvailabilityID");

                    b.HasOne("Hotel_Management.Models.Room")
                        .WithMany()
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("Hotel_Management.Models.Staff", b =>
                {
                    b.HasOne("Hotel_Management.Models.Hotel")
                        .WithMany()
                        .HasForeignKey("HotelID");

                    b.HasOne("Hotel_Management.Models.JobPosition")
                        .WithMany()
                        .HasForeignKey("JobPositionID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Hotel_Management.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Hotel_Management.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Hotel_Management.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
