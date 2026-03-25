-- 1. Tworzenie bazy danych
CREATE DATABASE DomoweWypieki;
GO

USE DomoweWypieki;
GO

-- 2. Tabela: Klienci
CREATE TABLE dbo.Klienci (
    IdKlienta INT IDENTITY(1,1) PRIMARY KEY,
    Imie NVARCHAR(60) NOT NULL,
    Nazwisko NVARCHAR(60) NOT NULL,
    Telefon NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL,
);
GO

-- 3. Tabela: Zamowienia
CREATE TABLE dbo.Zamowienia (
    IdZamowienia INT IDENTITY(1,1) PRIMARY KEY,
    IdKlienta INT NOT NULL,
    DataZlozenia DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    DataRealizacji DATETIME2 NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT N'Przyjęte',
    RabatProcent DECIMAL(5,4) NOT NULL DEFAULT 0.00,
    WartoscSumaryczna DECIMAL(12,2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Zamowienia_Klienci FOREIGN KEY (IdKlienta) REFERENCES dbo.Klienci(IdKlienta),
    CONSTRAINT CK_Zamowienia_Rabat CHECK (RabatProcent BETWEEN 0 AND 0.20)
);
GO

-- 4. Tabela: Platnosci
CREATE TABLE dbo.Platnosci (
    IdPlatnosci INT IDENTITY(1,1) PRIMARY KEY,
    IdZamowienia INT NOT NULL,
    DataPlatnosci DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Kwota DECIMAL(12,2) NOT NULL CHECK (Kwota > 0),
    RodzajPlatnosci NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_Platnosci_Zamowienia FOREIGN KEY (IdZamowienia) REFERENCES dbo.Zamowienia(IdZamowienia)
);
GO

-- 5. Tabela: Ciasta 
CREATE TABLE dbo.Ciasta (
    IdCiasta INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(120) NOT NULL,
    Opis NVARCHAR(400) NULL,
    CenaJednostkowa DECIMAL(12,2) NOT NULL CHECK (CenaJednostkowa > 0),
    Aktywne BIT NOT NULL DEFAULT 1
);
GO

-- 6. Tabela: TortRozmiary 
CREATE TABLE dbo.TortRozmiary (
    IdRozmiaru INT IDENTITY(1,1) PRIMARY KEY,
    Rozmiar NVARCHAR(20) NOT NULL,
    CenaBazowa DECIMAL(12,2) NOT NULL CHECK (CenaBazowa > 0)
);
GO

-- 7. Tabela: TortDoplaty 
CREATE TABLE dbo.TortDoplaty (
    IdDoplaty INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(120) NOT NULL,
    TypNaliczania NVARCHAR(10) NOT NULL, -- 'KWOTA' lub 'PROCENT'
    Wartosc DECIMAL(12,4) NOT NULL CHECK (Wartosc > 0),
    Aktywna BIT NOT NULL DEFAULT 1,
    CONSTRAINT CK_TypNaliczania CHECK (TypNaliczania IN (N'KWOTA', N'PROCENT'))
);
GO

-- 8. Tabela: PozycjeZamowienia 
CREATE TABLE dbo.PozycjeZamowienia (
    IdPozycji INT IDENTITY(1,1) PRIMARY KEY,
    IdZamowienia INT NOT NULL,
    
    -- Typ decyduje, co to za pozycja ('CIASTO' lub 'TORT')
    TypPozycji NVARCHAR(10) NOT NULL CHECK (TypPozycji IN (N'CIASTO', N'TORT')),
    
    -- Klucze obce (mogą być NULL, bo pozycja to albo ciasto, albo tort)
    IdCiasta INT NULL,
    IdRozmiaruTortu INT NULL,
    
    Ilosc INT NOT NULL DEFAULT 1 CHECK (Ilosc >= 1),
    
    -- Zapisana cena z momentu sprzedaży (dla ciasta - jednostkowa, dla tortu - bazowa z rozmiaru)
    CenaBazowa DECIMAL(12,2) NOT NULL CHECK (CenaBazowa > 0),
    
    -- Opis wybranych dopłat
    KonfiguracjaOpisowa NVARCHAR(400) NULL,
    
    -- Łączna kwota dopłat do tortu (wyliczona w C#)
    SumaDoplat DECIMAL(12,2) NOT NULL DEFAULT 0.00 CHECK (SumaDoplat >= 0),
    
    -- Automatyczne wyliczenie: (Cena bazowa + Dopłaty) * Ilość
    CenaRazem AS ((CenaBazowa + SumaDoplat) * CAST(Ilosc AS DECIMAL(12,2))) PERSISTED,

    CONSTRAINT FK_PozycjeZam_Zamowienia FOREIGN KEY (IdZamowienia) REFERENCES dbo.Zamowienia(IdZamowienia),
    CONSTRAINT FK_PozycjeZam_Ciasta FOREIGN KEY (IdCiasta) REFERENCES dbo.Ciasta(IdCiasta),
    CONSTRAINT FK_PozycjeZam_TortRozmiary FOREIGN KEY (IdRozmiaruTortu) REFERENCES dbo.TortRozmiary(IdRozmiaru)
);
GO