## Database Biblioteca
Si vuole progettare un sistema per la gestione di una biblioteca.

Gli utenti registrati al sistema forniscono nome, cognome, mail, password, recapito telefononico.

Possono effettuare prestiti di diverso tipo: DVD, libri, CD.
Essi sono caratterizzati da codice ISBN (libri) numero seriale per DVD, titolo, anno, settore, STATO (bool) In prestito / Disponibile, scaffale in cui è posizionato.
Per i libri si ha numero di pagine, per i dvd la durata. 

### Fase 1: creare il database SQL
L'impostazione è a stella, dove il corpo centrale è la Tabella Prestiti: dai prestiti sarà possibile visualizzare l'utente che ha preso a prestito e il libro preso a prestito, oltre che data inizio prestito / fine prestito. 
Da utente non ci sono ulteriori concatenazioni, mentre da prestiti si va a libro e da libro a 
-> generi, per individuare lo scaffale dove si trova il genere
-> autori, per individuare gli autori registrati a database

```sql
 @"
        CREATE TABLE IF NOT EXISTS utenti (id_utente INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, cognome TEXT, data_registrazione DATE, indirizzo TEXT, stato BOOL);
        
        CREATE TABLE IF NOT EXISTS autori (id_autore INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, cognome TEXT, anno_nascita DATE, luogo_nascita TEXT);
        
        CREATE TABLE IF NOT EXISTS generi (id_genere INTEGER PRIMARY KEY AUTOINCREMENT, nome_genere TEXT, scaffale TEXT);
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Giallo', 'In alto a sinistra');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Thriller', 'In alto al centro');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Avventura', 'In alto a destra');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Fantascienza', 'Al centro a sinistra');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Distopico', 'Al centro al centro');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Fantasy', 'Al centro a destra');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Horror', 'In basso a sinistra');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Rosa', 'In basso al centro');
        INSERT INTO generi (nome_genere, scaffale) VALUES ('Biografico', 'In basso a destra');

        CREATE TABLE IF NOT EXISTS libri (id_libro INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT, annoPubblicazione INT, disponibilità BOOL, id_autore INTEGER NOT NULL, id_genere INTEGER,
        FOREIGN KEY (id_autore) REFERENCES autori(id_autore),
        FOREIGN KEY (id_genere) REFERENCES generi(id_genere));
        
        CREATE TABLE IF NOT EXISTS prestito (id_prestito INTEGER PRIMARY KEY, data_inizio_prestito DATE, data_fine_prestito DATE, id_utente INTEGER, id_libro INTEGER,
        FOREIGN KEY (id_libro) REFERENCES libri (id_libro),
        FOREIGN KEY (id_utente) REFERENCES utenti (id_utente));
        ";
```
