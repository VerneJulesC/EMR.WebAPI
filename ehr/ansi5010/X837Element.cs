using Org.BouncyCastle.Utilities;
using System;
using System.Diagnostics;
using System.Globalization;

namespace EMR.WebAPI.ehr.ansi5010
{
    public class X837Element
    {
        public X837Element(string position, string element, string type, string req, int min, int max, int repeat, string[] codes, X837Element[] composite)
        {
            this.Position = position;
            this.Element = element;
            this.Repeat = repeat;
            this.Mandatory = req.Equals("Mandatory");
            this.Min = min;
            this.Max = max;
            this.Type = type;
            _Codes = codes;
            this.Composite = composite;
        }

        public string Value
        {
            get
            {
                return this.Value;
            }
            set
            {
                this.Value = formatValue(value);
            }
        }

        public string formatValue(string paramval)
        {
            bool correctFormat = true;
            string closest = null;
            int closest_distance = 0;
            int distance = 0;

            string eval = paramval;
            if(eval == null)
            {
                eval = String.Empty;
            }

            if (Codes.Length > 0)
            {
                closest = Codes[0];
                closest_distance = X837Config.LevenshteinDistance(eval.ToUpper(), closest.ToUpper());
                correctFormat = false;
                for (int i = 0; i < Codes.Length; i++)
                {
                    distance = X837Config.LevenshteinDistance(eval.ToUpper(), Codes[i].ToUpper());
                    if (distance < closest_distance)
                    {
                        closest_distance = distance;
                        closest = Codes[i];
                    }
                    if (Codes[i].Equals(eval, StringComparison.OrdinalIgnoreCase))
                    {
                        correctFormat = true;
                        eval = Codes[i];
                        break;
                    }
                }
            }
            if (!correctFormat)
            {
                eval = closest;
            }

            if((this.Type.Equals("Numeric (N0)") || this.Type.Equals("Decimal number (R)"))){
                if (eval.Length > 0)
                {
                    double dble = double.Parse(eval, CultureInfo.InvariantCulture);
                    int intgr = (int)dble;
                    if (dble.ToString().Length < this.Max)
                    {
                        eval = dble.ToString();
                    }
                    else
                    {
                        int sym = 0;
                        if (dble < 0)
                        {
                            sym = sym + 1;
                        }
                        if ((double)intgr < dble)
                        {
                            sym = sym + 1;
                        }
                        int dec = this.Max - intgr.ToString().Length - sym;
                        if (dec < 0)
                        {
                            dec = 0;
                        }
                        eval = Math.Round((Double)intgr, sym).ToString();
                    }
                }
                else if(this.Mandatory)
                {
                    eval = new string('0', this.Min);
                }
            }
            if (this.Type.Equals("Time (TM)"))
            {
                string patt = "";
                string patt2 = "";
                if (this.Max >= 8)
                {
                    patt = "HHmmssff";
                }
                else if (this.Max >= 6)
                {
                    patt = "HHmmss";
                }
                else
                {
                    patt = "HHmm";
                }
                if (eval.Length > 8) {
                    patt2 = "o";
                } else if (eval.Length == 8)
                {
                    patt2 = "HHmmssff";
                }
                else if (eval.Length >= 6)
                {
                    patt2 = "HHmmss";
                }
                else
                {
                    patt2 = "HHmm";
                }
                eval = DateTime.ParseExact(eval, patt2, System.Globalization.CultureInfo.InvariantCulture).ToString(patt);
            }

            if (this.Type.Equals("Date (DT)"))
            {
                if (this.Max >= 8)
                {
                    eval = DateTime.ParseExact(eval, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                }
                else
                {
                    eval = DateTime.ParseExact(eval, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyMMdd");
                }
            }

            if (eval.Length > this.Max)
            {
                char[] charsToTrim = { '\t', ' ' };
                eval = eval.Trim(charsToTrim);
            }
            if (eval.Length > this.Max && this.Max >= 0)
            {
                eval = eval.Substring(0, this.Max);
            }
            if (eval.Length < this.Min && this.Mandatory)
            {
                if((this.Type.Equals("Numeric (N0)") || this.Type.Equals("Decimal number (R)")))
                {
                    eval = (new string('0', (this.Min - eval.Length))) + eval;
                }
                else {
                    eval = eval + (new string(' ', (this.Min - eval.Length)));
                }
            }

            return eval;
        }

        public string Position
        {
            get;
            set;
        }

        public string Element
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public int Repeat
        {
            get;
            set;
        }

        public bool Mandatory
        {
            get;
            set;
        }

        public int Min
        {
            get;
            set;
        }

        public int Max
        {
            get;
            set;
        }

        public string[] _Codes;
        public string[] Codes
        {
            get
            {
                return _Codes;
            }
            set
            {
                for (int i = 0; i < _Codes.Length; i++)
                {

                    if (_Codes[i].Length > this.Max)
                    {
                        char[] charsToTrim = { '\t', ' ' };
                        _Codes[i] = _Codes[i].Trim(charsToTrim);
                    }
                    if (_Codes[i].Length > this.Max)
                    {
                        _Codes[i] = _Codes[i].Substring(0, this.Max);
                    }
                    if (_Codes[i].Length < Min && this.Mandatory)
                    {
                        _Codes[i] = _Codes[i] + (new string(' ', (this.Min - _Codes[i].Length)));
                    }

                }
            }
        }

        public X837Element[] Composite { get; set; }

    }
}