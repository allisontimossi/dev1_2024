using System.Data.SQLite;
class Database
{
    //impostiamo l'accesso privato
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");  // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
        string sql = 
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

        CREATE TABLE IF NOT EXISTS libri (id_libro INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT, annoPubblicazione INT, codiceISBN INT, disponibilità BOOL, id_autore INTEGER NOT NULL, id_genere INTEGER,
        FOREIGN KEY (id_autore) REFERENCES autori(id_autore),
        FOREIGN KEY (id_genere) REFERENCES generi(id_genere));
        
        CREATE TABLE IF NOT EXISTS prestito (id_prestito INTEGER PRIMARY KEY, data_inizio_prestito DATE, data_fine_prestito DATE, id_utente INTEGER, id_libro INTEGER,
        FOREIGN KEY (id_libro) REFERENCES libri (id_libro),
        FOREIGN KEY (id_utente) REFERENCES utenti (id_utente));
        ";
        var command = new SQLiteCommand(sql, _connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }
    //nome TEXT, cognome TEXT, data_registrazione DATE, indirizzo TEXT, stato BOOL
public void AddUser(string nome, string cognome, int dataRegistrazione, string indirizzo, bool stato)
{
    var command = new SQLiteCommand("INSERT INTO utenti (nome, cognome, data_registrazione, indirizzo, stato) VALUES (@nome, @cognome, @dataRegistrazione, @indirizzo, @stato)", _connection);
        command.Parameters.AddWithValue("@nome", nome);
        command.Parameters.AddWithValue("@cognome", cognome);
        command.Parameters.AddWithValue("@dataRegistrazione", dataRegistrazione);
        command.Parameters.AddWithValue("@indirizzo", indirizzo);
        command.Parameters.AddWithValue("@stato", stato);
        command.ExecuteNonQuery();  
}
public void AddBook(string titolo, int annoPubblicazione, int codiceISBN, bool disponibilità, int idAutore, int idGenere)
{
    var command = new SQLiteCommand("INSERT INTO libri (titolo, annoPubblicazione, codiceISBN, disponibilità, id_autore, id_genere) VALUES (@titolo, @annoPubblicazione, @codiceISBN, @disponibilità, @idAutore, @idGenere)", _connection);
        command.Parameters.AddWithValue("@titolo", titolo);
        command.Parameters.AddWithValue("@annoPubblicazione", annoPubblicazione);
        command.Parameters.AddWithValue("@codiceISBN", codiceISBN);
        command.Parameters.AddWithValue("@disponibilità", disponibilità);
        command.Parameters.AddWithValue("@idAutore", idAutore);
        command.Parameters.AddWithValue("@idGenere", idGenere);
        command.ExecuteNonQuery();  
}
public void AddAuthor(string nome, string cognome, int annoNascita, string luogoNascita)
{
    var command = new SQLiteCommand("INSERT INTO autori (nome, cognome, anno_nascita, luogo_nascita) VALUES (@nome, @cognome, @annoNascita, @luogoNascita)", _connection);
        command.Parameters.AddWithValue("@nome", nome);
        command.Parameters.AddWithValue("@cognome", cognome);
        command.Parameters.AddWithValue("@annoNascita", annoNascita);
        command.Parameters.AddWithValue("@luogoNascita", luogoNascita);
        command.ExecuteNonQuery();  
}

public List <Genere> GetGenres ()
{
    var command = new SQLiteCommand("SELECT * FROM generi ORDER BY nome_genere ASC", _connection);
    var reader = command.ExecuteReader();
    var genere = new List<Genere>();
    while (reader.Read())
    {
        genere.Add(new Genere
        {
            Id = reader.GetInt32(0),
            NomeGenere = reader.GetString(1),  
            Scaffale = reader.GetString(2)
        });
    }
    return genere;
}

public List <Autore> GetAuthors()
{
    var command = new SQLiteCommand("SELECT * FROM autori ORDER BY cognome ASC", _connection);
    var reader = command.ExecuteReader();  
    var autore = new List<Autore>(); //creazione della lista Autori
    while (reader.Read())
    {
        autore.Add(new Autore
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Cognome = reader.GetString(2)
        });
    }
    return autore; //restituzione della lista
}
}
                                                                