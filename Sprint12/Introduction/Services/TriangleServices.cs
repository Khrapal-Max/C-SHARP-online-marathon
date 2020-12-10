using Introduction.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Introduction.Services
{
    public class TriangleServices : ITriangleServices
    {
        public Triangle GetTriangle(Triangle triangle)
        {
            var newTriangle = new double[] { triangle.Side1, triangle.Side2, triangle.Side3 }.OrderBy(x => x).ToArray();
            var viewModel = new Triangle()
            {
                Side1 = newTriangle[0],
                Side2 = newTriangle[1],
                Side3 = newTriangle[2]
            };
            return viewModel;
        }
        public double[] Reduced(Triangle triangle)
        {
            List<double> reduced = new List<double>();
            reduced.Add(Math.Round(triangle.Side1 / Perimeter(triangle), 3));
            reduced.Add(Math.Round(triangle.Side2 / Perimeter(triangle), 3));
            reduced.Add(Math.Round(triangle.Side3 / Perimeter(triangle), 3));
            return reduced.OrderBy(x => x).ToArray();
        }
        public double Area(Triangle triangle)
        {
            return triangle.GetArea();
        }
        public double Perimeter(Triangle triangle)
        {
            return triangle.GetPerimeter();
        }
        public bool IsRightAngled(Triangle triangle)
        {
            return Math.Pow(triangle.Side2, 2) == Math.Pow(triangle.Side1, 2) + Math.Pow(triangle.Side3, 2);
        }
        public bool IsEquilateral(Triangle triangle)
        {
            return triangle.Side1 == triangle.Side2 && triangle.Side1 == triangle.Side3 && triangle.Side2 == triangle.Side3;
        }
        public bool IsIsosceles(Triangle triangle)
        {
            return triangle.Side1 == triangle.Side2 || triangle.Side1 == triangle.Side3 || triangle.Side2 == triangle.Side3;
        }
        public bool AreCongruent(Triangle Left, Triangle Rigth)
        {
            var trLeft = new double[] { Left.Side1, Left.Side2, Left.Side3 };
            var trRigth = new double[] { Rigth.Side1, Rigth.Side2, Rigth.Side3 };
            return trLeft.SequenceEqual(trRigth);
        }
        public bool AreSimilar(Triangle Left, Triangle Rigth)
        {
            return Reduced(Left).SequenceEqual(Reduced(Rigth));
        }
        public Triangle GreatesByPerimeter(Triangle[] tr)
        {
            return tr.Where(x => x.Perimeter == tr.Max(y => y.Perimeter)).First();
        }
        public Triangle GreatesByArea(Triangle[] tr)
        {
            return tr.Where(x => x.Area == tr.Max(y => y.Area)).First();
        }
        public List<Couple> PairwiseNonSimilar(Triangle[] tr)
        {
            List<Couple> list = new List<Couple>();
            List<Triangle> resList = new List<Triangle>();
            int k = 0;
            for (int i = 0; i < tr.Count(); i++)
            {
                for (int j = k; j < tr.Count(); j++)
                {
                    if (i != j)
                    {
                        if (!AreSimilar(tr[i], tr[j]))
                        { 
                            list.Add(new Couple(tr[i], tr[j]));                            
                        }
                    }
                }
                k++;
            }
            return list;
        }
        public bool ValideTriangle(Triangle triangle)
        {
            return (triangle.Side1 + triangle.Side2) > triangle.Side3 && (triangle.Side2 + triangle.Side3) > triangle.Side1 && (triangle.Side3 + triangle.Side1) > triangle.Side2
                    && (triangle.Side1 != 0 || triangle.Side2 != 0 || triangle.Side3 != 0);
        }
    }
}
