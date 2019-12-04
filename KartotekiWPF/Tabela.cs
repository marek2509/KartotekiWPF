using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KartotekiWPF
{
    class Tabela
    {
        public Tabela()
        {

        }

        public Tabela(string idObr, string nrDz)
        {
            _idObr = idObr;
            _idBud = "";
            _nrDz = nrDz;
            _miejscowosc = "";
            _nrAdr = "";
            _statusBud = "";
            _fUZ = "";
            _rodzKST = "";
            _kLASAPKOB = "";
            _gLFNBUD = "";
            _rBB = "";
            _uSTDATYBB = "";
            _pEW = "";
            _lKON = "";
            _lKONP = "";
            _sCN = "";
            _wIATA = "";
        }


        public Tabela(string[] liniaZTxt)
        {
            if (liniaZTxt.Length == 17)
            {
                _idObr = liniaZTxt[0];
                _idBud = liniaZTxt[1];
                _nrDz = liniaZTxt[2];
                _miejscowosc = liniaZTxt[3];
                _nrAdr = liniaZTxt[4];
                _statusBud = liniaZTxt[5];
                _fUZ = liniaZTxt[6];
                _rodzKST = liniaZTxt[7];
                _kLASAPKOB = liniaZTxt[8];
                _gLFNBUD = liniaZTxt[9];
                _rBB = liniaZTxt[10];
                _uSTDATYBB = liniaZTxt[11];
                _pEW = liniaZTxt[12];
                _lKON = liniaZTxt[13];
                _lKONP = liniaZTxt[14];
                _sCN = liniaZTxt[15];
                _wIATA = liniaZTxt[16];
            }
            else
            {
                var resultat = MessageBox.Show("Niepoprawna liczba elementów \nw wierszu importowanego pliku. Przerwać?", "ERROR", MessageBoxButton.YesNo);

                if (resultat == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        public string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        char[] teryt = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '_' };
        char[] charcyfry = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] charNrAdr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'W', 'X', 'Y', 'Z' };

        string _idObr;
        string _idBud;
        string _nrDz;
        string _miejscowosc;
        string _nrAdr;
        string _statusBud;
        string _fUZ;
        string _rodzKST;
        string _kLASAPKOB;
        string _gLFNBUD;
        string _rBB;
        string _uSTDATYBB;
        string _pEW;
        string _lKON;
        string _lKONP;
        string _sCN;
        string _wIATA;

        public string IdObr
        {
            get
            {
                return _idObr;
            }
            set
            {
                _idObr = value.Trim();

                _idObr = _idObr.Substring(_idObr.LastIndexOf('.') + 1).Trim();

                for (int i = 0; i < _idObr.Length; i++)
                {
                    if (_idObr[i].Equals('0'))
                    {
                        continue;
                    }
                    else
                    {
                        _idObr = _idObr.Substring(i);
                        break;
                    }

                }
                //StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < _idObr.Length; i++)
                //{


                //    foreach (var item in teryt)
                //    {
                //        if (_idObr[i].Equals(item))
                //        {
                //            sb.Append(item);
                //        }
                //    }
                //}
                //_idObr = sb.ToString();

                /*
                if (_idObr[_idObr.Length - 2].Equals('0'))
                {
                    _idObr = _idObr.Substring(_idObr.Length - 1);
                }
                else
                {
                    _idObr = _idObr.Substring(_idObr.Length - 2);                  
                }
                */
            }
        }

        public string IdBud
        {
            get
            {
                return _idBud;
            }
            set
            {
                _idBud = value.Trim();
                _idBud = _idBud.Substring(_idBud.LastIndexOf('.') + 1).Trim();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < _idBud.Length; i++)
                {


                    foreach (var item in charcyfry)
                    {
                        if (_idBud[i].Equals(item))
                        {
                            sb.Append(item);
                        }
                    }
                }
                _idBud = sb.ToString();

                sb.Clear();

            }
        }

        public string NrDz
        {
            get
            {
                return _nrDz;
            }
            set
            {
                _nrDz = value.Trim();
                _nrDz = _nrDz.Substring(_nrDz.LastIndexOf('.') + 1).Trim();
                /*  Console.WriteLine("value set nrdz" + _nrDz);
                  StringBuilder sb = new StringBuilder();
                  for (int i = 0; i < _nrDz.Length; i++)
                  {


                      foreach (var item in teryt)
                      {
                          if (_nrDz[i].Equals(item))
                          {
                              sb.Append(item);
                          }
                      }
                  }
                  _nrDz = sb.ToString();

                  sb.Clear();

                  for (int i = _nrDz.Length - 1; i >= 0; i--)
                  {
                      if (_nrDz[i].Equals('.'))
                      {
                          break;
                      }
                      sb.Append(_nrDz[i]);
                  }

                  _nrDz = sb.ToString();
                  _nrDz = Reverse(_nrDz);

                  //usuniecie nr '3' z konca txt bo to numer kolejnego wiersza
                  _nrDz = _nrDz.Trim();
                  _nrDz = _nrDz.Remove((_nrDz.Length - 1));*/
            }

        }

        public string Miejscowosc
        {
            get
            {
                return _miejscowosc;
            }
            set
            {
                _miejscowosc = value.Trim().ToUpper();
                //_miejscowosc = _miejscowosc.Replace("   ", "@");
                //_miejscowosc = _miejscowosc.Replace(" ", "");
                //_miejscowosc = _miejscowosc.Replace("@", " ");
                //_miejscowosc = _miejscowosc.Trim();
                //  _miejscowosc = _miejscowosc.Replace("\n", String.Empty);
            }
        }

        public string nrAdr
        {
            get
            {
                return _nrAdr;
            }
            set
            {
                _nrAdr = value.Trim();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < _nrAdr.Length; i++)
                {


                    foreach (var item in charNrAdr)
                    {
                        if (_nrAdr[i].Equals(item))
                        {
                            sb.Append(item);
                        }
                    }
                }
                _nrAdr = sb.ToString();

                sb.Clear();

                //    for (int i = _nrAdr.Length - 1; i >= 0; i--)
                //    {
                //        if (_nrAdr[i].Equals('.'))
                //        {
                //            break;
                //        }
                //        sb.Append(_nrAdr[i]);
                //    }

                //    _nrAdr = sb.ToString();


                //  _nrAdr = Reverse(_nrAdr);

                ////usuniecie nr '3' z konca txt bo to numer kolejnego wiersza
                //_nrAdr = _nrAdr.Trim();
                //_nrAdr = _nrAdr.Replace(" ", "");

                //_nrAdr = _nrAdr.Remove((_nrAdr.Length - 1));
            }

        }

        public string StatusBud
        {
            get
            {
                return _statusBud;
            }
            set
            {
                _statusBud = value.Trim();
                if (_statusBud.Contains("1"))
                {
                    _statusBud = "1";
                }
                else if (_statusBud.Contains("2"))
                {
                    _statusBud = "2";
                }
                else if (_statusBud.Contains("3"))
                {
                    _statusBud = "3";
                }
                else if (_statusBud.Contains("4"))
                {
                    _statusBud = "4";
                }
            }
        }

        public string FUZ
        {
            get
            {
                return _fUZ;
            }
            private set // fuz jest ustawiany w KŚT
            {
            }
        }

        public string RodzKST
        {
            get
            {
                return _rodzKST;
            }
            set
            {
                _rodzKST = value.Trim();
                setFUZ();
            }
        }



        public string KLASAPKOB
        {
            get
            {
                return _kLASAPKOB;
            }
            set
            {
                _kLASAPKOB = value.Trim();
            }
        }

        public string GLFNBUD
        {
            get
            {
                return _gLFNBUD;
            }
            set
            {
                _gLFNBUD = value.Trim();
            }
        }


        public string RBB
        {
            get
            {
                return _rBB;
            }
            set
            {
                _rBB = value.Trim();
            }
        }
        public string USTDATYBB
        {
            get
            {
                return _uSTDATYBB;
            }
            set
            {
                _uSTDATYBB = value.Trim();
            }
        }
        public string PEW
        {
            get
            {
                return _pEW;
            }
            set
            {
                _pEW = value.Trim();
            }
        }
        public string LKON
        {
            get
            {
                return _lKON;
            }
            set
            {
                _lKON = value.Trim();
            }
        }
        public string LKONP
        {
            get
            {
                return _lKONP;
            }
            set
            {
                _lKONP = value.Trim();
            }
        }
        public string SCN
        {
            get
            {
                return _sCN;
            }
            set
            {
                _sCN = value.Trim();
                if (_sCN.Contains("1") || _sCN.ToLower().Contains("mur"))
                {
                    _sCN = "1";
                }
                else if (_sCN.Contains("2") || _sCN.ToLower().Contains("drewno"))
                {
                    _sCN = "2";
                }
                else if (_sCN.Contains("3") || _sCN.ToLower().Contains("inny"))
                {
                    _sCN = "3";
                }
            }
        }

        public string WIATA
        {
            get
            {
                return _wIATA;
            }
            set
            {
                _wIATA = value.Trim();
                if (_wIATA.ToLower().Equals("tak"))
                {
                    _wIATA = "1";
                }
                else
                {
                    _wIATA = "2";
                }
            }
        }

        private void setFUZ()
        {
            if (_rodzKST.Equals("110"))
            {
                _fUZ = "1";
            }
            else if (_rodzKST.Equals("101"))
            {
                _fUZ = "2";
            }
            else if (_rodzKST.Equals("102"))
            {
                _fUZ = "3";
            }
            else if (_rodzKST.Equals("103"))
            {
                _fUZ = "4";
            }
            else if (_rodzKST.Equals("104"))
            {
                _fUZ = "5";
            }
            else if (_rodzKST.Equals("105"))
            {
                _fUZ = "6";
            }
            else if (_rodzKST.Equals("106"))
            {
                _fUZ = "7";
            }
            else if (_rodzKST.Equals("107"))
            {
                _fUZ = "8";
            }
            else if (_rodzKST.Equals("108"))
            {
                _fUZ = "9";
            }
            else if (_rodzKST.Equals("109"))
            {
                _fUZ = "10";
            }
        }

        public void wypiszWszystko()
        {
            Console.WriteLine("ID OBR>" + _idObr + "<");
            Console.WriteLine("idbud>" + _idBud + "<");
            Console.WriteLine("nrDz>" + _nrDz + "<");
            Console.WriteLine("miejscowosc>" + _miejscowosc + "<");
            Console.WriteLine("nrAdr>" + _nrAdr + "<");
            Console.WriteLine("statbud>" + _statusBud + "<");
            Console.WriteLine("fuz>" + _fUZ + "<");
            Console.WriteLine("kst>" + _rodzKST + "<");
            Console.WriteLine("pkob>" + _kLASAPKOB + "<");
            Console.WriteLine("glfun>" + _gLFNBUD + "<");
            Console.WriteLine("rokbud>" + _rBB + "<");
            Console.WriteLine("ustalDaty>" + _uSTDATYBB + "<");
            Console.WriteLine("pew>" + _pEW + "<");
            Console.WriteLine("lkon>" + _lKON + "<");
            Console.WriteLine("lkonPodz>" + _lKONP + "<");
            Console.WriteLine("scn>" + _sCN + "<");
            Console.WriteLine("wiata>" + _wIATA + "<");
        }




        public string wypiszPoziomoZSeparotorem(string separator)
        {
            return _idObr + separator + _idBud + separator + _nrDz + separator + _miejscowosc + separator + _nrAdr + separator +
                _statusBud + separator + _fUZ + separator + _rodzKST + separator + _kLASAPKOB + separator + _gLFNBUD + separator + _rBB +
                separator + _uSTDATYBB + separator + _pEW + separator + _lKON + separator + _lKONP + separator + SCN + separator + _wIATA;
        }

    }


}
