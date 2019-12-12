using Microsoft.Win32;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace KartotekiWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void wczytanieUstawienDomyślnych()
        {
            try
            {
                radioButtonTabulator.IsChecked = Properties.Settings.Default.boolExportTab;
                radioButtonSrednik.IsChecked = Properties.Settings.Default.booIExportsrednik;
                radioButtonPrzecinek.IsChecked = Properties.Settings.Default.boolExportPrzecinek;
                radioButtonWlasny.IsChecked = Properties.Settings.Default.boolExportWlasny;
                textboxSeparator.Text = Properties.Settings.Default.textExportWlasny;

                radioButtonimportDoc.IsChecked = Properties.Settings.Default.boolImportDOC;
                importTab.IsChecked = Properties.Settings.Default.boolImportTab;
                importWlasny.IsChecked = Properties.Settings.Default.boolImportDOC;
                textboxSeparatorImport.Text = Properties.Settings.Default.textImportwlasny;

                textboxKodPocztowy.Text = Properties.Settings.Default.textBoxKodPocztowy;
                textBoxMiejscowoscGdyBrakWTabeli.Text = Properties.Settings.Default.textBoxMiejcscowoscGdyBrakWTabeli;

                if (!((bool)radioButtonimportDoc.IsChecked || (bool)importTab.IsChecked || (bool)importWlasny.IsChecked))
                {
                    radioButtonimportDoc.IsChecked = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd wczytania ustawień domyślnych. " + e);
            }
        }

        public void zapisUstawienDomyslnych()
        {
            try
            {
                Properties.Settings.Default.boolExportTab = (bool)radioButtonTabulator.IsChecked;
                Properties.Settings.Default.booIExportsrednik = (bool)radioButtonSrednik.IsChecked;
                Properties.Settings.Default.boolExportPrzecinek = (bool)radioButtonPrzecinek.IsChecked;
                Properties.Settings.Default.boolExportWlasny = (bool)radioButtonWlasny.IsChecked;
                Properties.Settings.Default.textExportWlasny = textboxSeparator.Text;

                Properties.Settings.Default.boolImportDOC = (bool)radioButtonimportDoc.IsChecked;
                Properties.Settings.Default.boolImportTab = (bool)importTab.IsChecked;
                Properties.Settings.Default.boolImportDOC = (bool)importWlasny.IsChecked;
                Properties.Settings.Default.textImportwlasny = textboxSeparatorImport.Text;

                Properties.Settings.Default.textBoxKodPocztowy = textboxKodPocztowy.Text;
                Properties.Settings.Default.textBoxMiejcscowoscGdyBrakWTabeli = textBoxMiejscowoscGdyBrakWTabeli.Text;

                Properties.Settings.Default.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd zapisu ustawien domyslnych. " + e);
            }
        }


        // public XpsDocument(string path, System.IO.FileAccess packageAccess);
        List<Tabela> wczytaneKartoteki = new List<Tabela>();
        List<TabelaGML> listaKartotekGML = new List<TabelaGML>();
        public MainWindow()
        {

            InitializeComponent();
            wczytanieUstawienDomyślnych();

            dgUsers.ItemsSource = wczytaneKartoteki;
            dgUsers.Items.Refresh();

            dgUsersGML.ItemsSource = listaKartotekGML;
            dgUsersGML.Items.Refresh();
 
            try
            {

                Title = "GML inż. Marek Wojciechowicz    Wersja nr " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            }
            catch
            {
                Console.WriteLine("błąd odczytu versji");
            }
        }

        private void UpdateProgress()
        {
            progresBar.Value += 1;
        }
        private delegate void ProgressBarDelegate();



        string calyOdczzytanyText = "";
        string[] calyOdczzytanyTextLinie = null;
        private void OtworzZPliku(object sender, RoutedEventArgs e)
        {
            zapisUstawienDomyslnych();
            poczatek:
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (importTab.IsChecked == true)
            {
                dlg.Multiselect = false;
            }
            else if (importWlasny.IsChecked == true)
            {
                dlg.Multiselect = false;
            }
            else if (radioButtonimportDoc.IsChecked == true)
            {
                dlg.Multiselect = true;
            }
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";

            dlg.Filter = "All files(*.*) | *.*|TXT Files (*.txt)|*.txt| CSV(*.csv)|*.csv";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                // textBox1.Text = filename;

                try
                {
                    progresBar.Maximum = dlg.FileNames.Count();
                    // calyOdczzytanyText = Plik.odczytZPliku(filename);
                    //Console.WriteLine(filename);
                    //calyOdczzytanyText = Plik.convertDocToTXT(filename);

                    wczytaneKartoteki.Clear();
                    listaKartotekGML.Clear();
                    calyProgram.IsEnabled = false;

                    if (importTab.IsChecked == true)
                    {
                        calyOdczzytanyTextLinie = Plik.odczytZPlikuLinie(dlg.FileName);

                        foreach (var item in calyOdczzytanyTextLinie)
                        {
                            Console.WriteLine(item);
                            wczytaneKartoteki.Add(new Tabela(Plik.pobranieWartoscZTXT(item, '\t')));
                            progresBar.Dispatcher.Invoke(new ProgressBarDelegate(UpdateProgress), DispatcherPriority.Background);
                        }
                    }
                    else if (importWlasny.IsChecked == true)
                    {
                        calyOdczzytanyTextLinie = Plik.odczytZPlikuLinie(dlg.FileName);

                        foreach (var item in calyOdczzytanyTextLinie)
                        {

                            wczytaneKartoteki.Add(new Tabela(Plik.pobranieWartoscZTXT(item, textboxSeparatorImport.Text)));

                            progresBar.Dispatcher.Invoke(new ProgressBarDelegate(UpdateProgress), DispatcherPriority.Background);
                        }
                    }
                    else
                    {
                        foreach (var item in dlg.FileNames)
                        {

                            calyOdczzytanyTextLinie = Plik.convertDocToTXTLine(item);

                            wczytaneKartoteki.Add(Plik.pobranieWartosciDoGMLZLinii(calyOdczzytanyTextLinie));
                            progresBar.Dispatcher.Invoke(new ProgressBarDelegate(UpdateProgress), DispatcherPriority.Background);

                        }
                    }
                    calyProgram.IsEnabled = true;
                }
                catch (Exception esa)
                {
                    /*var resultat = MessageBox.Show(esa.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

                    if (resultat == MessageBoxResult.Yes)
                    {
                        goto poczatek;
                    }
                    Console.WriteLine(esa + "goto poczatek catch");
                   */
                }

                for (int i = 0; i < wczytaneKartoteki.Count; i++)
                {
                    wczytaneKartoteki[i].ustawID( i + 1);
                }

                dgUsers.Items.Refresh();
                dgUsersGML.Items.Refresh();
                progresBar.Value = 0;
                /*       wczytaneKartoteki.Sort(delegate (Tabela x, Tabela y)
                        {
                            if (x.IdObr == null && y.IdObr == null) return 0;
                            else if (x.IdObr == null) return -1;
                            else if (y.IdObr == null) return 1;
                            else return x.IdObr.CompareTo(y.IdObr);
                        });*/

                // Plik.pobranieWartosciDoGML(calyOdczzytanyText);


                calyProgram.IsEnabled = true;
            }
        }



        private void ZapiszDoPliku(object sender, RoutedEventArgs e)
        {
            zapisUstawienDomyslnych();
            SaveFileDialog svd = new SaveFileDialog();
            svd.DefaultExt = "";
            svd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*|HTML (*.html)|*.html|doc (*.doc)|*.doc";
            if (svd.ShowDialog() == true)
            {

                using (Stream s = File.Open(svd.FileName, FileMode.Create))
                //  using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                    try
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            string separ = "";
                            if (radioButtonSrednik.IsChecked == true)
                            {
                                separ = ";";
                            }
                            else if (radioButtonPrzecinek.IsChecked == true)
                            {
                                separ = ",";
                            }
                            else if (radioButtonWlasny.IsChecked == true)
                            {
                                separ = textboxSeparator.Text;
                            }
                            else
                            {
                                separ = "\t";
                            }

                            if (sender.ToString().Contains("Standard"))
                            {
                                foreach (var item in wczytaneKartoteki)
                                {

                                    sb.AppendLine(item.wypiszPoziomoZSeparotorem(separ));

                                }
                            }
                            else
                            {
                                foreach (var item in listaKartotekGML)
                                {

                                    sb.AppendLine(item.wypiszPoziomoZSeparotorem(separ));

                                }
                            }

                            //Console.WriteLine(sb.ToString());
                            sw.Write(sb.ToString());
                            sw.Close();
                        }
                        catch (Exception exc)
                        {
                            var resultat = MessageBox.Show(exc.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

                            if (resultat == MessageBoxResult.Yes)
                            {
                                Application.Current.Shutdown();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var resultat = MessageBox.Show(ex.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

                        if (resultat == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                    }
            }
        }


        private void MenuItem_ClickZamknij(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();
            zapisUstawienDomyslnych();
        }

        private void GenerujGML(object sender, RoutedEventArgs e)
        {
            listaKartotekGML.Clear();
            foreach (var item in wczytaneKartoteki)
            {
                listaKartotekGML.Add(new TabelaGML(item));
            }
            dgUsersGML.Items.Refresh();
        }

        private void MenuItemAdresyDlaBudynków_Click(object sender, RoutedEventArgs e)
        {
            zapisUstawienDomyslnych();
            SaveFileDialog svd = new SaveFileDialog();
            svd.DefaultExt = "";
            svd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (svd.ShowDialog() == true)
            {

                using (Stream s = File.Open(svd.FileName, FileMode.Create))
                //  using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                    try
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            string separ = "";

                            foreach (var item in listaKartotekGML)
                            {

                                sb.AppendLine(item.IdObr + "\t" + item.IdBud);
                                sb.AppendLine("**");
                                sb.AppendLine(item.Miejscowosc + ",," + item.nrAdr + "," + textboxKodPocztowy.Text.Trim().ToUpper());
                                sb.AppendLine("****");
                            }


                            //Console.WriteLine(sb.ToString());
                            sw.Write(sb.ToString());
                            sw.Close();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.ToString() + "  problem z plikiem");
                        }
                    }
                    catch (Exception ex)
                    {
                        var resultat = MessageBox.Show(ex.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

                        if (resultat == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                    }
            }
        }

        private void kopiujDoTabeliGML(object sender, RoutedEventArgs e)
        {
            listaKartotekGML.Clear();
            foreach (var item in wczytaneKartoteki)
            {
                listaKartotekGML.Add(new TabelaGML(item, 0));
            }

            dgUsersGML.Items.Refresh();





        }

        private void otworzDzialki(object sender, RoutedEventArgs e)
        {
            poczatek:
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";

            dlg.Filter = "All files(*.*) | *.*|TXT Files (*.txt)|*.txt| CSV(*.csv)|*.csv";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;


                try
                {
                   
                    wczytaneKartoteki.Clear();
                    listaKartotekGML.Clear();
                    calyProgram.IsEnabled = false;

                    calyOdczzytanyTextLinie = Plik.odczytZPlikuLinie(dlg.FileName);
                    progresBar.Maximum = calyOdczzytanyTextLinie.Length;
                    foreach (var item in calyOdczzytanyTextLinie)
                    {
                        // Console.WriteLine(item);

                        string[] odczytaneDzialki = Plik.pobranieWartoscZTXT(item, '-');

                       // wczytaneKartoteki.Add(new Tabela(Plik.pobranieWartoscZTXT(item, '-')[0], Plik.pobranieWartoscZTXT(item, '-')[1]));
                       if(odczytaneDzialki.Length>1)
                        {
                            wczytaneKartoteki.Add(new Tabela(odczytaneDzialki[0], odczytaneDzialki[1]));
                        }
                        else
                        {
                            Console.WriteLine("Błędny format");
                        }
                      


                        progresBar.Dispatcher.Invoke(new ProgressBarDelegate(UpdateProgress), DispatcherPriority.Background);
                    }

                    for (int i = 0; i < wczytaneKartoteki.Count; i++)
                    {
                        wczytaneKartoteki[i].ustawID( i + 1);
                    }
                    calyProgram.IsEnabled = true;
                    dgUsers.Items.Refresh();
                    dgUsersGML.Items.Refresh();
                    progresBar.Value = 0;
                }
                catch (Exception esa)
                {

                    var resultat = MessageBox.Show(esa.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

                    if (resultat == MessageBoxResult.Yes)
                    {
                        Application.Current.Shutdown();
                    }

                    Console.WriteLine(esa + "Błędny format importu działek");
                    goto poczatek;
                }
            }

            // sprawdzenie duplikatów ID BUD



        }

        private void MenuItemAdresyDlaDzialek_Click(object sender, RoutedEventArgs e)
        {
            zapisUstawienDomyslnych();
            SaveFileDialog svd = new SaveFileDialog();
            svd.DefaultExt = ".txt";
            svd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (svd.ShowDialog() == true)
            {

                using (Stream s = File.Open(svd.FileName, FileMode.Create))
                //  using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                    try
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            string separ = "";

                            foreach (var item in listaKartotekGML)
                            {
                                sb.AppendLine(item.IdObr + "\t" + item.NrDz);
                                sb.AppendLine("**");
                                Console.WriteLine("item>" + item.Miejscowosc);
                                if (!item.Miejscowosc.Equals(""))
                                {
                                    sb.AppendLine(item.Miejscowosc + ",,," + textboxKodPocztowy.Text.Trim().ToUpper());
                                }
                                else
                                {
                                    sb.AppendLine(textBoxMiejscowoscGdyBrakWTabeli.Text.Trim().ToUpper() + ",,," + textboxKodPocztowy.Text.Trim().ToUpper());
                                }
                                sb.AppendLine("****");
                            }


                            //Console.WriteLine(sb.ToString());
                            sw.Write(sb.ToString());
                            sw.Close();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.ToString() + "  problem z plikiem");
                        }
                    }
                    catch (Exception ex)
                    {
                        var resultat = MessageBox.Show(ex.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

                        if (resultat == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                    }
            }
        }

        private void MenuItemBudynki_Click(object sender, RoutedEventArgs e)
        {
            zapisUstawienDomyslnych();
            SaveFileDialog svd = new SaveFileDialog();
            svd.DefaultExt = ".txt";
            svd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (svd.ShowDialog() == true)
            {
                using (Stream s = File.Open(svd.FileName, FileMode.Create))
                //  using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                    try
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("IDOBR,IDB,NRDZ,STATBUD,FUZ,RODZKST,KLASAPKOB,GLFNBUD,RBB,USTDATYBB,PEW,LKON,LKONP,SCN");
                            foreach (var item in listaKartotekGML)
                            {
                                    sb.AppendLine(item.IdObr + ",\"" + item.IdBud + "\",\"" + item.NrDz + "\"," + item.StatusBud + "," + item.FUZ + "," + item.RodzKST 
                                        + "," + item.KLASAPKOB + "," + item.GLFNBUD + "," + item.RBB + "," + item.USTDATYBB + "," + item.PEW + "," + item.LKON 
                                        + "," + item.LKONP + "," + item.SCN);
                            }


                            //Console.WriteLine(sb.ToString());
                            sw.Write(sb.ToString());
                            sw.Close();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.ToString() + "  problem z plikiem");
                        }
                    }
                    catch (Exception ex)
                    {
                        var resultat = MessageBox.Show(ex.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

                        if (resultat == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                    }

            }
        }

        private void MenuItemDzialkiDlaBudynku_Click(object sender, RoutedEventArgs e)
        {
            zapisUstawienDomyslnych();
            SaveFileDialog svd = new SaveFileDialog();
            svd.DefaultExt = ".txt";
            svd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (svd.ShowDialog() == true)
            {

                using (Stream s = File.Open(svd.FileName, FileMode.Create))
                //  using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                {

                    //try
                    //{
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            string separ = "";

                            foreach (var item in listaKartotekGML)
                            {
                                sb.AppendLine(item.IdObr + "\t" + item.IdBud);
                                sb.AppendLine("**");
                                sb.AppendLine(item.IdObr + "-" + item.NrDz);
                                sb.AppendLine("****");
                            }
                            sw.Write(sb.ToString());
                            sw.Close();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.ToString() + "  problem z plikiem");
                        }
              //      }
              //      catch (Exception ex)
              //      {
              //          var resultat = MessageBox.Show(ex.ToString() + " Przerwać?", "ERROR", MessageBoxButton.YesNo);

              //          if (resultat == MessageBoxResult.Yes)
              //          {
              //              Application.Current.Shutdown();
              //          }
              //      }
                }
            }
        }

        private void MenuItemWyczyśćTabele_Click(object sender, RoutedEventArgs e)
        {
            wczytaneKartoteki.Clear();
            listaKartotekGML.Clear();
          
            dgUsers.Items.Refresh();
            dgUsersGML.Items.Refresh();


        }

        private void KontrolaDanych_Click(object sender, RoutedEventArgs e)
        {


            List<Tabela> dublikatyWypisane = new List<Tabela>();
            List<Tabela> dubleAdresów = new List<Tabela>();
            foreach (var item in wczytaneKartoteki)
            {

                if (item.nrAdr != "")
                {
                    var znalezioneDuplikatyAdresow = wczytaneKartoteki.Select(test => test).Where(test => test.nrAdr == item.nrAdr).Where(test => test.IdObr == item.IdObr).ToList();

                    if (znalezioneDuplikatyAdresow.Count > 1)
                    {


                        if (dubleAdresów.Count < 1)
                        {
                            foreach (var elem in znalezioneDuplikatyAdresow)
                            {
                                dubleAdresów.Add(elem);
                            }
                        }
                        else
                        {

                            var czyPowtorzony = dubleAdresów.Select(test => test).Where(test => test.IdBud == znalezioneDuplikatyAdresow[0].IdBud).ToList();
                            if (czyPowtorzony.Count < 1)
                            {

                                foreach (var el1 in znalezioneDuplikatyAdresow)
                                {
                                    dubleAdresów.Add(el1);
                                }


                            }

                        }
                    }
                }
                //------------------------------------------------------------------
                var znalezioneDuplikaty = wczytaneKartoteki.Select(test => test).Where(test => test.IdBud == item.IdBud).Where(test => test.IdObr == item.IdObr).ToList();

                if (znalezioneDuplikaty.Count > 1)
                {


                    if (dublikatyWypisane.Count < 1)
                    {
                        foreach (var elem in znalezioneDuplikaty)
                        {
                            dublikatyWypisane.Add(elem);
                        }
                    }
                    else
                    {

                        var czyPowtorzony = dublikatyWypisane.Select(test => test).Where(test => test.IdBud == znalezioneDuplikaty[0].IdBud).ToList();
                        if (czyPowtorzony.Count < 1)
                        {

                            foreach (var el1 in znalezioneDuplikaty)
                            {
                                dublikatyWypisane.Add(el1);
                            }


                        }

                    }
                }
            }

            if (dublikatyWypisane.Count > 0)
            {
                // logBledow.IsEnabled = true;
                logBledow.Visibility = Visibility.Visible;
                textBlockBledy.Text += "Zdublowane nr BUDYNKÓW!!!\n";
            }
            foreach (var qew in dublikatyWypisane)
            {
                textBlockBledy.Text += "Id w tabeli:" + qew.ID + " Id budynku: " + qew.IdObr + "-" + qew.IdBud + "\t" + "działka nr: " + qew.NrDz + "\t" + "GLFUN: " + qew.GLFNBUD + "\t" + "Pow.:" + qew.PEW + "\n";
            }

            if (dubleAdresów.Count > 0)
            {
                // logBledow.IsEnabled = true;
                logBledow.Visibility = Visibility.Visible;
            }

            foreach (var item in dubleAdresów)
            {
                textBlockBledy.Text += "Powielone nr adresowe w obrębie. Id w tabeli: " + item.ID + "\t" + " Id bud: " + item.IdBud + "\t" + " nr Adresowy: " + item.nrAdr + "\n";
            }

            //LKON z przecinkiem
            var kondygnacjeZPrzecinkami = wczytaneKartoteki.Select(test => test).Where(test => test.LKON.Contains(",")).ToList();
            var kondygnacjeZKropkami = wczytaneKartoteki.Select(test => test).Where(test => test.LKON.Contains(".")).ToList();

            if (kondygnacjeZPrzecinkami.Count > 0 || kondygnacjeZKropkami.Count > 0)
            {
                Console.WriteLine("kondygn ");
                logBledow.Visibility = Visibility.Visible;
                textBlockBledy.Text += "\n";

                foreach (var item in kondygnacjeZPrzecinkami)
                {
                    textBlockBledy.Text += "Dla budynku " + item.IdObr + "-" + item.IdBud + " liczba kondygnacji jest niepoprawna " + item.LKON + "\n";
                }

                //lokon z Kropka

                foreach (var item in kondygnacjeZKropkami)
                {
                    textBlockBledy.Text += "Dla budynku " + item.IdObr + "-" + item.IdBud + " liczba kondygnacji jest niepoprawna " + item.LKON + "\n";
                }
            }
        }
    }
}
