using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_APIOracle.Migrations
{
    public partial class addASM_Z_ROLES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductRecordId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "CM_HINMO_ALL");

            migrationBuilder.AddColumn<string>(
                name: "ITM_CD",
                table: "CM_HINMO_ALL",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CO_CD",
                table: "CM_HINMO_ALL",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ITM_NM",
                table: "CM_HINMO_ALL",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PROD_ITM_GRP_CD",
                table: "CM_HINMO_ALL",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UNIT_CD",
                table: "CM_HINMO_ALL",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CM_HINMO_ALL",
                table: "CM_HINMO_ALL",
                column: "ITM_CD");

            migrationBuilder.CreateTable(
                name: "custItemCds",
                columns: table => new
                {
                    ITM_CD = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CST_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CST_ITM_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CST_ITM_NM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custItemCds", x => x.ITM_CD);
                });

            migrationBuilder.CreateTable(
                name: "HM_TOKUIH_ALL",
                columns: table => new
                {
                    ITM_CD = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CST_CD = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CO_CD = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CST_ITM_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CST_ITM_NM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    INVALID_FLG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    INS_TS = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    INS_USR_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UPD_CNTR = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    UPD_TS = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UPD_USR_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HM_TOKUIH_ALL", x => new { x.ITM_CD, x.CO_CD, x.CST_CD });
                });

            migrationBuilder.CreateTable(
                name: "MANUFACTURE_PRINT_LABEL",
                columns: table => new
                {
                    PRINT_ID_H = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TOUNYU_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ITM_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LOT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PALLETE_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PRINT_DT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PRINT_LOC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PRINT_FLG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUFACTURE_PRINT_LABEL", x => x.PRINT_ID_H);
                });

            migrationBuilder.CreateTable(
                name: "ST_ORDER_ALL",
                columns: table => new
                {
                    ORD_NO = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    BR_NO = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CO_CD = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ORD_TYP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ITM_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ITM_NM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PROD_LOC_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PROD_ST_SCHD_DT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ST_ORDER_ALL", x => new { x.CO_CD, x.BR_NO, x.ORD_NO });
                });

            migrationBuilder.CreateTable(
                name: "ST_TOUNYU_ALL",
                columns: table => new
                {
                    INPT_NO = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CO_CD = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    INST_NO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    C_ITM_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ST_TOUNYU_ALL", x => new { x.CO_CD, x.INPT_NO });
                });

            migrationBuilder.CreateTable(
                name: "WM_USER",
                columns: table => new
                {
                    USR_ID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CO_CD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PASSWORD = table.Column<byte[]>(type: "RAW(2000)", nullable: false),
                    INVALIDATE_FLG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WM_USER", x => x.USR_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "custItemCds");

            migrationBuilder.DropTable(
                name: "HM_TOKUIH_ALL");

            migrationBuilder.DropTable(
                name: "MANUFACTURE_PRINT_LABEL");

            migrationBuilder.DropTable(
                name: "ST_ORDER_ALL");

            migrationBuilder.DropTable(
                name: "ST_TOUNYU_ALL");

            migrationBuilder.DropTable(
                name: "WM_USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CM_HINMO_ALL",
                table: "CM_HINMO_ALL");

            migrationBuilder.DropColumn(
                name: "ITM_CD",
                table: "CM_HINMO_ALL");

            migrationBuilder.DropColumn(
                name: "CO_CD",
                table: "CM_HINMO_ALL");

            migrationBuilder.DropColumn(
                name: "ITM_NM",
                table: "CM_HINMO_ALL");

            migrationBuilder.DropColumn(
                name: "PROD_ITM_GRP_CD",
                table: "CM_HINMO_ALL");

            migrationBuilder.DropColumn(
                name: "UNIT_CD",
                table: "CM_HINMO_ALL");

            migrationBuilder.RenameTable(
                name: "CM_HINMO_ALL",
                newName: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductRecordId",
                table: "Products",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0)
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "NVARCHAR2(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Products",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "NVARCHAR2(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductRecordId");
        }
    }
}
