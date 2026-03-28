# Wypożyczalnia sprzętu

Ćwiczenia 2 - Projekt obiektowy w C#
Aplikacja konsolowa z naciskiem na strukturę kodu, odpowiedzialności klas i dobre praktyki


Projekt zawiera:

- użytkowników: `Student`, `Employee`,
- sprzęt: `Laptop`, `Camera`, `Projector`,
- wypożyczenia, zwroty i kara za opóźnienie,
- raport końcowy,
- scenariusz demonstracyjny uruchamiany w `Program.cs`.

## Uruchomienie

Za pomocą Ridera.

## Podział kodu

- Klasy dziedziczące po `User` (`Employee`, `Student`), `Device` (`Camera`, `Projector`, `Laptop`)(pogrupowane w foldery) oraz klasa `Rental`,
- poza nimi wydzielone nastepujace klasy serwisowe z pojedyńczymi odpowiedzialnościami:
- `UserService` odpowiada za operacje na użytkownikach.
- `DeviceService` odpowiada za sprzęt i jego status.
- `RentalService` trzyma logikę wypożyczeń, limitów i zwrotów.
- `ReportService` składa prosty raport tekstowy.
- dodany wzorzec projektowy strategia `IExtraFeeCalucatorStrategy` wraz z implementacją, żeby ułatwić ewentualną zmianę zasad naliczania kar,
- `Program.cs` zawiera scenariusz demonstracyjny.

## Kohezja i coupling

Każda klasa ma swoją jedną odpowiedzialność, np. istnieją dedykowane serwisy do zarządzania użytkownikami, urządzeniami i wypożyczeniami.

Niski coupling - klasy serwisowe nie tworzą instancji innych klas serwisowych, a np. do serwisu generującego raporty są przekazywane przez dependency injection. Innym przykładem jest wzorzec strategii.
