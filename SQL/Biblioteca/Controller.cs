class Controller{
     // Riferimento al modello (Database) e alla vista (Veew)
    private Database _db;
    private View _view;

    //Installazione del riferimento al modello e alla vista
    public Controller(Database db, View view){
        _db = db;
        _view = view;
    }

// Menu principale dell'app (lato Controller) con principali funzioni dell'applicazione
    public void MainMenu(){
        while(true){
            //Visualizzazione del menu principale
            _view.ShowMainMenu();

            var input = _view.GetInput();

            if(input == "1"){
                AddBook();
                }

            if(input == "2"){
                AddAuthor();
                }

            if(input == "3"){
                ViewAuthors();
                }

            if(input == "4"){
                SearchBook();
                }

            if(input == "5"){
                AddUser();
                }
            if(input == "6"){
                NuovoPrestito();
                }
            if(input == "10"){
                _db.CloseConnection();
                }
        }
    }

//Metodo NuovoPrestito 
    //Setta la variabile 'disponibilità' (bool) del libro su False
    //Aggiunta Time Stamp con data corrente di registrazione Prestito 
        //Convertita in stringa la data di inizio prestito
        //Convertita in stringa la data di fine prestito (aggiunti 30 giorni alla data di inizio prestito)
    //Visualizzazione lista Utenti per poter selezionare l' 'idUtente '
        //Richiede all'utente l'inserimento della variabile 'idUtente' del richiedente il prestito
        //(dev'essere un dato di tipo int - non nullo - non vuoto)
    //Visualizzazione lista Generi per poter selezionare l''idGenere'
        //Richiede all'utente l'inserimento della variabile 'idGenere'
            //(dev'essere un int - non nullo - non vuoto)
    //Aggiunge il record che rispetta i requisiti alla tabella 'Prestiti' nelle colonne 'inizioPrestito','finePrestito','idAutore','idGenere'

    private void NuovoPrestito(){
        
        DateTime inizio_prestito = DateTime.Today;

        string data_inizio_prestito = inizio_prestito.ToShortDateString();
        string data_fine_prestito =  inizio_prestito.AddDays(30).ToShortDateString(); 

        Console.WriteLine("Inserisci id utente:");
        ViewUsers();
        var idUtente = _view.GetIntInput();

        Console.WriteLine("Inserisci id libro:");

        var idLibro = _view.GetIntInput();

        _db.NuovoPrestito(data_inizio_prestito, data_fine_prestito, idUtente, idLibro);
        Console.WriteLine("Prestito inserito correttamente.\n");
    }

//Metodo per Aggiunta di nuovo utente

    //Setta la variabile 'stato' (bool) del nuovo libro su True (1)

    //Richiede all'utente l'inserimento del campo Titolo 
        //(non dev'essere nullo - spazio vuoto - o con insufficiente numero di caratteri (<3))
    //Visualizzazione lista Autore per poter selezionare l'idAutore del nuovo libro
    //Richiede all'utente l'inserimento della variabile 'idAutore'
        //(dev'essere un int - non nullo - non vuoto)
    //Visualizzazione lista Generi per poter selezionare l''idGenere'
        //(dev'essere un int - non nullo - non vuoto)
    //Richiede all'utente l'inserimento della variabile 'idGenere'
    //Richiede l'inserimento della variabile 'annoPubblicazione'
        //(dev'essere un int di 4 cifre (<2025)- non nullo - non vuoto)
    //Aggiunge il record che rispetta i requisiti alla tabella 'libri' nelle colonne 'titolo','annoPubblicazione','id_autore','id_genere'
    private void AddBook(){
    private void AddUser(){
        //Utente Attivo di default
        var stato = true;

        DateTime data_registrazione = DateTime.Today;
        string dataRegistrazione = data_registrazione.ToShortDateString();

        Console.WriteLine("Inserisci nome utente");
        var nome = _view.GetInput();

        Console.WriteLine("Inserisci cognome utente");
        var cognome = _view.GetInput();

        Console.WriteLine("Inserisci indirizzo");
        var indirizzo = _view.GetInput();

        _db.AddUser(nome, cognome, indirizzo, dataRegistrazione, stato);
        Console.WriteLine("Utente inserito correttamente.\n");
        
    }
//Metodo AddBook 
    //Setta la variabile 'disponibilità' (bool) del nuovo libro su True
    //Richiede all'utente l'inserimento del campo Titolo 
        //(non dev'essere nullo - spazio vuoto - o con insufficiente numero di caratteri (<3))
    //Visualizzazione lista Autore per poter selezionare l'idAutore del nuovo libro
    //Richiede all'utente l'inserimento della variabile 'idAutore'
        //(dev'essere un int - non nullo - non vuoto)
    //Visualizzazione lista Generi per poter selezionare l''idGenere'
        //(dev'essere un int - non nullo - non vuoto)
    //Richiede all'utente l'inserimento della variabile 'idGenere'
    //Richiede l'inserimento della variabile 'annoPubblicazione'
        //(dev'essere un int di 4 cifre (<2025)- non nullo - non vuoto)
    //Aggiunge il record che rispetta i requisiti alla tabella 'Libri' nelle colonne 'titolo','annoPubblicazione','id_autore','id_genere'
    private void AddBook(){
        
        // Disponibiltà libro settata su True
        var disponibilità = true;

        // 1- Richiesta
        Console.WriteLine("Inserisci titolo del libro");
        // 2- Lettura
        var titolo = _view.GetInput();

        //  Visualizzazione Lista Autore per inserimento idAutore nella tabella libri
        Console.WriteLine("Inserisci id autore del libro:\n----Premi 0 se non è presente l'autore che cerchi----");
        ViewAuthors();
        var idAutore = _view.GetIntInput();
        if (idAutore == 0){
            AddAuthor();
        }

        // 1- Richiesta
        Console.WriteLine("Inserisci id genere del libro:");
        ViewGenres(); //visualizzazione lista generi
        // 2- Lettura
        var idGenere = _view.GetIntInput();
        
        // 1- Richiesta
        Console.WriteLine("Inserisci anno di pubblicazione");
        // 2- Lettura
        var anno = _view.GetIntInput();

        // 3- Aggiunta a tabella libri
        _db.AddBook(titolo, anno, disponibilità, idAutore, idGenere);

        Console.WriteLine("Libro inserito correttamente.\n");
    }
    
//Metodo per Aggiunta autore
    //Richiede all'utente l'inserimento della variabile 'nome' dell'autore
        //(non dev'essere nullo - spazio vuoto - o con insufficiente numero di caratteri (<3))
    //Richiede all'utente l'inserimento della variabile 'cognome' dell'autore
        //(non dev'essere nullo - spazio vuoto - o con insufficiente numero di caratteri (<3))
    //Richiede all'utente l'inserimento della variabile 'annoNascita' dell'autore
        //(non dev'essere nullo - spazio vuoto - int (>1200))
    //Richiede all'utente l'inserimento della variabile 'cognome' dell'autore
        //(non dev'essere nullo - spazio vuoto - o con insufficiente numero di caratteri (<3)) 
    //Aggiunge il record che rispetta i requisiti alla tabella 'Libri' nelle colonne 'titolo','annoPubblicazione','id_autore','id_genere'

    private void AddAuthor(){
        Console.WriteLine("Inserisci nome autore");
        var nome = _view.GetInput();
        Console.WriteLine("Inserisci cognome autore");
        var cognome = _view.GetInput();

        Console.WriteLine("Inserisci anno di nascita");
        var annoNascita = _view.GetIntInput();

        Console.WriteLine("Inserisci luogo di nascita");
        var luogoNascita = _view.GetInput();

        _db.AddAuthor(nome, cognome, annoNascita, luogoNascita);
        Console.WriteLine("Autore inserito correttamente.\n");
    }

//Metodi per vista 
    private void ViewAuthors(){
        var autore = _db.GetAuthors();
        _view.ViewAuthors(autore);
    }

    private void ViewGenres(){
        var genere = _db.GetGenres();
        _view.ViewGenres(genere);
    }

    private void ViewUsers(){
        var utente = _db.GetUsers();
        _view.ViewUsers(utente);   
    }

//Metodo SearchBook
    //Permette di cercare un libro restituendo la posizione sullo scaffale

    //Richiede all'utente l'inserimento della variabile 'titolo' dell'oggetto Libro
        //(non dev'essere nullo - spazio vuoto - o con insufficiente numero di caratteri (<3))
    private void SearchBook(){

    Console.WriteLine("Inserisci il nome da cercare:");
    var titolo = _view.GetInput();
    var libro = _db.SearchBookByName(titolo);
    _view.ViewBooks(libro);
    }


}