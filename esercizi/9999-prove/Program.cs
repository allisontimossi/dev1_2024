DateTime inizio_prestito = DateTime.Today;


        string data_inizio_prestito = inizio_prestito.ToShortDateString();
        string data_fine_prestito =  inizio_prestito.AddDays(30).ToShortDateString(); 

        System.Console.WriteLine("fine: " + data_fine_prestito);
        System.Console.WriteLine("inizio: " + data_inizio_prestito);