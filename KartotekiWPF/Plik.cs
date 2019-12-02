using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KartotekiWPF
{
    class Plik
    {
        public static string convertDocToTXT(string path)
        {
            Document document = new Document();
            try
            {
                document.LoadFromFile(path);

            }catch(Exception exc)
            {
                Console.WriteLine(exc);
            }
       
            //Save doc file.
            return document.GetText();
        }

        public static string[] convertDocToTXTLine(string path)
        {
            Document document = new Document();
            try
            {
                document.LoadFromFile(path);


            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            char[] charSeparators = new char[] { '\n' };
            string[] linie = document.GetText().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            return linie;
        }


        public static Tabela pobranieWartosciDoGMLZLinii(string[] textKartoteki)
        {
            Tabela tabela = new Tabela();
       
            for (int i = 0; i < textKartoteki.Count(); i++)
            {
                {
                    if (textKartoteki[i].Contains("miejscowość")) 
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.Miejscowosc = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Identyfikator TERYT miejscowości"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.IdObr = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Numer porządkowy"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.nrAdr = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Identyfikator działki ewidencyjnej"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                       tabela.NrDz = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Identyfikator budynku"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.IdBud = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Status budynku"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.StatusBud = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Rodzaj wg KŚT"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.RodzKST = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Klasa wg PKOB"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.KLASAPKOB = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("główna")) //9
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.GLFNBUD = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("budowy") && textKartoteki[i-1].Contains("Data zakończenia"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.RBB = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("budowy") && textKartoteki[i-1].Contains("Stopień pewności daty")) // STOPIEN PEWNOSCI 10
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.USTDATYBB = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Materiał ścian zewnętrznych")) 
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.SCN = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("podziemnych"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.LKONP = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("nadziemnych"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.LKON = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Pole powierzchni zabudowy"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.PEW = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Informacja czy budynek jest wiatą"))
                    {
                        Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.WIATA = textKartoteki[i + 1];
                    }

                }
              
            }
          //  tabela.wypiszWszystko();
            return tabela;
        }



            public static void pobranieWartosciDoGML(string textKartoteki) // niedokonczona metoda
        {
            Tabela tabela = new Tabela();

            Console.WriteLine(textKartoteki);
            Console.WriteLine("length1: " + textKartoteki.Length);

          //  textKartoteki = textKartoteki.Replace((char)0, ' ');//textKartoteki[2639] zamiana znakow zapytania 
 

            //wyszukanie nazwy miejscowosci
            //int indexMiejscStart = textKartoteki.IndexOf("m i e j s c o w o [") + 19; //<< odczyt dla surowego pliku .doc
            int indexMiejscStart = textKartoteki.IndexOf("miejscowość") + 11;
            //  int dlugoscMiejscKoniec = textKartoteki.IndexOf("I d e n t y f i k a t o r   T E R Y T   m i e j s c o w") - indexMiejscStart; //<< odczyt dla surowego pliku .doc 
            int dlugoscMiejscKoniec = textKartoteki.IndexOf("Identyfikator TERYT miejscowości") - indexMiejscStart;
            tabela.Miejscowosc = textKartoteki.Substring(indexMiejscStart, dlugoscMiejscKoniec);           

            //wyszukanie id obrebu
            int indexIdObrStart = textKartoteki.IndexOf("Identyfikator TERYT miejscowości") + 32;
            int dlugoscIdObrKoniec = textKartoteki.IndexOf("dzielnica") - indexIdObrStart;
            tabela.IdObr = textKartoteki.Substring(indexIdObrStart, dlugoscIdObrKoniec);


            //wyszukanie nr dzialki
            int indexDzialkaStart = textKartoteki.IndexOf("Identyfikator działki ewidencyjnej") + 34;
            int dlugoscDzialkaKoniec = textKartoteki.IndexOf("Identyfikator budynku") - indexDzialkaStart;
            tabela.NrDz = textKartoteki.Substring(indexDzialkaStart, dlugoscDzialkaKoniec);

            //wyszukanie nr porzadkowego
            int indexNrPorzadkStart = textKartoteki.IndexOf("Numer porządkowy") + 16;
            int dlugoscNrPorzadkKoniec = textKartoteki.IndexOf("Identyfikator działki ewidencyjnej") - indexNrPorzadkStart;
            tabela.nrAdr = textKartoteki.Substring(indexNrPorzadkStart, dlugoscNrPorzadkKoniec);



            Console.WriteLine("tabela miejscowosci:>" + tabela.Miejscowosc + "<end");
            Console.WriteLine("tabela id obr>" + tabela.IdObr);
            Console.WriteLine("tabela nrdz : ||>" + tabela.NrDz + "<||");
            Console.WriteLine("tabela nrADR : ||>" + tabela.nrAdr + "<||");
        
        }



        public static string odczytZPliku(string a) //odczyt z pliku z wyjatkami niepowodzenia należy podać ścieżkę, zwraca tablicę odczytaną z pliku
        {
            string all = "";
             //string[] lines = null;
            try
            {

                  
              all = System.IO.File.ReadAllText(a);

            }
            catch (Exception e)
            {
                Console.WriteLine("Do dupy: {0}", e.Message);
                MessageBox.Show("Błąd odcztu pliku txt lub csv.\nUpewnij się, że plik, \nktóry chcesz otworzyć jest zamknięty!", "ERROR", MessageBoxButton.OK);
            }
            return all;
        }



        public static string[] odczytZPlikuLinie(string a) //odczyt z pliku z wyjatkami niepowodzenia należy podać ścieżkę, zwraca tablicę odczytaną z pliku
        {
            string[] all = null;
            //string[] lines = null;
            try
            {


                all = System.IO.File.ReadAllLines(a);

            }
            catch (Exception e)
            {
                Console.WriteLine("Do dupy: {0}", e.Message);
                MessageBox.Show("Błąd odcztu pliku txt lub csv.\nUpewnij się, że plik, \nktóry chcesz otworzyć jest zamknięty!", "ERROR", MessageBoxButton.OK);

            }
            return all;
        }


        public static string metodaDopisujeZera(string liczba)
        {

            if (liczba.Length - liczba.IndexOf(",") == 5)
            {

            }
            else if (liczba.Length - liczba.IndexOf(",") == 4)
            {
                liczba += "0";
            }
            else if (liczba.Length - liczba.IndexOf(",") == 3)
            {
                liczba += "00";
            }
            else if (liczba.Length - liczba.IndexOf(",") == 2)
            {
                liczba += "000";
            }
            else if (liczba.Length - liczba.IndexOf(",") == 1)
            {
                liczba += "0000";
            }
            else
            {
                liczba += ",0000";
            }


            return liczba;
        }

    }
}