using Introduction.Models;
using Introduction.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Introduction.Controllers
{
    public class TriangleController : Controller
    {
        private ITriangleServices _triangleServices;
        public TriangleController(ITriangleServices triangleServices)
        {
            _triangleServices = triangleServices;
        }
        /// <summary>
        /// Shows information about the triangle.Its Area and Perimeter.
        /// Показывает информацию о треугольнике. Его Площадь и Периметр.
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public IActionResult Info(Triangle triangle)
        {
            if (_triangleServices.ValideTriangle(triangle) == false)
                return Error(triangle);
            List<Triangle> viewModel = new List<Triangle>();
            viewModel.Add(_triangleServices.GetTriangle(triangle));
            return View("~/Views/Triangle/InfoOutput.cshtml", viewModel);
        }
        /// <summary>
        /// This method calculates the area of ​​the triangle.
        /// Этот метод вычисляет площадь треугольника.
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public IActionResult Area(Triangle triangle)
        {
            if (_triangleServices.ValideTriangle(triangle) == false)
                return Error(triangle);
            ViewData["methodName "] = "Area.";
            return View("~/Views/Triangle/Result.cshtml", _triangleServices.Area(triangle));
        }
        /// <summary>
        /// This method calculates the perimeter of ​​the triangle .
        /// Этот метод вычисляет периметр треугольника.
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public IActionResult Perimeter(Triangle triangle)
        {
            if (_triangleServices.ValideTriangle(triangle) == false)
                return Error(triangle);
            ViewData["methodName "] = "Perimeter.";
            return View("~/Views/Triangle/Result.cshtml", _triangleServices.Perimeter(triangle));
        }
        /// <summary>
        /// This method determines if a triangle is rectangular.
        /// Этот метод определяет, является ли треугольник прямоугольным.
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public IActionResult IsRightAngled(Triangle triangle)
        {
            if (_triangleServices.ValideTriangle(triangle) == false)
                return Error(triangle);
            ViewData["methodName "] = "Is Right Angled.";
            return View("~/Views/Triangle/Result.cshtml", _triangleServices.IsRightAngled(triangle));
        }
        /// <summary>
        /// This method determines if a triangle is equilateral.
        /// Этот метод определяет, является ли треугольник равносторонним.
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public IActionResult IsEquilateral(Triangle triangle)
        {
            if (_triangleServices.ValideTriangle(triangle) == false)
                return Error(triangle);
            ViewData["methodName "] = "Is Equilateral.";
            return View("~/Views/Triangle/Result.cshtml", _triangleServices.IsEquilateral(triangle));
        }
        /// <summary>
        /// This method determines if a triangle is IsIsosceles.
        /// Этот метод определяет, является ли треугольник равнобедренным.
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public IActionResult IsIsosceles(Triangle triangle)
        {
            if (_triangleServices.ValideTriangle(triangle) == false)
                return Error(triangle);
            ViewData["methodName "] = "Is Isosceles.";
            return View("~/Views/Triangle/Result.cshtml", _triangleServices.IsIsosceles(triangle));
        }
        /// <summary>
        /// This method determines the сongruent of two triangles.
        /// Этот метод определяет конгруэнтность двух треугольников.
        /// </summary>
        /// <param name="tr1"></param>
        /// <param name="tr2"></param>
        /// <returns></returns>        /// 
        public IActionResult AreCongruent(Triangle tr1, Triangle tr2)
        {
            if (_triangleServices.ValideTriangle(tr1) == false)
                return Error(tr1);
            if (_triangleServices.ValideTriangle(tr2) == false)
                return Error(tr2);
            ViewData["methodName "] = "Are Congruent.";
            return View("~/Views/Triangle/Result.cshtml", _triangleServices.AreCongruent(_triangleServices.GetTriangle(tr1), _triangleServices.GetTriangle(tr2)));
        }
        /// <summary>
        /// This method determines the similar of two triangles.
        /// Этот метод определяет подобность двух треугольников.
        /// </summary>
        /// <param name="tr1"></param>
        /// <param name="tr2"></param>
        /// <returns></returns>
        public IActionResult AreSimilar(Triangle tr1, Triangle tr2)
        {
            if (_triangleServices.ValideTriangle(tr1) == false)
                return Error(tr1);
            if (_triangleServices.ValideTriangle(tr2) == false)
                return Error(tr2);
            ViewData["methodName "] = "Are Similar.";
            return View("~/Views/Triangle/Result.cshtml", _triangleServices.AreSimilar(tr1, tr2));
        }
        /// <summary>
        /// This method identifies the triangle with the largest perimeter.
        /// Этот метод определяет треугольник с наибольшим периметром.
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public IActionResult GreatesByPerimeter(Triangle[] tr)
        {
            foreach (var item in tr)
            {
                if (_triangleServices.ValideTriangle(item) == false)
                    return Error(item);
            }
            List<Triangle> viewModel = new List<Triangle>();
            viewModel.Add(_triangleServices.GetTriangle(_triangleServices.GreatesByPerimeter(tr)));
            return View("~/Views/Triangle/InfoOutput.cshtml", viewModel);
        }
        /// <summary>
        /// This method identifies the triangle with the largest area.
        /// Этот метод определяет треугольник с наибольшей площадью.
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public IActionResult GreatestByArea(Triangle[] tr)
        {
            foreach (var item in tr)
            {
                if (_triangleServices.ValideTriangle(item) == false)
                    return Error(item);
            }
            List<Triangle> viewModel = new List<Triangle>();
            viewModel.Add(_triangleServices.GetTriangle(_triangleServices.GetTriangle(_triangleServices.GreatesByArea(tr))));
            return View("~/Views/Triangle/InfoOutput.cshtml", viewModel);
        }
        /// <summary>
        /// This method detects non-similar triangles. With a conclusion in pairs.
        /// Этот метод обнаруживает непохожие треугольники. С выводом попарно.
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public IActionResult PairwiseNonSimilar(Triangle[] tr)
        {
            foreach (var item in tr)
            {
                if (_triangleServices.ValideTriangle(item) == false)
                    return Error(item);
            }
            ViewData["methodName "] = "Pairwise Non Similar.";
            //List<Couple> para = _triangleServices.PairwiseNonSimilar(tr);
            //List<Triangle> resList = new List<Triangle>();
            //foreach (Couple para_ in para)
            //{
            //    resList.Add(para_.tr1);
            //    resList.Add(para_.tr2);
            //}
            return View(_triangleServices.PairwiseNonSimilar(tr));
        }
        private IActionResult Error(Triangle triangle)
        {
            ViewData["error"] = "Triangle does not exist";
            return View("~/Views/Triangle/Error.cshtml", triangle);
        }
    }
}
