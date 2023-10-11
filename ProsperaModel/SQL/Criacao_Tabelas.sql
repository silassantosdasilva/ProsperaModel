-- Tabela de Extrato
CREATE TABLE Extrato (
    IdExtrato INT PRIMARY KEY,
    NomeExtrat VARCHAR(25) NOT NULL,
    TipoExtrat VARCHAR(25) UNIQUE NOT NULL,
    ValorExtrat MONEY NOT NULL,
    NomBancoExtrat VARCHAR(25) NOT NULL,
    CodContaExtrat INT NOT NULL,
    DestinatarioExtrat VARCHAR(120) NOT NULL,
    DataExtrat DATE NOT NULL,
    StatusExtrat VARCHAR(20),
    UsuarioExtrat INT,
    ObservacaoExtrat VARCHAR(50)
);

CREATE TABLE Meta (
    IdMeta INT PRIMARY KEY,
    NomeMeta VARCHAR(25),
    DescMeta VARCHAR(80),
    DatInicioMeta DATE,
    DataTerminoMeta DATE,
    ValorMeta MONEY,
    StatusMeta VARCHAR(20),
    ObservacaoMeta VARCHAR(80),
    CatMeta VARCHAR(50),
    UsuarioMeta INT
);

CREATE TABLE ContasReceber (
    IdContasReceber INT PRIMARY KEY,
    CodCR INT,
    DatEmissaoCR DATE,
    DatVencimentoCR DATE,
    DevedorCR VARCHAR(120),
    DescricaoCR VARCHAR(80),
    ValorCR MONEY,
    StatusCR VARCHAR(20),
    MetodoPgtoCR VARCHAR(20),
    ObservacaoCR VARCHAR(80),
    ContaBanCR INT,
    AgenciaContBanCR INT,
    UsuarioCR INT
);

CREATE TABLE ContasPagar (
    IdContasPagar INT PRIMARY KEY,
    CodCP INT,
    DatEmissaoCP DATE,
    DatVencimentoCP DATE,
    DevedorCP VARCHAR(120),
    DescricaoCP VARCHAR(80),
    ValorCP MONEY,
    StatusCP VARCHAR(20),
    MetodoPgtoCP VARCHAR(20),
    ObservacaoCP VARCHAR(80),
    ContaBanCP INT,
    AgenciaContBanCP INT,
    UsuarioCP INT
);

CREATE TABLE Orcamento (
    IdOrcamento INT PRIMARY KEY,
    NomeOrca VARCHAR(80),
    DatEmissaoOrca DATE,
    DataValidadeOrca DATE,
    DescricaoOrca VARCHAR(80),
    ValorOrca MONEY,
    ObservacaoOrca VARCHAR(80),
    StatusOrca VARCHAR(20),
    EnderecoOrca VARCHAR(80),
    NomeContatoOrca VARCHAR(120),
    TeleOrca VARCHAR(20),
    Tele2Orca VARCHAR(20),
    EmailOrca VARCHAR(120),
    EstadoOrca VARCHAR(80),
    BairroOrca VARCHAR(80),
    UsuarioOrca INT
);

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY,
    NomeUsuario VARCHAR(25),
    SobrenomeUsuario VARCHAR(105),
    EmailUsuario VARCHAR(120),
    SenhaUsuario VARCHAR(20),
    CargoUsuario VARCHAR(80),
    DatCadastroUsuario DATE,
    DatUltimoAcesUsuario DATE,
    StatusUsuario VARCHAR(20)
);

CREATE TABLE ConfiguracaoUsuario (
    IdConfiguracaoUsuario INT PRIMARY KEY,
    IdUsuario INT,
    NotificacoesAtivadas BIT
);

CREATE TABLE ContaBancaria (
    IdContBancaria INT PRIMARY KEY,
    NomeTitulaContBan VARCHAR(120),
    NumContBan INT,
    AgenciaContBan INT,
    SaldoContBan MONEY,
    TipoContBan VARCHAR(50),
    ObsContBan VARCHAR(80),
    UsuarioContBan INT
);

CREATE TABLE Transferencia (
    IdTransferencia INT PRIMARY KEY,
    DestinatarioTransfe VARCHAR(120),
    NumContBan INT,
    AgenciaContBan INT,
    NomeBanTransfe VARCHAR(80),
    ValorTransfe MONEY,
    DescricaoTransfe VARCHAR(80),
    DatAgendaTransfere DATE,
    TipoTransfe VARCHAR(50),
    UsuarioTransfe INT
);

CREATE TABLE Devedor (
    IdDevedor INT PRIMARY KEY,
    NomDevedor VARCHAR(120),
    EndereDevedor VARCHAR(80),
    CidadeDevedor VARCHAR(80),
    BairroDevedor VARCHAR(80),
    UFDevedor VARCHAR(10),
    CEPDevedor VARCHAR(10),
    TeleDevedor VARCHAR(20),
    Tele2Devedor VARCHAR(20),
    EmailDevedor VARCHAR(120),
    ObservaDevedor VARCHAR(80),
    DatCadasDevedor DATE,
    StatusDevedor VARCHAR(20),
    SaldoDevedor MONEY
);

CREATE TABLE Pagador (
    IdPagador INT PRIMARY KEY,
    NomPagador VARCHAR(120),
    EnderePagador VARCHAR(80),
    CidadePagador VARCHAR(80),
    BairroPagador VARCHAR(80),
    UFPagador VARCHAR(10),
    CEPPagador VARCHAR(10),
    TelePagador VARCHAR(20),
    Tele2Pagador VARCHAR(20),
    EmailPagador VARCHAR(120),
    ObservaPagador VARCHAR(80),
    DatCadasPagador DATE,
    StatusPagador VARCHAR(20),
    SaldoPagador MONEY
);

-- Tabela StatusTransacao
CREATE TABLE StatusTransacao (
    IdStatusTran INT PRIMARY KEY,
    DescTran VARCHAR(20)
);

-- Tabela StatusMeta
CREATE TABLE StatusMeta (
    IdStatusMeta INT PRIMARY KEY,
    DescStatusMeta VARCHAR(20)
);

-- Tabela StatusCR
CREATE TABLE StatusCR (
    IdStatusCR INT PRIMARY KEY,
    DescStatusCR VARCHAR(20)
);

-- Tabela StatusOrcamento
CREATE TABLE StatusOrcamento (
    IdStatusOrca INT PRIMARY KEY,
    DescStatusOrca VARCHAR(20)
);

-- Tabela StatusUsuario
CREATE TABLE StatusUsuario (
    IdStatusUsuario INT PRIMARY KEY,
    DescStatusUsuario VARCHAR(20)
);

-- Tabela StatusContBancaria
CREATE TABLE StatusContBancaria (
    IdStatusContBan INT PRIMARY KEY,
    DescStatusContBan VARCHAR(20)
);

-- Tabela StatusTransferencia
CREATE TABLE StatusTransferencia (
    IdStatusTransfe INT PRIMARY KEY,
    DescStatusTransfe VARCHAR(20)
);


-- Adição de Chaves Estrangeiras

-- Tabela Extrato
ALTER TABLE Extrato
ADD FOREIGN KEY (CodContaExtrat) REFERENCES ContaBancaria(IdContBancaria);

-- Tabela Meta
ALTER TABLE Meta
ADD FOREIGN KEY (UsuarioMeta) REFERENCES Usuario(IdUsuario);

-- Tabela Orcamento
ALTER TABLE Orcamento
ADD FOREIGN KEY (UsuarioOrca) REFERENCES Usuario(IdUsuario);

-- Tabela ConfiguracaoUsuario
ALTER TABLE ConfiguracaoUsuario
ADD FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario);

-- Tabela ContaBancaria
ALTER TABLE ContaBancaria
ADD FOREIGN KEY (UsuarioContBan) REFERENCES Usuario(IdUsuario);

-- Tabela Transferencia
ALTER TABLE Transferencia
ADD FOREIGN KEY (UsuarioTransfe) REFERENCES Usuario(IdUsuario);

-- Tabela ContasReceber
ALTER TABLE ContasReceber
ADD FOREIGN KEY (ContaBanCR) REFERENCES ContaBancaria(IdContBancaria);

ALTER TABLE ContasReceber
ADD FOREIGN KEY (UsuarioCR) REFERENCES Usuario(IdUsuario);

-- Tabela ContasPagar
ALTER TABLE ContasPagar
ADD FOREIGN KEY (ContaBanCP) REFERENCES ContaBancaria(IdContBancaria);

ALTER TABLE ContasPagar
ADD FOREIGN KEY (UsuarioCP) REFERENCES Usuario(IdUsuario);

