using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class anything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BartenderId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "Bills",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Coupon",
                table: "Bills",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025415ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "d724d0be-4835-4f75-9b74-41321267b495", new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9340), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9341), "d8ec46a0-df03-4162-8883-fe52377032a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025416ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "7854954d-4088-4ede-81da-9726073bb003", new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9333), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9333), "ba791f2d-f1c5-4791-96ab-1bae52e616ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025417ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "c48d9dc6-dca5-4606-854f-74c42289f272", new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9325), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9325), "093cfb5a-17ea-40ca-9150-79df4f1c8576" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025418ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "e6ff2f24-45d7-4c98-8987-571637cf1a8b", new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9299), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9308), "12280d81-ddce-4ac0-83c4-156f7fdf4203" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9487), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9490), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9492), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9494), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9499), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9499) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9501), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9503), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9503) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9505), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9506) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9507), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9508) });

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9397), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9398) });

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("eb22e2ea-0305-4778-a129-f400e6a64447"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9382), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9383) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9581), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9582) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("16d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9526), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9555), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1afeafff-f9d3-4a88-8a03-950482af826f"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9648), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9648) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9584), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("26d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9530), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9558), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9559) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2afeafff-f9d3-4a88-8a03-950482af826f"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9650), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9652) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9587), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("36d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9536), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9561), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3afeafff-f9d3-4a88-8a03-950482af826f"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9654), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9655) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("4649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9590), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("46d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9540), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("4929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9567), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48321"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9616), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9617) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48322"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9620), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48323"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9623), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9624) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48324"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9627), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48325"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9632), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9632) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48326"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9635), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9635) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48327"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9638), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48328"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9640), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9641) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48329"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9643), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9644) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("56d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9543), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("66d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9546), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9546) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e841a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9570), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e842a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9573), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e843a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9576), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e844a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9579), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d135806f-52da-434f-840b-ae253b0fbbff"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9596), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9596) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d18ca698-10a5-42e3-b044-3bdd2e5d81bd"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9606), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9606) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d235806f-52da-434f-840b-ae253b0fbbff"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9599), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9599) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d28ca698-10a5-42e3-b044-3bdd2e5d81bd"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9609), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d335806f-52da-434f-840b-ae253b0fbbff"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9602), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d38ca698-10a5-42e3-b044-3bdd2e5d81bd"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9613), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9614) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b1"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9549), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9549) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b2"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9552), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9552) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("1f3ebd56-dbf5-453f-819d-2757a152d0a5"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9465), new DateTime(2023, 11, 1, 18, 1, 35, 803, DateTimeKind.Utc).AddTicks(9467) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BartenderId",
                table: "Orders",
                column: "BartenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_BartenderId",
                table: "Orders",
                column: "BartenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_BartenderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BartenderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BartenderId",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "Bills",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Coupon",
                table: "Bills",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025415ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "c2c8cb03-d09a-4fc3-b370-5d08265952d0", new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8474), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8474), "d0af4e82-2362-4376-a1cf-3fd39b433873" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025416ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "1b55d5a4-657e-43df-b154-fe7a023185a7", new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8466), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8466), "4506a731-ec28-4ef3-a082-3a4a40a9a29c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025417ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "c2d33395-0e90-48f2-97ec-31c696e73635", new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8460), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8460), "ddacd69a-8af1-45a9-8eef-8c222592336a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acc7a1a-ae85-4e5a-8cb7-0b47025418ac",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "SecurityStamp" },
                values: new object[] { "cf6ee6fd-73a4-40b1-967b-f3b0323a835f", new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8447), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8451), "284a5d56-cde8-4367-b1e7-1ec0c8afb8bf" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8541), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8545), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8545) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8549), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8549) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8551), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8551) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8553), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8556), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8556) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8558), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8558) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8561), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8561) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8563), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8563) });

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("eb22e2ea-0305-4778-a129-f400e6a64445"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8512), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8512) });

            migrationBuilder.UpdateData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("eb22e2ea-0305-4778-a129-f400e6a64447"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8500), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8627), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("16d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8575), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8575) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8602), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1afeafff-f9d3-4a88-8a03-950482af826f"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8733), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8734) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8665), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8665) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("26d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8578), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8579) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8605), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2afeafff-f9d3-4a88-8a03-950482af826f"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8738), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8739) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8668), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8669) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("36d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8581), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8582) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8608), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8608) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3afeafff-f9d3-4a88-8a03-950482af826f"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8742), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8742) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("4649ec15-fcec-4368-83f9-5b16f43fee5b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8672), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8672) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("46d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8585), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8587) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("4929dacf-d25a-4a8d-b647-c9a29d3d552b"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8611), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48321"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8693), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8693) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48322"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8696), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48323"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8699), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8699) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48324"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8702), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48325"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8706), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8706) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48326"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8714), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8715) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48327"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8719), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48328"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8722), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8723) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5020bd91-1caf-4868-9fe5-9a1360c48329"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8728), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8729) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("56d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8590), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("66d3154f-b5e8-4b00-9262-a4215b43f6ee"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8593), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e841a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8615), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e842a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8618), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8619) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e843a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8621), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8622) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("c3667f70-c2b7-4af9-8300-ad54c79e844a"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8624), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d135806f-52da-434f-840b-ae253b0fbbff"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8675), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d18ca698-10a5-42e3-b044-3bdd2e5d81bd"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8684), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8684) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d235806f-52da-434f-840b-ae253b0fbbff"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8678), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8678) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d28ca698-10a5-42e3-b044-3bdd2e5d81bd"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8687), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8687) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d335806f-52da-434f-840b-ae253b0fbbff"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8681), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8681) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d38ca698-10a5-42e3-b044-3bdd2e5d81bd"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8690), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b1"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8596), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8596) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b2"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8599), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8599) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("1f3ebd56-dbf5-453f-819d-2757a152d0a5"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8527), new DateTime(2022, 11, 2, 14, 32, 48, 608, DateTimeKind.Utc).AddTicks(8528) });
        }
    }
}
