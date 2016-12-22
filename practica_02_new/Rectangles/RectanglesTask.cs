using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            // просто для красткости записи условия создаем переменные с короткими именами
            var x1 = r1.Left;
            var x2 = r1.Left + r1.Width;
            var y1 = r1.Top;
            var y2 = r1.Top + r1.Height;

            var a1 = r2.Left;
            var a2 = r2.Left + r2.Width;
            var b1 = r2.Top;
            var b2 = r2.Top + r2.Height;

            //if( a2 < x1 || a1 > x2 || b2 < y1 || b1 > y2  )
            //return false;

            //if (a2 < x1 || a1 > x2 || b2 < y1 || b1 > y2)
                return (!(a2 < x1 || a1 > x2 || b2 < y1 || b1 > y2));
            //else return true;

            //if ( ((x1 <= a1 && a1 <= x2) || (a1 <= x1 && x1 <= a2)) && ((y1 <= b1 && b1 <= y2) || (b1 <= y1 && y1 <= b2)) )
            //    return true;
            //else return false;
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (AreIntersected(r1, r2))
            {
                int x1, y1, x2, y2;

                x1 = Math.Max(r1.Left, r2.Left);
                x2 = Math.Min(r1.Left+r1.Width, r2.Left+r2.Width);

                y1 = Math.Max(r1.Top, r2.Top);
                y2 = Math.Min(r1.Top+r1.Height, r2.Top+r2.Height);
                //if (r1.Left <= r2.Left)
                //{
                //    x1 = r2.Left;
                //}
                //else
                //{
                //    x1 = r1.Left;
                //}

                //if ((r2.Left + r2.Width) >= (r1.Left + r1.Width))
                //{
                //    x2 = r1.Left + r1.Width;
                //}
                //else
                //{
                //    x2 = r2.Left + r2.Width;
                //}


                //if (r1.Top <= r2.Top)
                //{
                //    y1 = r2.Top;
                //}
                //else
                //{
                //    y1 = r1.Top;
                //}

                //if ((r1.Top + r1.Height) <= (r2.Top + r2.Height))
                //{
                //    y2 = r1.Top + r1.Height;
                //}
                //else
                //{
                //    y2 = r2.Top + r2.Height;
                //}


                return (x2 - x1) * (y2 - y1);


            }
            else return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if (AreIntersected(r1, r2))
            {
                var x1 = r1.Left;
                var x2 = r1.Left + r1.Width;
                var y1 = r1.Top;
                var y2 = r1.Top + r1.Height;

                var a1 = r2.Left;
                var a2 = r2.Left + r2.Width;
                var b1 = r2.Top;
                var b2 = r2.Top + r2.Height;
                
                if ((x1 <= a1 && a2 <= x2) && (y1 <= b1 && b2 <= y2))
                    return 1;
                else if ((a1 <= x1 && x2 <= a2) && (b1 <= y1 && y2 <= b2))
                    return 0;
                else return -1;
            }
			else return -1;
		}
	}
}