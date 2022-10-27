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
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025415ac", 0, "c2b47bdd-16d3-48ff-ae63-34dab845b15e", null, false, "Cashier", false, null, null, "CASHIER", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "5bbc813a-9425-4d27-8519-24eeeaacc430", false, "cashier" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025416ac", 0, "9c036d15-dc35-468b-a143-357485a890ca", null, false, "Employee", false, null, null, "EMPLOYEE", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "79a7b071-a3b3-43aa-ac7a-4f542d6d2094", false, "employee" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025417ac", 0, "eb51bbb8-953b-488a-b715-d2e7c7200771", null, false, "Bartender", false, null, null, "BARTENDER", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "6dbdc74f-4118-47cf-a7f5-c1d6414634ff", false, "bartender" },
                    { "9acc7a1a-ae85-4e5a-8cb7-0b47025418ac", 0, "e0d51f55-8976-49ba-88db-38058e768bf3", null, false, "Admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGVatu9u6IGD4AfolpXDzxhKcuCy0o3bKiqLlg6fYkabzGPInIrlJLxkV4aUbOa1dw==", null, false, "f76be786-93de-4886-ab03-5333d8cee9ee", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4472), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4473), "Cà phê truyền thống", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4474), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4475), "Cà phê ép máy", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4476), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4476), "Cà phê đặc biệt", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4481), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4481), "Nước ép", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4483), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4483), "Sinh tố", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4484), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4485), "Trà sữa", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4486), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4486), "Trà nóng", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4488), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4488), "Trà trà", false },
                    { new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4490), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4490), "Ăn vặt", false }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4449), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4449), "Tầng 2", false },
                    { new Guid("eb22e2ea-0305-4778-a129-f400e6a64447"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4435), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4438), "Tầng 1", false }
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
                    { new Guid("1649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4539), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4539), null, false, "Sinh tố bơ", 25000.0 },
                    { new Guid("16d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4501), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4502), null, false, "Cà phê đen phin", 12000.0 },
                    { new Guid("1929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4522), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4522), null, false, "Cà phê kem trứng muối", 29000.0 },
                    { new Guid("1afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4580), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4581), null, false, "Bắp rang bơ", 15000.0 },
                    { new Guid("2649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4541), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4541), null, false, "Sinh tố bơ sầu riêng", 35000.0 },
                    { new Guid("26d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4505), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4505), null, false, "Cà phê sữa phin", 14000.0 },
                    { new Guid("2929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4524), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4524), null, false, "Cà phê cốt dừa", 29000.0 },
                    { new Guid("2afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4583), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4583), null, false, "Bắp rang bơ caramel", 20000.0 },
                    { new Guid("3649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4543), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4544), null, false, "Sinh tố xoài", 25000.0 },
                    { new Guid("36d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4508), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4508), null, false, "Cà phê đen đá Sài Gòn", 18000.0 },
                    { new Guid("3929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4526), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4526), null, false, "Cà phê trứng", 29000.0 },
                    { new Guid("3afeafff-f9d3-4a88-8a03-950482af826f"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4614), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4614), null, false, "Bắp rang bơ phô mai", 20000.0 },
                    { new Guid("4649ec15-fcec-4368-83f9-5b16f43fee5b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4545), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4546), null, false, "Sinh tố dâu tây", 25000.0 },
                    { new Guid("46d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4510), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4510), null, false, "Cà phê sữa đá Sài Gòn", 20000.0 },
                    { new Guid("4929dacf-d25a-4a8d-b647-c9a29d3d552b"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4528), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4528), null, false, "Cappuchino", 29000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48321"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4561), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4561), null, false, "Trà chanh", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48322"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4563), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4563), null, false, "Trà chanh dây", 22000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48323"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4565), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4565), null, false, "Trà lipton nóng - đá", 20000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48324"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4567), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4568), null, false, "Trà gừng nóng - đá", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48325"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4570), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4570), null, false, "Trà đào cam xả", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48326"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4572), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4572), null, false, "Trà vải", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48327"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4574), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4574), null, false, "Trà sen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48328"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4576), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4576), null, false, "Trà đen macchiato", 25000.0 },
                    { new Guid("5020bd91-1caf-4868-9fe5-9a1360c48329"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4578), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4579), null, false, "Trà dâu", 25000.0 },
                    { new Guid("56d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4512), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4513), null, false, "Bạc xỉu", 22000.0 },
                    { new Guid("66d3154f-b5e8-4b00-9262-a4215b43f6ee"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4515), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4515), null, false, "Ca cao nóng - đá", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e841a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4530), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4531), null, false, "Nước ép dưa hấu", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e842a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4533), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4533), null, false, "Nước ép cà rốt", 22000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e843a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4535), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4535), null, false, "Nước ép thơm", 25000.0 },
                    { new Guid("c3667f70-c2b7-4af9-8300-ad54c79e844a"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4537), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4537), null, false, "Nước ép cam", 25000.0 },
                    { new Guid("d135806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4547), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4548), null, false, "Trà sữa truyền thống", 22000.0 },
                    { new Guid("d18ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4554), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4555), null, false, "Trà olong cúc mật ong nóng", 22000.0 },
                    { new Guid("d235806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4549), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4550), null, false, "Trà sữa kem trứng muối", 29000.0 },
                    { new Guid("d28ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4557), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4557), null, false, "Trà hoa cúc nóng", 25000.0 },
                    { new Guid("d335806f-52da-434f-840b-ae253b0fbbff"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4552), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4553), null, false, "Trà sữa khoai môn", 25000.0 },
                    { new Guid("d38ca698-10a5-42e3-b044-3bdd2e5d81bd"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4559), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4559), null, false, "Trà chanh nóng", 22000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b1"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4517), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4517), null, false, "Cà phê đen máy", 16000.0 },
                    { new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b2"), true, new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4519), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4520), null, false, "Cà phê sữa máy", 18000.0 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "CurrentOrder", "DateCreated", "DateUpdated", "Description", "FloorId", "IsDeleted", "Position", "Rotation", "Shape", "Size" },
                values: new object[] { new Guid("1f3ebd56-dbf5-453f-819d-2757a152d0a5"), 0, new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4462), new DateTime(2022, 10, 27, 20, 41, 34, 49, DateTimeKind.Utc).AddTicks(4463), "101", new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"), false, "22,823660714285715-31,412337662337663", 0, "Rectangle", "9,988839285714286-9,983766233766234" });

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
