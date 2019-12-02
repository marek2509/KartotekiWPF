﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartotekiWPF
{
    class Tabela
    {
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
        char[] charcyfry = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
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

                _idObr = _idObr.Substring(_idObr.LastIndexOf('.')+1).Trim();

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
                _miejscowosc = value.Trim();
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
              
                //   StringBuilder sb = new StringBuilder();
                //    for (int i = 0; i < _nrAdr.Length; i++)
                //    {


                //        foreach (var item in charNrAdr)
                //        {
                //            if (_nrAdr[i].Equals(item))
                //            {
                //                sb.Append(item);
                //            }
                //        }
                //    }
                //    _nrAdr = sb.ToString();

                //    sb.Clear();

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
            get {
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
            set
            {
                _fUZ = value.Trim(); 
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

        public void wypiszWszystko()
        {
            Console.WriteLine("ID OBR>" + _idObr+"<");
            Console.WriteLine("idbud>"+_idBud + "<");
            Console.WriteLine("nrDz>" + _nrDz + "<");
            Console.WriteLine("miejscowosc>" + _miejscowosc + "<");
            Console.WriteLine("nrAdr>" + _nrAdr + "<");
            Console.WriteLine("statbud>" + _statusBud + "<");
            Console.WriteLine("fuz>" + _fUZ + "<");
            Console.WriteLine("kst>"+_rodzKST + "<");
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
    }


}