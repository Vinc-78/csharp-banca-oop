using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti
che una banca concede ai propri clienti.

La banca è caratterizzata da
- un nome
- un insieme di clienti (una lista)
- un insieme di prestiti concessi ai clienti (una lista)

I clienti sono caratterizzati da
- nome,
- cognome,
- codice fiscale
- stipendio

I prestiti sono caratterizzati da
- intestatario del prestito (il cliente),
- un ammontare, una rata,
- una data inizio,
- una data fine.

Per la banca deve essere possibile:
- aggiungere, modificare, eliminare e ricercare un cliente.
- aggiungere un prestito.
- effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
- sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.

Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo
con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere. */

namespace EserciziII_1
{
    public class Cliente
    {
         // si possono settare le varie variabili private e pubbliche per i relativi controlli
         //Esempio per nome
        private string _nome;
        public string Nome { get { return _nome; } set { if (Nome != null) { _nome = Nome; } else { Console.WriteLine("Nome non valido"); Environment.Exit(1) ; } } }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public double Stipendio { get; set; }

        public override string ToString()
        {
            //quando stampo Cliente ritorna questo formato

            return string.Format("Nome:{0}\nCognome: {1}\nCodice Fiscale: {2}\nStipendio: {3}",
                    this.Nome,
                    this.Cognome,
                    this.CodiceFiscale,
                    this.Stipendio

                );
            ;
        }

    }

    public class Prestito
    {
        public double Ammontare { get; set; }
        public double Rata { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public Cliente Intestatario { get; set; }

    }


    public class Banca 
    {
        private string NomeBanca { get; set; }

        private List<Cliente> lsCliente { get; set; }
        private List<Prestito> lsPrestiti { get; set; }


        public Banca(string sNome)
        {
            NomeBanca = sNome;
            lsCliente = new List<Cliente>();
            lsPrestiti = new List<Prestito>();


        }

        

        public void AggiungiCliente(string nome, string cognome, string codiceFiscale, double stipendio)
        {
                Cliente nuovoCliente = new Cliente();

                nuovoCliente.Nome = nome;
                nuovoCliente.Cognome = cognome;
                nuovoCliente.CodiceFiscale = codiceFiscale;
                nuovoCliente.Stipendio = stipendio;

                lsCliente.Add(nuovoCliente);

        }
        // nell'update ricerco per codice fiscale e aggiorno lo stipendio
        public bool UpdateCliente(string sCodiceFiscale, double nuovoStipendio)
        {
            for (int i = 0; i < lsCliente.Count; i++) 
            {
                if (lsCliente[i].CodiceFiscale == sCodiceFiscale ) 
                { 
                    lsCliente[i].Stipendio = nuovoStipendio;
                    return true;
                }
            }
            return false;
            
        }

        public bool EliminaCliente(string sCodiceFiscale)
        {
            foreach (Cliente cliente in lsCliente)
            {
                if (cliente.CodiceFiscale == sCodiceFiscale) 
                { lsCliente.Remove(cliente);
                    return true;
                }
                
            }
            return false;
            
        }

        public bool AggiungiPrestito(double ammontare, double rata, DateTime dataInizio, DateTime DataFine,  Cliente Intestatario ) 
        {

            foreach (Cliente cliente in lsCliente) 
            
            {
                if (Intestatario.CodiceFiscale == cliente.CodiceFiscale) 
                {
                    Prestito nuovoPrestito = new Prestito();
                    nuovoPrestito.Ammontare = ammontare;
                    nuovoPrestito.Rata = rata;
                    nuovoPrestito.DataInizio = dataInizio;
                    nuovoPrestito.DataFine = DataFine;
                    nuovoPrestito.Intestatario = Intestatario;

                    lsPrestiti.Add(nuovoPrestito);
                    return true ;
                }
            }
            return false;
           
        }

        //effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale

        public bool RicercaPrestito(string codiceFiscale)
        {
            foreach (Prestito prestito in lsPrestiti)
            {
                if (prestito.Intestatario.CodiceFiscale == codiceFiscale)
                { 
                    return true ;
                }
            }
            return false ;
        
        }

        //sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.

        public double AmmontarePrestiti(string codiceFiscale )
        {
            
            double totale =0.0;

            foreach (Prestito prestito in lsPrestiti)
            {
                if (prestito.Intestatario.CodiceFiscale == codiceFiscale)
                {
                    totale += prestito.Ammontare;

                }
            }

            return totale;


        }


       

    }
    /*
       


    public int GiorniAllaScadenza()
    {
        TimeSpan tsManca = DataFine - DataTime.Now;
        return (int)tsManca.TotalDays;
    }


    */


}