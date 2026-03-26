-- WSTAWIANIE KLIENTÓW
INSERT INTO Klienci (Imie, Nazwisko, Telefon, Email) VALUES 
('Jan', 'Kowalski', '500100200', 'jan.kowalski@example.com'),
('Anna', 'Nowak', '600200300', 'a.nowak@poczta.pl');

-- WSTAWIANIE SŁOWNIKÓW (TORTY I CIASTA)
SET IDENTITY_INSERT Torty ON;
INSERT INTO Torty (IdRozmiaru, Rozmiar, CenaBazowa) VALUES 
(1, 'Mały (16cm)', 80.00),
(2, 'Średni (24cm)', 120.00),
(3, 'Duży (30cm)', 180.00);
SET IDENTITY_INSERT Torty OFF;

--Tabela ciasta
SET IDENTITY_INSERT Ciasta ON;
INSERT INTO Ciasta (IdCiasta, Nazwa, Opis, CenaJednostkowa, Aktywne) VALUES 
(1, 'Sernik', 'Klasyczny z rodzynkami', 45.00, 1),
(2, 'Szarlotka', 'Na kruchym cieście', 40.00, 1),
(3, 'Brownie', 'Mocno czekoladowe', 50.00, 1);
SET IDENTITY_INSERT Ciasta OFF;

-- 1. NAJPIERW zdejmujemy blokadę (usuwamy kolumnę wyliczaną)
ALTER TABLE PozycjeZamowienia DROP CONSTRAINT DF__PozycjeZa__Ilosc__3F466844;
ALTER TABLE PozycjeZamowienia DROP CONSTRAINT CK__PozycjeZa__Ilosc__403A8C7D;

-- 2. TERAZ zmieniamy typy danych (nie ma już zależności, więc SQL na to pozwoli)
ALTER TABLE PozycjeZamowienia ALTER COLUMN CenaBazowa DECIMAL(10,2);
ALTER TABLE PozycjeZamowienia ALTER COLUMN Ilosc DECIMAL(10,2);
ALTER TABLE PozycjeZamowienia ALTER COLUMN SumaDoplat DECIMAL(10,2);

-- 3. NA KONIEC przywracamy kolumnę wyliczaną na swoje miejsce
ALTER TABLE PozycjeZamowienia ADD CenaRazem AS (Ilosc * CenaBazowa + SumaDoplat);

SELECT definition 
FROM sys.check_constraints 
WHERE name = 'CK_Zamowienia_Rabat';

-- WSTAWIANIE ZAMÓWIEŃ
SET IDENTITY_INSERT Zamowienia ON;
INSERT INTO Zamowienia (IdZamowienia, IdKlienta, DataZlozenia, DataRealizacji, Status, RabatProcent, WartoscSumaryczna) VALUES 
(101, 1, '2024-05-20 10:00:00', '2024-05-25 14:00:00', 'W realizacji', 0.00, 120),
(102, 2, '2024-05-21 12:30:00', '2024-05-23 16:00:00', 'Nowe', 0.10, 117),
(103, 1, '2024-05-22 09:15:00', '2024-05-27 12:00:00', 'Zakończone', 0.05, 210.00),
(104, 2, '2024-05-23 15:45:00', '2024-05-26 10:00:00', 'Nowe', 0.00, 85.50),
(105, 1, '2024-05-24 11:00:00', '2024-05-30 16:30:00', 'W realizacji', 0.10, 350.00),
(106, 2, '2024-05-25 08:30:00', '2024-05-25 18:00:00', 'Nowe', 0.00, 120.00),
(107, 1, '2024-05-26 14:20:00', '2024-06-01 12:00:00', 'Nowe', 0.15, 450.00),
(108, 2, '2024-05-27 10:00:00', '2024-05-29 15:00:00', 'Zakończone', 0.00, 99.99);
SET IDENTITY_INSERT Zamowienia OFF;


-- WSTAWIANIE POZYCJI ZAMÓWIENIA
SET IDENTITY_INSERT PozycjeZamowienia ON;
-- Dodaliśmy 'TypPozycji' do listy kolumn i odpowiednie wartości do wierszy
INSERT INTO PozycjeZamowienia (IdPozycji, IdZamowienia, TypPozycji, IdCiasta, IdRozmiaruTortu, Ilosc, CenaBazowa, SumaDoplat) 
VALUES 
(1, 101, 'Tort', NULL, 2, 1, 120.00, 0.00),
(2, 102, 'Ciasto', 1, NULL, 2, 45.00, 0.00),
(3, 102, 'Ciasto', 3, NULL, 0.8, 50.00, 0.00);
SET IDENTITY_INSERT PozycjeZamowienia OFF;

-- WSTAWIANIE PŁATNOŚCI
SET IDENTITY_INSERT Platnosci ON;
INSERT INTO Platnosci (IdPlatnosci, IdZamowienia, DataPlatnosci, Kwota, RodzajPlatnosci) VALUES 
(1, 101, '2024-05-20 10:05:00', 120.00, 'Karta'),
(2, 102, '2024-05-21 12:45:00', 50.00, 'Przelew (Zaliczka)');
SET IDENTITY_INSERT Platnosci OFF;
