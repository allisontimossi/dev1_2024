/*
Gli operatori sono utilizzati per eserguire operazioni su uno o più operandi

Gli operatori possono essere:

aritmetci
di confronto
logici
di assegnazione
*/

//esempio di utilizzo i operatori aritmetici

int a = 10;

int b = 20;

int somma = a + b;

int differenza = a - b;

int prodotto = a * b;

int divisione = a / b;

int modulo = a % b; // modulo = 10

// esempio di utilzzo degli operatori di confronto

int c = 30; 
int c ==a; //false, per chiedergli che la variabile sia uguale ad un specifico numero 

int c != a; //true, a=10 e c=30

int c > a;  //true

int c < a;  //false

int c >= a; //true

int c <= a; //false

// ESEMPIO DI UTILIZZO degli operatori logici

bool x = true;
bool y = false;


//and
bool z = x && y;        //false

/or
bool w = x || y;        //true

//not
bool v = !x;            //false

//esempio di utilizzo degli operatori di ssegnazione

/*
Gli operatori di assegnazione possono essere:

assegnazione (-)
assegnazione con addizione (+=)
assegnazione con sottrazione (-=)
*/

int d = 10;

d += 5; // d = 15
d -= 5  // d = 5

// esempio di utilizzo di operatori di incremento e decremento

int e = 10;

e++;        // e = 11 (per aumentarlo di 1 di default)

e --;       // e = 9 (per diminuirlo di 1 di default)

// esempio di utilizzo di operatori di concatenazione

string f = "Gello";

string g = "World";

string h = f + " " + g; //Hello World"

//esempio di concatenazione con interpolazione

string i = $"{f} {g}"; //i = "Hello World"