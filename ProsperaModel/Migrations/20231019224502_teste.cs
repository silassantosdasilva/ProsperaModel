using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsperaModel.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaBancariaModel",
                columns: table => new
                {
                    IdContBancaria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTitulaContBan = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NumContBan = table.Column<int>(type: "int", nullable: false),
                    AgenciaContBan = table.Column<int>(type: "int", nullable: false),
                    SaldoContBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoContBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ObsContBan = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancariaModel", x => x.IdContBancaria);
                });

            migrationBuilder.CreateTable(
                name: "DevedorModel",
                columns: table => new
                {
                    IdDevedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDevedor = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    EmailDevedor = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    TeleDevedor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tele2Devedor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EndereDevedor = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CidadeDevedor = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BairroDevedor = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UFDevedor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CEPDevedor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ObservaDevedor = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DatCadasDevedor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDevedor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SaldoDevedor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevedorModel", x => x.IdDevedor);
                });

            migrationBuilder.CreateTable(
                name: "StatusContBancariaModel",
                columns: table => new
                {
                    IdStatusContBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusContBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContBancariaModel = table.Column<int>(type: "int", nullable: false),
                    ContaBancariaModelIdContBancaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusContBancariaModel", x => x.IdStatusContBan);
                    table.ForeignKey(
                        name: "FK_StatusContBancariaModel_ContaBancariaModel_ContaBancariaModelIdContBancaria",
                        column: x => x.ContaBancariaModelIdContBancaria,
                        principalTable: "ContaBancariaModel",
                        principalColumn: "IdContBancaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerceirosModel",
                columns: table => new
                {
                    IdTerceiros = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTerceiros = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    TelefoneTerceiros = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefone2Terceiros = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailTerceiros = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    EnderecoTerceiros = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CidadeTerceiros = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BairroTerceiros = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UFTerceiros = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CEPTerceiros = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ObservacaoTerceiros = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataCadastroTerceiros = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusTerceiros = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SaldoTerceiros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdContaBancariaModel = table.Column<int>(type: "int", nullable: false),
                    ContaBancariaModelIdContBancaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerceirosModel", x => x.IdTerceiros);
                    table.ForeignKey(
                        name: "FK_TerceirosModel_ContaBancariaModel_ContaBancariaModelIdContBancaria",
                        column: x => x.ContaBancariaModelIdContBancaria,
                        principalTable: "ContaBancariaModel",
                        principalColumn: "IdContBancaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioModel",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SobrenomeUsuario = table.Column<string>(type: "nvarchar(105)", maxLength: 105, nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    SenhaUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CargoUsuario = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DatCadastroUsuario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatUltimoAcesUsuario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdTerceiros = table.Column<int>(type: "int", nullable: false),
                    TerceirosModelIdTerceiros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModel", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_UsuarioModel_TerceirosModel_TerceirosModelIdTerceiros",
                        column: x => x.TerceirosModelIdTerceiros,
                        principalTable: "TerceirosModel",
                        principalColumn: "IdTerceiros",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoUsuarioModel",
                columns: table => new
                {
                    IdConfiguracaoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioConfiguracaoUsuario = table.Column<int>(type: "int", nullable: false),
                    NotificacoesAtivadas = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoUsuarioModel", x => x.IdConfiguracaoUsuario);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoUsuarioModel_UsuarioModel_UsuarioConfiguracaoUsuario",
                        column: x => x.UsuarioConfiguracaoUsuario,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasPagarModel",
                columns: table => new
                {
                    IdContasPagar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCP = table.Column<int>(type: "int", nullable: false),
                    DatEmissaoCP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatVencimentoCP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DevedorCP = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    DescricaoCP = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ValorCP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusCP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MetodoPgtoCP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ObservacaoCP = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ContaBanCP = table.Column<int>(type: "int", nullable: false),
                    AgenciaContBanCP = table.Column<int>(type: "int", nullable: false),
                    UsuarioCP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagarModel", x => x.IdContasPagar);
                    table.ForeignKey(
                        name: "FK_ContasPagarModel_UsuarioModel_UsuarioCP",
                        column: x => x.UsuarioCP,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasReceberModel",
                columns: table => new
                {
                    IdContasReceber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCR = table.Column<int>(type: "int", nullable: false),
                    DatEmissaoCR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatVencimentoCR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DevedorCR = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    DescricaoCR = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ValorCR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusCR = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MetodoPgtoCR = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ObservacaoCR = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ContaBanCR = table.Column<int>(type: "int", nullable: false),
                    AgenciaContBanCR = table.Column<int>(type: "int", nullable: false),
                    UsuarioCR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasReceberModel", x => x.IdContasReceber);
                    table.ForeignKey(
                        name: "FK_ContasReceberModel_UsuarioModel_UsuarioCR",
                        column: x => x.UsuarioCR,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtratoModel",
                columns: table => new
                {
                    IdExtrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeExtrat = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TipoExtrat = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ValorExtrat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomBancoExtrat = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CodContaExtrat = table.Column<int>(type: "int", nullable: false),
                    DestinatarioExtrat = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    DataExtrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusExtrat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UsuarioExtrat = table.Column<int>(type: "int", nullable: false),
                    ObservacaoExtrat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtratoModel", x => x.IdExtrato);
                    table.ForeignKey(
                        name: "FK_ExtratoModel_UsuarioModel_UsuarioExtrat",
                        column: x => x.UsuarioExtrat,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaModel",
                columns: table => new
                {
                    IdMeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMeta = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DescMeta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DatInicioMeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTerminoMeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMeta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusMeta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ObservacaoMeta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CatMeta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioMeta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaModel", x => x.IdMeta);
                    table.ForeignKey(
                        name: "FK_MetaModel_UsuarioModel_UsuarioMeta",
                        column: x => x.UsuarioMeta,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoModel",
                columns: table => new
                {
                    IdOrcamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOrca = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DatEmissaoOrca = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidadeOrca = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoOrca = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ValorOrca = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObservacaoOrca = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    StatusOrca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NomeContatoOrca = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    TeleOrca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tele2Orca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailOrca = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    EnderecoOrca = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstadoOrca = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BairroOrca = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UsuarioOrca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoModel", x => x.IdOrcamento);
                    table.ForeignKey(
                        name: "FK_OrcamentoModel_UsuarioModel_UsuarioOrca",
                        column: x => x.UsuarioOrca,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusUsuarioModel",
                columns: table => new
                {
                    IdStatusUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUsuarioModel", x => x.IdStatusUsuario);
                    table.ForeignKey(
                        name: "FK_StatusUsuarioModel_UsuarioModel_UsuarioModelId",
                        column: x => x.UsuarioModelId,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferenciaModel",
                columns: table => new
                {
                    IdTransferencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinatarioTransfe = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NumContBan = table.Column<int>(type: "int", nullable: false),
                    AgenciaContBan = table.Column<int>(type: "int", nullable: false),
                    NomeBanTransfe = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ValorTransfe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoTransfe = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DatAgendaTransfere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoTransfe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioTransfe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferenciaModel", x => x.IdTransferencia);
                    table.ForeignKey(
                        name: "FK_TransferenciaModel_UsuarioModel_UsuarioTransfe",
                        column: x => x.UsuarioTransfe,
                        principalTable: "UsuarioModel",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusCRModel",
                columns: table => new
                {
                    IdStatusCR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRModel = table.Column<int>(type: "int", nullable: false),
                    ContasReceberModelIdContasReceber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCRModel", x => x.IdStatusCR);
                    table.ForeignKey(
                        name: "FK_StatusCRModel_ContasReceberModel_ContasReceberModelIdContasReceber",
                        column: x => x.ContasReceberModelIdContasReceber,
                        principalTable: "ContasReceberModel",
                        principalColumn: "IdContasReceber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusMetaModel",
                columns: table => new
                {
                    IdStatusMeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusMeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMetaModel", x => x.IdStatusMeta);
                    table.ForeignKey(
                        name: "FK_StatusMetaModel_MetaModel_MetaModelId",
                        column: x => x.MetaModelId,
                        principalTable: "MetaModel",
                        principalColumn: "IdMeta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrcamentoModel",
                columns: table => new
                {
                    IdStatusOrca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusOrca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrcamentoModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrcamentoModel", x => x.IdStatusOrca);
                    table.ForeignKey(
                        name: "FK_StatusOrcamentoModel_OrcamentoModel_OrcamentoModelId",
                        column: x => x.OrcamentoModelId,
                        principalTable: "OrcamentoModel",
                        principalColumn: "IdOrcamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusTransferenciaModel",
                columns: table => new
                {
                    IdStatusTransfe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusTransfe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferenciaModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTransferenciaModel", x => x.IdStatusTransfe);
                    table.ForeignKey(
                        name: "FK_StatusTransferenciaModel_TransferenciaModel_TransferenciaModelId",
                        column: x => x.TransferenciaModelId,
                        principalTable: "TransferenciaModel",
                        principalColumn: "IdTransferencia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoUsuarioModel_UsuarioConfiguracaoUsuario",
                table: "ConfiguracaoUsuarioModel",
                column: "UsuarioConfiguracaoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ContasPagarModel_UsuarioCP",
                table: "ContasPagarModel",
                column: "UsuarioCP");

            migrationBuilder.CreateIndex(
                name: "IX_ContasReceberModel_UsuarioCR",
                table: "ContasReceberModel",
                column: "UsuarioCR");

            migrationBuilder.CreateIndex(
                name: "IX_ExtratoModel_UsuarioExtrat",
                table: "ExtratoModel",
                column: "UsuarioExtrat");

            migrationBuilder.CreateIndex(
                name: "IX_MetaModel_UsuarioMeta",
                table: "MetaModel",
                column: "UsuarioMeta");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoModel_UsuarioOrca",
                table: "OrcamentoModel",
                column: "UsuarioOrca");

            migrationBuilder.CreateIndex(
                name: "IX_StatusContBancariaModel_ContaBancariaModelIdContBancaria",
                table: "StatusContBancariaModel",
                column: "ContaBancariaModelIdContBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCRModel_ContasReceberModelIdContasReceber",
                table: "StatusCRModel",
                column: "ContasReceberModelIdContasReceber");

            migrationBuilder.CreateIndex(
                name: "IX_StatusMetaModel_MetaModelId",
                table: "StatusMetaModel",
                column: "MetaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusOrcamentoModel_OrcamentoModelId",
                table: "StatusOrcamentoModel",
                column: "OrcamentoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransferenciaModel_TransferenciaModelId",
                table: "StatusTransferenciaModel",
                column: "TransferenciaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusUsuarioModel_UsuarioModelId",
                table: "StatusUsuarioModel",
                column: "UsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TerceirosModel_ContaBancariaModelIdContBancaria",
                table: "TerceirosModel",
                column: "ContaBancariaModelIdContBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_TransferenciaModel_UsuarioTransfe",
                table: "TransferenciaModel",
                column: "UsuarioTransfe");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModel_TerceirosModelIdTerceiros",
                table: "UsuarioModel",
                column: "TerceirosModelIdTerceiros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoUsuarioModel");

            migrationBuilder.DropTable(
                name: "ContasPagarModel");

            migrationBuilder.DropTable(
                name: "DevedorModel");

            migrationBuilder.DropTable(
                name: "ExtratoModel");

            migrationBuilder.DropTable(
                name: "StatusContBancariaModel");

            migrationBuilder.DropTable(
                name: "StatusCRModel");

            migrationBuilder.DropTable(
                name: "StatusMetaModel");

            migrationBuilder.DropTable(
                name: "StatusOrcamentoModel");

            migrationBuilder.DropTable(
                name: "StatusTransferenciaModel");

            migrationBuilder.DropTable(
                name: "StatusUsuarioModel");

            migrationBuilder.DropTable(
                name: "ContasReceberModel");

            migrationBuilder.DropTable(
                name: "MetaModel");

            migrationBuilder.DropTable(
                name: "OrcamentoModel");

            migrationBuilder.DropTable(
                name: "TransferenciaModel");

            migrationBuilder.DropTable(
                name: "UsuarioModel");

            migrationBuilder.DropTable(
                name: "TerceirosModel");

            migrationBuilder.DropTable(
                name: "ContaBancariaModel");
        }
    }
}
