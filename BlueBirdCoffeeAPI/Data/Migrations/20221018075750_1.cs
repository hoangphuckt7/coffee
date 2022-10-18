using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemMissingReason = table.Column<string>(type: "text", nullable: true),
                    Coupon = table.Column<string>(type: "text", nullable: true),
                    Discount = table.Column<double>(type: "double precision", nullable: false),
                    IsTakeAway = table.Column<bool>(type: "boolean", nullable: false),
                    BillNumber = table.Column<int>(type: "integer", nullable: false),
                    CasherId = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_AspNetUsers_CasherId",
                        column: x => x.CasherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bills_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentOrder = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Shape = table.Column<string>(type: "text", nullable: false),
                    Rotation = table.Column<int>(type: "integer", nullable: false),
                    FloorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsCheckout = table.Column<bool>(type: "boolean", nullable: false),
                    IsRejected = table.Column<bool>(type: "boolean", nullable: false),
                    IsMissing = table.Column<bool>(type: "boolean", nullable: false),
                    RejectedReason = table.Column<string>(type: "text", nullable: true),
                    TableId = table.Column<Guid>(type: "uuid", nullable: true),
                    EmployeeId = table.Column<string>(type: "text", nullable: true),
                    UserRejectedId = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserRejectedId",
                        column: x => x.UserRejectedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillOrders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    BillId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOrders", x => new { x.OrderId, x.BillId });
                    table.ForeignKey(
                        name: "FK_BillOrders_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    FinalQuantity = table.Column<int>(type: "integer", nullable: false),
                    MissingReason = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ADMIN", "ADMIN", "ADMIN", "ADMIN" },
                    { "BARTENDER", "BARTENDER", "BARTENDER", "BARTENDER" },
                    { "CASHIER", "CASHIER", "CASHIER", "CASHIER" },
                    { "CUSTOMER", "CUSTOMER", "CUSTOMER", "CUSTOMER" },
                    { "EMPLOYEE", "EMPLOYEE", "EMPLOYEE", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fullname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025415ac", 0, "d45a0a31-f211-46da-9748-73ac3a6c1f65", null, false, "Cashier", false, null, null, "CASHIER", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "053b8c8a-5265-43a1-afaa-13d83c739b6a", false, "cashier" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025416ac", 0, "0873b158-0d43-4f52-bafa-5ce406db4433", null, false, "Employee", false, null, null, "EMPLOYEE", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "40664e87-5924-4af9-8e4e-83d05d4671e2", false, "employee" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025417ac", 0, "c5d27e48-2a7f-4d41-944f-492220318a75", null, false, "Bartender", false, null, null, "BARTENDER", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "d9ce3c8d-167b-4a46-9ba1-c1f0492a47a5", false, "bartender" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025418ac", 0, "6067a285-42c2-4938-a674-c1ab618bb652", null, false, "Admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "6d2f65a9-2e92-47cb-9229-66f5271f9f5d", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1626), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1626), "Cà phê truyền thống", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1627), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1628), "Cà phê ép máy", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1629), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1630), "Cà phê đặc biệt", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1631), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1631), "Nước ép", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1633), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1633), "Sinh tố", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1635), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1635), "Trà sữa", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1637), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1637), "Trà nóng", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1638), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1639), "Trà trà", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1640), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1640), "Ăn vặt", false }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1580), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1581), "Tầng 2", false },
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64447"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1565), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1569), "Tầng 1", false }
                });

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Key", "Value" },
                values: new object[] { "ORDER_RECEIVER", "[\"BARTENDER\"]" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "CASHIER", "9acc7a1a-ae85-4e5a-8cb7-0b47025415ac" },
                    { "EMPLOYEE", "9acc7a1a-ae85-4e5a-8cb7-0b47025416ac" },
                    { "BARTENDER", "9acc7a1a-ae85-4e5a-8cb7-0b47025417ac" },
                    { "ADMIN", "9acc7a1a-ae85-4e5a-8cb7-0b47025418ac" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Available", "CategoryId", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1689), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1690), null, false, "Sinh tố bơ", 25000.0 },
                    { new Guid("16d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1653), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1653), null, false, "Cà phê đen phin", 12000.0 },
                    { new Guid("1929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1672), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1672), null, false, "Cà phê kem trứng muối", 29000.0 },
                    { new Guid("1afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1730), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1730), null, false, "Bắp rang bơ", 15000.0 },
                    { new Guid("2649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1691), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1692), null, false, "Sinh tố bơ sầu riêng", 35000.0 },
                    { new Guid("26d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1656), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1656), null, false, "Cà phê sữa phin", 14000.0 },
                    { new Guid("2929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1674), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1674), null, false, "Cà phê cốt dừa", 29000.0 },
                    { new Guid("2afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1732), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1732), null, false, "Bắp rang bơ caramel", 20000.0 },
                    { new Guid("3649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1693), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1694), null, false, "Sinh tố xoài", 25000.0 },
                    { new Guid("36d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1658), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1658), null, false, "Cà phê đen đá Sài Gòn", 18000.0 },
                    { new Guid("3929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1676), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1677), null, false, "Cà phê trứng", 29000.0 },
                    { new Guid("3afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1734), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1734), null, false, "Bắp rang bơ phô mai", 20000.0 },
                    { new Guid("4649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1696), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1696), null, false, "Sinh tố dâu tây", 25000.0 },
                    { new Guid("46d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1660), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1661), null, false, "Cà phê sữa đá Sài Gòn", 20000.0 },
                    { new Guid("4929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1678), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1679), null, false, "Cappuchino", 29000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48321"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1711), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1711), null, false, "Trà chanh", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48322"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1713), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1713), null, false, "Trà chanh dây", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48323"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1715), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1715), null, false, "Trà lipton nóng - đá", 20000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48324"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1717), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1718), null, false, "Trà gừng nóng - đá", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48325"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1719), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1720), null, false, "Trà đào cam xả", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48326"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1721), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1722), null, false, "Trà vải", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48327"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1723), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1724), null, false, "Trà sen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48328"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1725), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1726), null, false, "Trà đen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48329"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1728), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1728), null, false, "Trà dâu", 25000.0 },
                    { new Guid("56d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1663), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1663), null, false, "Bạc xỉu", 22000.0 },
                    { new Guid("66d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1665), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1665), null, false, "Ca cao nóng - đá", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e841a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1680), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1681), null, false, "Nước ép dưa hấu", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e842a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1683), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1683), null, false, "Nước ép cà rốt", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e843a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1685), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1685), null, false, "Nước ép thơm", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e844a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1687), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1687), null, false, "Nước ép cam", 25000.0 },
                    { new Guid("d135806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1698), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1698), null, false, "Trà sữa truyền thống", 22000.0 },
                    { new Guid("d18ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1704), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1704), null, false, "Trà olong cúc mật ong nóng", 22000.0 },
                    { new Guid("d235806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1700), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1700), null, false, "Trà sữa kem trứng muối", 29000.0 },
                    { new Guid("d28ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1706), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1707), null, false, "Trà hoa cúc nóng", 25000.0 },
                    { new Guid("d335806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1702), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1702), null, false, "Trà sữa khoai môn", 25000.0 },
                    { new Guid("d38ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1708), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1709), null, false, "Trà chanh nóng", 22000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b1"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1667), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1668), null, false, "Cà phê đen máy", 16000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b2"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1669), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1670), null, false, "Cà phê sữa máy", 18000.0 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "CurrentOrder", "DateCreated", "DateUpdated", "Description", "FloorId", "IsDeleted", "Position", "Rotation", "Shape", "Size" },
                values: new object[] { new Guid("1f3ebd56-dbf5-453f-819d-2757a152d0a5"), 0, new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1615), new DateTime(2022, 10, 18, 14, 57, 49, 800, DateTimeKind.Utc).AddTicks(1617), "101", new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"), false, "22,823660714285715-31,412337662337663", 0, "Rectangle", "9,988839285714286-9,983766233766234" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillOrders_BillId",
                table: "BillOrders",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CasherId",
                table: "Bills",
                column: "CasherId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserRejectedId",
                table: "Orders",
                column: "UserRejectedId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_FloorId",
                table: "Tables",
                column: "FloorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BillOrders");

            migrationBuilder.DropTable(
                name: "ItemImages");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Floors");
        }
    }
}
