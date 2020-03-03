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
             
                var resultat = MessageBox.Show("Błąd otwarcia pliku: " + path + "Wyłączyć program?", "ERROR", MessageBoxButton.YesNo);

                if (resultat == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }


            }

            char[] charSeparators = new char[] { '\n' };
            string[] linie = document.GetText().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            return linie;
        }


        public static string[] pobranieWartoscZTXT(string LiniaTekstu, char separator)
        {


            char[] charSeparators = new char[] {separator};
            string[] wartosciZlini =  LiniaTekstu.Split(charSeparators);

            return wartosciZlini;
        }

        public static string[] pobranieWartoscKW(string LiniaTekstu)
        {


            char[] charSeparators = new char[] { '\t', ',' };
            string[] wartosciZlini = LiniaTekstu.Trim().Split(charSeparators);

            return wartosciZlini;
        }

        public static string[] pobranieWartoscZTXT(string LiniaTekstu, string separator, StringSplitOptions a = StringSplitOptions.None)
        {


            string[] charSeparators = new string[] { separator };
            string[] wartosciZlini = LiniaTekstu.Split(charSeparators, a);

            return wartosciZlini;
        }

        public static Tabela pobranieWartosciDoGMLZLinii(string[] textKartoteki)
        {
            Tabela tabela = new Tabela();
       
            for (int i = 0; i < textKartoteki.Count(); i++)
            {
                {
                    if (textKartoteki[i].Contains("miejscowość")) 
                    {
                      //  Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.Miejscowosc = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Identyfikator TERYT miejscowości"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.IdObr = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Numer porządkowy"))
                    {
                        //Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.nrAdr = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Identyfikator działki ewidencyjnej"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                       tabela.NrDz = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Identyfikator budynku"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.IdBud = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Status budynku"))
                    {
                      //  Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.StatusBud = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Rodzaj wg KŚT"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.RodzKST = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Klasa wg PKOB"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.KLASAPKOB = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("główna")) //9
                    {
                      //  Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.GLFNBUD = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("budowy") && textKartoteki[i-1].Contains("Data zakończenia"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.RBB = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("budowy") && textKartoteki[i-1].Contains("Stopień pewności daty")) // STOPIEN PEWNOSCI 10
                    {
                      //  Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.USTDATYBB = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Materiał ścian zewnętrznych")) 
                    {
                      //  Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.SCN = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("podziemnych"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.LKONP = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("nadziemnych"))
                    {
                      //  Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.LKON = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Pole powierzchni zabudowy"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.PEW = textKartoteki[i + 1];
                    }
                    else if (textKartoteki[i].Contains("Informacja czy budynek jest wiatą"))
                    {
                       // Console.WriteLine("item>" + textKartoteki[i + 1]);
                        tabela.WIATA = textKartoteki[i + 1];
                    }

                }
              
            }
          //  tabela.wypiszWszystko();
            return tabela;
        }




        public static string odczytZPlikuCalyTekst(string a) //odczyt z pliku z wyjatkami niepowodzenia należy podać ścieżkę, zwraca cały text
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
                    all = System.IO.File.ReadAllLines(a, Encoding.Default);
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