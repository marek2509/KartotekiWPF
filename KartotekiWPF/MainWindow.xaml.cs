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
            else if(radioButtonimportDoc.IsChecked == true)
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

                    if(importTab.IsChecked == true)
                    {     
                            calyOdczzytanyTextLinie = Plik.odczytZPlikuLinie(dlg.FileName);

                        foreach (var item in calyOdczzytanyTextLinie)
                        {
                            Console.WriteLine(item);
                            wczytaneKartoteki.Add(new Tabela(Plik.pobranieWartoscZTXT(item,'\t')));

                            progresBar.Dispatcher.Invoke(new ProgressBarDelegate(UpdateProgress), DispatcherPriority.Background);
                        }    
                    }
                    else if(importWlasny.IsChecked == true)
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
                }
                catch (Exception esa)
                {
                    MessageBox.Show(esa.ToString());
                    Console.WriteLine(esa + "goto poczatek catch");
                    goto poczatek;
                }

                dgUsers.Items.Refresh();
                progresBar.Value = 0;
                /*       wczytaneKartoteki.Sort(delegate (Tabela x, Tabela y)
                        {
                            if (x.IdObr == null && y.IdObr == null) return 0;
                            else if (x.IdObr == null) return -1;
                            else if (y.IdObr == null) return 1;
                            else return x.IdObr.CompareTo(y.IdObr);
                        });*/

                // Plik.pobranieWartosciDoGML(calyOdczzytanyText);

            }
        }



        private void ZapiszDoPliku(object sender, RoutedEventArgs e)
        {
            zapisUstawienDomyslnych();
            SaveFileDialog svd = new SaveFileDialog();
            svd.DefaultExt = "";
            svd.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt|HTML (*.html)|*.html|doc (*.doc)|*.doc";
            if (svd.ShowDialog() == true)
            {

                using (Stream s = File.Open(svd.FileName + ".txt", FileMode.Create))
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
                            MessageBox.Show(exc.ToString() + "  problem z plikiem");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();
            zapisUstawienDomyslnych();
        }

        private void GenerujGML(object sender, RoutedEventArgs e)
        {
            foreach (var item in wczytaneKartoteki)
            {
                listaKartotekGML.Add(new TabelaGML(item));
            }
            dgUsersGML.Items.Refresh();
        }

    }
}
