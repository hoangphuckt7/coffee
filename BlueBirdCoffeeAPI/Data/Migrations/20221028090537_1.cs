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
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Limit = table.Column<int>(type: "integer", nullable: true),
                    Maximum = table.Column<double>(type: "double precision", nullable: true),
                    Minium = table.Column<double>(type: "double precision", nullable: true),
                    Discount = table.Column<double>(type: "double precision", nullable: true),
                    Default = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
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
                    Coupon = table.Column<double>(type: "double precision", nullable: true),
                    Discount = table.Column<double>(type: "double precision", nullable: true),
                    IsTakeAway = table.Column<bool>(type: "boolean", nullable: false),
                    BillNumber = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    CouponCode = table.Column<string>(type: "text", nullable: false),
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
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025415ac", 0, "ecd3d03d-78e0-4b23-aa13-364dd9a6de04", null, false, "Cashier", false, null, null, "CASHIER", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "1ba0a432-2e26-40be-961b-ddab7d0e1adf", false, "cashier" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025416ac", 0, "1167fedd-1abe-4d04-a72f-f075561ac7a3", null, false, "Employee", false, null, null, "EMPLOYEE", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "0b8c2d59-7104-45d5-bf49-6b4393e01f28", false, "employee" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025417ac", 0, "9ececd87-bd5c-4002-9544-0b9cfc93187e", null, false, "Bartender", false, null, null, "BARTENDER", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "40ad3377-8a34-4bd9-a992-d97b07bb3eab", false, "bartender" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025418ac", 0, "3c5104c1-196e-455a-bf6f-b2ddb55a316f", null, false, "Admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "256effde-b8cd-41f3-b6f8-529409ec9aa7", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8242), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8242), "Cà phê truyền thống", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8244), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8245), "Cà phê ép máy", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8246), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8246), "Cà phê đặc biệt", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8248), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8248), "Nước ép", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8250), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8250), "Sinh tố", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8251), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8252), "Trà sữa", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8253), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8253), "Trà nóng", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8255), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8255), "Trà trà", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8257), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8257), "Ăn vặt", false }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8179), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8179), "Tầng 2", false },
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64447"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8167), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8170), "Tầng 1", false }
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
                    { new Guid("1649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8305), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8306), null, false, "Sinh tố bơ", 25000.0 },
                    { new Guid("16d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8269), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8269), null, false, "Cà phê đen phin", 12000.0 },
                    { new Guid("1929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8287), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8288), null, false, "Cà phê kem trứng muối", 29000.0 },
                    { new Guid("1afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8345), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8345), null, false, "Bắp rang bơ", 15000.0 },
                    { new Guid("2649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8307), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8308), null, false, "Sinh tố bơ sầu riêng", 35000.0 },
                    { new Guid("26d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8272), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8272), null, false, "Cà phê sữa phin", 14000.0 },
                    { new Guid("2929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8290), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8290), null, false, "Cà phê cốt dừa", 29000.0 },
                    { new Guid("2afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8351), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8351), null, false, "Bắp rang bơ caramel", 20000.0 },
                    { new Guid("3649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8310), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8310), null, false, "Sinh tố xoài", 25000.0 },
                    { new Guid("36d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8274), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8274), null, false, "Cà phê đen đá Sài Gòn", 18000.0 },
                    { new Guid("3929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8292), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8293), null, false, "Cà phê trứng", 29000.0 },
                    { new Guid("3afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8353), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8353), null, false, "Bắp rang bơ phô mai", 20000.0 },
                    { new Guid("4649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8312), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8312), null, false, "Sinh tố dâu tây", 25000.0 },
                    { new Guid("46d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8276), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8277), null, false, "Cà phê sữa đá Sài Gòn", 20000.0 },
                    { new Guid("4929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8294), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8295), null, false, "Cappuchino", 29000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48321"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8326), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8326), null, false, "Trà chanh", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48322"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8328), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8329), null, false, "Trà chanh dây", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48323"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8330), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8331), null, false, "Trà lipton nóng - đá", 20000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48324"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8332), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8333), null, false, "Trà gừng nóng - đá", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48325"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8334), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8335), null, false, "Trà đào cam xả", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48326"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8336), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8337), null, false, "Trà vải", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48327"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8338), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8339), null, false, "Trà sen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48328"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8341), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8341), null, false, "Trà đen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48329"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8343), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8343), null, false, "Trà dâu", 25000.0 },
                    { new Guid("56d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8279), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8279), null, false, "Bạc xỉu", 22000.0 },
                    { new Guid("66d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8281), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8281), null, false, "Ca cao nóng - đá", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e841a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8297), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8297), null, false, "Nước ép dưa hấu", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e842a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8299), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8299), null, false, "Nước ép cà rốt", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e843a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8301), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8301), null, false, "Nước ép thơm", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e844a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8303), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8303), null, false, "Nước ép cam", 25000.0 },
                    { new Guid("d135806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8314), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8314), null, false, "Trà sữa truyền thống", 22000.0 },
                    { new Guid("d18ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8320), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8320), null, false, "Trà olong cúc mật ong nóng", 22000.0 },
                    { new Guid("d235806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8316), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8316), null, false, "Trà sữa kem trứng muối", 29000.0 },
                    { new Guid("d28ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8322), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8322), null, false, "Trà hoa cúc nóng", 25000.0 },
                    { new Guid("d335806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8318), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8318), null, false, "Trà sữa khoai môn", 25000.0 },
                    { new Guid("d38ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8324), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8324), null, false, "Trà chanh nóng", 22000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b1"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8283), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8283), null, false, "Cà phê đen máy", 16000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b2"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8285), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8285), null, false, "Cà phê sữa máy", 18000.0 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "CurrentOrder", "DateCreated", "DateUpdated", "Description", "FloorId", "IsDeleted", "Position", "Rotation", "Shape", "Size" },
                values: new object[] { new Guid("1f3ebd56-dbf5-453f-819d-2757a152d0a5"), 0, new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8193), new DateTime(2022, 10, 28, 16, 5, 37, 446, DateTimeKind.Utc).AddTicks(8194), "101", new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"), false, "22,823660714285715-31,412337662337663", 0, "Rectangle", "9,988839285714286-9,983766233766234" });

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
                name: "IX_Coupons_Description",
                table: "Coupons",
                column: "Description",
                unique: true);

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
                name: "Coupons");

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
