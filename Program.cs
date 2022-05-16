using System;

namespace EserciziII_1
{
    internal class Program
    {
        static void Main(string[] args)  //entry point
          {
            Studente applicazione = new Studente();

            Console.WriteLine("Lista operazioni ");
            //scrivere la lista delle operazioni con un switch si seleziona il metodo

            // con uno switch o un for accedere al metodo che serve chiedendo le relative informazioni

            Banca nuovaBanca = new Banca("MiaBanca");

            nuovaBanca.AggiungiCliente("Marco", "Rossi", "codiceRossi", 1000.00);

            nuovaBanca.UpdateCliente("codiceRossi", 1200.00);



        }


    }
}