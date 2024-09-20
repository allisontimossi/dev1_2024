class Dado
{
    private Random random = new Random ();
    private int faces;
    public int Faces
    {   //sono metodi che permettono di avere qualcosa indietro (get) mentre con (set)
        get { return faces;}
        set { faces = value; }  
    }

    
    public Dado (int faces)
    {
        this.faces = faces;
    }
    public int Throw ()
    {
        return random.Next (1, faces+1);
    }
}

class Program{
    static void Main (string[] args)    
    {
        faces = int.Parse(Console.ReadLine());
        
        Dado dado1 = new Dado (6); //creiamo nello stack un'etichetta dado1 di tipo Dado
        Dado dado2 = new Dado (faces); //crea un dado con le facce indicate di default

        Dado dado3 = new Dado ();
        dado3.Faces = 12

        int n1 = dado1.Throw ();   
        int n2 = dado2.Throw ();   

        Console.WriteLine ($"Dado 1: {n1}");
        Console.WriteLine ($"Dado 2: {n2}");
    }
}