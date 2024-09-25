## Database Biblioteca
Si vuole progettare un sistema per la gestione di una biblioteca, con modello MVC + SQL.

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
### Fase 2: obiettivi principali del programma (aula)
Tra le funzioni elementari che il programma deve avere (allo scopo di consolidare l'argomento Classi + MVC):
- [x] Aggiunta di un libro alla libreria (sapersi muovere tra Database-Controller-View)
- [x] Aggiunta dell'id autore durante aggiunta libro alla libreria
- [x] Cercare un libro su uno scaffale (saper usare JOIN tra due tabelle)
- [x] Registrazione di un prestito (sviluppo della tabella centrale del database)
- endere Indisponibile il libro al momento della prenotazione
- [x] Documentare adeguatamente il codice per renderlo leggibile a terzi
- [ ] 


### Fase 3: implementazioni (casa)
Andranno implementate:
- [ ] Gestione di errori (nomi null o codici con x cifre)
- [ ] Implementare più funzioni per rendere il database completo e user frienfly (aggiungendo metodi già consolidati):
        - Modifica libro
        - Cancella libro 
        - Banna utente (se numero di giorni > 30): visualizzare se l'utente è in tempo per la restituzione del libro, bannarlo in caso contrario
        - Restituzione libro (rende il libro nuovamente Disponibile)
        - Visualizzare quando tornerà disponibile il libro 
- [ ] Menu con spectre
- [ ] Aggiornare il Readme con codice riorganizzato