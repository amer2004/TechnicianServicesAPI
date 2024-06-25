using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalServicesAPI.Migrations
{
    /// <inheritdoc />
    public partial class TableCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    IsTechnician = table.Column<bool>(type: "bit", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    XLocation = table.Column<double>(type: "float", nullable: false),
                    YLocation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtendServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MainServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtendServices_MainServices_MainServiceId",
                        column: x => x.MainServiceId,
                        principalTable: "MainServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastSigninDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    ApprovedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technicians_Admins_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Technicians_TechnicianStatus_statusId",
                        column: x => x.statusId,
                        principalTable: "TechnicianStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Technicians_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersIncoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersIncoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersIncoms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersNotifcations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersNotifcations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersNotifcations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPayments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPayments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechniciansRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingTypeId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniciansRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechniciansRatings_RatingTypes_RatingTypeId",
                        column: x => x.RatingTypeId,
                        principalTable: "RatingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechniciansRatings_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechniciansServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtendServiceId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniciansServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechniciansServices_ExtendServices_ExtendServiceId",
                        column: x => x.ExtendServiceId,
                        principalTable: "ExtendServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechniciansServices_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    ExtendServiceId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    XLocation = table.Column<double>(type: "float", nullable: false),
                    YLocation = table.Column<double>(type: "float", nullable: false),
                    ChosenResponseId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ExtendServices_ExtendServiceId",
                        column: x => x.ExtendServiceId,
                        principalTable: "ExtendServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    EstimatedTime = table.Column<double>(type: "float", nullable: false),
                    EstimatedPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responses_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TechniciansFeedBack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniciansFeedBack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechniciansFeedBack_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersFeedBack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFeedBack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersFeedBack_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianFeedBackResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    TechnicianFeedBackId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianFeedBackResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicianFeedBackResponses_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicianFeedBackResponses_TechniciansFeedBack_TechnicianFeedBackId",
                        column: x => x.TechnicianFeedBackId,
                        principalTable: "TechniciansFeedBack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedBackResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UserFeedBackId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedBackResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFeedBackResponses_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFeedBackResponses_UsersFeedBack_UserFeedBackId",
                        column: x => x.UserFeedBackId,
                        principalTable: "UsersFeedBack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersFeedBackRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFeedBackId = table.Column<int>(type: "int", nullable: false),
                    RatingTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFeedBackRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersFeedBackRatings_RatingTypes_RatingTypeId",
                        column: x => x.RatingTypeId,
                        principalTable: "RatingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersFeedBackRatings_UsersFeedBack_UserFeedBackId",
                        column: x => x.UserFeedBackId,
                        principalTable: "UsersFeedBack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtendServices_MainServiceId",
                table: "ExtendServices",
                column: "MainServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ChosenResponseId",
                table: "Orders",
                column: "ChosenResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExtendServiceId",
                table: "Orders",
                column: "ExtendServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_OrderId",
                table: "Responses",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_TechnicianId",
                table: "Responses",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianFeedBackResponses_AdminId",
                table: "TechnicianFeedBackResponses",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianFeedBackResponses_TechnicianFeedBackId",
                table: "TechnicianFeedBackResponses",
                column: "TechnicianFeedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_ApprovedById",
                table: "Technicians",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_statusId",
                table: "Technicians",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansFeedBack_OrderId",
                table: "TechniciansFeedBack",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansRatings_RatingTypeId",
                table: "TechniciansRatings",
                column: "RatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansRatings_TechnicianId",
                table: "TechniciansRatings",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansServices_ExtendServiceId",
                table: "TechniciansServices",
                column: "ExtendServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansServices_TechnicianId",
                table: "TechniciansServices",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedBackResponses_AdminId",
                table: "UserFeedBackResponses",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedBackResponses_UserFeedBackId",
                table: "UserFeedBackResponses",
                column: "UserFeedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFeedBack_OrderId",
                table: "UsersFeedBack",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFeedBackRatings_RatingTypeId",
                table: "UsersFeedBackRatings",
                column: "RatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFeedBackRatings_UserFeedBackId",
                table: "UsersFeedBackRatings",
                column: "UserFeedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersIncoms_UserId",
                table: "UsersIncoms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersNotifcations_UserId",
                table: "UsersNotifcations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPayments_PaymentTypeId",
                table: "UsersPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPayments_UserId",
                table: "UsersPayments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Responses_ChosenResponseId",
                table: "Orders",
                column: "ChosenResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtendServices_MainServices_MainServiceId",
                table: "ExtendServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ExtendServices_ExtendServiceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_StatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Responses_ChosenResponseId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "TechnicianFeedBackResponses");

            migrationBuilder.DropTable(
                name: "TechniciansRatings");

            migrationBuilder.DropTable(
                name: "TechniciansServices");

            migrationBuilder.DropTable(
                name: "UserFeedBackResponses");

            migrationBuilder.DropTable(
                name: "UsersFeedBackRatings");

            migrationBuilder.DropTable(
                name: "UsersIncoms");

            migrationBuilder.DropTable(
                name: "UsersNotifcations");

            migrationBuilder.DropTable(
                name: "UsersPayments");

            migrationBuilder.DropTable(
                name: "TechniciansFeedBack");

            migrationBuilder.DropTable(
                name: "RatingTypes");

            migrationBuilder.DropTable(
                name: "UsersFeedBack");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "MainServices");

            migrationBuilder.DropTable(
                name: "ExtendServices");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "TechnicianStatus");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
