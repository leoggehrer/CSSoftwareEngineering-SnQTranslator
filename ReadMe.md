Übung:
------

**Lernziele der Aufgaben:** 
- Die Erstellung eines Backend-Service mit Authentifizierung.
- Hosten des Services in einem Docker-Container.

## Translator-Service
## Grundsystem

**Translator** 

Erstellen Sie die Projektstruktur von *SnQTranslator* und fassen Sie die einzelnen Projekte zu einer Solution zusammen. Die Struktur besteht aus den im Unterricht verwendeten SmartNQuick-Projekten.

### Datenstruktur des Translators

**Translation**

|Name|Type|Nullable|MaxLength|Anmerkung|
|---|---|---|---|---|
|AppName|String|No|128|Name der Anwendung|
|KeyLanguage|Enum|No|---|Quellsprache|
|Key|String|No|1024|Quelltext|
|ValueLanguage|Enum|No|---|Zielsprache|
|Value|String|No|1024|Zieltext|

**Funktionsumfang** 

Über eine Web-Anwendung (AspMvc) können Übersetzungen eingetragen werden. Allerdings ist für das Eintragen, Ändern und Löschen von Übersetzungen ein Konto notwendig.  
Für das Abfragen von Übersetzungen ist kein Konto notwendig. Das bedeutet, dass die Abfrage von Übersetzungen anonyme durchgeführt werden kann.

## Hilfsmitteln
- Die Verwendung des Frameworks 'SmartNQuick'

## Abgabe
-   Termin: 1 Woche nach der Ausgabe

-   Klasse:

-   Name:

## Quellen
- Keine Angabe

# 
<center><strong>Viel Erfolg!</strong></center>
