using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Takke.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_name = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    Client_number = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    Client_Mobile = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Client_gender = table.Column<bool>(type: "bit", nullable: false),
                    Client_Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    registeration_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    notes = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    mainphoto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Client_id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Driver_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Driver_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Driver_birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Driver_gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    certificate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    registerationdate = table.Column<DateTime>(type: "date", nullable: false),
                    isdeleted = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Driver_id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KM_price = table.Column<double>(type: "float", nullable: false),
                    Hour_price = table.Column<double>(type: "float", nullable: false),
                    _5000_Cobon = table.Column<double>(name: "5000_Cobon", type: "float", nullable: false),
                    _10000_Cobon = table.Column<double>(name: "10000_Cobon", type: "float", nullable: false),
                    _25000_Cobon = table.Column<double>(name: "25000_Cobon", type: "float", nullable: false),
                    Lowest_Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entryname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    entryvalue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    entrytype = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Activation_code",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creating_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    registeration_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activation_code", x => x.id);
                    table.ForeignKey(
                        name: "FK_Activation_code_Client",
                        column: x => x.Client_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cardrift",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientid = table.Column<int>(type: "int", nullable: true),
                    annData = table.Column<DateTime>(type: "date", nullable: true),
                    departdate = table.Column<DateTime>(type: "date", nullable: true),
                    departtime = table.Column<TimeSpan>(type: "time", nullable: true),
                    departaddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    arriveaddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    departlocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    arrivelocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cartype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    numofclients = table.Column<int>(type: "int", nullable: true),
                    cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardrift", x => x.id);
                    table.ForeignKey(
                        name: "FK_cardrift_Client",
                        column: x => x.clientid,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client_payment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paid = table.Column<int>(type: "int", nullable: false),
                    paymentdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Client_id = table.Column<int>(type: "int", nullable: false),
                    isfromorder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_payment_Client",
                        column: x => x.Client_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cobon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cobon_value = table.Column<int>(type: "int", nullable: false),
                    Creation_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activation_code = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activated = table.Column<bool>(type: "bit", nullable: false),
                    Client_id = table.Column<int>(type: "int", nullable: false),
                    cobontype = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cobon_Client",
                        column: x => x.Client_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detailes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientid = table.Column<int>(type: "int", nullable: false),
                    detailvalue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    detailname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detailes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detailes_Client",
                        column: x => x.clientid,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favourite_address",
                columns: table => new
                {
                    Address_id = table.Column<int>(type: "int", nullable: false),
                    Client_id = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    typeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorit_address", x => x.Address_id);
                    table.ForeignKey(
                        name: "FK_Favourite_address_Client",
                        column: x => x.Client_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Massage",
                columns: table => new
                {
                    Massage_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Massage_type = table.Column<int>(type: "int", nullable: false),
                    Client_id = table.Column<int>(type: "int", nullable: false),
                    Message_content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Read_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isread = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Massage", x => x.Massage_ID);
                    table.ForeignKey(
                        name: "FK_Massage_Client",
                        column: x => x.Client_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification_",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notification_id = table.Column<int>(type: "int", nullable: false),
                    Notification_text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Is_read = table.Column<bool>(type: "bit", nullable: false),
                    Client_id = table.Column<int>(type: "int", nullable: false),
                    notificationdate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification_", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notification__Client",
                        column: x => x.Client_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car_",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Car_number = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    madeyear = table.Column<int>(type: "int", nullable: false),
                    manufacture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tarvel_distance = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    Car_Model = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    Driver_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_", x => x.id);
                    table.ForeignKey(
                        name: "FK_Car__Driver",
                        column: x => x.Driver_id,
                        principalTable: "Driver",
                        principalColumn: "Driver_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Driver_payment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Paid = table.Column<int>(type: "int", nullable: false),
                    Driver_id = table.Column<int>(type: "int", nullable: false),
                    orderid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver_payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Driver_payment_Driver",
                        column: x => x.Driver_id,
                        principalTable: "Driver",
                        principalColumn: "Driver_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Driver_salary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receipt_number = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Driver_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver_salary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Driver_salary_Driver",
                        column: x => x.Driver_id,
                        principalTable: "Driver",
                        principalColumn: "Driver_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Approximate_cost = table.Column<int>(type: "int", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Paid = table.Column<int>(type: "int", nullable: false),
                    Source_details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destenation_details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Client_id = table.Column<int>(type: "int", nullable: false),
                    Driver_id = table.Column<int>(type: "int", nullable: false),
                    source_location = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    destenation_location = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    order_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_Order_Client",
                        column: x => x.Client_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Driver",
                        column: x => x.Driver_id,
                        principalTable: "Driver",
                        principalColumn: "Driver_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "driftpassenger",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driftid = table.Column<int>(type: "int", nullable: true),
                    clientid = table.Column<int>(type: "int", nullable: true),
                    requestdate = table.Column<DateTime>(type: "date", nullable: true),
                    requesttime = table.Column<TimeSpan>(type: "time", nullable: true),
                    isapproved = table.Column<bool>(type: "bit", nullable: true),
                    ispayed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driftpassenger", x => x.id);
                    table.ForeignKey(
                        name: "FK_driftpassenger_cardrift",
                        column: x => x.driftid,
                        principalTable: "cardrift",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Type",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    typename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Type", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Type_Order",
                        column: x => x.id,
                        principalTable: "Order",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favourite_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorit_type_Order_Type",
                        column: x => x.typename,
                        principalTable: "Order_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activation_code_Client_id",
                table: "Activation_code",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Car__Driver_id",
                table: "Car_",
                column: "Driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_cardrift_clientid",
                table: "cardrift",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_Client_payment_Client_id",
                table: "Client_payment",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cobon_Client_id",
                table: "Cobon",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detailes_clientid",
                table: "Detailes",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_driftpassenger_driftid",
                table: "driftpassenger",
                column: "driftid");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_payment_Driver_id",
                table: "Driver_payment",
                column: "Driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_salary_Driver_id",
                table: "Driver_salary",
                column: "Driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_address_Client_id",
                table: "Favourite_address",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_type_typename",
                table: "Favourite_type",
                column: "typename");

            migrationBuilder.CreateIndex(
                name: "IX_Massage_Client_id",
                table: "Massage",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification__Client_id",
                table: "Notification_",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Client_id",
                table: "Order",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Driver_id",
                table: "Order",
                column: "Driver_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activation_code");

            migrationBuilder.DropTable(
                name: "Car_");

            migrationBuilder.DropTable(
                name: "Client_payment");

            migrationBuilder.DropTable(
                name: "Cobon");

            migrationBuilder.DropTable(
                name: "Detailes");

            migrationBuilder.DropTable(
                name: "driftpassenger");

            migrationBuilder.DropTable(
                name: "Driver_payment");

            migrationBuilder.DropTable(
                name: "Driver_salary");

            migrationBuilder.DropTable(
                name: "Favourite_address");

            migrationBuilder.DropTable(
                name: "Favourite_type");

            migrationBuilder.DropTable(
                name: "Massage");

            migrationBuilder.DropTable(
                name: "Notification_");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "cardrift");

            migrationBuilder.DropTable(
                name: "Order_Type");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
