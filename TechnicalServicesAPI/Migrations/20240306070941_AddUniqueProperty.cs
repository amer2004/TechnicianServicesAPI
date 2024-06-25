using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalServicesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersFeedBackRatings_UserFeedBackId",
                table: "UsersFeedBackRatings");

            migrationBuilder.DropIndex(
                name: "IX_TechniciansServices_TechnicianId",
                table: "TechniciansServices");

            migrationBuilder.DropIndex(
                name: "IX_TechniciansRatings_TechnicianId",
                table: "TechniciansRatings");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians");

            migrationBuilder.DropIndex(
                name: "IX_Responses_TechnicianId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ChosenResponseId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFeedBackRatings_UserFeedBackId_RatingTypeId",
                table: "UsersFeedBackRatings",
                columns: new[] { "UserFeedBackId", "RatingTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansServices_TechnicianId_ExtendServiceId",
                table: "TechniciansServices",
                columns: new[] { "TechnicianId", "ExtendServiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansRatings_TechnicianId_RatingTypeId",
                table: "TechniciansRatings",
                columns: new[] { "TechnicianId", "RatingTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_SocialSecurityNumber",
                table: "Technicians",
                column: "SocialSecurityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_UserName",
                table: "Technicians",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_TechnicianId_OrderId",
                table: "Responses",
                columns: new[] { "TechnicianId", "OrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ChosenResponseId",
                table: "Orders",
                column: "ChosenResponseId",
                unique: true,
                filter: "[ChosenResponseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_PhoneNumber",
                table: "Admins",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_SocialSecurityNumber",
                table: "Admins",
                column: "SocialSecurityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserName",
                table: "Admins",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersFeedBackRatings_UserFeedBackId_RatingTypeId",
                table: "UsersFeedBackRatings");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TechniciansServices_TechnicianId_ExtendServiceId",
                table: "TechniciansServices");

            migrationBuilder.DropIndex(
                name: "IX_TechniciansRatings_TechnicianId_RatingTypeId",
                table: "TechniciansRatings");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_SocialSecurityNumber",
                table: "Technicians");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_UserName",
                table: "Technicians");

            migrationBuilder.DropIndex(
                name: "IX_Responses_TechnicianId_OrderId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ChosenResponseId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Admins_Email",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_PhoneNumber",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_SocialSecurityNumber",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserName",
                table: "Admins");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFeedBackRatings_UserFeedBackId",
                table: "UsersFeedBackRatings",
                column: "UserFeedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansServices_TechnicianId",
                table: "TechniciansServices",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniciansRatings_TechnicianId",
                table: "TechniciansRatings",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_UserId",
                table: "Technicians",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_TechnicianId",
                table: "Responses",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ChosenResponseId",
                table: "Orders",
                column: "ChosenResponseId");
        }
    }
}
