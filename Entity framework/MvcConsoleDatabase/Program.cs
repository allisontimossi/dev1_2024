using Microsoft.EntityFrameworkCore;
class Program
{
static void Main(string[] args)
{
    //crea un'istanza del database
    var db = new Database ();
    //crea un'istanza della vista
    var view = new View (db);
    //crea un'istanza del controller
    var controller = new Controller (db, view);

    //avvia il menu princiaple
    controller.MainMenu();
}
}
class User
{
    public int Id { get; set; } //chiave primaria
    public string Name { get; set; } //nome dell'utente
}
//Estendiamo la classe DbContext  con il database
class Database : DbContext 
{
    public DbSet<User> Users { get; set; } //tabella degli utenti
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=database.db"); //utilizzo di un database SQLite
    }
}
class View{
private Database _db;
    public View  (Database db)
    {
        _db=db;
    }
    public void ShowMainMenu()
    //anziché interfacciarsi con SQLite si interfacciano con l'utente mediante dei cicli
    //senza fare la richiesta sql e mostrarci il contenuto della tabella
    //andiamo a chiamare direttamente la lista (non l'abbiamo ancora popolata)
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Esci");
    }
    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }

   //Legge l'input dell'utente
    public string GetInput()
    {
        return Console.ReadLine(); //Legge l'input dell'utente
    }
}

class Controller{
    //costruttore che inizializza il database e la vista
    private Database _db; //Databse del controller
    private View _view;
    
    public Controller (Database db, View view)
    {
        _db = db;
        _view = view;
    }


public void MainMenu()
{   //elenco di operazioni CRUD 
    while (true)
    {   
        _view.ShowMainMenu();
        var input = _view.GetInput();
        if (input =="1")
        {
            AddUser();
        }
        if (input =="2")
        {
            ShowUsers(); //lancio il comando
        }
        if (input =="3")
        {
            UpdateUser(); //lancio il comando
        }
        if (input =="4")
        {
            DeleteUser(); //lancio il comando
        }
        if (input =="5")
        {
            break; //lancio il comando
        }
    }
}
private void AddUser()
{
    //prima dovevamo specificare delle cose, qui sappiamo già di dover andare a lavorare sulla tbella User e a lavora solamente su un utente mettendoci il parametro name
    Console.WriteLine ("Enter user name:");
    var name = _view.GetInput();
    //Aggiunta di un utente al database
    _db.Users.Add(new User {Name = name});
    //Salva le modifiche
    _db.SaveChanges();
}

private void ShowUsers()
{
    //Prende tutti gli utenti dal database
    var users = _db.Users.ToList(); 
    //.. e li mostra
    _view.ShowUsers(users);
}
private void UpdateUser()
{
    Console.Write ("Enter user name:");
    var oldName = _view.GetInput();
    Console.Write ("Enter NEW user name:");
    var newName = _view.GetInput();

    User user = null; //inizializza l'utente a null
    foreach (var u in _db.Users)
    {
        if (u.Name == oldName)
        {
            user = u; //trova l'utente con il nome specificato
            break;  //esce dal ciclo una volta trovato l'utente
        }
    }

    if (user != null)
    {
        user.Name = newName;
        _db.SaveChanges();
    }
}
private void DeleteUser()
{
    Console.WriteLine ("Enter user name: ");
    var name = _view.GetInput();

    User userToDelete = null;
    foreach (var user in _db.Users)
    {
        if (user.Name == name)
        {
            userToDelete = user;
            break; //esce dal ciclo una volta trovato l'utente
        }
    }
    if (userToDelete != null)
    {
        _db.Users.Remove(userToDelete); //rimuove l'utente
        _db.SaveChanges();
    }
}
}