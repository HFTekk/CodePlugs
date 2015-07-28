using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntennaCalculator
{
    public enum CurveType {POWER};

    class TxLine
    {
        
        public string Name { get; set; }
        public int MaxFrequency { get; set; }
        private ArrayList curves = new ArrayList();

        public TxLine()
        {
            
        }

        public TxLine(string name, int maxfreq)
        {
            this.Name = name;
            this.MaxFrequency = maxfreq;
        }

        public void addCurve(Curve curve)
        {
            this.curves.Add(curve);
        }

        public double calcLoss(int frequency)
        {
            double result = -1.0;
            
            foreach(Curve curve in this.curves)
            {
                if ((frequency >= curve.Lowf) && (frequency <= curve.Highf))
                {
                    result = curve.Calc(frequency);
                    break;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class Curve
    {
        /*
         * <curve lowf="0" highf="1800" type="log" a="0.1089" p="0.528"></curve>
         * <curve lowf="1801" highf="max" type="linear" a="0.0015" b="3.1288"></curve> 
         */

        public int Lowf { get; set; }
        public int Highf { get; set; }
        public CurveType type { get; set; }
        private double[] coeffs = new double[4];

        public void SetA(double a) { this.coeffs[0] = a; }
        public void SetB(double b) { this.coeffs[1] = b; }
        public void SetC(double c) { this.coeffs[2] = c; }
        public void SetP(double p) { this.coeffs[3] = p; }

        public double GetA() { return this.coeffs[0]; }
        public double GetB() { return this.coeffs[1]; }
        public double GetC() { return this.coeffs[2]; }
        public double GetP() { return this.coeffs[3]; }

        public double Calc(int freq)
        {
            double result = -1.0;
            switch (this.type)
            {
                case CurveType.POWER:
                    result = GetA() * Math.Pow(freq, GetP()) + GetC();
                    break;

            }

            return result;
        }

    }
}
