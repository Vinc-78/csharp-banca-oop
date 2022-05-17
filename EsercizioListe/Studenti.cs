using System;
using System.Collections.Generic;

namespace EserciziII_1
{
    public class Studente
    {
        public string sCodiceFiscale;
        public string nome;
        public string cognome;
        public DateTime dataDiNascita ;
        public ulong matricola; 

    }

    public class Università
    {
       
        
        private List<string> lsSedi;
        private Dictionary<string, Studente> lsStudenti;

       // private List<Studente> lsStudenti;

        public Università()
        { 
            lsSedi = new List<string>();
            lsStudenti = new Dictionary<string, Studente>();
        
        }
        public void AggiungiSedi(string newSede) 
        {
            lsSedi.Add(newSede);
        }

        public bool AggiungiStudente(string sCodiceFiscale, string nome, string cognome, string dataNascita, ulong matricola)
        {
                      

            DateTime dtDataNascitaStudente;

            if (DateTime.TryParse(dataNascita, out dtDataNascitaStudente))
            {

                Studente newStudente = new Studente();

                newStudente.sCodiceFiscale = sCodiceFiscale;
                newStudente.nome = nome;
                newStudente.cognome = cognome;
                newStudente.dataDiNascita = dtDataNascitaStudente;
                newStudente.matricola = matricola;

                lsStudenti.Add(sCodiceFiscale, newStudente);

                return true;
            }
            else { 
                Console.WriteLine("Data non valida");
                return false; 
            }
   
        }

        public void RimuoviSede(string sSede)
        { 
            lsSedi.Remove(sSede);
        }


        public bool RimuoviStudente(string sCodiceFiscale)
        {

            return lsStudenti.Remove(sCodiceFiscale);
        }


        /* public void RimuoviStudente(ulong lMatricola)
         {
             foreach (Studente studente in lsStudenti)
             {
                 if (studente.matricola == lMatricola) 
                 {
                     lsStudenti.Remove(studente);
                     return;

                 }
                 else Console.WriteLine("Studente non trovato ");
             }

         } */

        // il foreach

        public void RimuoviStudente(ulong lMatricola)
        {
            foreach (string sCodiceFiscale in lsStudenti.Keys)
            {
                if (lsStudenti[sCodiceFiscale].matricola == lMatricola)
                {
                    lsStudenti.Remove(sCodiceFiscale);
                    return;

                }
                else Console.WriteLine("Studente non trovato ");
            }

        }

        public bool CercaSede(string sSede) 
        {
            foreach (string sede in lsSedi)
            {
                if (sede.ToLower() == sSede.ToLower()) 
                { 
                    return true;
                }

            }
            return false;

        }

        /*
        public void CercaStudente(int anno, out List<Studente>TrovatiList)
        {
            TrovatiList = new List<Studente>();

            foreach (Studente studente in lsStudenti)
            {
                if (studente.dataDiNascita.Year == anno) 
                { 
                    TrovatiList.Add(studente);
                }
            }


            // oppure TrovatiList = lsStudenti.FindAll(t => t.dataDiNascita.Year == anno);


        }
        
        */

    }
}
