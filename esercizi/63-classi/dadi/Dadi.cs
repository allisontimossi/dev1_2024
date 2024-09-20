class Dado //la classe va maiuscola
{
    //Dichiarazione variabili
    private Random random= new Random(); //istanziato un nuovo OGGETTO random PRIVATE perché vogliamo che sia accessibile solodove vogliamo noi
    int facce; //istanziato una variabile di tipo intero chiamato facce

    //creiamo un metodo per Settare il numero di facce di un dado
    public void SetFacce(int facce)//tra parentesi dobbiamo dirgli quante
    {
        //la variabile facce 
        this.facce = facce;
    }
    //istanziare = creare nella mmoria del pc un'area dove risiede l'oggetto
    //non abbiamo fatto il costruttore: come fosse un metodo che istanziare e inizilizzare un oggetto quando lo creo
    // quando 
    public Dado (int facce) //
    {
        this.facce = facce;
    }
}