﻿Console.Clear();
Console.WriteLine("Giochiamo a Yahtzee! Premi un tasto per iniziare..");
Console.ReadKey(true);
bool dadiUguali = true;


Random random = new Random();
int[] dadi = new int[5];
    dadi[0] = random.Next(1,7);
    dadi[1] = random.Next(1,7);
    dadi[2] = random.Next(1,7);
    dadi[3] = random.Next(1,7);
    dadi[4] = random.Next(1,7);

for (int i = 0; i < 5; i++) 
{
    Console.WriteLine($"Dado {i +1} = {dadi[i]}");
}

/* CHIEDEREEEEEEEEEEEEEE
if (dadi [0] = dadi [1] = dadi [2] = dadi [3] = dadi [4]);
{
    Console.WriteLine("YAY! Hai vinto");
}
*/

//finché non siamo soddisfatti
while (dadiUguali)
{
    Console.WriteLine("Vuoi riprovare? (yes / no)");
    string riprovare = (Console.ReadLine());
    if (riprovare = "no")
        {
            Console.WriteLine("YAY! Hai vinto");
            dadiUguali = false;
        }
    else
        {
        Console.WriteLine("Quanti dadi vuoi rilanciare?");
        numeroDadiRilanciati = int.Parse();
        switch (numeroDadiRilanciati)
            {
                case 1:
                    Console.WriteLine("Quale dado vuoi rilanciare?");
                    dadi[rilancio1 - 1] = random.Next(1,7);

                break;
                case 2:
                    Console.WriteLine("Quali dadi vuoi rilanciare?");

                    int rilancio1 = int.Parse(Console.ReadLine());    
                    int rilancio2 = int.Parse(Console.ReadLine());
                    
                    dadi[rilancio1 - 1] = random.Next(1,7);
                    dadi[rilancio2 - 1] = random.Next(1,7);
                break;
                case 3:
                    Console.WriteLine("Quali dadi vuoi rilanciare?");

                    int rilancio1 = int.Parse(Console.ReadLine());    
                    int rilancio2 = int.Parse(Console.ReadLine());
                    int rilancio3 = int.Parse(Console.ReadLine());
                
                    dadi[rilancio1 - 1] = random.Next(1,7);
                    dadi[rilancio2 - 1] = random.Next(1,7);
                    dadi[rilancio3 - 1] = random.Next(1,7);
                break;
                case 4:
                    Console.WriteLine("Quali dadi vuoi rilanciare?");
                    int rilancio1 = int.Parse(Console.ReadLine());    
                    int rilancio2 = int.Parse(Console.ReadLine()); 
                    int rilancio3 = int.Parse(Console.ReadLine());    
                    int rilancio4 = int.Parse(Console.ReadLine());

                    dadi[rilancio1 - 1] = random.Next(1,7);
                    dadi[rilancio2 - 1] = random.Next(1,7);
                    dadi[rilancio3 - 1] = random.Next(1,7);
                    dadi[rilancio4 - 1] = random.Next(1,7);
                break;
                default:
                    Console.WriteLine("Hai scelto troppi dadi!");
                break;
            }
        for (int i = 0; i < 5; i++) 
            {
            Console.WriteLine($"Dado {i +1} = {dadi[i]}");
            }
        }
}