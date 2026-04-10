USE master;
GO

-- 1. RESTART BAZY DANYCH
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

-- 2. TWORZENIE STRUKTURY TABEL

CREATE TABLE dbo.Klienci (
    IdKlienta INT IDENTITY(1,1) PRIMARY KEY,
    Imie NVARCHAR(60) NOT NULL,
    Nazwisko NVARCHAR(60) NOT NULL,
    Telefon NVARCHAR(30) NOT NULL,
    Email NVARCHAR(50) NULL
);

CREATE TABLE dbo.Kategorie (
    IdKategorii INT IDENTITY(1,1) PRIMARY KEY,
    NazwaKategorii NVARCHAR(30) NOT NULL
);

CREATE TABLE dbo.OfertaCukierni (
    IdProduktu INT IDENTITY(1,1) PRIMARY KEY,
    IdKategorii INT NOT NULL,
    Nazwa NVARCHAR(120) NOT NULL,
    Opis NVARCHAR(400) NULL,
    Cena DECIMAL(12,2) NOT NULL CHECK (Cena > 0),
    CONSTRAINT FK_OfertaCuk_Kategorie FOREIGN KEY (IdKategorii) REFERENCES dbo.Kategorie(IdKategorii)
);

CREATE TABLE dbo.StatusyZamowien (
    IdStatusu INT IDENTITY(1,1) PRIMARY KEY,
    NazwaStatusu NVARCHAR(30) NOT NULL
);

CREATE TABLE dbo.Zamowienia (
    IdZamowienia INT IDENTITY(1,1) PRIMARY KEY,
    IdKlienta INT NOT NULL,
    IdStatusu INT NOT NULL,
    DataZlozenia DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    DataRealizacji DATETIME2 NULL,
    RabatProcent DECIMAL(5,4) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Zamowienia_Klienci FOREIGN KEY (IdKlienta) REFERENCES dbo.Klienci(IdKlienta),
    CONSTRAINT FK_Zamowienia_Statusy FOREIGN KEY (IdStatusu) REFERENCES dbo.StatusyZamowien(IdStatusu),
    CONSTRAINT CK_Zamowienia_Rabat CHECK (RabatProcent BETWEEN 0 AND 0.20)
);

CREATE TABLE dbo.RodzajePlatnosci (
    IdRodzajuPlatnosci INT IDENTITY(1,1) PRIMARY KEY,
    NazwaPlatnosci NVARCHAR(30) NOT NULL
);

CREATE TABLE dbo.Platnosci (
    IdPlatnosci INT IDENTITY(1,1) PRIMARY KEY,
    IdZamowienia INT NOT NULL UNIQUE,
    IdRodzajuPlatnosci INT NOT NULL,
    DataPlatnosci DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Kwota DECIMAL(12,2) NOT NULL CHECK (Kwota > 0),
    CONSTRAINT FK_Platnosci_Zamowienia FOREIGN KEY (IdZamowienia) REFERENCES dbo.Zamowienia(IdZamowienia),
    CONSTRAINT FK_Platnosci_RodzajePlatnosci FOREIGN KEY (IdRodzajuPlatnosci) REFERENCES dbo.RodzajePlatnosci(IdRodzajuPlatnosci)
);

-- Tabela z KLUCZEM ZŁOŻONYM
CREATE TABLE dbo.PozycjeZamowienia (
    IdZamowienia INT NOT NULL,
    IdProduktu INT NOT NULL,
    Ilosc DECIMAL(10,2) NOT NULL DEFAULT 1.00 CHECK (Ilosc > 0),
    CenaBazowa DECIMAL(12,2) NOT NULL CHECK (CenaBazowa > 0),
    ProsbaKlienta NVARCHAR(400) NULL,
    SumaDoplat DECIMAL(12,2) NOT NULL DEFAULT 0.00 CHECK (SumaDoplat >= 0),
    CenaRazem AS (CAST((Ilosc * CenaBazowa) + SumaDoplat AS DECIMAL(12,2))) PERSISTED,
    
    -- Definicja klucza złożonego: para (Zamówienie + Produkt) musi być unikalna
    CONSTRAINT PK_PozycjeZamowienia PRIMARY KEY (IdZamowienia, IdProduktu),
    CONSTRAINT FK_PozycjeZam_Zamowienia FOREIGN KEY (IdZamowienia) REFERENCES dbo.Zamowienia(IdZamowienia),
    CONSTRAINT FK_PozycjeZam_Oferta FOREIGN KEY (IdProduktu) REFERENCES dbo.OfertaCukierni(IdProduktu)
);
GO

-- 3. WSTAWIANIE DANYCH SŁOWNIKOWYCH

INSERT INTO Kategorie (NazwaKategorii) VALUES ('CIASTO'), ('TORT');

INSERT INTO StatusyZamowien (NazwaStatusu) VALUES 
('Przyjęte'), ('W realizacji'), ('Gotowe do odbioru'), ('Wydane'), ('Anulowane');

INSERT INTO RodzajePlatnosci (NazwaPlatnosci) VALUES 
('Gotówka'), ('Karta'), ('Przelew'), ('BLIK');

-- 4. WSTAWIANIE OFERTY

INSERT INTO OfertaCukierni (IdKategorii, Nazwa, Opis, Cena) VALUES 
(1, 'Sernik Królewski', 'Tradycyjny sernik z kręconego twarogu na ciemnym, kruchym spodzie.', 130.00),
(1, 'Seromakowiec', 'Idealne połączenie wilgotnej masy serowej i makowej na kruchym cieście.', 130.00),
(1, 'Słonecznikowiec', 'Wyjątkowe ciasto z masą kajmakową, prażonym słonecznikiem i kakowym wykończeniem.', 130.00),
(1, 'Makowiec Japoński', 'Wilgotne ciasto makowe z kręconego maku z dodatkiem jabłek, oblane czekoladą.', 130.00),
(1, 'Izaura', 'Ciemne ciasto czekoladowe z delikatną wkładką serową i polewą.', 120.00),
(1, 'Chałwowiec', 'Puszysty czekoladowy biszkopt przełożony dżemem z czarnej porzeczki.', 120.00),
(1, 'Malinowa Chmurka', 'Kruche ciasto, galaretka z malinami, krem śmietankowy i chrupiąca beza.', 120.00),
(1, 'Jabłecznik Cappuccino', 'Aromatyczne ciasto z jabłkami i ananasem.', 120.00),
(1, 'Kubanka', 'Biszkopt kakaowy, masa budyniowa, herbatniki.', 120.00),
(1, 'Raffaello', 'Biszkopt z aksamitnym kremem kokosowym.', 120.00),
(1, 'Pijana Śliwka', 'Czekoladowy biszkopt ze śliwkami w alkoholu.', 120.00),
(1, 'Krówka', 'Ciasto miodowe z kajmakiem.', 120.00),
(1, 'Morze Czarne', 'Ciemne ciasto z wiśniami i bezą.', 120.00),
(1, 'Sernik Nowojorski', 'Kremowy, gęsty sernik.', 110.00),
(1, 'Szarlotka', 'Ciasto kruche z jabłkami i kruszonką.', 90.00),
(1, 'Keks', 'Wilgotne ciasto z bakaliami.', 75.00),
(1, 'Piernik Korzenny', 'Miodowe ciasto z przyprawami.', 75.00);

INSERT INTO OfertaCukierni (IdKategorii, Nazwa, Opis, Cena) VALUES 
(2, 'Tort (1-5 osób)', 'Rozmiar: 1-5 osób', 150.00),
(2, 'Tort (6-8 osób)', 'Rozmiar: 6-8 osób', 200.00),
(2, 'Tort (10-12 osób)', 'Rozmiar: 10-12 osób', 280.00),
(2, 'Tort (14-16 osób)', 'Rozmiar: 14-16 osób', 320.00),
(2, 'Tort (18-20 osób)', 'Rozmiar: 18-20 osób', 360.00),
(2, 'Tort (20-25 osób)', 'Rozmiar: 20-25 osób', 400.00),
(2, 'Tort (25-30 osób)', 'Rozmiar: 25-30 osób', 440.00),
(2, 'Tort (30-35 osób)', 'Rozmiar: 30-35 osób', 480.00),
(2, 'Tort (35-40 osób)', 'Rozmiar: 35-40 osób', 520.00),
(2, 'Tort (40-45 osób)', 'Rozmiar: 40-45 osób', 560.00),
(2, 'Tort (45-50 osób)', 'Rozmiar: 45-50 osób', 600.00),
(2, 'Tort (50-55 osób)', 'Rozmiar: 50-55 osób', 640.00),
(2, 'Tort (55-60 osób)', 'Rozmiar: 55-60 osób', 680.00);

-- 5. DANE TRANSAKCYJNE

INSERT INTO Klienci (Imie, Nazwisko, Telefon, Email) VALUES 
('Jan', 'Kowalski', '500100200', 'jan.kowalski@example.com'),
('Anna', 'Nowak', '600200300', 'a.nowak@poczta.pl'),
('Piotr', 'Wiśniewski', '700300400', 'piotr.w@example.com'),
('Maria', 'Wójcik', '800400500', 'maria.wojcik@poczta.pl'),
('Krzysztof', 'Kamiński', '900500600', 'k.kaminski@example.com');

INSERT INTO Zamowienia (IdKlienta, DataZlozenia, DataRealizacji, IdStatusu, RabatProcent) VALUES 
(1, '2024-05-20 10:00:00', '2024-05-25 14:00:00', 4, 0.00),
(2, '2024-05-21 12:30:00', '2024-05-28 16:00:00', 3, 0.10),
(3, '2024-05-23 09:15:00', '2024-05-30 12:00:00', 2, 0.00),
(4, '2024-05-24 15:45:00', '2024-06-02 10:00:00', 2, 0.05),
(4, '2024-05-25 11:00:00', '2024-06-05 16:30:00', 3, 0.00);

INSERT INTO Platnosci (IdZamowienia, DataPlatnosci, Kwota, IdRodzajuPlatnosci) VALUES 
(1, '2024-05-20 10:05:00', 130.00, 2),
(2, '2024-05-28 16:00:00', 280.00, 3), 
(3, '2024-05-23 09:20:00', 50.00, 1),
(4, '2024-05-24 15:50:00', 430.00, 4),
(5, '2024-05-25 11:10:00', 180.00, 1);

-- Wstawianie pozycji z wykorzystaniem KLUCZA ZŁOŻONEGO
INSERT INTO PozycjeZamowienia (IdZamowienia, IdProduktu, Ilosc, CenaBazowa, ProsbaKlienta, SumaDoplat) VALUES 
(1, 1, 1.00, 130.00, NULL, 0.00),
(2, 20, 1.00, 280.00, 'Smak Premium, Topper z napisem', 50.00),
(3, 15, 2.00, 90.00, NULL, 0.00),
(4, 23, 1.00, 400.00, 'Figurka z masy cukrowej', 30.00),
(5, 7, 1.50, 120.00, NULL, 0.00);
GO
