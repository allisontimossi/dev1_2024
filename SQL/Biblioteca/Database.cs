using System.Configuration;
 // Importazione del namespace per utilizzare SQLite
using System.Data.SQLite;
class Database
{
    //Impostazione dell'accesso privato
    private SQLiteConnection _connection;

//Inizializzazione del database per creare le tabelle Prestiti, Utenti, Libri, Autori
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

        CREATE TABLE IF NOT EXISTS libri (id_libro INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT, annoPubblicazione INT, disponibilità BOOL, id_autore INTEGER NOT NULL, id_genere INTEGER,
        FOREIGN KEY (id_autore) REFERENCES autori(id_autore),
        FOREIGN KEY (id_genere) REFERENCES generi(id_genere));
        
        CREATE TABLE IF NOT EXISTS prestito (id_prestito INTEGER PRIMARY KEY, data_inizio_prestito DATE, data_fine_prestito DATE, id_utente INTEGER, id_libro INTEGER,
        FOREIGN KEY (id_libro) REFERENCES libri (id_libro),
        FOREIGN KEY (id_utente) REFERENCES utenti (id_utente));
        ";
        var command = new SQLiteCommand(sql, _connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }




public void NuovoPrestito (string data_inizio_prestito, string data_fine_prestito, int idUtente, int idLibro, bool disponibilità)
{
    var command = new SQLiteCommand("INSERT INTO prestito (data_inizio_prestito, data_fine_prestito, id_utente, id_libro) VALUES (@data_inizio_prestito, @data_fine_prestito, @idUtente, @idLibro)", _connection);
        command.Parameters.AddWithValue("@data_inizio_prestito", data_inizio_prestito);
        command.Parameters.AddWithValue("@data_fine_prestito", data_fine_prestito);
        command.Parameters.AddWithValue("@idUtente", idUtente);
        command.Parameters.AddWithValue("@idLibro", idLibro);
      command.ExecuteNonQuery();   

    var command2 = new SQLiteCommand("UPDATE libri SET disponibilità = 0 WHERE idLibro = @idLibro", _connection);
        command2.Parameters.AddWithValue("@idLibro, idLibro");
        command2.ExecuteNonQuery(); 
    
}
public void AddUser(string nome, string cognome, string dataRegistrazione, string indirizzo, bool stato)
{
    var command = new SQLiteCommand("INSERT INTO utenti (nome, cognome, data_registrazione, indirizzo, stato) VALUES (@nome, @cognome, @dataRegistrazione, @indirizzo,  @stato)", _connection);
        command.Parameters.AddWithValue("@nome", nome);
        command.Parameters.AddWithValue("@cognome", cognome);
        command.Parameters.AddWithValue("@dataRegistrazione", dataRegistrazione);
        command.Parameters.AddWithValue("@indirizzo", indirizzo);
        command.Parameters.AddWithValue("@stato", stato);
        command.ExecuteNonQuery();  
}

public void AddBook(string titolo, int annoPubblicazione, bool disponibilità, int idAutore, int idGenere)
{
    var command = new SQLiteCommand("INSERT INTO libri (titolo, annoPubblicazione, disponibilità, id_autore, id_genere) VALUES (@titolo, @annoPubblicazione, @disponibilità, @idAutore, @idGenere)", _connection);
        command.Parameters.AddWithValue("@titolo", titolo);
        command.Parameters.AddWithValue("@annoPubblicazione", annoPubblicazione);

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

// Creazione di un comando per leggere gli utenti: creazione di una Lista Utenti + compliazione reader + restituzione Lista
public List <User> GetUsers ()
{
    var command = new SQLiteCommand("SELECT * FROM utenti", _connection);
    var reader = command.ExecuteReader();
    var utenti = new List<User> ();

    while (reader.Read()) 
    {
        utenti.Add(new User 
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Cognome = reader.GetString(2)
        }
        );
    }
    return utenti;
}
// Creazione di un comando per leggere gli generi: creazione di una Lista Generi + compliazione reader + restituzione Lista

public List <Genere> GetGenres ()
{
    var command = new SQLiteCommand("SELECT * FROM generi", _connection);
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
// Creazione di un comando per leggere gli Autori: creazione di una Lista Autori + compliazione reader + restituzione Lista

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

// Creazione di un comando per Cercare libri sugli Scaffali
// JOIN tra tabella Libri e tabella Generi con sola visualizzazione Libro e Scaffale

public List<Libri> SearchBookByName(string titolo)
{
    var command = new SQLiteCommand($"SELECT libri.titolo, libri.disponibilità, generi.scaffale AS scaffale FROM libri JOIN generi ON libri.id_genere = generi.id_genere WHERE titolo = '{titolo}'", _connection);
    var reader = command.ExecuteReader();
    var libro = new List<Libri>();
    while (reader.Read())
    {
        libro.Add(new Libri
        {
            Titolo = reader.GetString(0),
            Disponibilità = reader.GetBoolean(1),
            Scaffale = reader.GetString(2),
        });
    }
    return libro;
}
public void CloseConnection()
{
    if (_connection.State != System.Data.ConnectionState.Closed)
    {
        _connection.Close();
    }
}
}
                                                                