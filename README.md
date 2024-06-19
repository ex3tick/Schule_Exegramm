
# WebApp API

## Übersicht

Die WebApp API dient zur Verwaltung von Daten im Zusammenhang mit Meldern, Kategorien, Sichtungen und Bildern. Sie bietet Endpunkte zum Erstellen, Lesen, Aktualisieren und Löschen von Datensätzen in diesen Kategorien. Die API ist organisiert und dokumentiert mit Swagger, was eine benutzerfreundliche Oberfläche zum Erkunden und Testen bietet.

## API-Funktionen

### Melder
- **GET /api/Melder**: Abrufen aller Melder oder eines bestimmten Melders nach ID.
- **POST /api/Melder**: Hinzufügen eines neuen Melders.
- **PUT /api/Melder**: Aktualisieren eines bestehenden Melders.
- **DELETE /api/Melder**: Löschen eines Melders nach ID.
- **GET /api/Melder/Email**: Abrufen eines Melders nach E-Mail.
- **GET /api/Melder/Benutzername**: Abrufen eines Melders nach Benutzername.

### Kategorie
- **GET /api/Kategorie**: Abrufen aller Kategorien oder einer bestimmten Kategorie nach ID.
- **POST /api/Kategorie**: Hinzufügen einer neuen Kategorie.
- **PUT /api/Kategorie**: Aktualisieren einer bestehenden Kategorie.
- **DELETE /api/Kategorie**: Löschen einer Kategorie nach ID.
- **GET /api/Kategorie/Bezeichnung**: Abrufen einer Kategorie nach Bezeichnung.

### Sichtung
- **GET /api/Sichtung**: Abrufen aller Sichtungen oder einer bestimmten Sichtung nach ID.
- **POST /api/Sichtung**: Hinzufügen einer neuen Sichtung.
- **PUT /api/Sichtung**: Aktualisieren einer bestehenden Sichtung.
- **DELETE /api/Sichtung**: Löschen einer Sichtung nach ID.
- **GET /api/Sichtung/KategorieId**: Abrufen von Sichtungen nach Kategorie-ID.
- **GET /api/Sichtung/MelderId**: Abrufen von Sichtungen nach Melder-ID.

### Bild
- **GET /api/Bild**: Abrufen aller Bilder oder eines bestimmten Bildes nach ID.
- **POST /api/Bild**: Hinzufügen eines neuen Bildes.
- **PUT /api/Bild**: Aktualisieren eines bestehenden Bildes.
- **DELETE /api/Bild**: Löschen eines Bildes nach ID.

## Datenbankeinrichtung

Führen Sie die folgenden SQL-Befehle aus, um die Datenbank und die erforderlichen Tabellen zu erstellen:

```sql
CREATE DATABASE exegramm;

USE exegramm;

CREATE TABLE Melder (
    MId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50),
    KennwortHash VARCHAR(255),
    Salt VARCHAR(255),
    IsAktiv TINYINT,
    IsAdmin TINYINT,
    RegDatum DATETIME,
    Email VARCHAR(100) UNIQUE,
    Benutzername VARCHAR(50) UNIQUE
);

CREATE TABLE Kategorie (
    KId INT AUTO_INCREMENT PRIMARY KEY,
    Bezeichnung VARCHAR(100)
);

CREATE TABLE Sichtung (
    SId INT AUTO_INCREMENT PRIMARY KEY,
    MId INT NOT NULL,
    Titel VARCHAR(50),
    Anmerkung TEXT,
    Datum DATETIME,
    Eintragsdatum DATETIME,
    Laengengrad TEXT,
    Breitengrad TEXT,
    KId INT NOT NULL,
    FOREIGN KEY (MId) REFERENCES Melder(MId),
    FOREIGN KEY (KId) REFERENCES Kategorie(KId)
);

CREATE TABLE Bild (
    BId INT AUTO_INCREMENT PRIMARY KEY,
    SId INT NOT NULL,
    Name TEXT,
    FOREIGN KEY (SId) REFERENCES Sichtung(SId)
);
```

## Swagger

Um Swagger zu verwenden und die API-Dokumentation anzuzeigen, starten Sie die Anwendung und navigieren Sie zu `http://localhost:<port>/swagger`. Hier können Sie alle Endpunkte der API erkunden und testen.
