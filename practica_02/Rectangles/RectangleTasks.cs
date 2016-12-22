using System;
using System.Drawing;

namespace Rectangles
{
	public class RectangleTasks
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public bool AreIntersected(Rectangle r1, Rectangle r2)
		{            

            var r1X1 = r1.X;
            var r1X2 = r1.X + r1.Width;

            var r1Y1 = r1.Y;
            var r1Y2 = r1.Y + r1.Height;

            var r2X1 = r2.X;
            var r2X2 = r2.X + r2.Width;

            var r2Y1 = r2.Y;
            var r2Y2 = r2.Y + r2.Height;

            if ((r1X1 <= r2X1) && (r1X2 >= r2X1))
            {
                if (r1Y1 <= r2Y1 && r1Y2 >= r2Y1)
                {
                    return true;
                }
                else if (r2Y1 <= r1Y1 && r2Y2 >= r1Y1)
                {
                    return true;
                }
                else return false;

            }
            else if ((r2X1 <= r1X1) && (r2X2 >= r1X1))
            {
                if (r1Y1 <= r2Y1 && r1Y2 >= r2Y1)
                {
                    return true;
                }
                else if (r2Y1 <= r1Y1 && r2Y2 >= r1Y1)
                {
                    return true;
                }
                else return false;

            }
            else return false;
		}

		// Площадь пересечения прямоугольников
		public int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (Math.Min(r2.X, r1.X) == r2.X) //вынести проверку условий в одну фуекцию, в данном случае не важно иксы это или игреки
            {
                Rectangle temp = r1;
                r1 = r2;
                r2 = temp;

            }


            var r1X1 = r1.X;
            var r1X2 = r1.X + r1.Width;
            var r2X1 = r2.X;
            var r2X2 = r2.X + r2.Width;

            

            int deltaX = 0;
            int deltaY = 0;

            ///////////////проверка на пересечение по X

            if (r1X1 <= r2X1 && r1X2 <= r2X2)
            {
                deltaX = r1X2 - r2X1;
            }
            else if (r2X2 <= r1X1 && r2X2 <= r1X2)
            {
                deltaX = r2X2 - r1X1;
            }
            else if (r1X1 <= r2X1 && r1X2 >= r2X2)
            {
                deltaX = r2.Width;
            }
            else if (r2X1 <= r1X1 && r2X2 >= r1X2)
            {
                deltaX = r1.Width;
            }else if (r1X1 == r2X1 && r1X2 == r2X2)
            {
                deltaX = r1.Width;
            }           

            if (deltaX < 0)
                deltaX = 0;

            //////////////////////проверка пересечения по Y


            if (Math.Min(r2.Y, r1.Y) == r2.Y)
            {
                Rectangle temp = r1;
                r1 = r2;
                r2 = temp;
            }

            var r1Y1 = r1.Y;
            var r1Y2 = r1.Y + r1.Height;
            var r2Y1 = r2.Y;
            var r2Y2 = r2.Y + r2.Height;

            if (r1Y1 <= r2Y1 && r1Y2 <= r2Y2)
            {
                deltaY = r1Y2 - r2Y1;
            }
            else if (r1Y1 >= r2Y1 && r1Y2 >= r2Y2)
            {
                deltaY = r2Y2 - r1Y1;
            }
            else if (r1Y1 >= r2Y1 && r1Y2 <= r2Y2)
            {
                deltaY = r1.Height;
            }
            else if (r2Y1 >= r1Y1 && r2Y2 <= r1Y2)
            {
                deltaY = r2.Height;
            }
            else if (r1Y1 == r2Y1 && r1Y2 == r2Y2)
            {
                deltaY = r1.Height;
            }            

            if (deltaY < 0)
                deltaY = 0;

            return deltaX * deltaY;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		public int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            var x11 = r1.X;
            var x12 = r1.X + r1.Width;

            var y11 = r1.Y;
            var y12 = r1.Y + r1.Height;

            var x21 = r2.X;
            var x22 = r2.X + r2.Width;

            var y21 = r2.Y;
            var y22 = r2.Y + r2.Height;

            if ((x11 < x21 && x12 > x22) && (y11 < y21 && y12 > y22))
                return 1;
            else if ((x21 < x11 && x22 > x12) && (y21 < y11 && y22 > y12))
                return 0;
            else  return -1;
		}
	}
}