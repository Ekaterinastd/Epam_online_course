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
            Coefficiencts = coef;
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

            foreach(var key in Coefficiencts.Keys)
                if(!p.Coefficiencts.ContainsKey(key))
                    return false;
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

            var p3 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };

            foreach (var key in p1.Coefficiencts.Keys)
            {
                if (p3.Coefficiencts.ContainsKey(key))
                    p3.Coefficiencts[key] += p1.Coefficiencts[key];
                else p3.Coefficiencts.Add(key, p1.Coefficiencts[key]);
            }
            foreach (var key in p2.Coefficiencts.Keys)
            {
                if (p3.Coefficiencts.ContainsKey(key))
                    p3.Coefficiencts[key] += p2.Coefficiencts[key];
                else p3.Coefficiencts.Add(key, p2.Coefficiencts[key]);
            }

            return RemoveZeroElements(p3);
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
                return p1;            
            else if (p1.Coefficiencts.Count == 0 && p2.Coefficiencts.Count == 0)
                return p1;

            if (p1.Coefficiencts.Keys.Min() < 0 || p2.Coefficiencts.Keys.Min() < 0)
                throw new ArgumentException("Keys must be positive or zero");

            var p3 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            foreach (var key in p1.Coefficiencts.Keys)
            {
                if (p3.Coefficiencts.ContainsKey(key))
                    p3.Coefficiencts[key] -= p1.Coefficiencts[key];
                else p3.Coefficiencts.Add(key, p1.Coefficiencts[key]);
            }
            foreach (var key in p2.Coefficiencts.Keys)
            {
                if (p3.Coefficiencts.ContainsKey(key))
                    p3.Coefficiencts[key] -= p2.Coefficiencts[key];
                else p3.Coefficiencts.Add(key, -p2.Coefficiencts[key]);
            }

            return RemoveZeroElements(p3);
        }

        public static Polinom operator *(Polinom p1, Polinom p2)
        {
            if (p1.Coefficiencts.Count == 0 || p2.Coefficiencts.Count == 0)
                return new Polinom() { Coefficiencts = new Dictionary<int, double>() };

            if (p1.Coefficiencts.Keys.Min() < 0 || p2.Coefficiencts.Keys.Min() < 0)
                throw new ArgumentException("Keys must be positive or zero");

            var p3 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };

            foreach (var key1 in p1.Coefficiencts.Keys)
                foreach (var key2 in p2.Coefficiencts.Keys)
                    if (p3.Coefficiencts.ContainsKey(key1 + key2))
                        p3.Coefficiencts[key1 + key2] += p1.Coefficiencts[key1] * p2.Coefficiencts[key2];
                    else p3.Coefficiencts.Add(key1 + key2, p1.Coefficiencts[key1] * p2.Coefficiencts[key2]);
               
            return RemoveZeroElements(p3);
        }

        private static Polinom RemoveZeroElements(Polinom p)
        {
            var count = p.Coefficiencts.Count;
            for (var i = 0; i < count; i++)
            {
                if (p.Coefficiencts.ContainsKey(i) && p.Coefficiencts[i] == 0)
                    p.Coefficiencts.Remove(i);
            }
            return p;            
        }
    }
}
