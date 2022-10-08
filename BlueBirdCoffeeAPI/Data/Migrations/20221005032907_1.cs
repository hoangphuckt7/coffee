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
                    { "CASHER", "CASHER", "CASHER", "CASHER" },
                    { "CUSTOMER", "CUSTOMER", "CUSTOMER", "CUSTOMER" },
                    { "EMPLOYEE", "EMPLOYEE", "EMPLOYEE", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7982), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7983), "Cà phê truyền thống", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7985), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7987), "Cà phê ép máy", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7990), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7990), "Cà phê đặc biệt", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7993), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7995), "Nước ép", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7997), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7997), "Sinh tố", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7999), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8000), "Trà sữa", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8004), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8005), "Trà nóng", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8006), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8007), "Trà trà", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8009), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8009), "Ăn vặt", false }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7963), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7963), "Tầng 2", false },
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64447"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7921), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(7927), "Tầng 1", false }
                });

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Key", "Value" },
                values: new object[] { "ORDER_RECEIVER", "[\"BARTENDER\"]" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Available", "CategoryId", "DateCreated", "DateUpdated", "Description", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8069), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8069), null, false, "Sinh tố bơ", 25000.0 },
                    { new Guid("16d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8025), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8026), null, false, "Cà phê đen phin", 12000.0 },
                    { new Guid("1929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8048), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8049), null, false, "Cà phê kem trứng muối", 29000.0 },
                    { new Guid("1afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8154), null, false, "Bắp rang bơ", 15000.0 },
                    { new Guid("2649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8071), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8071), null, false, "Sinh tố bơ sầu riêng", 35000.0 },
                    { new Guid("26d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8029), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8030), null, false, "Cà phê sữa phin", 14000.0 },
                    { new Guid("2929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8051), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8051), null, false, "Cà phê cốt dừa", 29000.0 },
                    { new Guid("2afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8156), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8156), null, false, "Bắp rang bơ caramel", 20000.0 },
                    { new Guid("3649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8073), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8074), null, false, "Sinh tố xoài", 25000.0 },
                    { new Guid("36d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8032), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8032), null, false, "Cà phê đen đá Sài Gòn", 18000.0 },
                    { new Guid("3929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8054), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8054), null, false, "Cà phê trứng", 29000.0 },
                    { new Guid("3afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8158), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8158), null, false, "Bắp rang bơ phô mai", 20000.0 },
                    { new Guid("4649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8077), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8077), null, false, "Sinh tố dâu tây", 25000.0 },
                    { new Guid("46d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8035), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8036), null, false, "Cà phê sữa đá Sài Gòn", 20000.0 },
                    { new Guid("4929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8056), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8057), null, false, "Cappuchino", 29000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48321"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8127), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8127), null, false, "Trà chanh", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48322"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8130), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8130), null, false, "Trà chanh dây", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48323"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8134), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8134), null, false, "Trà lipton nóng - đá", 20000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48324"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8136), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8137), null, false, "Trà gừng nóng - đá", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48325"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8139), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8139), null, false, "Trà đào cam xả", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48326"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8142), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8143), null, false, "Trà vải", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48327"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8145), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8145), null, false, "Trà sen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48328"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8149), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8149), null, false, "Trà đen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48329"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8151), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8151), null, false, "Trà dâu", 25000.0 },
                    { new Guid("56d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8038), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8039), null, false, "Bạc xỉu", 22000.0 },
                    { new Guid("66d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8041), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8041), null, false, "Ca cao nóng - đá", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e841a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8059), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8059), null, false, "Nước ép dưa hấu", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e842a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8061), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8062), null, false, "Nước ép cà rốt", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e843a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8064), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8064), null, false, "Nước ép thơm", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e844a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8066), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8067), null, false, "Nước ép cam", 25000.0 },
                    { new Guid("d135806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8079), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8080), null, false, "Trà sữa truyền thống", 22000.0 },
                    { new Guid("d18ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8086), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8087), null, false, "Trà olong cúc mật ong nóng", 22000.0 },
                    { new Guid("d235806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8082), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8082), null, false, "Trà sữa kem trứng muối", 29000.0 },
                    { new Guid("d28ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8090), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8092), null, false, "Trà hoa cúc nóng", 25000.0 },
                    { new Guid("d335806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8084), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8084), null, false, "Trà sữa khoai môn", 25000.0 },
                    { new Guid("d38ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8095), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8095), null, false, "Trà chanh nóng", 22000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b1"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8043), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8044), null, false, "Cà phê đen máy", 16000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b2"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8046), new DateTime(2022, 10, 5, 10, 29, 7, 688, DateTimeKind.Utc).AddTicks(8046), null, false, "Cà phê sữa máy", 18000.0 }
                });

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
