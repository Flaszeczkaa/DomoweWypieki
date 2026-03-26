USE master;
GO

IF DB_ID('DomoweWypieki') IS NOT NULL
BEGIN
    ALTER DATABASE DomoweWypieki SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DomoweWypieki;
END
GO

CREATE DATABASE DomoweWypieki;
GO

USE DomoweWypieki;
GO
    
-- TWORZENIE TABEL 
    
-- Tabela 1: Klienci
CREATE TABLE dbo.Klienci (
    IdKlienta INT IDENTITY(1,1) PRIMARY KEY,
    Imie NVARCHAR(60) NOT NULL,
    Nazwisko NVARCHAR(60) NOT NULL,
    Telefon NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL
);
GO

-- Tabela 2: Zamowienia 
CREATE TABLE dbo.Zamowienia (
    IdZamowienia INT IDENTITY(1,1) PRIMARY KEY,
    IdKlienta INT NOT NULL,
    DataZlozenia DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    DataRealizacji DATETIME2 NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT N'Przyjęte',
    RabatProcent DECIMAL(5,4) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Zamowienia_Klienci FOREIGN KEY (IdKlienta) REFERENCES dbo.Klienci(IdKlienta),
    CONSTRAINT CK_Zamowienia_Rabat CHECK (RabatProcent BETWEEN 0 AND 0.20)
);
GO

-- Tabela 3: Platnosci
CREATE TABLE dbo.Platnosci (
    IdPlatnosci INT IDENTITY(1,1) PRIMARY KEY,
    IdZamowienia INT NOT NULL,
    DataPlatnosci DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Kwota DECIMAL(12,2) NOT NULL CHECK (Kwota > 0),
    RodzajPlatnosci NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_Platnosci_Zamowienia FOREIGN KEY (IdZamowienia) REFERENCES dbo.Zamowienia(IdZamowienia)
);
GO

-- Tabela 4: Ciasta
CREATE TABLE dbo.Ciasta (
    IdCiasta INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(120) NOT NULL,
    Opis NVARCHAR(400) NULL,
    CenaJednostkowa DECIMAL(12,2) NOT NULL CHECK (CenaJednostkowa > 0),
    Aktywne BIT NOT NULL DEFAULT 1
);
GO

-- Tabela 5: Torty 
CREATE TABLE dbo.Torty (
    IdRozmiaru INT IDENTITY(1,1) PRIMARY KEY,
    Rozmiar NVARCHAR(20) NOT NULL,
    CenaBazowa DECIMAL(12,2) NOT NULL CHECK (CenaBazowa > 0)
);
GO

-- Tabela 6: PozycjeZamowienia 
CREATE TABLE dbo.PozycjeZamowienia (
    IdPozycji INT IDENTITY(1,1) PRIMARY KEY,
    IdZamowienia INT NOT NULL,
    TypPozycji NVARCHAR(10) NOT NULL CHECK (TypPozycji IN (N'CIASTO', N'TORT')),
    IdCiasta INT NULL,
    IdRozmiaruTortu INT NULL,
    Ilosc DECIMAL(10,2) NOT NULL DEFAULT 1.00 CHECK (Ilosc > 0),
    CenaBazowa DECIMAL(12,2) NOT NULL CHECK (CenaBazowa > 0),
    KonfiguracjaOpisowa NVARCHAR(400) NULL,
    SumaDoplat DECIMAL(12,2) NOT NULL DEFAULT 0.00 CHECK (SumaDoplat >= 0),
    CenaRazem AS (CAST((Ilosc * CenaBazowa) + SumaDoplat AS DECIMAL(12,2))) PERSISTED,
    CONSTRAINT FK_PozycjeZam_Zamowienia FOREIGN KEY (IdZamowienia) REFERENCES dbo.Zamowienia(IdZamowienia),
    CONSTRAINT FK_PozycjeZam_Ciasta FOREIGN KEY (IdCiasta) REFERENCES dbo.Ciasta(IdCiasta),
    CONSTRAINT FK_PozycjeZam_Torty FOREIGN KEY (IdRozmiaruTortu) REFERENCES dbo.Torty(IdRozmiaru)
);
GO

-- 3. WSTAWIANIE SŁOWNIKÓW (CIASTA I TORTY)
INSERT INTO Ciasta (Nazwa, Opis, CenaJednostkowa, Aktywne) VALUES 
('Sernik Królewski', 'Tradycyjny sernik z kręconego twarogu na ciemnym, kruchym spodzie.', 130.00, 1),
('Seromakowiec', 'Idealne połączenie wilgotnej masy serowej i makowej na kruchym cieście.', 130.00, 1),
('Słonecznikowiec', 'Wyjątkowe ciasto z masą kajmakową, prażonym słonecznikiem i kakowym wykończeniem.', 130.00, 1),
('Makowiec Japoński', 'Wilgotne ciasto makowe z kręconego maku z dodatkiem jabłek, oblane czekoladą.', 130.00, 1),
('Izaura', 'Ciemne ciasto czekoladowe z delikatną wkładką serową i polewą.', 120.00, 1),
('Chałwowiec', 'Puszysty czekoladowy biszkopt przełożony dżemem z czarnej porzeczki, kremem o smaku chałwy oraz kremem kakaowym.', 120.00, 1),
('Malinowa Chmurka', 'Kruche ciasto, galaretka z malinami, krem śmietankowy i chrupiąca beza.', 120.00, 1),
('Jabłecznik Cappuccino', 'Aromatyczne ciasto z jabłkami i ananasem oraz delikatną nutą kremu cappuccino.', 120.00, 1),
('Kubanka', 'Biszkopt kakaowy, masa budyniowa, herbatniki i dżem porzeczkowy.', 120.00, 1),
('Raffaello', 'Biszkopt z aksamitnym kremem kokosowym i białą czekoladą.', 120.00, 1),
('Pijana Śliwka', 'Czekoladowy biszkopt z kremem i śliwkami nasączonymi alkoholem.', 120.00, 1),
('Krówka', 'Ciasto miodowe przełożone masą budyniową i słodkim kajmakiem.', 120.00, 1),
('Morze Czarne', 'Ciemne ciasto kakaowe z warstwą kremu kakaowego, frużeliną wiśniową aksamitnym kremem śmietanowym i bezą.', 120.00, 1),
('Sernik Nowojorski', 'Kremowy, gęsty i aksamitny sernik z okrągłej tortownicy. Możliwość personalizowanego wykończenia.', 110.00, 1),
('Szarlotka', 'Tradycyjne ciasto kruche z dużą ilością prażonych jabłek i kruszonką.', 90.00, 1),
('Keks', 'Wilgotne ciasto ucierane z bogactwem bakalii i owoców kandyzowanych.', 75.00, 1),
('Piernik Korzenny', 'Aromatyczne ciasto z miodem i autorską mieszanką przypraw korzennych.', 75.00, 1);

INSERT INTO Torty (Rozmiar, CenaBazowa) VALUES 
('1-5 osób', 150.00), ('6-8 osób', 200.00), ('10-12 osób', 280.00), ('14-16 osób', 320.00),
('18-20 osób', 360.00), ('20-25 osób', 400.00), ('25-30 osób', 440.00), ('30-35 osób', 480.00),
('35-40 osób', 520.00), ('40-45 osób', 560.00), ('45-50 osób', 600.00), ('50-55 osób', 640.00),
('55-60 osób', 680.00), ('60-65 osób', 720.00), ('65-70 osób', 760.00), ('70-75 osób', 800.00),
('75-80 osób', 840.00), ('80-85 osób', 880.00), ('85-90 osób', 920.00), ('90-95 osób', 960.00),
('95-100 osób', 1000.00), ('100-105 osób', 1040.00), ('105-110 osób', 1080.00), ('110-115 osób', 1120.00),
('115-120 osób', 1160.00), ('120-125 osób', 1200.00), ('125-130 osób', 1240.00), ('130-135 osób', 1280.00),
('135-140 osób', 1320.00), ('140-145 osób', 1360.00), ('145-150 osób', 1400.00), ('150-155 osób', 1440.00),
('155-160 osób', 1480.00), ('160-165 osób', 1520.00), ('165-170 osób', 1560.00), ('170-175 osób', 1600.00),
('175-180 osób', 1640.00), ('180-185 osób', 1680.00), ('185-190 osób', 1720.00), ('190-195 osób', 1760.00),
('195-200 osób', 1800.00);
GO


-- 4. WSTAWIANIE DANYCH TESTOWYCH

-- 5 Klientów
INSERT INTO Klienci (Imie, Nazwisko, Telefon, Email) VALUES 
('Jan', 'Kowalski', '500100200', 'jan.kowalski@example.com'),
('Anna', 'Nowak', '600200300', 'a.nowak@poczta.pl'),
('Piotr', 'Wiśniewski', '700300400', 'piotr.w@example.com'),
('Maria', 'Wójcik', '800400500', 'maria.wojcik@poczta.pl'),
('Krzysztof', 'Kamiński', '900500600', 'k.kaminski@example.com');

-- 5 Zamówień
INSERT INTO Zamowienia (IdKlienta, DataZlozenia, DataRealizacji, Status, RabatProcent) VALUES 
(1, '2024-05-20 10:00:00', '2024-05-25 14:00:00', 'Wydane', 0.00),
(2, '2024-05-21 12:30:00', '2024-05-28 16:00:00', 'W realizacji', 0.10),
(3, '2024-05-23 09:15:00', '2024-05-30 12:00:00', 'Przyjęte', 0.00),
(4, '2024-05-24 15:45:00', '2024-06-02 10:00:00', 'Przyjęte', 0.05),
(5, '2024-05-25 11:00:00', '2024-06-05 16:30:00', 'W realizacji', 0.00);

-- 5 Pozycji Zamówień (Mieszanka ciast i tortów)
INSERT INTO PozycjeZamowienia (IdZamowienia, TypPozycji, IdCiasta, IdRozmiaruTortu, Ilosc, CenaBazowa, KonfiguracjaOpisowa, SumaDoplat) VALUES 
(1, 'CIASTO', 1, NULL, 1.00, 130.00, NULL, 0.00), -- Sernik Królewski
(2, 'TORT', NULL, 3, 1.00, 280.00, 'Smak Premium, Topper z napisem', 50.00), -- Tort 10-12 osób + dopłaty
(3, 'CIASTO', 15, NULL, 2.00, 90.00, NULL, 0.00), -- 2x Szarlotka
(4, 'TORT', NULL, 6, 1.00, 400.00, 'Figurka z masy cukrowej', 30.00), -- Tort 20-25 osób + dopłaty
(5, 'CIASTO', 7, NULL, 1.50, 120.00, NULL, 0.00); -- 1.5 blachy Malinowej Chmurki

-- 5 Płatności 
INSERT INTO Platnosci (IdZamowienia, DataPlatnosci, Kwota, RodzajPlatnosci) VALUES 
(1, '2024-05-20 10:05:00', 130.00, 'Karta'),
(2, '2024-05-21 12:45:00', 100.00, 'Przelew (Zaliczka)'),
(3, '2024-05-23 09:20:00', 50.00, 'Gotówka (Zaliczka)'),
(4, '2024-05-24 15:50:00', 430.00, 'Blik'),
(5, '2024-05-25 11:10:00', 180.00, 'Gotówka');
GO
