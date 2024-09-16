using System.Data.SQLite;
using Spectre.Console;
class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db"; // la rotta del file del database
        if (!File.Exists(path)) // se il file del database non esiste
        {
            SQLiteConnection.CreateFile(path); // crea il file del database
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al database la versione 3 è un indicazione della versione del database e può esser personalizzata
            connection.Open(); // apre la connessione al database
            string sql = @"
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
                        ";

            SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
            command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
            connection.Close(); // chiude la connessione al database
        }
        while (true)
        {

            Console.WriteLine("Benvenuto!");
            Console.WriteLine("Scegli un'opzione:");
            string scelta = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                .AddChoices(new[] {
                    "Inserisci prodotto", "Visualizza prodotti", "Classifiche", "Aggiornamenti Record","Elimina prodotto","Esci dal programma"
                    })); 

            if (scelta == "Inserisci prodotto")
            {
                InserisciProdotto();
            }
            else if (scelta == "Visualizza prodotti")
            {
                VisualizzaProdotti();
            }
            else if (scelta == "Classifiche")
            {
                Classifiche();
            }
            else if (scelta == "Aggiornamenti Record")
            {
                AggiornamentiRecord();
            }

            else if (scelta == "Elimina prodotto")
            {
                EliminaProdotto();
            }
            else if (scelta == "Esci dal programma")
            {
                break;
            }
            
        }
    }

    static void InserisciProdotto()
    {
        Console.WriteLine("Inserisci il nome del prodotto: ");
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il prezzo del prodotto: ");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("inserisci la quantità del prodotto: ");
        string quantita = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
        connection.Open(); // apre la connessione al database
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";
        SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
        connection.Close(); // chiude la connessione al database
    }

    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
        connection.Open(); // apre la connessione al database
        string sql = "SELECT * FROM prodotti";
        SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        }
        connection.Close(); // chiude la connessione al database
    }

    static void AggiornamentiRecord()
    {
        Console.Write("\nCosa vuoi aggiornare?");
            string scelta3 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                        .AddChoices(new[] {
                            "Nome prodotto", "Prezzo prodotto","Quantità prodotto"
                            })); 
            switch (scelta3)
            {
                case "Nome prodotto":
                AggiornaNomeProdotto();
                break;
                case "Prezzo prodotto":
                AggiornaPrezzoProdotto();
                break;
                case "Quantità prodotto":
                AggiornaQuantitàProdotto();
                break;
            }
    }
    static void Classifiche()
    {
    string scelta2 = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                    .AddChoices(new[] {
                        "Top 3 prodotti più costosi", "Top 3 prodotti meno costosi"
                        })); 
    switch (scelta2)
    {
    case "Top 3 prodotti più costosi":
        SQLiteConnection connection2 = new SQLiteConnection($"Data Source=database.db;Version=3;"); 
        connection2.Open(); 
        string sql2 = "SELECT * FROM prodotti ORDER BY prezzo DESC LIMIT 3";
        SQLiteCommand command2 = new SQLiteCommand(sql2, connection2); 
        SQLiteDataReader reader2 = command2.ExecuteReader(); 
        while (reader2.Read())
        {
            Console.WriteLine($"id: {reader2["id"]}, nome: {reader2["nome"]}, prezzo: {reader2["prezzo"]}, quantita: {reader2["quantita"]}");
        }
        connection2.Close(); 
    break;
    case "Top 3 prodotti meno costosi":
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); 
        connection.Open(); 
        string sql = "SELECT * FROM prodotti ORDER BY prezzo ASC LIMIT 3";
        SQLiteCommand command = new SQLiteCommand(sql, connection); 
        SQLiteDataReader reader = command.ExecuteReader(); 
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        }
        connection.Close();
    break;
    }
    }

static void AggiornaNomeProdotto()
{
    Console.Write("Inserisci il nome del prodotto da rinominare: ");
    string nome = Console.ReadLine()!;
    Console.Write("Digita la quantità aggiornata: ");
    string nomeNuovo = Console.ReadLine()!;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();
    string sql = $"UPDATE prodotti SET nome = '{nomeNuovo}' WHERE nome = '{nome}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close(); 
}

static void AggiornaPrezzoProdotto()
{
    Console.Write("Inserisci il nome del prodotto a cui cambiare il prezzo: ");
    string nome = Console.ReadLine()!;
    Console.Write("Digita il prezzo aggiornato: ");
    string prezzo = Console.ReadLine()!;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();
    string sql = $"UPDATE prodotti SET prezzo = {prezzo} WHERE nome = '{nome}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close(); 
}

static void AggiornaQuantitàProdotto()
{
    Console.Write("Inserisci il nome del prodotto di cui aggiornare la quantità: ");
    string nome = Console.ReadLine()!;
    Console.Write("Digita la quantità aggiornata: ");
    string quantita = Console.ReadLine()!;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();
    string sql = $"UPDATE prodotti SET quantita = {quantita} WHERE nome = '{nome}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close(); 
}


    static void EliminaProdotto()
    {
        Console.Write("inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
        connection.Open(); // apre la connessione al database
        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
        connection.Close(); // chiude la connessione al database
    }
}