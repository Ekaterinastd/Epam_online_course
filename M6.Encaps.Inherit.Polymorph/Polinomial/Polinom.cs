using System;
using System.Collections.Generic;
using System.Linq;

namespace Polinomial
{
    public class Polinom
    {
        public Dictionary<int, double> Coefficiencts;

        public Polinom(Dictionary<int, double> coef)
        {
            this.Coefficiencts = coef;
        }

        public Polinom()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Polinom p = obj as Polinom;
            if (p as Polinom == null)
                return false;
            if (Coefficiencts.Count != p.Coefficiencts.Count)
                return false;
            for (var i = 0; i < Coefficiencts.Count; i++)
            {
                if (Coefficiencts[i] != p.Coefficiencts[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return -2011244702 + EqualityComparer<Dictionary<int, double>>.Default.GetHashCode(Coefficiencts);
        }

        public static Polinom operator +(Polinom p1, Polinom p2)
        {
            if (p1.Coefficiencts.Count == 0 && p2.Coefficiencts.Count != 0)
                return p2;
            else if (p1.Coefficiencts.Count != 0 && p2.Coefficiencts.Count == 0)
                return p1;
            else if (p1.Coefficiencts.Count == 0 && p2.Coefficiencts.Count == 0)
                return p1;

            if (p1.Coefficiencts.Keys.Min() < 0 || p2.Coefficiencts.Keys.Min() < 0)
                throw new ArgumentException("Keys must be positive or zero");

            var maxDegree = Math.Max(p1.Coefficiencts.Keys.Max(), p2.Coefficiencts.Keys.Max());
            var p3 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            for (var i = 0; i <= maxDegree; i++)
            {
                if (i <= p1.Coefficiencts.Keys.Max())
                {
                    if (p1.Coefficiencts.ContainsKey(i))
                        if (p3.Coefficiencts.ContainsKey(i))
                            p3.Coefficiencts[i] += p1.Coefficiencts[i];
                        else p3.Coefficiencts.Add(i, p1.Coefficiencts[i]);
                }

                if (i <= p2.Coefficiencts.Keys.Max())
                {
                    if (p2.Coefficiencts.ContainsKey(i))
                        if (p3.Coefficiencts.ContainsKey(i))
                            p3.Coefficiencts[i] += p2.Coefficiencts[i];
                        else p3.Coefficiencts.Add(i, p2.Coefficiencts[i]);
                }
            }
            foreach (var c in p3.Coefficiencts)
                if (c.Value == 0)
                    p3.Coefficiencts.Remove(c.Key);
            return p3;
        }

        public static Polinom operator -(Polinom p1, Polinom p2)
        {
            if (p1.Coefficiencts.Count == 0 && p2.Coefficiencts.Count != 0)
            {
                for (var i = 0; i < p2.Coefficiencts.Count; i++)
                    p2.Coefficiencts[i] = -p2.Coefficiencts[i];
                return p2;
            }
            else if (p1.Coefficiencts.Count != 0 && p2.Coefficiencts.Count == 0)
            {
                for (var i = 0; i < p1.Coefficiencts.Count; i++)
                    p1.Coefficiencts[i] = -p1.Coefficiencts[i];
                return p1;
            }
            else if (p1.Coefficiencts.Count == 0 && p2.Coefficiencts.Count == 0)
                return p1;

            if (p1.Coefficiencts.Keys.Min() < 0 || p2.Coefficiencts.Keys.Min() < 0)
                throw new ArgumentException("Keys must be positive or zero");

            var maxDegree = Math.Max(p1.Coefficiencts.Keys.Max(), p2.Coefficiencts.Keys.Max());
            var p3 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            for (var i = 0; i <= maxDegree; i++)
            {
                if (i <= p1.Coefficiencts.Keys.Max())
                {
                    if (p1.Coefficiencts.ContainsKey(i))
                        if (p3.Coefficiencts.ContainsKey(i))
                            p3.Coefficiencts[i] -= p1.Coefficiencts[i];
                        else p3.Coefficiencts.Add(i, p1.Coefficiencts[i]);
                }

                if (i <= p2.Coefficiencts.Keys.Max())
                {
                    if (p2.Coefficiencts.ContainsKey(i))
                        if (p3.Coefficiencts.ContainsKey(i))
                            p3.Coefficiencts[i] -= p2.Coefficiencts[i];
                        else p3.Coefficiencts.Add(i, -p2.Coefficiencts[i]);
                }
            }
            foreach (var c in p3.Coefficiencts)
                if (c.Value == 0)
                    p3.Coefficiencts.Remove(c.Key);
            return p3;
        }

        public static Polinom operator *(Polinom p1, Polinom p2)
        {
            var maxDegree = p1.Coefficiencts.Keys.Max() + p2.Coefficiencts.Keys.Max();
            var p3 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };

            p3.Coefficiencts[0] = p1.Coefficiencts[0] * p2.Coefficiencts[0];
            return p3;
        }
    }
}
