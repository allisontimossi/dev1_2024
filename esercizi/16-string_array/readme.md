La parentesi quadra identifica l'array. 
string[] 
La parola "new" identifica un costruttore: identifica l'array di stringhe.
Dentro alle parentesi quadre dobbiamo mettere la lunghezza dell'array: gli elementi nell'array devono corrispondere al numero messo in oggetto.

Riserviamo all'interno della memoria un determinato spazio.
Con gli indici "indicizziamo" i valori, in questo caso i nomi. (li ordiniamo per numero)
Li andiamo a richiamare in stampa a seconda dell'indice. Se in lista si invertono i nomi, i nomi si invertono anche in output
string [] nomi = new string [3];
nomi[1] = "Mario";
nomi[0] = "Luigi";
nomi[2] = "Bowser";
Console.WriteLine ($"Ciao {nomi[0]}, {nomi[1]}, {nomi[2]}");

Se li voglio stampare tutti: Console.WriteLine ($"Ciao {nomi}");