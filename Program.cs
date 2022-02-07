using System;
using System.Collections.Generic;
using System.Linq;

namespace KClosest
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[2][];
            array[0] = new int[2]{1,3};
            array[1] = new int[2]{-2,2};
            
            Console.WriteLine(KClosest(array, 1));
        }

       static int[][] KClosest(int[][] points, int k) 
       {
        
            var pointsModel = new List<Point>();
            for(int i=0; i<points.GetLength(0); i++)
            {
                var point = new Point();
                    
                pointsModel.Add(new Point{
                    Distance = findDist(points[i][0], points[i][1]),
                    X = points[i][0],
                    Y = points[i][1]
                });
            }
            var result = new int[k][];
            pointsModel = pointsModel.OrderBy(o => o.Distance).Take(k).ToList();
            foreach(var item in pointsModel)
            {
                result[--k] = new int[2] {item.X, item.Y};
            }
            
            return result;
        
       }

        static double findDist(int x, int y)
        {
            return Math.Sqrt(x*x + y*y);
        }

    }

    public class Point
    {
        public int X {get;set;}
        public int Y {get;set;}
        public double Distance {get;set;}
    }
}


