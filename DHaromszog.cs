using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerekszoguHaromszogek
{
    public class DHaromszog
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;
        public double a
        {
            get { return aOldal; }
            set
            {
                if (value > 0)
                {
                    aOldal = value;
                }
                else
                {
                    throw new Exception("Az 'a' oldal nem lehet 0, vagy negatív!");
                }
            }
        }
        public double b
        {
            get { return bOldal; }
            set
            {
                if (value > 0)
                {
                    bOldal = value;
                }
                else
                {
                    throw new Exception("A 'b' oldal nem lehet 0, vagy negatív!");
                }
            }
        }
        public double c
        {
            get { return cOldal; }
            set
            {
                if (value > 0)
                {
                    cOldal = value;
                }
                else
                {
                    throw new Exception("A 'c' oldal nem lehet 0, vagy negatív!");
                }
            }
        }

        private bool EllDerekszogu {
            get
            {
                if ((a * a) + (b * b) == (c * c))
                {
                    return true;
                }
                else
                {
                    return false;
                }    
            }
        }
        private bool EllMegszerkesztheto 
        {
            get 
            {
                if (a + b > c) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool EllNovekvoSorrend 
        {
            get 
            {
                if ((b > a) & (c > b))
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }


        public double Kerulet 
        {
            get
            {
                return a + b + c;
            }
        }
        public double Terulet 
        {
            get
            {                
                return Math.Round(((a * b) / 2), 2);
            }
        }
        public int sorSzama 
        { 
            get; 
            set; 
        }

        public DHaromszog(string sor, int sorSzama)
        {
            string[] oldalak = sor.Split(' ');
            this.a = double.Parse(oldalak[0]);
            this.b = double.Parse(oldalak[1]);
            this.c = double.Parse(oldalak[2]);
            this.sorSzama = sorSzama;

            if (EllNovekvoSorrend == false)
            {
                throw new Exception("Az adatok nincsenek növekvő rendben!");
            }

            if (EllMegszerkesztheto == false) 
            {
                throw new Exception("A háromszöget nem lehet megszerkeszteni!");
            }

            if (EllDerekszogu == false)
            {
                throw new Exception("A háromszög nem derékszögű!");
            }
        }


        public override string ToString() {
            return $"{sorSzama} sor: a={a} b={b} c={c}";
        }


    }
}
