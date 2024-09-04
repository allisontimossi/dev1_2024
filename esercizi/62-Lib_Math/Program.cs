int [] numeri = {5, -9, 1, 3, 4};
int max = numeri [0];
int min = numeri [0];

//ricerca del numero piùgrande e più piccolo all'interno dell'array
for (int i = 1; i < numeri.Length; i ++)
{
    max = Math.Max(max, numeri[i]);
    min = Math.Min(min, numeri [i]);    
}

//stampa
Console.WriteLine("Massimo: " + max);
Console.WriteLine("Minimo: " + min);

//arrotondamento di numeri
double [] numeri2 = {3.14159, 2.71828, 1.61803};

for (int i = 0; i < numeri2.Length; i++)
{
    double arrotondamentoPerEccesso = Math.Ceiling(numeri2[i]);
    double arrotondamentoPerDifetto = Math.Floor(numeri2[i]);
    Console.WriteLine("Numero arrotondato per eccesso: " + arrotondamentoPerEccesso);
    Console.WriteLine("Numero arrotondato per difetto: " + arrotondamentoPerDifetto);
    Console.WriteLine("");
}

//arrotondamento di numeri
double [] numeri3 = {3.5, 4.5, 5.5};
for (int i = 0; i < numeri3.Length; i++)
{
    double arrotondamentoPerEccesso2 = Math.Round(numeri3[i], MidpointRounding.AwayFromZero); //AwayFromZero: arrotonda per eccesso
    double arrotondamentoPerDifetto2 = Math.Round(numeri3[i], MidpointRounding.ToEven);       //ToEven: arrotonda per eccesso
    Console.WriteLine("Numero arrotondato per difetto: " +arrotondamentoPerDifetto2);
    Console.WriteLine("Numero arrotondato per eccesso: " +arrotondamentoPerEccesso2);
    Console.WriteLine("");
}

//
int dividendo = 10;
int divisore = 0;
int quoziente = Math.DivRem (dividendo, divisore, out int resto);
Console.WriteLine("Quoziente: " + quoziente);
Console.WriteLine("Resto: " + resto);