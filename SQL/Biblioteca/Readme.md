## Database Biblioteca
Si vuole progettare un sistema per la gestione di una biblioteca.

Gli utenti registrati al sistema forniscono nome, cognome, mail, password, recapito telefononico.

Possono effettuare prestiti di diverso tipo: DVD, libri, CD.
Essi sono caratterizzati da codice ISBN (libri) numero seriale per DVD, titolo, anno, settore, STATO (bool) In prestito / Disponibile, scaffale in cui è posizionato.
Per i libri si ha numero di pagine, per i dvd la durata. 

### Fase 1: creare il database SQL
```sql
@"
        
        CREATE TABLE IF NOT EXISTS tessere (id_tessera INTEGER PRIMARY KEY AUTOINCREMENT, data_registrazione DATE, stato BOOL);
        
        CREATE TABLE IF NOT EXISTS utenti (id_utente INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, cognome TEXT, compleanno DATE, indirizzo TEXT, id_tessera INTEGER,
        FOREIGN KEY (id_tessera) REFERENCES tessera(id_tessera));
        
        CREATE TABLE IF NOT EXISTS autori (id_autore INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, cognome TEXT, data_nascita DATE, luogo_nascita TEXT);
        
        CREATE TABLE IF NOT EXISTS generi (id_genere INTEGER PRIMARY KEY AUTOINCREMENT, nome_genere TEXT, scaffale INTEGER);
        
        CREATE TABLE IF NOT EXISTS libri (id_libro INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT, annoPubblicazione INT, codiceISBN INT, disponibilità BOOL, id_autore INTEGER NOT NULL, id_genere INTEGER,
        FOREIGN KEY (id_autore) REFERENCES autori(id_autore),
        FOREIGN KEY (id_genere) REFERENCES generi(id_genere));
        
        CREATE TABLE IF NOT EXISTS prestito (id_prestito INTEGER PRIMARY KEY, data_inizio_prestito DATE, data_fine_prestito DATE, id_utente INTEGER, id_libro INTEGER,
        FOREIGN KEY (id_libro) REFERENCES libri (id_libro),
        FOREIGN KEY (id_utente) REFERENCES utenti (id_utente));
        ";
```
