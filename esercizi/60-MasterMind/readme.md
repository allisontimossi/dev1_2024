Un'applicazione per giocare a Mastermind contro il computer.

## Obiettivo applicazione: regole del gioco

Mastermind è un gioco da tabolo astratto di critto analisi per due giocatori, in cui un giocatore, in questo caso il computer, genera un codice segreto composto da un numero variabile di cursori, mentre tu sarai il decodificatore e dovrai indovinare tale codice. 

Ad ogni turno potrai scegliere da una palette colori i pioli che secondo te compongono il codice, sono ammesse ripetizioni.
In risposta, avrai due tipi di suggerimento:
- se hai indovinato un colore e la sua posizione, ti verrà suggerito un piolo nero;
- se hai indovinato un colore ma non la sua posizione, ti verrà invece suggerito un piolo bianco. 

Se indovini il codice entro il numero di tentativi predeterminato hai vinto la partita. 

### Versione 1.0: capire la logica inserendo i confronti manualmente
-  [x] Generare una lista di colori tra cui il Codificatore potrà scegliere
-  [x] Generare singolarmente i colori estratti dalla CPU
-  [x] Creare singolarmente menu multiselezione per scelta colori
-  [x] Ciclo while [break: numero tentativi: 10; codiceCpu = codiceSegreto]: comparazione tra codice manuale (16 if)

### Versione 2.0: una volta capita la logica dietro ai confronti manuali, sintetizzarli tramite cicli for
-  [ ] Chiedere all'utente il suo nome: rendere persistente questa info con anche il suo punteggio alla fine del gioco
-  [x] Generare una lista di colori tra cui il Codificatore potrà scegliere
-  [x] Generare  i colori estratti dalla CPU e inserirli in un array
-  [x] Creare  menu multiselezione per scelta colori e inserimento in un array
-  [x] Ciclo while [break: numero tentativi: 10; codiceCpu = codiceSegreto]: comparazione con for
-  [x] Possibilità di tenere i risultati tracciati tramite tabella
-  [ ] Implementare menu inizio gioco

### Refactoring codice
-  [ ] Creazione nuovo repository: first complete project


## Wishlist
-  [x] Readme con regole del gioco
-  [x] Mermaid
-  [ ] Implementare funzioni
-  [ ] Rendere l'interfaccia appetibile con tabella (servono funzioni T.T)
-  [x] Livelli di difficoltà: chiede in quanti turni e con quante pedine giocare (inventare sistema più efficiente per punteggi)
-  [x] Chiedere all'utente il suo nome: rendere persistente questa info con anche il suo punteggio alla fine del gioco (si può riordinare?)
-  [ ] Aggiungere data punteggi
-  [ ] Mostra i primi 5 punteggi migliori
-  [ ] Sistema di punteggi
-  [ ] Gestione eccezioni menu iniziale di scelta

## Mermaid della logica gioco
```mermaid
flowchart TD
    A(Welcome! \n Let's play MasterMind) -->|print: rules| B{{code generated: \n CPU picks 4 random colours from a 6 colours palette}}
    B --loop--> C([new attemp: \n input guess code])
    C --> D(if 1° guess colour == 1° CPU's colour)
    D --true \n black dot--> E(if 2° guess colour == 2° CPU's colour)    
        D --false--> J(if 1° guess colour == 2° CPU's colour \n OR \n if 1° guess colour == 3° CPU's colour \n OR \n if 1° guess colour == 4° CPU's colour)--true \n white dot--> E
        J --false \n no dot--> E
    
    E --true \n black dot--> F(if 3° guess colour == 3° CPU's colour)
        E --false--> L(if 2° guess colour == 1° CPU's colour \n OR \n if 2° guess colour == 3° CPU's colour \n OR \n if 2° guess colour == 4° CPU's colour)--true \n white dot -->F
        L--false \n no dot-->F
        F --true \n black dot--> G(if 4° guess colour == 4° CPU's colour)
    
    F --false-->N(if 3° guess colour == 1° CPU's colour \n OR \n if 3° guess colour == 2° CPU's colour \n OR \n if 3° guess colour == 4° CPU's colour)--true \n white dot-->G
    N--false \n no dot-->G
    G --true--> H(WE WON)
    G--false-->O(if 4° guess colour == 1° CPU's colour \n OR \n if 4° guess colour == 2° CPU's colour \n OR \n if 4° guess colour == 3° CPU's colour)--true \n white dot -->C
    O--false-->C

B-->P(if attemps = 10 \n OR \n 1° guess = 1° CPU's colour AND 2°guess =2°CPU's colour AND 3°guess =3°CPU's colour AND 4°guess =4°CPU's colour)-->Q(WE LOST)
```