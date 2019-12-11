using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartotekiWPF
{
    class TabelaGML : Tabela
    {
        string[,] kodowanieKST = {
            { "101", "102", "103", "104", "105", "106", "107", "108", "109", "110" },
            { "14", "15","16","17","18","19","20","21","22", "23" }
        };

        string[,] kodowaniePKOB =
        {
            {"1110", "1121", "1122", "1130", "1211", "1212", "1220", "1230", "1241", "1242", "1251",
                "1252", "1261", "1262", "1263", "1264", "1265", "1271", "1272", "1273", "1274"},
            {"24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37",
                "38", "39", "40", "41", "42", "43", "44"}
        };
        string[,] kodowanieGLFUN = 
        {
            {"1110.DJ", "1110.Dl",  "1110.Ls",  "1110.In",  "1121.Db",  "1122.Dw",  "1130.Bs",  "1130.Db",  "1130.Dd",  "1130.Os",  "1130.Dp",  "1130.Ds",
                "1130.Dz",  "1130.Hr",  "1130.t",   "1130.Kl",  "1130.Km",  "1130.Po",  "1130.Ra",  "1130.Rb",  "1130.Rp",  "1130.Zk",  "1130.Zp",  "1130.In",
                "1211.Dw",  "1211.Ht",  "1211.Mt",  "1211.Pj",  "1211.Rj",  "1211.Zj",  "1211.In",  "1212.Dk",  "1212.Dr",  "1212.Dw",  "1212.Os",  "1212.St",
                "1212.In",  "1220.Bk",  "1220.Ck",  "1220.Km",  "1220.Mn",  "1220.Pd",  "1220.Pc",  "1220.Pk",  "1220.Pg",  "1220.Sd",  "1220.Sf",  "1220.Pw",
                "1220.Sg",  "1220.Sp",  "1220.Uc",  "1220.Ug",  "1220.Um",  "1220.Umg", "1220.Mr",  "1220.Up",  "1220.Uw",  "1220.Ap",  "1230.Ap",  "1230.Ch",
                "1230.Dh",  "1230.Ht",  "1230.Hw",  "1230.Hm",  "1230.Ph",  "1230.So",  "1230.Sp",  "1230.In",  "1241.Kk",  "1241.Kp",  "1241.Ct",  "1241.Da",
                "1241.Dk",  "1241.Dl",  "1241.Hg",  "1241.Lm",  "1241.Lk",  "1241.Kg",  "1241.Rt",  "1241.Tp",  "1241.Ab",  "1241.Tr",  "1241.Tb",  "1241.In",
                "1242.Gr",  "1242.Pw",  "1251.El",  "1251.Ek",  "1251.Kt",  "1251.Mn",  "1251.Pr",  "1251.Rf",  "1251.Ss",  "1251.Wr",  "1251.Wt",  "1251.In",
                "1252.Sp",  "1252.Ch",  "1252.El",  "1252.Mg",  "1252.Sl",  "1252.Gz",  "1252.Ci",  "1252.In",  "1261.Oz",  "1261.Dk",  "1261.Fh",  "1261.Hw",
                "1261.Ks",  "1261.Kn",  "1261.Kl",  "1261.Sz",  "1261.Op",  "1261.Tt",  "1261.In",  "1262.Ar",  "1262.Bl",  "1262.Ci",  "1262.Gs",  "1262.Mz",
                "1262.In",  "1263.Ob",  "1263.Pb",  "1263.Ps",  "1263.Sh",  "1263.Sm",  "1263.Sp",  "1263.Sd",  "1263.Sw",  "1263.In",  "1264.Hs",  "1264.Iw",
                "1264.Jr",  "1264.Kw",  "1264.Oo",  "1264.Po",  "1264.St",  "1264.Sk",  "1264.Ss",  "1264.Sz",  "1264.Zb",  "1264.In",  "1265.Hs",  "1265.Ht",
                "1265.Ks",  "1265.Kt",  "1265.Kr",  "1265.Pl",  "1265.Sg",  "1265.St",  "1265.Sl",  "1265.Uj",  "1265.In",  "1271.Bg",  "1271.Bp",  "1271.St",
                "1271.Sz",  "1271.In",  "1272.Bc",  "1272.Ck",  "1272.Dp",  "1272.Dz",  "1272.Kp",  "1272.Ks",  "1272.Kr",  "1272.Mc",  "1272.Sn",  "1272.Ir",
                "1273.Zb",  "1274.As",  "1274.Bc",  "1274.Sc",  "1274.Sg",  "1274.Sp",  "1274.St",  "1274.Tp",  "1274.Zk",  "1274.Zp",  "1274.In"},
         
            {"68",  "69",   "70",   "71",   "72",   "73",   "74",   "75",   "76",   "77",   "78",   "79",   "80",   "81",   "82",   "83",   "84",   "85",
                "86",   "87",   "88",   "89",   "90",   "91",   "92",   "93",   "94",   "95",   "96",   "97",   "98",   "99",   "100",  "101",  "102",  "103",
                "104",  "105",  "106",  "107",  "108",  "109",  "110",  "111",  "112",  "113",  "114",  "115",  "116",  "117",  "118",  "119",  "120",  "121",
                "122",  "123",  "124",  "125",  "126",  "127",  "128",  "129",  "130",  "131",  "132",  "133",  "134",  "135",  "136",  "137",  "138",  "139",
                "140",  "141",  "142",  "143",  "144",  "145",  "146",  "147",  "148",  "149",  "150",  "151",  "152",  "153",  "154",  "155",  "156",  "157",
                "158",  "159",  "160",  "161",  "162",  "163",  "164",  "165",  "166",  "167",  "168",  "169",  "170",  "171",  "172",  "173",  "174",  "175",
                "176",  "177",  "178",  "179",  "180",  "181",  "182",  "183",  "184",  "185",  "186",  "187",  "188",  "189",  "190",  "191",  "192",  "193",
                "194",  "195",  "196",  "197",  "198",  "199",  "200",  "201",  "202",  "203",  "204",  "205",  "206",  "207",  "208",  "209",  "210",  "211",
                "212",  "213",  "214",  "215",  "216",  "217",  "218",  "219",  "220",  "221",  "222",  "223",  "224",  "225",  "226",  "227",  "228",  "229",
                "230",  "231",  "232",  "233",  "234",  "235",  "236",  "237",  "238",  "239",  "240",  "241",  "242",  "243",  "244",  "245",  "246"}
        };

        string[,] kodowanieUstalenieDatyBudowy =
        {
            {"1", "2", "3" },
            {"65", "66", "67" }
        };

        string wyszukiwanieKodow(string[,] tablicakodow, string szukana)
        {
            if(szukana==null)
            {
                szukana = "";
            }

            for (int i = 0; i < (tablicakodow.Length / tablicakodow.Rank); i++)
            {
                if (szukana.ToUpper().Equals(tablicakodow[0, i].ToUpper()))
                {
                    return tablicakodow[1, i];
                }

            }
            return "";
        }

        public TabelaGML(Tabela tabela)
        {
            this.ID = tabela.ID;
            this.IdObr = tabela.IdObr;
            this.IdBud = tabela.IdBud;
            this.NrDz = tabela.NrDz;
            this.Miejscowosc = tabela.Miejscowosc;
            this.nrAdr = tabela.nrAdr;
            this.StatusBud = tabela.StatusBud;
            this.FUZ = tabela.FUZ;
            this.RodzKST = tabela.RodzKST;
            this.KLASAPKOB = tabela.KLASAPKOB;
            this.GLFNBUD = tabela.GLFNBUD;
            this.RBB = tabela.RBB;
            this.USTDATYBB = tabela.USTDATYBB;
            this.PEW = tabela.PEW;
            this.LKON = tabela.LKON;
            this.LKONP = tabela.LKONP;
            this.SCN = tabela.SCN;
            this.WIATA = tabela.WIATA;
        }

        public TabelaGML(Tabela tabela, int podajDowolnaCyfre)
        {
            this.ID = tabela.ID;
            this.IdObr = tabela.IdObr;
            this.IdBud = tabela.IdBud;
            this.NrDz = tabela.NrDz;
            this.Miejscowosc = tabela.Miejscowosc;
            this.nrAdr = tabela.nrAdr;
            this._statusBud = tabela.StatusBud;
            this.FUZ = tabela.FUZ;
            this._rodzKST = tabela.RodzKST;
            this._kLASAPKOB = tabela.KLASAPKOB;
            this._gLFNBUD = tabela.GLFNBUD;
            this.RBB = tabela.RBB;
            this._uSTDATYBB = tabela.USTDATYBB;
            this.PEW = tabela.PEW;
            this.LKON = tabela.LKON;
            this.LKONP = tabela.LKONP;
            this.SCN = tabela.SCN;
            this.WIATA = tabela.WIATA;
        }

        string _statusBud;
        string _rodzKST;
        string _kLASAPKOB;
        string _gLFNBUD;
        string _uSTDATYBB;

       public new int ID { get; private set; }
        public new string IdObr { get; set; }
        public new string IdBud { get; set; }
        public new string NrDz { get; set; }
        public new string Miejscowosc { get; set; }
        public new string nrAdr { get; set; }
        public new string StatusBud
        {
            get
            {
                return _statusBud;
            }
            set
            {
                if (value == null) {
                    _statusBud = "";
                }
                else
                {
                    _statusBud = value.Trim();
                }
                if (_statusBud.Contains("1"))
                {
                    _statusBud = "4";
                }
                else if (_statusBud.Contains("2"))
                {
                    _statusBud = "5";
                }
                else if (_statusBud.Contains("3"))
                {
                    _statusBud = "6";
                }
                else if (_statusBud.Contains("4"))
                {
                    _statusBud = "7";
                }
                else
                {
                    _statusBud = "";
                }
            }
        }
        public new string FUZ { get; set; }
        public new string RodzKST
        {
            get
            {
                return _rodzKST;
            }
            set
            {
                if (value == null)
                {
                    _rodzKST = "";
                }
                else
                {
                    _rodzKST = value.Trim();
                }
               
                _rodzKST = wyszukiwanieKodow(kodowanieKST, _rodzKST);
            }
        }

        public new string KLASAPKOB
        {
            get
            {
                return _kLASAPKOB;
            }
            set
            {
                _kLASAPKOB = value;
                _kLASAPKOB = wyszukiwanieKodow(kodowaniePKOB, _kLASAPKOB);
            }
        }
        public new string GLFNBUD
        {
            get
            {
                return _gLFNBUD;
            }
            set
            {
                _gLFNBUD = value;
                _gLFNBUD = wyszukiwanieKodow(kodowanieGLFUN, _gLFNBUD);
            }
        }
        public new string RBB { get; set; }
        public new string USTDATYBB
        {
            get
            {
                return _uSTDATYBB;
            }
            set
            {
                _uSTDATYBB = value;
                _uSTDATYBB = wyszukiwanieKodow(kodowanieUstalenieDatyBudowy, _uSTDATYBB);
            }
        }
        public new string PEW { get; set; }
        public new string LKON { get; set; }
        public new string LKONP { get; set; }
        public new string SCN { get; set; }
        public new string WIATA { get; set; }

        public new string wypiszPoziomoZSeparotorem(string separator)
        {
            return IdObr + separator + IdBud + separator + NrDz + separator + Miejscowosc + separator + nrAdr + separator +
                _statusBud + separator + FUZ + separator + _rodzKST + separator + _kLASAPKOB + separator + _gLFNBUD + separator + RBB +
                separator + _uSTDATYBB + separator + PEW + separator + LKON + separator + LKONP + separator + SCN + separator + WIATA;
        }
    }
}
