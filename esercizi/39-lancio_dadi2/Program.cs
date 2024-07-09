﻿Console.Clear();

int somma = 0;
int  [] frequenza= new int [6]; // Inizializza un array di 6 elementi a 0

Console.WriteLine("Quanti dadi vuoi lanciare?");
int numLanci = int.Parse(Console.ReadLine()); //input del numero di dadi che vogliamo lanciare

//creazione dell'array 
int [] risultatoLancio = new int[numLanci];

Random random = new Random(); 

for (int i = 0; i < numLanci; i++) 
{
    risultatoLancio[i] = random.Next(1, 7);
    Console.WriteLine($"Dado {i + 1}: è uscito il {risultatoLancio[i]}");
    somma += risultatoLancio[i];
    frequenza [risultatoLancio[i]-1]++; // Incrementa la frequenza del numero ottenuto
}

Console.WriteLine($"La somma dei dadi usciti è {somma}");

for (int i = 0; i < 6 ; i++)
{
    Console.WriteLine($"Frequenza del numero {i + 1}: {frequenza[i]}"); // Stampa la frequenza di ciascun numero
}

