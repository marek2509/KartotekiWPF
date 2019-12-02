using Microsoft.Win32;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Xml;
using System.Xml.Linq;

namespace KartotekiWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // public XpsDocument(string path, System.IO.FileAccess packageAccess);
        List<Tabela> wczytaneKartoteki = new List<Tabela>();
        public MainWindow()
        {
           
            InitializeComponent();

        }

 
        string calyOdczzytanyText = "";
        string[] calyOdczzytanyTextLinie = null;
        private void OtworzZPliku(object sender, RoutedEventArgs e)
        {
        
            poczatek:
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;
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
                    // calyOdczzytanyText = Plik.odczytZPliku(filename);
                    //Console.WriteLine(filename);
                    //calyOdczzytanyText = Plik.convertDocToTXT(filename);
                    foreach (var item in dlg.FileNames)
                    {
                      calyOdczzytanyTextLinie = Plik.convertDocToTXTLine(item);

                        wczytaneKartoteki.Add(Plik.pobranieWartosciDoGMLZLinii(calyOdczzytanyTextLinie));
                    }

                    foreach (var item in wczytaneKartoteki)
                    {
                        Console.WriteLine(item.IdObr + " " + item.NrDz + " " + item.Miejscowosc + item.IdBud );
                    }

                }
                catch( Exception esa)
                {
                    Console.WriteLine( esa + "goto poczatek catch");
                    goto poczatek;
                }

               // Plik.pobranieWartosciDoGML(calyOdczzytanyText);
               
            }


        }



        private void ZapiszDoPliku(object sender, RoutedEventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.DefaultExt = "";
            svd.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt|HTML (*.html)|*.html|doc (*.doc)|*.doc";
            if (svd.ShowDialog() == true)
            {



                // Console.WriteLine(bazaDanych.Count() + "count");


                using (Stream s = File.Open(svd.FileName + ".txt", FileMode.Create))
                //  using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                using (StreamWriter sw = new StreamWriter(s, Encoding.Default))

                    try
                    {
                        try
                        {
                            sw.Write(calyOdczzytanyText);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;

            if (dlg.ShowDialog() == true)
            {

                Console.WriteLine(  dlg.FileNames);
                foreach (var item in dlg.FileNames)
                {
                    Console.WriteLine(item);
                }

            }
               
        }
    }
}
