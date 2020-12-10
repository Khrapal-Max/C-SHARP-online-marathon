using Introduction.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Introduction.Services
{
    public interface ITriangleServices
    {
        public Triangle GetTriangle(Triangle triangle);
        public double[] Reduced(Triangle triangle);
        public double Area(Triangle triangle);
        public double Perimeter(Triangle triangle);
        public bool IsRightAngled(Triangle triangle);
        public bool IsEquilateral(Triangle triangle);
        public bool IsIsosceles(Triangle triangle);
        public bool AreCongruent(Triangle Left, Triangle Rigth);
        public bool AreSimilar(Triangle Left, Triangle Rigth);
        public Triangle GreatesByPerimeter(Triangle[] triangles);
        public Triangle GreatesByArea(Triangle[] tr);
        public List<Couple> PairwiseNonSimilar(Triangle[] tr);
        public bool ValideTriangle(Triangle triangle);
    }
}