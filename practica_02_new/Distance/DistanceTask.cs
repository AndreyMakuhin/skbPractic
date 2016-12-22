using System;

namespace DistanceTask
{
    public class MyPoint
    {
        public double x;
        public double y;

        public MyPoint(double X, double Y)
        {
            x = X;
            y = Y;
        }
    }

	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            MyPoint start = new MyPoint(ax, ay);
            MyPoint end = new MyPoint(bx, by);
            MyPoint point = new MyPoint(x,y);

            MyPoint vec1 = new MyPoint(point.x - start.x, point.y - start.y);//вектора
            MyPoint vec2 = new MyPoint(end.x - start.x, end.y - start.y);

            var scalar = vec1.x * vec2.x + vec1.y * vec2.y;//скалярное произведение

            //var length = Math.Sqrt((end.x - start.x)*(end.x - start.x) + (end.y - start.y)*(end.y - start.y));// Длина отрезка
            var length = Math.Sqrt(vec2.x*vec2.x + vec2.y*vec2.y);
            

            var proection = scalar / length;//длина отрезка проекции

            if (proection < 0 || proection > length)
            {
                return 0.0;
            }
            else
            {
                MyPoint norm = new MyPoint(vec2.x/length, vec2.y/length);
                MyPoint proj = new MyPoint(norm.x * proection, norm.y * proection);
                return Math.Sqrt((proj.x-start.x)* (proj.x - start.x) + (proj.y - start.y)* (proj.y - start.y));
            }            
		}
	}
}