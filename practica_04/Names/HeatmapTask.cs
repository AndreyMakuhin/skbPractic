using System;

namespace Names
{
	internal static class HeatmapTask
	{

		public static HeatmapData GetHistogramBirthsPerDate(NameData[] names)
		{
            /*
			Подготовьте данные для построения карты интенсивностей, у которой по оси X — число месяца, по Y — номер месяца, 
			а интенсивность точки (она отображается цветом и размером) обозначает количество рожденных людей в это число этого месяца.
			Не учитывайте людей, родившихся первого числа любого месяца.

			В качестве подписей (label) по X используйте число месяца (начиная со второго), 
			а по Y — номер месяца (январь — 1, февраль — 2, ...)
			*/
            string[] days = new string[30];
            string[] months = new string[12];

            for (int i = 1; i < 31; i++)
            {
                days[i-1] = (i + 1).ToString();
            }

            for (int j = 0; j < 12; j++)
            {
                months[j] = (j + 1).ToString();
            }

            double[,] items = new double[30, 12];

            //for (int i = 0; i < 31; i++)
            //{
            //    for (int j = 0; j < 12; j++)
            //    {
            //        if(names.[])
            //        items[i, j]++;
            //    }
            //}

            for (int i = 0; i < names.Length; i++)
            {
               if (names[i].BirthDate.Day != 1)
               {
                    var x = names[i].BirthDate.Day;
                    var y = names[i].BirthDate.Month;
                    items[x - 2, y - 1]++;
                }
                
            }

			return new HeatmapData("Пример карты интенсивностей",
				                   items,
                                   days,
                                   months);
		}
	}
}