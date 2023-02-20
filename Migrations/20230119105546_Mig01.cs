using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tenchex.Migrations
{
    /// <inheritdoc />
    public partial class Mig01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cables",
                columns: table => new
                {
                    CableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KKS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CableType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.CableId);
                });

            migrationBuilder.CreateTable(
                name: "Compressors",
                columns: table => new
                {
                    CompressorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KKS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompressorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compressors", x => x.CompressorId);
                });

            migrationBuilder.CreateTable(
                name: "DiffrentialPressureGauge",
                columns: table => new
                {
                    DiffrentialPressureGaugeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpanRange = table.Column<short>(type: "smallint", nullable: true),
                    Accuracy = table.Column<byte>(type: "tinyint", nullable: true),
                    Repeatabilty = table.Column<byte>(type: "tinyint", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MountingBracket = table.Column<bool>(type: "bit", nullable: true),
                    MountingBracketMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialSize = table.Column<short>(type: "smallint", nullable: true),
                    CaseFilling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlassType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverPressureProtector = table.Column<bool>(type: "bit", nullable: true),
                    BlowOutProtection = table.Column<bool>(type: "bit", nullable: true),
                    Siphone = table.Column<bool>(type: "bit", nullable: true),
                    Manifold = table.Column<bool>(type: "bit", nullable: true),
                    ManifoldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManifoldMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaphragmSeal = table.Column<bool>(type: "bit", nullable: true),
                    DiaphragmSealMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabillaryTubes = table.Column<bool>(type: "bit", nullable: true),
                    CabillaryTubesMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiffrentialPressureGauge", x => x.DiffrentialPressureGaugeId);
                });

            migrationBuilder.CreateTable(
                name: "DiffrentialPressureTransmitter",
                columns: table => new
                {
                    DiffrentialPressureTransmitterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpanRange = table.Column<short>(type: "smallint", nullable: true),
                    CallibrationRange = table.Column<short>(type: "smallint", nullable: true),
                    SensorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accuracy = table.Column<byte>(type: "tinyint", nullable: true),
                    Repeatabilty = table.Column<byte>(type: "tinyint", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lcd = table.Column<bool>(type: "bit", nullable: true),
                    KeyPad = table.Column<bool>(type: "bit", nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _420mA = table.Column<bool>(type: "bit", nullable: true),
                    Installation = table.Column<bool>(type: "bit", nullable: true),
                    MountingBracket = table.Column<bool>(type: "bit", nullable: true),
                    MountingBracketMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manifold = table.Column<bool>(type: "bit", nullable: true),
                    ManifoldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManifoldMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaphragmSeal = table.Column<bool>(type: "bit", nullable: true),
                    DiaphragmSealMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabillaryTubes = table.Column<bool>(type: "bit", nullable: true),
                    CabillaryTubesMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiffrentialPressureTransmitter", x => x.DiffrentialPressureTransmitterId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Pipes",
                columns: table => new
                {
                    PipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KKS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NominalDiameter = table.Column<short>(type: "smallint", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipes", x => x.PipeId);
                });

            migrationBuilder.CreateTable(
                name: "PressureGauge",
                columns: table => new
                {
                    PressureGaugeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpanRange = table.Column<short>(type: "smallint", nullable: true),
                    Accuracy = table.Column<byte>(type: "tinyint", nullable: true),
                    Repeatabilty = table.Column<byte>(type: "tinyint", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MountingBracket = table.Column<bool>(type: "bit", nullable: true),
                    MountingBracketMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialSize = table.Column<short>(type: "smallint", nullable: true),
                    CaseFilling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlassType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverPressureProtector = table.Column<bool>(type: "bit", nullable: true),
                    BlowOutProtection = table.Column<bool>(type: "bit", nullable: true),
                    Siphone = table.Column<bool>(type: "bit", nullable: true),
                    Manifold = table.Column<bool>(type: "bit", nullable: true),
                    ManifoldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManifoldMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaphragmSeal = table.Column<bool>(type: "bit", nullable: true),
                    DiaphragmSealMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabillaryTubes = table.Column<bool>(type: "bit", nullable: true),
                    CabillaryTubesMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressureGauge", x => x.PressureGaugeId);
                });

            migrationBuilder.CreateTable(
                name: "PressureTransmitter",
                columns: table => new
                {
                    PressureTransmitterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpanRange = table.Column<short>(type: "smallint", nullable: true),
                    CallibrationRange = table.Column<short>(type: "smallint", nullable: true),
                    SensorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accuracy = table.Column<byte>(type: "tinyint", nullable: true),
                    Repeatabilty = table.Column<byte>(type: "tinyint", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lcd = table.Column<bool>(type: "bit", nullable: true),
                    KeyPad = table.Column<bool>(type: "bit", nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _420mA = table.Column<bool>(type: "bit", nullable: true),
                    Installation = table.Column<bool>(type: "bit", nullable: true),
                    MountingBracket = table.Column<bool>(type: "bit", nullable: true),
                    MountingBracketMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manifold = table.Column<bool>(type: "bit", nullable: true),
                    ManifoldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManifoldMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaphragmSeal = table.Column<bool>(type: "bit", nullable: true),
                    DiaphragmSealMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabillaryTubes = table.Column<bool>(type: "bit", nullable: true),
                    CabillaryTubesMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressureTransmitter", x => x.PressureTransmitterId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectLocation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectOwner = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectConsultant = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ProjectCatogry = table.Column<int>(type: "int", nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Pumps",
                columns: table => new
                {
                    PumpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KKS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PumpTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pumps", x => x.PumpId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierOrigin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KKS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TankDimensions = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.TankId);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureGauge",
                columns: table => new
                {
                    TemperatureGaugeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionToThermowell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertionLength = table.Column<short>(type: "smallint", nullable: true),
                    EmersionLength = table.Column<short>(type: "smallint", nullable: true),
                    TotalLength = table.Column<short>(type: "smallint", nullable: true),
                    WaveFrequencyCalculation = table.Column<bool>(type: "bit", nullable: true),
                    StemLength = table.Column<short>(type: "smallint", nullable: true),
                    StemDiameter = table.Column<byte>(type: "tinyint", nullable: true),
                    SpanRange = table.Column<short>(type: "smallint", nullable: true),
                    SensorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accuracy = table.Column<byte>(type: "tinyint", nullable: true),
                    Repeatabilty = table.Column<byte>(type: "tinyint", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThermowellType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThermowellProcessConnection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThermowellProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialSize = table.Column<short>(type: "smallint", nullable: true),
                    CaseFilling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlassType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureGauge", x => x.TemperatureGaugeId);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureTransmitter",
                columns: table => new
                {
                    TemperatureTransmitterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionToThermowell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertionLength = table.Column<short>(type: "smallint", nullable: true),
                    EmersionLength = table.Column<short>(type: "smallint", nullable: true),
                    TotalLength = table.Column<short>(type: "smallint", nullable: true),
                    WaveFrequencyCalculation = table.Column<bool>(type: "bit", nullable: true),
                    StemLength = table.Column<short>(type: "smallint", nullable: true),
                    StemDiameter = table.Column<byte>(type: "tinyint", nullable: true),
                    SpanRange = table.Column<short>(type: "smallint", nullable: true),
                    CallibrationRange = table.Column<short>(type: "smallint", nullable: true),
                    SensorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accuracy = table.Column<byte>(type: "tinyint", nullable: true),
                    Repeatabilty = table.Column<byte>(type: "tinyint", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lcd = table.Column<bool>(type: "bit", nullable: true),
                    KeyPad = table.Column<bool>(type: "bit", nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _420mA = table.Column<bool>(type: "bit", nullable: true),
                    ThermowellType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThermowellProcessConnection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThermowellProcessConnectionMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureTransmitter", x => x.TemperatureTransmitterId);
                });

            migrationBuilder.CreateTable(
                name: "Valves",
                columns: table => new
                {
                    ValveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KKS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ValveType = table.Column<int>(type: "int", nullable: false),
                    BodyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valves", x => x.ValveId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VendorOrigin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    SystemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SystemFluid = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.SystemId);
                    table.ForeignKey(
                        name: "FK_Systems_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "Instrumentations",
                columns: table => new
                {
                    InstrumentationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentType = table.Column<int>(type: "int", nullable: false),
                    PressureGaugeId = table.Column<int>(type: "int", nullable: true),
                    PressureTransmitterId = table.Column<int>(type: "int", nullable: true),
                    DiffrentialPressureGaugeId = table.Column<int>(type: "int", nullable: true),
                    DiffrentialPressureTransmitterId = table.Column<int>(type: "int", nullable: true),
                    TemperatureTransmitterId = table.Column<int>(type: "int", nullable: true),
                    TemperatureGaugeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumentations", x => x.InstrumentationId);
                    table.ForeignKey(
                        name: "FK_Instrumentations_DiffrentialPressureGauge_DiffrentialPressureGaugeId",
                        column: x => x.DiffrentialPressureGaugeId,
                        principalTable: "DiffrentialPressureGauge",
                        principalColumn: "DiffrentialPressureGaugeId");
                    table.ForeignKey(
                        name: "FK_Instrumentations_DiffrentialPressureTransmitter_DiffrentialPressureTransmitterId",
                        column: x => x.DiffrentialPressureTransmitterId,
                        principalTable: "DiffrentialPressureTransmitter",
                        principalColumn: "DiffrentialPressureTransmitterId");
                    table.ForeignKey(
                        name: "FK_Instrumentations_PressureGauge_PressureGaugeId",
                        column: x => x.PressureGaugeId,
                        principalTable: "PressureGauge",
                        principalColumn: "PressureGaugeId");
                    table.ForeignKey(
                        name: "FK_Instrumentations_PressureTransmitter_PressureTransmitterId",
                        column: x => x.PressureTransmitterId,
                        principalTable: "PressureTransmitter",
                        principalColumn: "PressureTransmitterId");
                    table.ForeignKey(
                        name: "FK_Instrumentations_TemperatureGauge_TemperatureGaugeId",
                        column: x => x.TemperatureGaugeId,
                        principalTable: "TemperatureGauge",
                        principalColumn: "TemperatureGaugeId");
                    table.ForeignKey(
                        name: "FK_Instrumentations_TemperatureTransmitter_TemperatureTransmitterId",
                        column: x => x.TemperatureTransmitterId,
                        principalTable: "TemperatureTransmitter",
                        principalColumn: "TemperatureTransmitterId");
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentId = table.Column<int>(type: "int", nullable: true),
                    CableId = table.Column<int>(type: "int", nullable: true),
                    PipeId = table.Column<int>(type: "int", nullable: true),
                    CompressorId = table.Column<int>(type: "int", nullable: true),
                    TankId = table.Column<int>(type: "int", nullable: true),
                    PumpId = table.Column<int>(type: "int", nullable: true),
                    ValveId = table.Column<int>(type: "int", nullable: true),
                    InstrumentationsInstrumentationId = table.Column<int>(type: "int", nullable: true),
                    CablesCableId = table.Column<int>(type: "int", nullable: true),
                    PipesPipeId = table.Column<int>(type: "int", nullable: true),
                    CompressorsCompressorId = table.Column<int>(type: "int", nullable: true),
                    TanksTankId = table.Column<int>(type: "int", nullable: true),
                    PumpsPumpId = table.Column<int>(type: "int", nullable: true),
                    ValvesValveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Types_Cables_CablesCableId",
                        column: x => x.CablesCableId,
                        principalTable: "Cables",
                        principalColumn: "CableId");
                    table.ForeignKey(
                        name: "FK_Types_Compressors_CompressorsCompressorId",
                        column: x => x.CompressorsCompressorId,
                        principalTable: "Compressors",
                        principalColumn: "CompressorId");
                    table.ForeignKey(
                        name: "FK_Types_Instrumentations_InstrumentationsInstrumentationId",
                        column: x => x.InstrumentationsInstrumentationId,
                        principalTable: "Instrumentations",
                        principalColumn: "InstrumentationId");
                    table.ForeignKey(
                        name: "FK_Types_Pipes_PipesPipeId",
                        column: x => x.PipesPipeId,
                        principalTable: "Pipes",
                        principalColumn: "PipeId");
                    table.ForeignKey(
                        name: "FK_Types_Pumps_PumpsPumpId",
                        column: x => x.PumpsPumpId,
                        principalTable: "Pumps",
                        principalColumn: "PumpId");
                    table.ForeignKey(
                        name: "FK_Types_Tanks_TanksTankId",
                        column: x => x.TanksTankId,
                        principalTable: "Tanks",
                        principalColumn: "TankId");
                    table.ForeignKey(
                        name: "FK_Types_Valves_ValvesValveId",
                        column: x => x.ValvesValveId,
                        principalTable: "Valves",
                        principalColumn: "ValveId");
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentCategory = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UnitePrice = table.Column<float>(type: "real", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Quantities = table.Column<short>(type: "smallint", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false),
                    TypesTypeId = table.Column<int>(type: "int", nullable: true),
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: true),
                    SuppliersSupplierId = table.Column<int>(type: "int", nullable: true),
                    VendorsVendorID = table.Column<int>(type: "int", nullable: true),
                    SystemsSystemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Equipments_Suppliers_SuppliersSupplierId",
                        column: x => x.SuppliersSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                    table.ForeignKey(
                        name: "FK_Equipments_Systems_SystemsSystemId",
                        column: x => x.SystemsSystemId,
                        principalTable: "Systems",
                        principalColumn: "SystemId");
                    table.ForeignKey(
                        name: "FK_Equipments_Types_TypesTypeId",
                        column: x => x.TypesTypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "FK_Equipments_Vendors_VendorsVendorID",
                        column: x => x.VendorsVendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EmployeesEmployeeId",
                table: "Equipments",
                column: "EmployeesEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SuppliersSupplierId",
                table: "Equipments",
                column: "SuppliersSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SystemsSystemId",
                table: "Equipments",
                column: "SystemsSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_TypesTypeId",
                table: "Equipments",
                column: "TypesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_VendorsVendorID",
                table: "Equipments",
                column: "VendorsVendorID");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentations_DiffrentialPressureGaugeId",
                table: "Instrumentations",
                column: "DiffrentialPressureGaugeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentations_DiffrentialPressureTransmitterId",
                table: "Instrumentations",
                column: "DiffrentialPressureTransmitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentations_PressureGaugeId",
                table: "Instrumentations",
                column: "PressureGaugeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentations_PressureTransmitterId",
                table: "Instrumentations",
                column: "PressureTransmitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentations_TemperatureGaugeId",
                table: "Instrumentations",
                column: "TemperatureGaugeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentations_TemperatureTransmitterId",
                table: "Instrumentations",
                column: "TemperatureTransmitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_ProjectsProjectId",
                table: "Systems",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_CablesCableId",
                table: "Types",
                column: "CablesCableId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_CompressorsCompressorId",
                table: "Types",
                column: "CompressorsCompressorId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_InstrumentationsInstrumentationId",
                table: "Types",
                column: "InstrumentationsInstrumentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_PipesPipeId",
                table: "Types",
                column: "PipesPipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_PumpsPumpId",
                table: "Types",
                column: "PumpsPumpId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_TanksTankId",
                table: "Types",
                column: "TanksTankId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_ValvesValveId",
                table: "Types",
                column: "ValvesValveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Cables");

            migrationBuilder.DropTable(
                name: "Compressors");

            migrationBuilder.DropTable(
                name: "Instrumentations");

            migrationBuilder.DropTable(
                name: "Pipes");

            migrationBuilder.DropTable(
                name: "Pumps");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "Valves");

            migrationBuilder.DropTable(
                name: "DiffrentialPressureGauge");

            migrationBuilder.DropTable(
                name: "DiffrentialPressureTransmitter");

            migrationBuilder.DropTable(
                name: "PressureGauge");

            migrationBuilder.DropTable(
                name: "PressureTransmitter");

            migrationBuilder.DropTable(
                name: "TemperatureGauge");

            migrationBuilder.DropTable(
                name: "TemperatureTransmitter");
        }
    }
}
