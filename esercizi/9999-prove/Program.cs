
class Program
{

    int [] secretCode;
    static int attempts = 0;

    static void Main(string[] args)
    {
        GenerateSecretCode();
        Console.WriteLine("Benvenuto a Mastermind! Prova a indovinare il codice di 4 numeri (ciascuno da 1 a 6).");
        Console.WriteLine($"Codice segreto: {string.Join(",", secretCode)}");

        while (true)
        {
            Console.Write("Inserisci il tuo tentativo (es. 1,2,3,4): ");
            string input = Console.ReadLine();
            int[] guess = Array.ConvertAll(input.Split(','), int.Parse);
            bool isCorrect = EvaluateGuess(guess);

            if (isCorrect)
            {
                Console.WriteLine("Complimenti! Hai indovinato il codice segreto!");
                break;
            }
        }
    }

    static void GenerateSecretCode()
    {
        secretCode = new int [4];
        Random random = new Random();
        for (int i = 0; i < secretCode.Length; i++)
        {
            secretCode[i] = random.Next(1, 7);  // Numeri da 1 a 6
        }
    }

    static bool EvaluateGuess(int[] guess)
    {
        int correctPositions = 0, correctNumbers = 0;
        bool[] visited = new bool[4];
        bool[] guessVisited = new bool[4];

        // Controllare la posizione corretta
        for (int i = 0; i < 4; i++)
        {
            if (guess[i] == secretCode[i])
            {
                correctPositions++;
                visited[i] = true;
                guessVisited[i] = true;
            }
        }

        // Controllare i numeri corretti ma in posizione sbagliata
        for (int i = 0; i < 4; i++)
        {
            if (!guessVisited[i])
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!visited[j] && guess[i] == secretCode[j])
                    {
                        correctNumbers++;
                        visited[j] = true;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"Tentativo {++attempts}: {string.Join(",", guess)} - Numeri giusti nelle posizioni giuste: {correctPositions}, Numeri giusti ma in posizioni sbagliate: {correctNumbers}");
        return correctPositions == 4;
    }
}