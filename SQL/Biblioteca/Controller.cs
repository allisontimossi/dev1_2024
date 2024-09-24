class Controller{
    private Database _db;
    private View _view;

    public Controller(Database db, View view){
        _db = db;
        _view = view;
    }

    public void MainMenu(){
        while(true){
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
        }
    }
    private void AddUser(){
        var stato = true;

        Console.WriteLine("Inserisci nome utente");
        var nome = _view.GetInput();

        Console.WriteLine("Inserisci cognome utente");
        var cognome = _view.GetInput();

        Console.WriteLine("Inserisci indirizzo");
        var indirizzo = _view.GetInput();
        
    }
    private void AddBook(){
        
        var disponibilità = true;

        Console.WriteLine("Inserisci titolo del libro");
        var titolo = _view.GetInput();


        Console.WriteLine("Inserisci id autore del libro:\n----Premi 0 se non è presente l'autore che cerchi----");
        //ViewAuthors();
        
        var idAutore = _view.GetIntInput();
        if (idAutore == 0){
            AddAuthor();
        }

        Console.WriteLine("Inserisci id genere del libro:");
        ViewGenres();
        var idGenere = _view.GetIntInput();
        
        Console.WriteLine("Inserisci anno di pubblicazione");
        var anno = _view.GetIntInput();



        _db.AddBook(titolo, anno, disponibilità, idAutore, idGenere);

        Console.WriteLine("Libro inserito correttamente.\n");
    }
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


    private void ViewAuthors(){
        var autore = _db.GetAuthors();
        _view.ViewAuthors(autore);
    }

    private void ViewGenres(){
        var genere = _db.GetGenres();
        _view.ViewGenres(genere);
    }
    private void SearchBook(){

    Console.WriteLine("Inserisci il nome da cercare:");
    var titolo = _view.GetInput();
    var libro = _db.SearchBookByName(titolo);
    _view.ViewBooks(libro);
}


}